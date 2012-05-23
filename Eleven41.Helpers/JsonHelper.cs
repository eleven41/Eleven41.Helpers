using System;
using System.IO;
using System.Text;


namespace Eleven41.Helpers
{
	public static class JsonHelper
	{
		public static string Serialize<T>(T obj)
		{
			return ServiceStack.Text.JsonSerializer.SerializeToString(obj, typeof(T));
		}

		public static void SerializeToStream<T>(T obj, Stream stream)
		{
			ServiceStack.Text.JsonSerializer.SerializeToStream(obj, stream);
		}

		public static T Deserialize<T>(string json)
		{
			return ServiceStack.Text.JsonSerializer.DeserializeFromString<T>(json);
		}

		public static T DeserializeFromStream<T>(Stream stream)
		{
			return ServiceStack.Text.JsonSerializer.DeserializeFromStream<T>(stream);
		}
	}
}