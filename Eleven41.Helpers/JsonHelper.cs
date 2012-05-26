using System;
using System.IO;
using System.Text;
using ServiceStack.Text;

namespace Eleven41.Helpers
{
	public static class JsonHelper
	{
		public static string Serialize<T>(T obj)
		{
			return JsonSerializer.SerializeToString(obj, typeof(T));
		}

		public static string SerializeAndFormat<T>(T obj)
		{
			return obj.SerializeAndFormat();
		}

		public static void SerializeToStream<T>(T obj, Stream stream)
		{
			JsonSerializer.SerializeToStream(obj, stream);
		}

		public static T Deserialize<T>(string json)
		{
			return JsonSerializer.DeserializeFromString<T>(json);
		}

		public static T DeserializeFromStream<T>(Stream stream)
		{
			return JsonSerializer.DeserializeFromStream<T>(stream);
		}
	}
}