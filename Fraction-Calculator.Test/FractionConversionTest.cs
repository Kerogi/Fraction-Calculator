using System;
using FractionMath;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fraction_Calculator.Test
{
	[TestClass]
	public class FractionConversionTest
	{
		public static Random rand = new Random();

		#region Constructors (explicit an insignificant)

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

		#endregion Integral type construction tests (signed)

		#region Integral type construction tests (unsigned)

		[TestMethod]
		public void ConstructionByteTest()
		{
			//Arrange
			byte number = Convert.ToByte(Math.Abs(rand.Next(byte.MinValue, byte.MaxValue)));
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

		#endregion Integral type construction tests (unsigned)

		#endregion Constructors (explicit an insignificant)

		#region Invalid convertations exeptions test

		[TestMethod]
		[ExpectedException(typeof(InvalidCastException))]
		public void InvalidConversationToBool()
		{
			//Arrange
			Fraction src = new Fraction(2, 5);

			//Act
			bool dst = src.ToBoolean(null);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidCastException))]
		public void InvalidConversationToChar()
		{
			//Arrange
			Fraction src = new Fraction(2, 5);

			//Act
			char dst = src.ToChar(null);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidCastException))]
		public void InvalidConversationToDateTime()
		{
			//Arrange
			Fraction src = new Fraction(2, 5);

			//Act
			DateTime dst = src.ToDateTime(null);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidCastException))]
		public void InvalidConversationToSignedByte()
		{
			Fraction src = new Fraction(2, 5);

			//Act
			sbyte dst = src.ToSByte(null);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidCastException))]
		public void InvalidConversationToShort()
		{
			Fraction src = new Fraction(2, 5);

			//Act
			short dst = src.ToInt16(null);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidCastException))]
		public void InvalidConversationToInt()
		{
			Fraction src = new Fraction(2, 5);

			//Act
			int dst = src.ToInt32(null);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidCastException))]
		public void InvalidConversationToLong()
		{
			Fraction src = new Fraction(2, 5);

			//Act
			long dst = src.ToInt64(null);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidCastException))]
		public void InvalidConversationToByte()
		{
			Fraction src = new Fraction(2, 5);

			//Act
			byte dst = src.ToByte(null);
		}

		[TestMethod]
		[ExpectedException(typeof(NotImplementedException))]
		public void InvalidConversationFallbackToType()
		{
			Fraction src = new Fraction(2, 5);

			//Act
			object dst = src.ToType(null, null);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidCastException))]
		public void InvalidConversationToUnsignedShort()
		{
			Fraction src = new Fraction(2, 5);

			//Act
			ushort dst = src.ToUInt16(null);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidCastException))]
		public void InvalidConversationToUnsignedInt()
		{
			Fraction src = new Fraction(2, 5);

			//Act
			uint dst = src.ToUInt32(null);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidCastException))]
		public void InvalidConversationToUnsignedLong()
		{
			Fraction src = new Fraction(2, 5);

			//Act
			ulong dst = src.ToUInt64(null);
		}

		#endregion Invalid convertations exeptions test

		#region Convertions implicid to and from tests

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void NullFractionToDecimalTest()
		{
			Fraction src = null;

			//Act
			decimal dst = src;
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void NullFractionToDoubleTest()
		{
			Fraction src = null;

			//Act
			double dst = src;
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void NullFractionToFloatTest()
		{
			Fraction src = null;

			//Act
			float dst = src;
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void NullFractionToStringTest()
		{
			Fraction src = null;

			//Act
			string dst = src;
		}

		[TestMethod]
		public void DecimalConversationsNegativeTest()
		{
			//Arrange
			Fraction src = new Fraction(1, 5, true);
			decimal expected = -0.2M;

			//Act
			decimal actual = src;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void DecimalConversationsPositiveTest()
		{
			//Arrange
			Fraction src = new Fraction(3, 15);
			decimal expected = 0.2M;

			//Act
			decimal actual = src;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void FloatConversationsTest()
		{
			//Arrange
			Fraction src = new Fraction(5, 10, false);
			float expected = 0.5f;

			//Act
			float actual = src;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void DoubleConversationsTest()
		{
			//Arrange
			Fraction src = new Fraction(-45, 75);
			double expected = -0.6;

			//Act
			double actual = src;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void StringConversationsVar1Test()
		{
			//Arrange
			Fraction src = new Fraction(1, 32);
			string expected = "1/32";

			//Act
			string actual = src;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void StringConversationsVar2Test()
		{
			//Arrange
			Fraction src = new Fraction(-25, 5);
			string expected = "-5/1";

			//Act
			string actual = src;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		#endregion Convertions implicid to and from tests
	}
}