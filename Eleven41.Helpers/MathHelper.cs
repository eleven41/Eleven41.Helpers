using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eleven41.Helpers
{
	/// <summary>
	/// A series of math-related helper functions.
	/// </summary>
	public class MathHelper
	{
		/// <summary>
		/// Rounds a double value to 2 decimal places.
		/// </summary>
		/// <param name="value">Value to round. Must be greater than or equal to 0.</param>
		/// <returns>Rounded result.</returns>
		public static double Round2(double value)
		{
			// Shortcut
			if (value == 0)
				return 0;

			// If the value to round is negative, then
			// round the absolute value, and return the negative of that.
			if (value < 0)
				return -Round2(-value);

			// Get just the decimal part
			double wholeValue = Math.Truncate(value);
			double d = value - wholeValue;

			// Shortcut
			if (d == 0)
				return value;

			int i = Convert.ToInt32(d * 1000);
			int mod = i % 10;
			if (mod > 0)
			{
				i = i - mod;
				if (mod >= 5)
					i += 10;
			}

			return wholeValue + Convert.ToDouble(i) / 1000.0;
		}
	}
}
