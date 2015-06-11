using System;
using Eleven41.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
	[TestClass]
	public class DateTimeHelperTests
	{
		[TestMethod]
		public void GetISO8601String_from_utc()
		{
			// Setup
			DateTime source = new DateTime(2015, 06, 11, 2, 0, 0, DateTimeKind.Utc);
			
			// Execute
			string result = DateTimeHelper.GetISO8601String(source);
			
			// Check the results
			Assert.AreEqual("2015-06-11T02:00:00.000Z", result);
		}

		[TestMethod]
		public void GetISO8601String_from_unspecified()
		{
			// Setup
			DateTime source = new DateTime(2015, 06, 11, 2, 0, 0, DateTimeKind.Unspecified);

			// Execute
			string result = DateTimeHelper.GetISO8601String(source);

			// Check the results
			Assert.AreEqual("2015-06-11T02:00:00.000Z", result);
		}

		[TestMethod]
		public void ParseAsUtc_from_iso8601()
		{
			// Setup
			DateTime source = new DateTime(2015, 6, 11, 2, 0, 0, DateTimeKind.Utc);
			string dateString = DateTimeHelper.GetISO8601String(source);

			// Execute
			var result = DateTimeHelper.ParseAsUtc(dateString);

			// Check the results
			Assert.AreEqual(2015, result.Year);
			Assert.AreEqual(6, result.Month);
			Assert.AreEqual(11, result.Day);
			Assert.AreEqual(2, result.Hour);
			Assert.AreEqual(0, result.Minute);
			Assert.AreEqual(0, result.Second);
			Assert.AreEqual(DateTimeKind.Utc, result.Kind);
		}

		[TestMethod]
		public void ParseToTimeZone_from_iso8601_to_EST()
		{
			// Setup
			DateTime source = new DateTime(2015, 6, 11, 2, 0, 0, DateTimeKind.Utc);
			string dateString = DateTimeHelper.GetISO8601String(source);
			TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

			// Execute
			var result = DateTimeHelper.ParseToTimeZone(dateString, tzi);
			
			// Check the results
			Assert.AreEqual(2015, result.Year);
			Assert.AreEqual(6, result.Month);
			Assert.AreEqual(10, result.Day);
			Assert.AreEqual(22, result.Hour);
			Assert.AreEqual(0, result.Minute);
			Assert.AreEqual(0, result.Second);
			Assert.AreEqual(DateTimeKind.Unspecified, result.Kind);
		}
	}
}
