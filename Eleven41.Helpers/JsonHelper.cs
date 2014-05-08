using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Eleven41.Helpers
{
	/// <summary>
	/// Uses Newtonsoft Json.Net to serialize/deserialize objects.
	/// </summary>
	public static class JsonHelper
	{
		public static string Serialize<T>(T obj)
		{
			if (obj == null)
				throw new ArgumentNullException("obj");

			using (StringWriter stringWriter = new StringWriter())
			{
				using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter)
					{
						CloseOutput = false
					})
				{
					var serializer = new JsonSerializer()
					{
						NullValueHandling = NullValueHandling.Ignore
					};
					serializer.Serialize(jsonTextWriter, obj);
					jsonTextWriter.Flush();
				}

				return stringWriter.ToString();
			}
		}

		public static string SerializeAndFormat<T>(T obj)
		{
			if (obj == null)
				throw new ArgumentNullException("obj");

			using (StringWriter stringWriter = new StringWriter())
			{
				using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter)
					{
						CloseOutput = false,
						Formatting = Formatting.Indented
					})
				{
					var serializer = new JsonSerializer()
					{
						NullValueHandling = NullValueHandling.Ignore
					};
					serializer.Serialize(jsonTextWriter, obj);
					jsonTextWriter.Flush();
				}

				return stringWriter.ToString();
			}
		}

		public static void SerializeToStream<T>(T obj, Stream stream)
		{
			if (obj == null)
				throw new ArgumentNullException("obj");
			if (stream == null)
				throw new ArgumentNullException("stream");

			StreamWriter streamWriter = new StreamWriter(stream);
			using (JsonTextWriter jsonTextWriter = new JsonTextWriter(streamWriter)
				{
					CloseOutput = false
				})
			{
				var serializer = new JsonSerializer()
				{
					NullValueHandling = NullValueHandling.Ignore
				};
				serializer.Serialize(jsonTextWriter, obj);
				jsonTextWriter.Flush();
			}
			streamWriter.Flush();
		}

		public static T Deserialize<T>(string json)
		{
			if (json == null)
				throw new ArgumentNullException("json");

			using (StringReader stringReader = new StringReader(json))
			{
				using (JsonTextReader jsonTextReader = new JsonTextReader(stringReader))
				{
					var serializer = new JsonSerializer();
					return serializer.Deserialize<T>(jsonTextReader);
				}
			}
		}

		public static T DeserializeFromStream<T>(Stream stream)
		{
			if (stream == null)
				throw new ArgumentNullException("stream");

			StreamReader streamReader = new StreamReader(stream);
			using (JsonTextReader jsonTextReader = new JsonTextReader(streamReader)
				{
					CloseInput = false
				})
			{
				var serializer = new JsonSerializer();
				return serializer.Deserialize<T>(jsonTextReader);
			}
		}
	}
}