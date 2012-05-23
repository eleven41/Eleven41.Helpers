using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Eleven41.Helpers
{
	public static class GuidHelper
	{
		[DllImport("rpcrt4.dll", SetLastError = true)]
		private static extern int UuidCreateSequential(out Guid guid);

		public static Guid NewSequentialId()
		{
			Guid result;
			int nResult = UuidCreateSequential(out result);
			if (nResult == 0)
				return result;
			throw new Exception(String.Format("Error creating UUID: {0}", nResult));
		}
	}
}
