using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eleven41.Helpers
{
	public static class ExceptionHelper
	{
		public static string GetInnermostMessage(System.Exception e)
		{
			string sMsg = e.Message;
			while (e.InnerException != null)
			{
				e = e.InnerException;
				sMsg = e.Message;
			}
			return sMsg;
		}
	}
}
