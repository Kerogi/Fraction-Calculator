using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fraction_Calculator;
using FractionMath;
using System;
using Moq;
using System.Collections.Generic;
using System.Collections;

namespace Fraction_Calculator.Test
{
	[TestClass, System.Runtime.InteropServices.GuidAttribute("0C01B76B-31C4-4E21-82EA-46A888D21AB0")]
	public class FractionTest
	{
		public static Random rand = new Random();

		[TestMethod()]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void DenominatorPropertyExceptionsTest()
		{
			Fraction frac = 0.123;
			frac.Denominator *= 0;
		}

		[TestMethod()]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void BaseConstructorExceptionsTest()
		{
			//Arrange
			ulong numerator = 1; 
			ulong denominator = 0; 
			bool isNegative = false; 

			//Act
			Fraction target = new Fraction(numerator, denominator, isNegative);
		}

		[TestMethod()]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void AlterConstructorExceptionsTest()
		{
			//Arrange
			int numerator = -1;
			int denominator = 0;

			//Act
			Fraction target = new Fraction(numerator, denominator);
		}

		[TestMethod]
		public void ConstructionBaseTest()
		{
			//Arrange
			ulong numerator = 5;
			ulong denominatior = 9;
			bool isNegative = true;

			//Act
			var fract = new Fraction(numerator, denominatior, isNegative);

			//Assert
			Assert.AreEqual<ulong>(5, fract.Numerator);
			Assert.AreEqual<ulong>(9, fract.Denominator);
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
			Assert.AreEqual<ulong>(1, fract.Numerator);
			Assert.AreEqual<ulong>(2, fract.Denominator);
			Assert.AreEqual<bool>(true, fract.IsNegative);
		}

		#region Integral type construction tests (signed)

		[TestMethod]
		public void ConstructionSByteTest()
		{
			//Arrange
			sbyte number = Convert.ToSByte(rand.Next(sbyte.MinValue, sbyte.MaxValue));
			Fraction expected = new Fraction(Convert.ToUInt64(Math.Abs(number)), 1, number < 0);

			//Act
			var actual = new Fraction(number);

			//Assert
			Assert.AreEqual<ulong>(expected.Numerator, actual.Numerator);
			Assert.AreEqual<ulong>(expected.Denominator, actual.Denominator);
			Assert.AreEqual<bool>(expected.IsNegative, actual.IsNegative);
		}

		[TestMethod]
		public void ConstructionShortTest()
		{
			//Arrange
			short number = Convert.ToInt16(rand.Next(short.MinValue, short.MaxValue));
			Fraction expected = new Fraction(Convert.ToUInt64(Math.Abs(number)), 1, number < 0);

			//Act
			var actual = new Fraction(number);

			//Assert
			Assert.AreEqual<ulong>(expected.Numerator, actual.Numerator);
			Assert.AreEqual<ulong>(expected.Denominator, actual.Denominator);
			Assert.AreEqual<bool>(expected.IsNegative, actual.IsNegative);
		}

		[TestMethod]
		public void ConstructionIntTest()
		{
			//Arrange
			int number = Convert.ToInt32(rand.Next());
			Fraction expected = new Fraction(Convert.ToUInt64(Math.Abs(number)), 1, number < 0);

			//Act
			var actual = new Fraction(number);

			//Assert
			Assert.AreEqual<ulong>(expected.Numerator, actual.Numerator);
			Assert.AreEqual<ulong>(expected.Denominator, actual.Denominator);
			Assert.AreEqual<bool>(expected.IsNegative, actual.IsNegative);
		}

		[TestMethod]
		public void ConstructionLongTest()
		{
			//Arrange
			long number = Convert.ToInt64(rand.Next());
			Fraction expected = new Fraction(Convert.ToUInt64(Math.Abs(number)), 1, number < 0);

			//Act
			var actual = new Fraction(number);

			//Assert
			Assert.AreEqual<ulong>(expected.Numerator, actual.Numerator);
			Assert.AreEqual<ulong>(expected.Denominator, actual.Denominator);
			Assert.AreEqual<bool>(expected.IsNegative, actual.IsNegative);
		}

		#endregion		

		#region Integral type construction tests (unsigned)

		[TestMethod]
		public void ConstructionByteTest()
		{
			//Arrange
			byte number = Convert.ToByte(Math.Abs(rand.Next(byte.MinValue,byte.MaxValue)));
			Fraction expected = new Fraction(Convert.ToUInt64(number), 1, number < 0);

			//Act
			var actual = new Fraction(number);

			//Assert
			Assert.AreEqual<ulong>(expected.Numerator, actual.Numerator);
			Assert.AreEqual<ulong>(expected.Denominator, actual.Denominator);
			Assert.AreEqual<bool>(expected.IsNegative, actual.IsNegative);
		}

