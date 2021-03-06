﻿using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using IDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;
using System.IO;

namespace espurl.explorer
{
   [ClassInterface(ClassInterfaceType.None)]
   [Guid("9A3A2126-8943-46AE-B697-8531A44E31CB"), ComVisible(true)]
   public class FileContextMenuExtension : IShellExtInit, IContextMenu
   {
      private string[] _fileExtensions = null; //new string[] { ".jpg", ".gif", ".png" };
      private string _selectedFile;
      private string _verb = "csdisplay";
      private uint _idmDisplay = 0;
      private string _menuText = "Get espUrl";
      private string _canonicalName = "Get espUrl.me link.";
      private string _helpText = "Gets espUrl.me link for the file.";
      private IntPtr menuBmp;

      private IFileHandler _fileHandler;

      #region Shell Extension Registration
      [ComRegisterFunction]
      public static void Register(Type t)
      {
         try
         {
            ShellExtReg.RegisterShellExtContextMenuHandler(t.GUID, "*", "espurl.explorer Class");
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
            throw;
         }
      }

      [ComUnregisterFunction]
      public static void Unregister(Type t)
      {
         try
         {
            ShellExtReg.UnregisterShellExtContextMenuHandler(t.GUID, "*");
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
            throw;
         }
      }

      #endregion

      public FileContextMenuExtension()
      {
         _fileHandler = new UploadFileHandler();

         // Load the bitmap for the menu item.
         var bmp = espurl.explorer.Properties.Resources.espurl_ico;
         bmp.MakeTransparent(bmp.GetPixel(0, 0));
         this.menuBmp = bmp.GetHbitmap();
      }

      ~FileContextMenuExtension()
      {
         if (this.menuBmp != IntPtr.Zero)
         {
            NativeMethods.DeleteObject(this.menuBmp);
            this.menuBmp = IntPtr.Zero;
         }
      }

      private void DoJob(IntPtr hWnd)
      {
         _fileHandler.HandleFile(_selectedFile);
      }

      private bool AcceptFile(string path)
      {
         if (_fileExtensions == null)
            return true;

         var exists = false;
         foreach (var ext in _fileExtensions)
         {
            if (Path.GetExtension(path).Equals(ext, StringComparison.InvariantCultureIgnoreCase))
            {
               exists = true;
               break;
            }
         }

         return exists;
      }

      public void Initialize(IntPtr pidlFolder, IntPtr pDataObj, IntPtr hKeyProgID)
      {
         if (pDataObj == IntPtr.Zero)
         {
            throw new ArgumentException();
         }

         FORMATETC fe = new FORMATETC();
         fe.cfFormat = (short)CLIPFORMAT.CF_HDROP;
         fe.ptd = IntPtr.Zero;
         fe.dwAspect = DVASPECT.DVASPECT_CONTENT;
         fe.lindex = -1;
         fe.tymed = TYMED.TYMED_HGLOBAL;
         STGMEDIUM stm;

         // The pDataObj pointer contains the objects being acted upon. In this 
         // example, we get an HDROP handle for enumerating the selected files 
         // and folders.
         IDataObject dataObject = (IDataObject)Marshal.GetObjectForIUnknown(pDataObj);
         dataObject.GetData(ref fe, out stm);

         try
         {
            // Get an HDROP handle.
            IntPtr hDrop = stm.unionmember;
            if (hDrop == IntPtr.Zero)
            {
               throw new ArgumentException();
            }
            // Determine how many files are involved in this operation.
            uint nFiles = NativeMethods.DragQueryFile(hDrop, UInt32.MaxValue, null, 0);
            if (nFiles == 1)
            {
               // Get the path of the file.
               StringBuilder fileName = new StringBuilder(260);
               if (0 == NativeMethods.DragQueryFile(hDrop, 0, fileName,
                  fileName.Capacity))
               {
                  Marshal.ThrowExceptionForHR(WinError.E_FAIL);
               }
               _selectedFile = fileName.ToString();
               if (!AcceptFile(_selectedFile))
                  Marshal.ThrowExceptionForHR(WinError.E_FAIL);
            }
            else
            {
               Marshal.ThrowExceptionForHR(WinError.E_FAIL);
            }
         }
         finally
         {
            NativeMethods.ReleaseStgMedium(ref stm);
         }
      }

      public int QueryContextMenu(
         IntPtr hMenu,
         uint iMenu,
         uint idCmdFirst,
         uint idCmdLast,
         uint uFlags)
      {

         // If uFlags include CMF_DEFAULTONLY then we should not do anything.
         if (((uint)CMF.CMF_DEFAULTONLY & uFlags) != 0)
         {
            return WinError.MAKE_HRESULT(WinError.SEVERITY_SUCCESS, 0, 0);
         }

         // Use either InsertMenu or InsertMenuItem to add menu items.

         MENUITEMINFO mii = new MENUITEMINFO();
         mii.cbSize = (uint)Marshal.SizeOf(mii);
         //mii.fMask = MIIM.MIIM_ID | MIIM.MIIM_TYPE | MIIM.MIIM_STATE;
         mii.fMask = MIIM.MIIM_BITMAP | MIIM.MIIM_STRING | MIIM.MIIM_FTYPE |
                MIIM.MIIM_ID | MIIM.MIIM_STATE;
         mii.wID = idCmdFirst + _idmDisplay;
         mii.fType = MFT.MFT_STRING;
         mii.dwTypeData = _menuText;
         mii.fState = MFS.MFS_ENABLED;
         mii.hbmpItem = this.menuBmp;
         if (!NativeMethods.InsertMenuItem(hMenu, iMenu, true, ref mii))
         {
            return Marshal.GetHRForLastWin32Error();
         }

         // Add a separator.
         MENUITEMINFO sep = new MENUITEMINFO();
         sep.cbSize = (uint)Marshal.SizeOf(sep);
         sep.fMask = MIIM.MIIM_TYPE;
         sep.fType = MFT.MFT_SEPARATOR;
         if (!NativeMethods.InsertMenuItem(hMenu, iMenu + 1, true, ref sep))
         {
            return Marshal.GetHRForLastWin32Error();
         }

         // Return an HRESULT value with the severity set to SEVERITY_SUCCESS. 
         // Set the code value to the offset of the largest command identifier 
         // that was assigned, plus one (1).
         return WinError.MAKE_HRESULT(WinError.SEVERITY_SUCCESS, 0, _idmDisplay + 1);
      }

