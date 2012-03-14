using Microsoft.VisualStudio.TestTools.UnitTesting;
using FractionMath;
using System;
using Moq;
using System.Collections.Generic;
using System.Collections;

namespace Fraction_Calculator.Test
{
	[TestClass]
	public class FractionTest
	{
		//TODO: write some exceptions test
		[TestMethod]
		public void ConstructionUintUintBoolTest()
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
		public void ConstructionLongLongTest()
		{
			//Arrange
			long numerator = -1;
			long denominatior = 2;
			

			//Act
			var fract = new Fraction(numerator, denominatior);

			//Assert
			Assert.AreEqual<uint>(1, fract.Numerator);
			Assert.AreEqual<uint>(2, fract.Denominator);
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
		public void CloneFractionTest()
		{
			//Arrange
			uint numerator = 123;
			uint denominatior = 456;
			Fraction srcFraction = new Fraction(numerator, denominatior);
			Fraction expectedFraction = new Fraction(numerator, denominatior);

			//Act 
            Fraction dstFraction = srcFraction.Clone() as Fraction;

			//Assert
			Assert.AreEqual(expectedFraction.Numerator, dstFraction.Numerator);
			Assert.AreEqual(expectedFraction.Denominator, dstFraction.Denominator);
			Assert.AreEqual(expectedFraction.IsNegative, dstFraction.IsNegative);
		}

		[TestMethod]
		public void IComparableTest()
		{
			//Arrange
			Fraction smaller= new Fraction(2, 5);
			Fraction bigger = new Fraction(1, 2);
			int expected = 1;

			//Act 
			var actual = ((IComparable<Fraction>)bigger).CompareTo(smaller);

			//Assert
			Assert.AreEqual(expected, actual);
	 
		}

		[TestMethod]
		public void IEquatableTest()
		{
			//Arrange
			Fraction a = new Fraction(6, 8);
			Fraction b = new Fraction(3, 4);
			bool expected = true;

			//Act 
			var actual = ((IEquatable<Fraction>)b).Equals(b);

			//Assert
			Assert.AreEqual(expected, actual);
		}


		#region Mathematical Operators Test
        [TestMethod]
        public void MathNegationTest()
        {
            //Arrange
            Fraction a = new Fraction(1, 2);
            Fraction expected = new Fraction(1, 2, true);

            //Act 
            Fraction actual = -a;

            //Assert
            Assert.AreEqual(expected, -a);
        }

		[TestMethod]
		public void OperatorAdditionTest()
		{
			//Arrange
			Fraction a = new Fraction(1, 2);
			Fraction b = new Fraction(1, 3);
			Fraction expected = new Fraction(5, 6);

			//Act 
			Fraction actual = a + b;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void OperatorSubtractionTest()
		{
			//Arrange
			Fraction a = new Fraction(-1, 2);
			Fraction b = new Fraction(1, 4);
			Fraction expected = new Fraction(-3, 4);

			//Act
			Fraction actual = (a - b);

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void SortArraysOfFractions()
		{
			//Arrange
            var numberOfSamples = 5;
            Random rand = new Random();

            Fraction[] fractions = new Fraction[numberOfSamples];
            uint[] values = new uint[numberOfSamples];
  
            for(int i = 0; i<numberOfSamples; i++)
            {
                fractions[i].Denominator = Convert.ToUInt32(rand.Next(2, 100));          
                values[i] = fractions[i].Denominator;
            }


            var comparerMock = new Mock< IComparer >();
			comparerMock.Setup(foo => foo.Compare(It.IsAny<uint>(), It.IsAny<Fraction>())).Returns((uint a, Fraction b) => (a.CompareTo(b.Denominator)));


			//Act
            Array.Sort(fractions);
            Array.Sort(values);

			//Assert
            CollectionAssert.AreEqual(values, fractions, comparerMock.Object);
		}		
        
        [TestMethod]
		public void OperatorMultiplyTest()
		{
			//Arrange
			Fraction a = new Fraction(1, 2);
			Fraction b = new Fraction(3, 4);
			Fraction expected = new Fraction(3, 8);

			//Act
			Fraction actual = (a * b);

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void OperatorDivisionTest()
		{
			//Arrange
			Fraction a = new Fraction(1, 2);
			Fraction b = new Fraction(1, 3);
			Fraction expected = new Fraction(3, 2);

			//Act
			Fraction actual = a / b;

			//Assert
			Assert.AreEqual(expected, actual);
		} 
		#endregion
	}
}
