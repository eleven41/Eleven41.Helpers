using System;
using System.Linq;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eleven41.Helpers;
using System.Runtime.Serialization;

namespace UnitTests
{
	[TestClass]
	public class JsonHelperTests
	{
		class TestObject
		{
			public int IntValue1 { get; set; }
			public string NullValue { get; set; }
		}

		[TestMethod]
		public void serialize_to_string_and_deserialize()
		{
			// Seed
			var obj = new TestObject()
			{
				IntValue1 = 2,
				NullValue = null
			};

			// Execute

			string json = JsonHelper.Serialize(obj);

			Assert.IsNotNull(json);
			Assert.AreEqual(-1, json.IndexOf("NullValue", StringComparison.OrdinalIgnoreCase)); // Should not be included since null
			Assert.AreEqual(-1, json.IndexOf("\r")); // Should not be formatted
			Assert.AreEqual(-1, json.IndexOf("\n")); // Should not be formatted

			TestObject result = JsonHelper.Deserialize<TestObject>(json);

			// Check results
			Assert.IsNotNull(result);
			Assert.AreEqual(2, result.IntValue1);
			Assert.AreEqual(null, result.NullValue);
		}

		[TestMethod]
		public void serialize_to_formatted_string_and_deserialize()
		{
			// Seed
			var obj = new TestObject()
			{
				IntValue1 = 2,
				NullValue = null
			};

			// Execute

			string json = JsonHelper.SerializeAndFormat(obj);

			Assert.IsNotNull(json);
			Assert.AreEqual(-1, json.IndexOf("NullValue", StringComparison.OrdinalIgnoreCase)); // Should not be included since null
			Assert.AreNotEqual(-1, json.IndexOf("\r")); // Should be formatted
			Assert.AreNotEqual(-1, json.IndexOf("\n")); // Should be formatted

			TestObject result = JsonHelper.Deserialize<TestObject>(json);

			// Check results
			Assert.IsNotNull(result);
			Assert.AreEqual(2, result.IntValue1);
			Assert.AreEqual(null, result.NullValue);
		}

		[TestMethod]
		public void serialize_to_stream_and_deserialize()
		{
			// Seed
			var obj = new TestObject()
			{
				IntValue1 = 2,
				NullValue = null
			};

			MemoryStream stream = new MemoryStream();

			// Execute

			JsonHelper.SerializeToStream(obj, stream);

			var bytes = stream.ToArray();

			Assert.IsNotNull(bytes);
			Assert.AreNotEqual(0, bytes.Length);

			string json = System.Text.Encoding.ASCII.GetString(bytes);
			Assert.IsNotNull(json);
			Assert.AreEqual(-1, json.IndexOf("NullValue", StringComparison.OrdinalIgnoreCase)); // Should not be included since null
			Assert.AreEqual(-1, json.IndexOf("\r")); // Should not be formatted
			Assert.AreEqual(-1, json.IndexOf("\n")); // Should not be formatted

			stream.Seek(0, SeekOrigin.Begin);
			TestObject result = JsonHelper.DeserializeFromStream<TestObject>(stream);

			// Check results
			Assert.IsNotNull(result);
			Assert.AreEqual(2, result.IntValue1);
			Assert.AreEqual(null, result.NullValue);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void serialize_to_string_null_object()
		{
			// Seed

			// Execute

			string json = JsonHelper.Serialize<TestObject>(null);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void serialize_to_stream_null_object()
		{
			// Seed

			// Execute

			JsonHelper.SerializeToStream<TestObject>(null, new MemoryStream());
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void serialize_to_stream_null_stream()
		{
			// Seed

			// Execute

			JsonHelper.SerializeToStream<TestObject>(new TestObject(), null);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void serialize_to_formatted_string_null_object()
		{
			// Seed

			// Execute

			string json = JsonHelper.SerializeAndFormat<TestObject>(null);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void deserialize_null_string()
		{
			// Seed
			
			// Execute

			TestObject result = JsonHelper.Deserialize<TestObject>(null);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void deserialize_null_stream()
		{
			// Seed
			
			// Execute

			TestObject result = JsonHelper.DeserializeFromStream<TestObject>(null);
		}

		[TestMethod]
		public void deserialize_empty_string()
		{
			// Seed

			// Execute

			TestObject result = JsonHelper.Deserialize<TestObject>("");

			Assert.IsNull(result);
		}

		[TestMethod]
		public void deserialize_empty_stream()
		{
			// Seed

			// Execute

			TestObject result = JsonHelper.DeserializeFromStream<TestObject>(new MemoryStream());

			Assert.IsNull(result);
		}
		
		[DataContract]
		class TestDataContractObject
		{
			[DataMember(Name = "prop1")]
			public int IntValue1 { get; set; }

			[DataMember(Name = "prop3")]
			public string StrValue1 { get; set; }

			[DataMember(Name = "prop2")]
			public string NullValue { get; set; }
		}

		[TestMethod]
		public void serialize_datacontract_to_string_and_deserialize()
		{
			// Seed
			var obj = new TestDataContractObject()
			{
				IntValue1 = 2,
				StrValue1 = "123",
				NullValue = null
			};

			// Execute

			string json = JsonHelper.Serialize(obj);

			Assert.IsNotNull(json);
			Assert.AreEqual(-1, json.IndexOf("IntValue1", StringComparison.OrdinalIgnoreCase)); // Should not be included due to DataMember
			Assert.AreNotEqual(-1, json.IndexOf("prop1", StringComparison.OrdinalIgnoreCase)); // Should be included due to DataMember
			Assert.AreEqual(-1, json.IndexOf("NullValue", StringComparison.OrdinalIgnoreCase)); // Should not be included since null
			Assert.AreEqual(-1, json.IndexOf("prop2", StringComparison.OrdinalIgnoreCase)); // Should not be included since null
			Assert.AreEqual(-1, json.IndexOf("\r")); // Should not be formatted
			Assert.AreEqual(-1, json.IndexOf("\n")); // Should not be formatted

			TestDataContractObject result = JsonHelper.Deserialize<TestDataContractObject>(json);

			// Check results
			Assert.IsNotNull(result);
			Assert.AreEqual(2, result.IntValue1);
			Assert.AreEqual("123", result.StrValue1);
			Assert.AreEqual(null, result.NullValue);
		}
	}
}
