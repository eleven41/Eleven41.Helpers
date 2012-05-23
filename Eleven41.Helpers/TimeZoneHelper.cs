using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eleven41.Helpers
{
	public static class TimeZoneHelper
	{
		public static DateTime AdjustToUtc(DateTime local, TimeZoneInfo tzi)
		{
			try
			{
				return TimeZoneInfo.ConvertTimeToUtc(local, tzi);
			}
			catch (ArgumentException)
			{
				// Assume that we get this because of clock adjustment,
				// so add an hour to the local and try again
				return TimeZoneInfo.ConvertTimeToUtc(local.AddHours(1), tzi);
			}
		}

		public static DateTime AdjustFromUtc(DateTime utc, TimeZoneInfo tzi)
		{
			return TimeZoneInfo.ConvertTimeFromUtc(utc, tzi);
		}

		public static DateTime AdjustTimeZone(DateTime source, TimeZoneInfo sourceTzi, TimeZoneInfo targetTzi)
		{
			return AdjustFromUtc(AdjustToUtc(source, sourceTzi), targetTzi);
		}
	}
}
