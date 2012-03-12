using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
	}
}
