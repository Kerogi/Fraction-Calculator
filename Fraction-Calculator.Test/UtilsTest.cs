﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FractionMath;

namespace Fraction_Calculator.Test
{
	[TestClass]
	public class UtilsTest
	{
		[TestMethod]
		public void GreatestCommonDivisorBasicTest()
		{
			//Arrange
			uint a = 12;
			uint b = 18;
			uint expected = 6;

			//Act
			var actual = FractionMath.Utils.GreatestCommonDivisor(a, b);

			//Assert
			Assert.AreEqual(expected, actual);
		}

		//TODO: Write test for mathematical properties of GDC (http://en.wikipedia.org/wiki/Greatest_common_divisor#Properties)

		[TestMethod]
		public void LeastCommonMultipleBasicTest()
		{
			//Arrange
			uint a = 16;
			uint b = 20;
			uint expected = 80;

			//Act
			var actual = FractionMath.Utils.LeastCommonMultiple(a, b);

			//Assert
			Assert.AreEqual(expected, actual);
		}

		//TODO: Write test for mathematical properties of LCM (http://ru.wikipedia.org/wiki/Наименьшее_общее_кратное)


		[TestMethod]
		public void GetFractionalDigitsForDoubleTest()
		{
			//Arrange
			double digitsAfterDot_0 = 55234;
			double digitsAfterDot_1 = 32425345.6;
			double digitsAfterDot_2 = -29371.24;
			double digitsAfterDot_3 = 801.234;
			double digitsAfterDot_4 = 2.0001;
			double digitsAfterDot_5 = 0.21745;


			//Act
			var actual_for_0 = FractionMath.Utils.GetFractionalDigits(digitsAfterDot_0);
			var actual_for_1 = FractionMath.Utils.GetFractionalDigits(digitsAfterDot_1);
			var actual_for_2 = FractionMath.Utils.GetFractionalDigits(digitsAfterDot_2);
			var actual_for_3 = FractionMath.Utils.GetFractionalDigits(digitsAfterDot_3);
			var actual_for_4 = FractionMath.Utils.GetFractionalDigits(digitsAfterDot_4);
			var actual_for_5 = FractionMath.Utils.GetFractionalDigits(digitsAfterDot_5);
		   
			//Assert
			Assert.AreEqual(0, actual_for_0);
			Assert.AreEqual(1, actual_for_1);
			Assert.AreEqual(2, actual_for_2);
			Assert.AreEqual(3, actual_for_3);
			Assert.AreEqual(4, actual_for_4);
			Assert.AreEqual(5, actual_for_5);
		}

		[TestMethod]
		public void GetFractionalDigitsForDecimalTest()
		{
			//Arrange
			decimal digitsAfterDot_0 = 55234M;
			decimal digitsAfterDot_1 = 32425345.6M;
			decimal digitsAfterDot_2 = 2920001237378123182371.24M;
			decimal digitsAfterDot_3 = 801.234M;
			decimal digitsAfterDot_4 = 2.2340M;
			decimal digitsAfterDot_5 = 0.21745M;


			//Act
			var actual_for_0 = FractionMath.Utils.GetFractionalDigits(digitsAfterDot_0);
			var actual_for_1 = FractionMath.Utils.GetFractionalDigits(digitsAfterDot_1);
			var actual_for_2 = FractionMath.Utils.GetFractionalDigits(digitsAfterDot_2);
			var actual_for_3 = FractionMath.Utils.GetFractionalDigits(digitsAfterDot_3);
			var actual_for_4 = FractionMath.Utils.GetFractionalDigits(digitsAfterDot_4);
			var actual_for_5 = FractionMath.Utils.GetFractionalDigits(digitsAfterDot_5);

			//Assert
			Assert.AreEqual(0, actual_for_0);
			Assert.AreEqual(1, actual_for_1);
			Assert.AreEqual(2, actual_for_2);
			Assert.AreEqual(3, actual_for_3);
			Assert.AreEqual(4, actual_for_4);
			Assert.AreEqual(5, actual_for_5);
		}


		[TestMethod()]
		public void GetSignificantDigitCountTest()
		{		
			Assert.AreEqual(1, Utils.GetSignificantDigitCount(0M));
			Assert.AreEqual(4, Utils.GetSignificantDigitCount(0.000M));
			Assert.AreEqual(3, Utils.GetSignificantDigitCount(1.23M));
			Assert.AreEqual(5, Utils.GetSignificantDigitCount(12.324M));
			Assert.AreEqual(5, Utils.GetSignificantDigitCount(1.2300M));
			Assert.AreEqual(1, Utils.GetSignificantDigitCount(-5M));
			Assert.AreEqual(3, Utils.GetSignificantDigitCount(-5.01M));
			Assert.AreEqual(4, Utils.GetSignificantDigitCount(-0.012M));
			Assert.AreEqual(4, Utils.GetSignificantDigitCount(-0.100M));
			Assert.AreEqual(2, Utils.GetSignificantDigitCount(0.0M));
			Assert.AreEqual(7, Utils.GetSignificantDigitCount(10443.31M));
			Assert.AreEqual(6, Utils.GetSignificantDigitCount(-130.340M));
			Assert.AreEqual(6, Utils.GetSignificantDigitCount(-80.8000M));
		}
	}
}
