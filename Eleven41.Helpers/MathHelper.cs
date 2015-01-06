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
		/// <param name="value">Value to round.</param>
		/// <returns>Rounded result.</returns>
		public static double Round2(double value)
		{
			decimal decimalValue = Convert.ToDecimal(value);
			decimal result = Math.Round(decimalValue, 2, MidpointRounding.AwayFromZero);
			return Convert.ToDouble(result);
		}
	}
}
