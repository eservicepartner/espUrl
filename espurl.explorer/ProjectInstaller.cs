using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Runtime.InteropServices;


namespace espurl.explorer
{
   [RunInstaller(true)]
   public partial class ProjectInstaller : Installer
   {
      public ProjectInstaller()
      {
         InitializeComponent();
      }

      [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
      public override void Install(IDictionary stateSaver)
      {
         base.Install(stateSaver);

         // Get the location of regasm
         string regasmPath = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory() + @"regasm.exe";
         if (OSHelperTools.Is64BitOperatingSystem())
         {
            regasmPath = regasmPath.Replace(@"Microsoft.NET\Framework", @"Microsoft.NET\Framework64");
         }

         // Get the location of our DLL
         string componentPath = typeof(FileContextMenuExtension).Assembly.Location;
         // Execute regasm
         System.Diagnostics.Process.Start(regasmPath, "/codebase \"" + componentPath + "\"");
      }

      [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
      public override void Uninstall(IDictionary savedState)
      {
         // Get the location of regasm
         string regasmPath = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory() + @"regasm.exe";
         if (OSHelperTools.Is64BitOperatingSystem())
         {
            regasmPath = regasmPath.Replace(@"Microsoft.NET\Framework", @"Microsoft.NET\Framework64");
         }
         // Get the location of our DLL
         string componentPath = typeof(FileContextMenuExtension).Assembly.Location;
         // Execute regasm
         System.Diagnostics.Process.Start(regasmPath, "/u \"" + componentPath + "\"");

         base.Uninstall(savedState);         
      }
   }
}
