using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eleven41.Helpers
{
	public static class PathHelper
	{
		public static string HomePath
		{
			get
			{
				// Get assembly directory
				System.Reflection.Assembly assembly = System.Reflection.Assembly.GetEntryAssembly();
				string sFullName = assembly.Location;
				return System.IO.Path.GetDirectoryName(sFullName);
			}
		}

		public static string GetAppPath(string sProductName)
		{
			string sAppData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData, Environment.SpecialFolderOption.Create);
			string sAppPath = System.IO.Path.Combine(sAppData, sProductName);
			System.IO.Directory.CreateDirectory(sAppPath);
			return sAppPath;
		}

		public static string GetLogPath(string sProductName)
		{
			string sAppPath = GetAppPath(sProductName);
			string sLogPath = System.IO.Path.Combine(sAppPath, "Log");
			System.IO.Directory.CreateDirectory(sLogPath);
			return sLogPath;
		}

		
	}
}