		[TestMethod]
		public void ConstructionUShortTest()
		{
			//Arrange
			ushort number = Convert.ToUInt16(Math.Abs(rand.Next(ushort.MinValue, ushort.MaxValue)));
			Fraction expected = new Fraction(Convert.ToUInt64(number), 1, number < 0);

			//Act
			var actual = new Fraction(number);

			//Assert
			Assert.AreEqual<ulong>(expected.Numerator, actual.Numerator);
			Assert.AreEqual<ulong>(expected.Denominator, actual.Denominator);
			Assert.AreEqual<bool>(expected.IsNegative, actual.IsNegative);
		}

		[TestMethod]
		public void ConstructionUIntTest()
		{
			//Arrange
			uint number = Convert.ToUInt32(Math.Abs(rand.Next()));
			Fraction expected = new Fraction(Convert.ToUInt64(number), 1, number < 0);

			//Act
			var actual = new Fraction(number);

			//Assert
			Assert.AreEqual<ulong>(expected.Numerator, actual.Numerator);
			Assert.AreEqual<ulong>(expected.Denominator, actual.Denominator);
			Assert.AreEqual<bool>(expected.IsNegative, actual.IsNegative);
		}

		[TestMethod]
		public void ConstructionULongTest()
		{
			//Arrange
			ulong number = Convert.ToUInt64(Math.Abs(rand.Next()));
			Fraction expected = new Fraction(number, 1, number < 0);

			//Act
			var actual = new Fraction(number);

			//Assert
			Assert.AreEqual<ulong>(expected.Numerator, actual.Numerator);
			Assert.AreEqual<ulong>(expected.Denominator, actual.Denominator);
			Assert.AreEqual<bool>(expected.IsNegative, actual.IsNegative);
		}

		#endregion	

		[TestMethod]
		public void ConstructionDecimalTest()
		{
			//Arrange
			Decimal number = new Decimal(-5.649);
			Fraction expected = new Fraction(5649, 1000, true);


			//Act
			var actual = new Fraction(number);

			//Assert
			Assert.AreEqual<ulong>(expected.Numerator, actual.Numerator);
			Assert.AreEqual<ulong>(expected.Denominator, actual.Denominator);
			Assert.AreEqual<bool>(expected.IsNegative, actual.IsNegative);
		}

		[TestMethod]
		public void ConstructionDoubleTest()
		{
			//Arrange
			double number = 1565.25168;
			Fraction expected = new Fraction(156525168, 100000);


			//Act
			var actual = new Fraction(number);

			//Assert
			Assert.AreEqual<ulong>(expected.Numerator, actual.Numerator);
			Assert.AreEqual<ulong>(expected.Denominator, actual.Denominator);
			Assert.AreEqual<bool>(expected.IsNegative, actual.IsNegative);
		}

		[TestMethod]
		public void ConstructionFloatTest()
		{
			//Arrange
			float number = 11.2394f;
			Fraction expected = new Fraction(112394, 10000);


			//Act
			var actual = new Fraction(number);

			//Assert
			Assert.AreEqual<ulong>(expected.Numerator, actual.Numerator);
			Assert.AreEqual<ulong>(expected.Denominator, actual.Denominator);
			Assert.AreEqual<bool>(expected.IsNegative, actual.IsNegative);
		}

