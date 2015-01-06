using System;
using Eleven41.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
	[TestClass]
	public class MathHelperTests
	{
		[TestMethod]
		public void Round2_zero()
		{
			double result = MathHelper.Round2(0);
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void Round2_zero_point_zero_zero_zero_one()
		{
			double result = MathHelper.Round2(0.0001);
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void Round2_zero_point_zero_zero_zero_nine()
		{
			double result = MathHelper.Round2(0.0009);
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void Round2_zero_point_zero_zero_one()
		{
			double result = MathHelper.Round2(0.001);
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void Round2_zero_point_zero_zero_two()
		{
			double result = MathHelper.Round2(0.002);
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void Round2_zero_point_zero_zero_three()
		{
			double result = MathHelper.Round2(0.003);
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void Round2_zero_point_zero_zero_four()
		{
			double result = MathHelper.Round2(0.004);
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void Round2_zero_point_zero_zero_five()
		{
			double result = MathHelper.Round2(0.005);
			Assert.AreEqual(0.01, result);
		}

		[TestMethod]
		public void Round2_zero_point_zero_zero_six()
		{
			double result = MathHelper.Round2(0.006);
			Assert.AreEqual(0.01, result);
		}

		[TestMethod]
		public void Round2_zero_point_zero_zero_seven()
		{
			double result = MathHelper.Round2(0.007);
			Assert.AreEqual(0.01, result);
		}

		[TestMethod]
		public void Round2_zero_point_zero_zero_eight()
		{
			double result = MathHelper.Round2(0.008);
			Assert.AreEqual(0.01, result);
		}

		[TestMethod]
		public void Round2_zero_point_zero_zero_nine()
		{
			double result = MathHelper.Round2(0.009);
			Assert.AreEqual(0.01, result);
		}

		[TestMethod]
		public void Round2_zero_point_zero_one()
		{
			double result = MathHelper.Round2(0.01);
			Assert.AreEqual(0.01, result);
		}

		[TestMethod]
		public void Round2_zero_point_zero_two()
		{
			double result = MathHelper.Round2(0.02);
			Assert.AreEqual(0.02, result);
		}

		[TestMethod]
		public void Round2_zero_point_zero_three()
		{
			double result = MathHelper.Round2(0.03);
			Assert.AreEqual(0.03, result);
		}

		[TestMethod]
		public void Round2_zero_point_zero_four()
		{
			double result = MathHelper.Round2(0.04);
			Assert.AreEqual(0.04, result);
		}

		[TestMethod]
		public void Round2_zero_point_zero_five()
		{
			double result = MathHelper.Round2(0.05);
			Assert.AreEqual(0.05, result);
		}

		[TestMethod]
		public void Round2_zero_point_zero_six()
		{
			double result = MathHelper.Round2(0.06);
			Assert.AreEqual(0.06, result);
		}

		[TestMethod]
		public void Round2_zero_point_zero_seven()
		{
			double result = MathHelper.Round2(0.07);
			Assert.AreEqual(0.07, result);
		}

		[TestMethod]
		public void Round2_zero_point_zero_eight()
		{
			double result = MathHelper.Round2(0.08);
			Assert.AreEqual(0.08, result);
		}

		[TestMethod]
		public void Round2_zero_point_zero_nine()
		{
			double result = MathHelper.Round2(0.09);
			Assert.AreEqual(0.09, result);
		}

		[TestMethod]
		public void Round2_zero_point_one()
		{
			double result = MathHelper.Round2(0.1);
			Assert.AreEqual(0.1, result);
		}

		[TestMethod]
		public void Round2_zero_point_one_four()
		{
			double result = MathHelper.Round2(0.14);
			Assert.AreEqual(0.14, result);
		}

		[TestMethod]
		public void Round2_zero_point_one_five()
		{
			double result = MathHelper.Round2(0.15);
			Assert.AreEqual(0.15, result);
		}

		[TestMethod]
		public void Round2_zero_point_one_one_four()
		{
			double result = MathHelper.Round2(0.114);
			Assert.AreEqual(0.11, result);
		}

		[TestMethod]
		public void Round2_zero_point_one_one_five()
		{
			double result = MathHelper.Round2(0.115);
			Assert.AreEqual(0.12, result);
		}

		[TestMethod]
		public void Round2_zero_point_one_nine_five()
		{
			double result = MathHelper.Round2(0.195);
			Assert.AreEqual(0.2, result);
		}

		[TestMethod]
		public void Round2_zero_point_one_nine_five_five()
		{
			double result = MathHelper.Round2(0.1955);
			Assert.AreEqual(0.2, result);
		}

		[TestMethod]
		public void Round2_zero_point_nine_nine_five()
		{
			double result = MathHelper.Round2(0.995);
			Assert.AreEqual(1.0, result);
		}

		[TestMethod]
		public void Round2_one()
		{
			double result = MathHelper.Round2(1);
			Assert.AreEqual(1, result);
		}

		[TestMethod]
		public void Round2_ten()
		{
			double result = MathHelper.Round2(10);
			Assert.AreEqual(10, result);
		}

		[TestMethod]
		public void Round2_one_hundred()
		{
			double result = MathHelper.Round2(100);
			Assert.AreEqual(100, result);
		}

		[TestMethod]
		public void Round2_int_max()
		{
			double result = MathHelper.Round2(Int32.MaxValue);
			Assert.AreEqual(Int32.MaxValue, result);
		}

		#region Negative Numbers

		[TestMethod]
		public void Round2_negative_zero_point_zero_zero_one()
		{
			double result = MathHelper.Round2(-0.001);
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void Round2_negative_zero_point_zero_zero_five()
		{
			double result = MathHelper.Round2(-0.005);
			Assert.AreEqual(-0.01, result);
		}

		[TestMethod]
		public void Round2_negative_zero_point_zero_one()
		{
			double result = MathHelper.Round2(-0.01);
			Assert.AreEqual(-0.01, result);
		}

		#endregion

		#region Known Problems with Math.Round

		[TestMethod]
		public void Round2_four_point_one_eight_five()
		{
			// Known problem with Math.Round (double version):
			//  Math.Round(4.185, 2, MidpointRounding.AwayFromZero) == 4.18
			//  but should equal 4.19.
			//  Note that using the Decimal version of Math.Round does work correctly.

			double result = MathHelper.Round2(4.185);
			Assert.AreEqual(4.19, result);
		}

		#endregion

		#region Known Values

		[TestMethod]
		public void Round2_four_point_six_six_one()
		{
			double result = MathHelper.Round2(4.661);
			Assert.AreEqual(4.66, result);
		}

		[TestMethod]
		public void Round2_four_point_four_four_six()
		{
			double result = MathHelper.Round2(4.446);
			Assert.AreEqual(4.45, result);
		}

		[TestMethod]
		public void Round2_zero_point_five_zero_seven()
		{
			double result = MathHelper.Round2(0.507);
			Assert.AreEqual(0.51, result);
		}

		[TestMethod]
		public void Round2_twenty_two_point_one_five_two()
		{
			double result = MathHelper.Round2(22.152);
			Assert.AreEqual(22.15, result);
		}

		[TestMethod]
		public void Round2_thirty_four_point_two_zero_three()
		{
			double result = MathHelper.Round2(34.203);
			Assert.AreEqual(34.20, result);
		}

		#endregion
	}
}
