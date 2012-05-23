using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eleven41.Helpers
{
	public static class StreamHelper
	{
		public static long CopyStream(System.IO.Stream target, System.IO.Stream source, long nMaxBytes = long.MaxValue)
		{
			long nTotalBytesRead = 0;
			byte[] buffer = new byte[20480];
			while (nTotalBytesRead < nMaxBytes)
			{
				long nCount = nMaxBytes - nTotalBytesRead;
				if (nCount > buffer.Length)
					nCount = buffer.Length;
				int nBytesRead = source.Read(buffer, 0, (int)nCount);
				if (nBytesRead == 0)
					break;
				target.Write(buffer, 0, nBytesRead);
				nTotalBytesRead += nBytesRead;
			}
			return nTotalBytesRead;
		}

		public static long FakeSeekRead(System.IO.Stream stream, long nBytes)
		{
			long nBytesRead = 0;
			byte[] temp = new byte[20480];
			while (nBytesRead < nBytes)
			{
				long nCount = nBytes - nBytesRead;
				if (nCount > temp.Length)
					nCount = temp.Length;
				long nRead = stream.Read(temp, 0, (int)nCount);

				// Increment by the actual bytes read
				nBytesRead += nRead;
				
				// If nothing could be read, then abort
				if (nRead == 0)
					break;
			}
			return nBytesRead;
		}

		public static void FakeSeekWrite(System.IO.Stream stream, long nBytes)
		{
			long nBytesWritten = 0;
			byte[] temp = new byte[20480];
			while (nBytesWritten < nBytes)
			{
				long nCount = nBytes - nBytesWritten;
				if (nCount > temp.Length)
					nCount = temp.Length;
				stream.Write(temp, 0, (int)nCount);
				nBytesWritten += nCount;
			}
		}
	}
}