		[TestMethod]
		public void ConstructionZeroTest()
		{
			//Arrange
			float number = 0;
			Fraction expected = new Fraction(0, 1);


			//Act
			var actual = new Fraction(number);

			//Assert
			Assert.AreEqual<ulong>(expected.Numerator, actual.Numerator);
			Assert.AreEqual<ulong>(expected.Denominator, actual.Denominator);
			Assert.AreEqual<bool>(expected.IsNegative, actual.IsNegative);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void DecimalCapacityConstructionTest()
		{
			//Arrange
			var veryLongNumber = 123M / 888M;

			//Act
			Fraction frac = new Fraction(veryLongNumber);
		}


		[TestMethod]
		public void ConstructionSimpleStringTest()
		{
			//Arrange
			String str = "-1.5";
			Fraction expected = new Fraction(3, 2, true);


			//Act
			var actual = new Fraction(str);

			//Assert
			Assert.AreEqual<ulong>(expected.Numerator, actual.Numerator);
			Assert.AreEqual<ulong>(expected.Denominator, actual.Denominator);
			Assert.AreEqual<bool>(expected.IsNegative, actual.IsNegative);
		}


		[TestMethod]
		public void ParseStringTest()
		{
			//Arrange
			string teststring = "-12/22";
			Fraction expected = new Fraction(-12, 22);

			//Act
			Fraction actual = Fraction.Parse(teststring);

			//Assert
			Assert.AreEqual(expected, actual);
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
			ulong numerator = 123;
			ulong denominatior = 456;
			Fraction srcFraction = new Fraction(numerator, denominatior);
			Fraction expectedFraction = new Fraction(numerator, denominatior);

			//Act 
			Fraction dstFraction = srcFraction.Clone() as Fraction;

			//Assert
			Assert.AreEqual(expectedFraction.Numerator, dstFraction.Numerator);
			Assert.AreEqual(expectedFraction.Denominator, dstFraction.Denominator);
			Assert.AreEqual(expectedFraction.IsNegative, dstFraction.IsNegative);
		}


		
		#region Equality and Order relatios tests
		[TestMethod()]
		public void GetHashCodeTest()
		{
			//Arrange
			var frac1 = new Fraction(0.5);
			var frac2 = new Fraction(1,2);
			var frac3 = Fraction.Parse("-1/2");

			//Act
			Fraction frac2_alt = (Fraction)frac2.Clone();
			frac2_alt.Numerator +=1;

			//Assert
			Assert.AreEqual(frac1.GetHashCode(), frac2.GetHashCode());
			Assert.AreNotEqual(frac1.GetHashCode(), frac3.GetHashCode());
			Assert.AreNotEqual(frac2.GetHashCode(), frac2_alt.GetHashCode());
		}


		[TestMethod]
		public void EqualsTest()
		{
			//Arrange
			Fraction x = new Fraction(6, 8);
			Fraction y = new Fraction(3, 4);
			Fraction z = new Fraction(1,1);
			z.Numerator = 12;
			z.Denominator = 16;
			Fraction a = new Fraction(-12, 16);

			object k = x.Clone();
			object m = z.Clone();
			object notFrac = new Double();
			notFrac = 5;
			Fraction l = null;

			//Assert
			Assert.IsTrue(x.Equals(x)); //Рефлексивность
			Assert.AreEqual(x.Equals(y), y.Equals(x)); //Симметричность
			Assert.AreEqual(y.Equals(z), x.Equals(z)); //Транзитивность
			Assert.IsFalse(k.Equals(a));
			Assert.IsFalse(k.Equals(null));
			Assert.IsFalse(k.Equals(notFrac));
			Assert.IsTrue(k.Equals(m));

			Assert.IsFalse(k.Equals(l));
			Assert.IsTrue(y.Equals(k));
			Assert.IsFalse(z.Equals(null));
		}

		[TestMethod]
		public void EqualOperatorTest()
		{
			//Arrange
			Fraction x = new Fraction(6, 8);
			Fraction y = new Fraction(3, 4);
			Fraction z = new Fraction(12, 16);
			Fraction a = new Fraction(11, 16);

			var dec = 3M / 4M; ;

			Fraction k = null;
			Fraction l = null;

			//Assert
			Assert.IsTrue(x == x); //Рефлексивность
			Assert.AreEqual(x == y, y == x); //Симметричность
			Assert.AreEqual(y == z, x == z); //Транзитивность
			
			Assert.IsTrue(k == null);
			Assert.IsTrue(l == null);
			Assert.IsTrue(null == k);
			Assert.IsTrue(null == l);
			Assert.IsTrue(k == l);

			Assert.IsFalse(a == dec);

			Assert.IsFalse(a == k);
			Assert.IsFalse(z == null);

			Assert.IsTrue(a != k);
			Assert.IsTrue(l != z);
		}

		[TestMethod]
		public void ComparisonOrderTest()
		{
			//Arrange
			Fraction a = new Fraction(6, 9);
			Fraction b = new Fraction(1, 2);
			Fraction c = new Fraction(2, 5);

			//Assert
			Assert.IsTrue(a > b);
			Assert.IsFalse(a < a); //Антирефлексивность
			Assert.IsFalse(a > a); //Антирефлексивность
			Assert.IsFalse(b > a); //Антисимметричность
			Assert.AreEqual(b > c, a > c); //Транзитивность
		}

		[TestMethod]
		public void SortArraysOfFractions()
		{
			//Arrange
			var numberOfSamples = 5;

			Fraction[] fractions = new Fraction[numberOfSamples];
			ulong[] values = new ulong[numberOfSamples];

			for (int i = 0; i < numberOfSamples; i++)
			{
				fractions[i] = new Fraction(1, Convert.ToUInt32(rand.Next(2, 100)), false);
				values[i] = fractions[i].Denominator;
			}

			var orderComparer = new Mock<IComparer>();
			orderComparer.Setup(foo => foo.Compare(It.IsAny<ulong>(), It.IsAny<Fraction>())).Returns((ulong a, Fraction b) => (a.CompareTo(b.Denominator)));

			//Act
			Array.Sort(fractions);
			Array.Sort(values, (a, b) => { return -a.CompareTo(b); });

			//Assert
			CollectionAssert.AreEqual(values, fractions, orderComparer.Object);
		}		 
		#endregion

		#region Mathematical operators test

		[TestMethod]
		public void MathNegationTest()
		{
			//Arrange
			Fraction a = new Fraction(1, 2);
			Fraction expected = new Fraction(1, 2, true);

			//Act 
			Fraction actual = -a;

			//Assert
			Assert.AreEqual(expected, actual);
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

		#region Convertions tests

		[TestMethod]
		public void FloatConversationsTest()
		{
			//Arrange
			Fraction expected = new Fraction(2, 5);

			//Act
			float temp = expected;
			Fraction actual = temp;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void DoubleConversationsTest()
		{
			//Arrange
			Fraction expected = new Fraction(3, 8);

			//Act
			double temp = expected;
			Fraction actual = temp;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void DecimalConversationsTest()
		{
			//Arrange
			Fraction expected = new Fraction(3, 15);

			//Act
			decimal temp = expected;
			Fraction actual = temp;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ByteConversationsTest()
		{
			//Arrange
			sbyte multiplier = -2;
			var numerator = 5;
			var denominator = 12;
			Fraction a = new Fraction(numerator, denominator);
			Fraction expected = new Fraction(numerator * multiplier, denominator);

			//Act
			Fraction actual = a * multiplier;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ShortConversationsTest()
		{
			//Arrange
			short multiplier = -4;
			var numerator = 1;
			var denominator = 3;
			Fraction a = new Fraction(numerator, denominator);
			Fraction expected = new Fraction(numerator * multiplier, denominator);

			//Act
			Fraction actual = a * multiplier;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void IntConversationsTest()
		{
			//Arrange
			int multiplier = -3;
			var numerator = 2;
			var denominator = 7;
			Fraction a = new Fraction(numerator, denominator);
			Fraction expected = new Fraction(numerator * multiplier, denominator);

			//Act
			Fraction actual = a * multiplier;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void LongConversationsTest()
		{
			//Arrange
			long multiplier = -6;
			var numerator = 8;
			var denominator = 9;
			Fraction a = new Fraction(numerator, denominator);
			Fraction expected = new Fraction(numerator * multiplier, denominator);

			//Act
			Fraction actual = a * multiplier;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void UnsignedByteConversationsTest()
		{
			//Arrange
			byte multiplier = 7;
			var numerator = 1;
			var denominator = 25;
			Fraction a = new Fraction(numerator, denominator);
			Fraction expected = new Fraction(numerator * multiplier, denominator);

			//Act
			Fraction actual = a * multiplier;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void UnsignedShortConversationsTest()
		{
			//Arrange
			ushort multiplier = 9;
			var numerator = 10;
			var denominator = 55;
			Fraction a = new Fraction(numerator, denominator);
			Fraction expected = new Fraction(numerator * multiplier, denominator);

			//Act
			Fraction actual = a * multiplier;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void UnsignedIntConversationsTest()
		{
			//Arrange
			byte multiplier = 2;
			var numerator = 9;
			var denominator = 2;
			Fraction a = new Fraction(numerator, denominator);
			Fraction expected = new Fraction(numerator * multiplier, denominator);

			//Act
			Fraction actual = a * multiplier;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void UnsignedLongConversationsTest()
		{
			//Arrange
			byte multiplier = 2;
			var numerator = 6;
			var denominator = 1221;
			Fraction a = new Fraction(numerator, denominator);
			Fraction expected = new Fraction(numerator * multiplier, denominator);

			//Act
			Fraction actual = a * multiplier;

			//Assert
			Assert.AreEqual(expected, actual);
		}
		
		[TestMethod]
		public void StringConversationsTest()
		{
			//Arrange
			Fraction expected = new Fraction(1, 32);

			//Act
			string temp = expected;
			Fraction actual = temp;

			//Assert
			Assert.AreEqual(expected, actual);
		}
		#endregion
	}
}
