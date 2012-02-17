using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace espurl.explorer.Tests
{
	public class ServiceHelperTests
	{
		public void GetUrlTest()
		{
			string testFilePath = @"d:\ape2.png";
			ServiceHelper.GetUrl(testFilePath);
			string clipboardText = Clipboard.GetText();
			Console.WriteLine(clipboardText);
         //StringAssert.AreEqualIgnoringCase("http://espurl.me/" + testFilePath, clipboardText);
		}
	}
}
