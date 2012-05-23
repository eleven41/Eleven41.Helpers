using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Eleven41.Helpers
{
	public static class UrlHelper
	{
		public static string BuildQueryString(string sStartingQueryString, params string[] args)
		{
			System.Diagnostics.Debug.Assert(args.Length % 2 == 0);

			StringBuilder sb = new StringBuilder(sStartingQueryString);

			for (int i = 0; i < args.Length; i += 2)
			{
				string sParam = args[i];
				string sVal = args[i + 1];

				if (sb.Length > 0)
					sb.Append("&");

				sb.AppendFormat("{0}={1}", sParam, sVal);
			}
			return sb.ToString();
		}

		public static string CreateUrl(string sBase, string sStartingQueryString, params string[] args)
		{
			string sQueryString = BuildQueryString(sStartingQueryString, args);
			if (String.IsNullOrEmpty(sQueryString))
				return sBase;

			return String.Format("{0}?{1}", sBase, sQueryString);
		}

		public static string GetBase(string sUrl)
		{
			int nIndex = sUrl.IndexOf("?");
			if (nIndex < 0)
				return sUrl;
			return sUrl.Substring(0, nIndex);
		}

		public static string GetQueryString(string sUrl)
		{
			int nIndex = sUrl.IndexOf("?");
			if (nIndex < 0)
				return "";
			return sUrl.Substring(nIndex + 1);
		}

		public static string RemoveParam(string sQueryString, string param)
		{
			int nIndex = sQueryString.IndexOf(param + "=");
			if (nIndex < 0)
				return sQueryString;

			int nIndex2 = sQueryString.IndexOf('&', nIndex);
			if (nIndex2 < 0)
				return sQueryString.Substring(0, nIndex);

			return sQueryString.Substring(0, nIndex) + sQueryString.Substring(nIndex2);
		}
	}
}