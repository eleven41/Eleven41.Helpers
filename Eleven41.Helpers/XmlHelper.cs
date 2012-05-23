using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Eleven41.Helpers
{
	public static class XmlHelper
	{
		public static string Serialize<T>(T obj)
		{
			MemoryStream ms = new MemoryStream();

			try
			{
				System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
				serializer.Serialize(ms, obj);
				string retVal = Encoding.Default.GetString(ms.ToArray());
				return retVal;
			}
			finally
			{
				ms.Dispose();
			}
		}

		public static void SerializeToStream<T>(T obj, Stream stream)
		{
			System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
			serializer.Serialize(stream, obj);
		}

		public static T Deserialize<T>(string xml)
		{
			MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(xml));
			try
			{
				System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
				Object obj = serializer.Deserialize(ms);
				return (T)obj;
			}
			finally
			{
				ms.Close();
				ms.Dispose();
			}
		}

		public static T DeserializeFromStream<T>(Stream stream)
		{
			System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
			Object obj = serializer.Deserialize(stream);
			return (T)obj;
		}
	}
}
