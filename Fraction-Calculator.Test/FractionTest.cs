using System;
using System.Collections;
using FractionMath;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Fraction_Calculator.Test
{
	[TestClass]
	public class FractionTest
	{
		public static Random rand = new Random();

		[TestMethod()]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void DenominatorPropertyExceptionsTest()
		{
			Fraction frac = new Fraction(1, 123);
			frac.Denominator *= 0;
		}

		#region Constructors explicit tests

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
		[ExpectedException(typeof(ArgumentException))]
		public void DecimalCapacityConstructionTest()
		{
			//Arrange
			var veryLongNumber = 123M / 888M;

			//Act
			Fraction frac = new Fraction(veryLongNumber);
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

		#endregion Constructors explicit tests

		#region Constructors implicit tests

		[TestMethod()]
		public void ConstructFractionFromDecimal()
		{
			//Arrange
			decimal src = 0.5M;
			Fraction expected = new Fraction(1, 2);

			//Act
			Fraction actual = src;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void ConstructFractionFromDouble()
		{
			//Arrange
			double src = -0.33;
			Fraction expected = new Fraction(33, 100, true);

			//Act
			Fraction actual = src;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void ConstructFractionFromFloat()
		{
			//Arrange
			float src = 0.25f;
			Fraction expected = new Fraction(1, 4);

			//Act
			Fraction actual = src;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void ConstructFractionFromByte()
		{
			//Arrange
			byte src = 1;
			Fraction expected = new Fraction(1, 1);

			//Act
			Fraction actual = src;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void ConstructFractionFromSByte()
		{
			//Arrange
			sbyte src = -6;
			Fraction expected = new Fraction(6, 1, true);

			//Act
			Fraction actual = src;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void ConstructFractionFromShort()
		{
			//Arrange
			short src = 9;
			Fraction expected = new Fraction(9, 1);

			//Act
			Fraction actual = src;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void ConstructFractionFromInt()
		{
			//Arrange
			int src = -12;
			Fraction expected = new Fraction(-24, 2);

			//Act
			Fraction actual = src;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void ConstructFractionFromLong()
		{
			//Arrange
			long src = -5;
			Fraction expected = new Fraction(5, 1, true);

			//Act
			Fraction actual = src;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void ConstructFractionFromUnsignedShort()
		{
			//Arrange
			ushort src = 5;
			Fraction expected = new Fraction(50, 10);

			//Act
			Fraction actual = src;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void ConstructFractionFromUnsignedLong()
		{
			//Arrange
			ulong src = 123;
			Fraction expected = new Fraction(123, 1);

			//Act
			Fraction actual = src;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void ConstructFractionFromUnsignedInt()
		{
			//Arrange
			uint src = 50;
			Fraction expected = new Fraction(100, 2);

			//Act
			Fraction actual = src;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void ConstructFractionFromString()
		{
			//Arrange
			string src = "0.126";
			Fraction expected = new Fraction(126, 1000);

			//Act
			Fraction actual = src;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		#endregion Constructors implicit tests

		#region String parsing tests

		[TestMethod]
		public void FractionStringsParsingTest()
		{
			//Arrange
			string teststringVar1 = "-12/22";
			string teststringVar2 = "-6|11";
			string teststringVar3 = @"-24\44";
			string teststringVar4 = @"-24|44/unused_part";

			Fraction expected = new Fraction(-12, 22);

			//Act
			Fraction actualVar1 = Fraction.Parse(teststringVar1);
			Fraction actualVar2 = Fraction.Parse(teststringVar2);
			Fraction actualVar3 = Fraction.Parse(teststringVar3);
			Fraction actualVar4 = Fraction.Parse(teststringVar4);

			//Assert
			Assert.AreEqual(expected, actualVar1);
			Assert.AreEqual(expected, actualVar2);
			Assert.AreEqual(expected, actualVar3);
			Assert.AreEqual(expected, actualVar4);
		}

		[TestMethod]
		public void DecimalStringParsingTest()
		{
			//Arrange
			string teststring = "1.25";
			Fraction expected = new Fraction(10, 8);

			//Act
			Fraction actual = Fraction.Parse(teststring);

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void NullStringParsingTest()
		{
			//Arrange
			string teststring = null;

			//Act
			Fraction actual = Fraction.Parse(teststring);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void EmptyStringParsingTest()
		{
			//Arrange
			string teststring = "";

			//Act
			Fraction actual = Fraction.Parse(teststring);
		}

		[TestMethod]
		[ExpectedException(typeof(FormatException))]
		public void BrokenDecimalStringParsingTest()
		{
			//Arrange
			string teststring = "-s1.5d";

			//Act
			Fraction actual = Fraction.Parse(teststring);
		}

		[TestMethod]
		[ExpectedException(typeof(FormatException))]
		public void BrokenFractionStringParsingTestNumeratorIsMissing()
		{
			//Arrange
			string teststring = "/7";

			//Act
			Fraction actual = Fraction.Parse(teststring);
		}

		[TestMethod]
		[ExpectedException(typeof(FormatException))]
		public void BrokenFractionStringParsingTestDenomiratorIsMissing()
		{
			//Arrange
			string teststring = "7|";

			//Act
			Fraction actual = Fraction.Parse(teststring);
		}

		[TestMethod]
		[ExpectedException(typeof(FormatException))]
		public void BrokenFractionStringParsingTestNumeratorIsInvalid()
		{
			//Arrange
			string teststring = "asd/7";

			//Act
			Fraction actual = Fraction.Parse(teststring);
		}

		[TestMethod]
		[ExpectedException(typeof(FormatException))]
		public void BrokenFractionStringParsingTestDenumeratorIsInvalid()
		{
			//Arrange
			string teststring = "1|5.6";

			//Act
			Fraction actual = Fraction.Parse(teststring);
		}

		#endregion String parsing tests

		#region Reduce test

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
		[ExpectedException(typeof(ArgumentNullException))]
		public void StaticReduceExceptionTest()
		{
			//Arrange
			Fraction bigFraction = null;

			//Act
			Fraction.Reduce(bigFraction);
		}

		[TestMethod]
		public void StaticReduceAndCopyFractionTest()
		{
			//Arrange
			Fraction bigFraction = new Fraction(36, 63);
			Fraction expectedSmallFraction = new Fraction(4, 7);

			//Act
			var actualReducedFraction = Fraction.Reduce(bigFraction, true);

			//Assert
			Assert.IsFalse(System.Object.ReferenceEquals(bigFraction, actualReducedFraction));
			Assert.AreEqual(expectedSmallFraction.Numerator, actualReducedFraction.Numerator);
			Assert.AreEqual(expectedSmallFraction.Denominator, actualReducedFraction.Denominator);
			Assert.AreEqual(expectedSmallFraction.IsNegative, actualReducedFraction.IsNegative);
		}

		[TestMethod]
		public void StaticReduceNotCopyFractionTest()
		{
			//Arrange
			Fraction bigFraction = new Fraction(36, 63);
			Fraction expectedSmallFraction = new Fraction(4, 7);

			//Act
			var actualReducedFraction = Fraction.Reduce(bigFraction);

			//Assert
			Assert.IsTrue(System.Object.ReferenceEquals(bigFraction, actualReducedFraction));
			Assert.AreEqual(expectedSmallFraction.Numerator, actualReducedFraction.Numerator);
			Assert.AreEqual(expectedSmallFraction.Denominator, actualReducedFraction.Denominator);
			Assert.AreEqual(expectedSmallFraction.IsNegative, actualReducedFraction.IsNegative);
		}

		#endregion Reduce test

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
			var frac2 = new Fraction(1, 2);
			var frac3 = Fraction.Parse("-1/2");

			//Act
			Fraction frac2_alt = (Fraction)frac2.Clone();
			frac2_alt.Numerator += 1;

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
			Fraction z = new Fraction(1, 1);
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

			object dec = 3M / 4M; ;

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
		public void ComparisonOperatorPropertiesTest()
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
		[ExpectedException(typeof(ArgumentNullException))]
		public void CompareToNullTest()
		{
			Fraction a = new Fraction(2, 5);
			a.CompareTo(null);
		}

		[TestMethod]
		public void CompareToTest()
		{
			//Arrange
			Fraction a = new Fraction(2, 5);
			Fraction a_str = new Fraction(20, 50);
			Fraction b = new Fraction(1, 2);
			Fraction c = b.Clone() as Fraction;
			c.Numerator *= 2;
			c.Denominator *= 2;
			Fraction d = -(b.Clone() as Fraction);

			//Act
			var result1 = b.CompareTo(a);
			var result2 = c.CompareTo(b);
			var result3 = d.CompareTo(a);
			var result4 = a.CompareTo(a_str);

			//Assert
			Assert.AreEqual(1, result1);
			Assert.AreEqual(0, result2);
			Assert.AreEqual(-1, result3);
			Assert.AreEqual(0, result4);
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

		#endregion Equality and Order relatios tests

		#region Mathematical operators test (exeptions)

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void OperatorNegationNullTest()
		{
			//Arrange
			Fraction b = null;

			//Act
			Fraction actual = -b;
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void MathAdditionNullRightTest()
		{
			//Arrange
			Fraction a = new Fraction(1, 1); ;
			Fraction b = null;

			//Act
			Fraction actual = a + b;
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void MathAdditionNullLeftTest()
		{
			//Arrange
			Fraction a = null;
			Fraction b = new Fraction(1, 1);

			//Act
			Fraction actual = a + b;
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void MathAdditionNullBothTest()
		{
			//Arrange
			Fraction a = null;
			Fraction b = null;

			//Act
			Fraction actual = a + b;
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void MathSubstractionNullRightTest()
		{
			//Arrange
			Fraction a = new Fraction(1, 1); ;
			Fraction b = null;

			//Act
			Fraction actual = a - b;
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void MathSubstractionNullLeftTest()
		{
			//Arrange
			Fraction a = null;
			Fraction b = new Fraction(1, 1); ;

			//Act
			Fraction actual = a - b;
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void MathSubstractionNullBothTest()
		{
			//Arrange
			Fraction a = null;
			Fraction b = null;

			//Act
			Fraction actual = a - b;
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void MathMultiplicationNullRightTest()
		{
			//Arrange
			Fraction a = new Fraction(1, 1); ;
			Fraction b = null;

			//Act
			Fraction actual = a * b;
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void MathMultiplicationNullLeftTest()
		{
			//Arrange
			Fraction a = null;
			Fraction b = new Fraction(1, 1); ;

			//Act
			Fraction actual = a * b;
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void MathMultiplicationNullBothTest()
		{
			//Arrange
			Fraction a = null;
			Fraction b = null;

			//Act
			Fraction actual = a * b;
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void MathDivisionNullRightTest()
		{
			//Arrange
			Fraction a = new Fraction(1, 1); ;
			Fraction b = null;

			//Act
			Fraction actual = a / b;
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void MathDivisionNullLeftTest()
		{
			//Arrange
			Fraction a = null;
			Fraction b = new Fraction(1, 1); ;

			//Act
			Fraction actual = a / b;
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void MathDivisionNullBothTest()
		{
			//Arrange
			Fraction a = null;
			Fraction b = null;

			//Act
			Fraction actual = a / b;
		}

		#endregion Mathematical operators test (exeptions)

		#region Mathematical operators test

		[TestMethod]
		public void OperatorNegationTest()
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
		public void OperatorMultiplyBothPositiveTest()
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
		public void OperatorMultiplyLeftNegativeTest()
		{
			//Arrange
			Fraction a = new Fraction(-1, 2);
			Fraction b = new Fraction(3, 4);
			Fraction expected = new Fraction(-3, 8);

			//Act
			Fraction actual = (a * b);

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void OperatorMultiplyRightNegativeTest()
		{
			//Arrange
			Fraction a = new Fraction(1, 2);
			Fraction b = new Fraction(-3, 4);
			Fraction expected = new Fraction(-3, 8);

			//Act
			Fraction actual = (a * b);

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void OperatorDivisionBothPositiveTest()
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

		[TestMethod]
		public void OperatorDivisionLeftNegativeTest()
		{
			//Arrange
			Fraction a = new Fraction(-1, 2);
			Fraction b = new Fraction(1, 3);
			Fraction expected = new Fraction(-3, 2);

			//Act
			Fraction actual = a / b;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void OperatorDivisionRightNegativeTest()
		{
			//Arrange
			Fraction a = new Fraction(1, 2);
			Fraction b = new Fraction(-1, 3);
			Fraction expected = new Fraction(-3, 2);

			//Act
			Fraction actual = a / b;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[ExpectedException(typeof(DivideByZeroException))]
		public void OperatorDivisionRightZeroTest()
		{
			//Arrange
			Fraction a = new Fraction(1, 2);
			Fraction b = new Fraction(0, 1234567890);

			//Act
			Fraction actual = a / b;
		}

		#endregion Mathematical operators test

		[TestMethod()]
		public void GetTypeCodeTest()
		{
			//Arrange
			Fraction target = new Fraction(1, 3);
			TypeCode expected = TypeCode.Object;

			//Act
			TypeCode actual = target.GetTypeCode();

			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}