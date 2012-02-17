using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace espurl.explorer.tests
{
   [TestClass]
   public class InstallerTests
   {
      [TestMethod]
      public void InstallTest()
      {
         // Get the location of regasm
         string regasmPath = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory() + @"regasm.exe";
         if (OSHelperTools.Is64BitOperatingSystem())
         {
            regasmPath = regasmPath.Replace(@"Microsoft.NET\Framework", @"Microsoft.NET\Framework64");
         }

         Console.WriteLine(regasmPath);
         //// Get the location of our DLL
         //string componentPath = typeof(FileContextMenuExtension).Assembly.Location;
         //// Execute regasm
         //System.Diagnostics.Process.Start(regasmPath, "/codebase \"" + componentPath + "\"");

      }

      [TestMethod]
      public void UninstallTest()
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
      }
   }
}
