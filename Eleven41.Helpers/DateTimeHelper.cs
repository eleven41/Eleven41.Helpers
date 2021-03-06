﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eleven41.Helpers
{
	public static class DateTimeHelper
	{
		// Our base is the same as the standard unix file base
		private static DateTime _base = new DateTime(1970, 1, 1);

		public static DateTime FromUnixTime(int dt)
		{
			return _base.AddSeconds(dt).ToLocalTime();
		}

		public static int ToUnixTime(DateTime dt)
		{
			TimeSpan span = dt.ToUniversalTime() - _base;
			return Convert.ToInt32(span.TotalSeconds);
		}

		public static DateTime FromXferTime(long dt)
		{
			return _base.AddMilliseconds(dt).ToLocalTime();
		}

		public static long ToXferTime(DateTime dt)
		{
			TimeSpan span = dt.ToUniversalTime() - _base;
			return Convert.ToInt64(span.TotalMilliseconds);
		}

		public static DateTime CombineDateWithTime(DateTime useTime, DateTime useDate)
		{
			return useDate.Date + useTime.TimeOfDay;
			//return new DateTime(useDate.Year, useDate.Month, useDate.Day, useTime.Hour, useTime.Minute, useTime.Second, useTime.Kind);
		}

		public static int WeekOfMonth(DateTime d)
		{
			int remainder;
			return Math.DivRem(d.Day - 1, 7, out remainder) + 1;
		}

		public static int InvWeekOfMonth(DateTime d)
		{
			// How many days in the month?
			int daysInMonth = DateTime.DaysInMonth(d.Year, d.Month);
			
			int invDay = (daysInMonth - d.Day);

			int remainder;
			return Math.DivRem(invDay, 7, out remainder) + 1;
		}

		/// <summary>
		/// Returns the specified date in ISO 8601 format.
		/// </summary>
		/// <param name="date">Date to convert to ISO 8601 format.</param>
		/// <returns>String of converted date.</returns>
		public static string GetISO8601String(DateTime date)
		{
			if (date.Kind == DateTimeKind.Local)
				date = date.ToUniversalTime();
			else if (date.Kind == DateTimeKind.Unspecified)
				date = DateTime.SpecifyKind(date, DateTimeKind.Utc);
			return date.ToString("yyyy-MM-dd\\THH:mm:ss.fff\\Z");
		}

		public static DateTime ParseAsUtc(string dateString)
		{
			DateTime utcResult = DateTime.Parse(dateString).ToUniversalTime();
			return utcResult;
		}

		public static DateTime ParseToTimeZone(string dateString, TimeZoneInfo tzi)
		{
			DateTime utcResult = DateTime.Parse(dateString).ToUniversalTime();
			return TimeZoneHelper.AdjustFromUtc(utcResult, tzi);
		}
	}
}