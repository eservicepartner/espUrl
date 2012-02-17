using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Globalization;

namespace espurl.explorer.tests
{
   [TestClass]
   public class TestMultipart
   {
      [TestMethod]
      public void TestAddFields()
      {
         MultiPart mp = new MultiPart();
         var field1Name = "field1";
         var field1Val = "a simple value";
         var field2Name = "field2";
         var field2Val = "another simple value";
         mp.AddField(field1Name, field1Val);
         mp.AddField(field2Name, field2Val);
         string body = Helpers.ReadEntireStream(mp.GetStream());
         string expected = string.Format("--{0}\r\n" +
"Content-Disposition: form-data; name=\"{1}\"\r\n" +
"Content-Type: text/plain; charset=utf-8\r\n\r\n" +
"{2}\r\n" +
"--{0}\r\n" +
"Content-Disposition: form-data; name=\"{3}\"\r\n" +
"Content-Type: text/plain; charset=utf-8\r\n\r\n" +
"{4}\r\n" +
"--{0}--", mp.Boundary, field1Name, field1Val,
field2Name, field2Val);
         Assert.AreEqual(expected, body);
      }

      [TestMethod]
      [Ignore]
      public void TestAddFiles()
      {
         MultiPart mp = new MultiPart();
         var name = "file";
         var filename = "..\\..\\..\\espurl.explorer.tests\\testfile.txt";
         mp.AddFileField(name, filename);
         string body = Helpers.ReadEntireStream(mp.GetStream());

         string expected = string.Format("--{0}\r\n" +
"Content-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\n" +
"Content-Type: application/octet-stream\r\n\r\n" +
"{3}\r\n" +
"--{0}--",
                        mp.Boundary, name, filename,
                        Helpers.ReadEntireStream(File.OpenRead(filename)));
         Assert.AreEqual(expected, body);
      }
   }
}