      public void InvokeCommand(IntPtr pici)
      {
         bool isUnicode = false;

         // Determine which structure is being passed in, CMINVOKECOMMANDINFO or 
         // CMINVOKECOMMANDINFOEX based on the cbSize member of lpcmi. Although 
         // the lpcmi parameter is declared in Shlobj.h as a CMINVOKECOMMANDINFO 
         // structure, in practice it often points to a CMINVOKECOMMANDINFOEX 
         // structure. This struct is an extended version of CMINVOKECOMMANDINFO 
         // and has additional members that allow Unicode strings to be passed.
         CMINVOKECOMMANDINFO ici = (CMINVOKECOMMANDINFO)Marshal.PtrToStructure(pici, typeof(CMINVOKECOMMANDINFO));
         CMINVOKECOMMANDINFOEX iciex = new CMINVOKECOMMANDINFOEX();
         if (ici.cbSize == Marshal.SizeOf(typeof(CMINVOKECOMMANDINFOEX)))
         {
            if ((ici.fMask & CMIC.CMIC_MASK_UNICODE) != 0)
            {
               isUnicode = true;
               iciex = (CMINVOKECOMMANDINFOEX)Marshal.PtrToStructure(pici, typeof(CMINVOKECOMMANDINFOEX));
            }
         }

         // Determines whether the command is identified by its offset or verb.
         // There are two ways to identify commands:
         // 
         //   1) The command's verb string 
         //   2) The command's identifier offset
         // 
         // If the high-order word of lpcmi->lpVerb (for the ANSI case) or 
         // lpcmi->lpVerbW (for the Unicode case) is nonzero, lpVerb or lpVerbW 
         // holds a verb string. If the high-order word is zero, the command 
         // offset is in the low-order word of lpcmi->lpVerb.

         // For the ANSI case, if the high-order word is not zero, the command's 
         // verb string is in lpcmi->lpVerb. 
         if (!isUnicode && NativeMethods.HighWord(ici.verb.ToInt32()) != 0)
         {
            // Is the verb supported by this context menu extension?
            if (Marshal.PtrToStringAnsi(ici.verb) == _verb)
            {
               DoJob(ici.hwnd);
            }
            else
            {
               // If the verb is not recognized by the context menu handler, it 
               // must return E_FAIL to allow it to be passed on to the other 
               // context menu handlers that might implement that verb.
               Marshal.ThrowExceptionForHR(WinError.E_FAIL);
            }
         }

         // For the Unicode case, if the high-order word is not zero, the 
         // command's verb string is in lpcmi->lpVerbW. 
         else if (isUnicode && NativeMethods.HighWord(iciex.verbW.ToInt32()) != 0)
         {
            // Is the verb supported by this context menu extension?
            if (Marshal.PtrToStringUni(iciex.verbW) == _verb)
            {
               DoJob(ici.hwnd);
            }
            else
            {
               // If the verb is not recognized by the context menu handler, it 
               // must return E_FAIL to allow it to be passed on to the other 
               // context menu handlers that might implement that verb.
               Marshal.ThrowExceptionForHR(WinError.E_FAIL);
            }
         }

         // If the command cannot be identified through the verb string, then 
         // check the identifier offset.
         else
         {
            // Is the command identifier offset supported by this context menu 
            // extension?
            if (NativeMethods.LowWord(ici.verb.ToInt32()) == _idmDisplay)
            {
               DoJob(ici.hwnd);
            }
            else
            {
               // If the verb is not recognized by the context menu handler, it 
               // must return E_FAIL to allow it to be passed on to the other 
               // context menu handlers that might implement that verb.
               Marshal.ThrowExceptionForHR(WinError.E_FAIL);
            }
         }

      }

      public void GetCommandString(
          UIntPtr idCmd,
          uint uFlags,
          IntPtr pReserved,
          StringBuilder pszName,
          uint cchMax)
      {
         if (idCmd.ToUInt32() == _idmDisplay)
         {
            switch ((GCS)uFlags)
            {
               case GCS.GCS_VERBW:
                  if (_canonicalName.Length > cchMax - 1)
                  {
                     Marshal.ThrowExceptionForHR(WinError.STRSAFE_E_INSUFFICIENT_BUFFER);
                  }
                  else
                  {
                     pszName.Clear();
                     pszName.Append(_canonicalName);
                  }
                  break;

               case GCS.GCS_HELPTEXTW:
                  if (_helpText.Length > cchMax - 1)
                  {
                     Marshal.ThrowExceptionForHR(WinError.STRSAFE_E_INSUFFICIENT_BUFFER);
                  }
                  else
                  {
                     pszName.Clear();
                     pszName.Append(_helpText);
                  }
                  break;
            }
         }
      }
   }
}
