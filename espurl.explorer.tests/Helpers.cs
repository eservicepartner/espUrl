using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace espurl.explorer.tests
{
	class Helpers
	{
		public static string ReadEntireStream(Stream stream)
		{
			using (var sr = new StreamReader(stream))
			{
				return sr.ReadToEnd();
			}
		}
	}
}
