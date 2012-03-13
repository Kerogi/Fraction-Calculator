using Microsoft.VisualStudio.TestTools.UnitTesting;
using FractionMath;

namespace Fraction_Calculator.Test
{
	[TestClass]
	public class FractionTest
	{
		//TODO: write some exceptions test
		[TestMethod]
		public void ConstructionTest()
		{
			//Arrange
			uint numerator = 5;
			uint denominatior = 9;
			bool isNegative = true;

			//Act
			var fract = new Fraction(numerator, denominatior, isNegative);

			//Assert
			Assert.AreEqual<uint>(5, fract.Numerator);
			Assert.AreEqual<uint>(9, fract.Denominator);
			Assert.AreEqual<bool>(true, fract.IsNegative);
		}

		[TestMethod]
		public void ReduceFractionTest()
		{
			//Arrange 
			Fraction actualFraction = new Fraction(36, 63);
			Fraction expectedFraction = new Fraction(4, 7);

			//Act 
			actualFraction.Reduce();

			//Assert
			Assert.AreEqual(expectedFraction.Numerator, actualFraction.Numerator);
			Assert.AreEqual(expectedFraction.Denominator, actualFraction.Denominator);
			Assert.AreEqual(expectedFraction.IsNegative, actualFraction.IsNegative);
		}

		[TestMethod]
		public void StaticReduceFractionTest()
		{
			//Arrange 
			Fraction bigFraction = new Fraction(36, 63);
			Fraction expectedSmallFraction = new Fraction(4, 7);

			//Act 
			var actualReducedFraction = Fraction.Reduce(bigFraction);

			//Assert
			Assert.AreEqual(expectedSmallFraction.Numerator, actualReducedFraction.Numerator);
			Assert.AreEqual(expectedSmallFraction.Denominator, actualReducedFraction.Denominator);
			Assert.AreEqual(expectedSmallFraction.IsNegative, actualReducedFraction.IsNegative);
		}

		[TestMethod]
		public void CopyFractionTest()
		{
			//Arrange
			uint numerator = 123;
			uint denominatior = 456;
			Fraction srcFraction = new Fraction(numerator, denominatior);
			Fraction expectedFraction = new Fraction(numerator, denominatior);

			//Act 
			var dstFraction = srcFraction.Copy();

			//Assert
			Assert.AreEqual(expectedFraction.Numerator, dstFraction.Numerator);
			Assert.AreEqual(expectedFraction.Denominator, dstFraction.Denominator);
			Assert.AreEqual(expectedFraction.IsNegative, dstFraction.IsNegative);
		}

		[TestMethod]
		public void CompareFractionsTest()
		{
			//Arrange
			Fraction smallerFraction = new Fraction(2, 5);
			Fraction biggerFraction = new Fraction(1, 2);
			int expected = 1;

			//Act 
			var actual = biggerFraction.CompareTo(smallerFraction);

			//Assert
			Assert.AreEqual(expected, actual);
	 
		}

        [TestMethod]
        public void AddFractionsTest()
        {
            //Arrange
            Fraction a = new Fraction(1, 2);
            Fraction b = new Fraction(3, 5);
            Fraction expected = new Fraction(11, 10);

            //Act 
            var actual = a + b;

            //Assert
            Assert.AreEqual(expected, actual);
        }
	}
}
