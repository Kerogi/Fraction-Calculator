using System;

namespace FractionMath
{
	public partial class Fraction : IConvertible
	{
		#region Constructors (explicit an insignificant)

		public Fraction(sbyte value)
			: this(Convert.ToUInt64(Math.Abs(value)), 1, value < 0)
		{ }

		public Fraction(short value)
			: this(Convert.ToUInt64(Math.Abs(value)), 1, value < 0)
		{ }

		public Fraction(int value)
			: this(Convert.ToUInt64(Math.Abs(value)), 1, value < 0)
		{ }

		public Fraction(long value)
			: this(Convert.ToUInt64(Math.Abs(value)), 1, value < 0)
		{ }

		public Fraction(byte value)
			: this(Convert.ToUInt64(value), 1)
		{ }

		public Fraction(ushort value)
			: this(Convert.ToUInt64(value), 1)
		{ }

		public Fraction(uint value)
			: this(Convert.ToUInt64(value), 1)
		{ }

		public Fraction(ulong value)
			: this(value, 1)
		{ }

		public Fraction(double number)
			: this(Convert.ToDecimal(number))
		{ }

		public Fraction(float number)
			: this(Convert.ToDecimal(number))
		{ }

		public Fraction(String str)
			: this(Convert.ToDecimal(str))
		{ }

		#endregion Constructors (explicit an insignificant)

		#region Constructors (implicit)

		public static implicit operator Fraction(Decimal value)
		{
			return new Fraction(value);
		}

		public static implicit operator Fraction(double value)
		{
			return new Fraction(value);
		}

		public static implicit operator Fraction(float value)
		{
			return new Fraction(value);
		}

		public static implicit operator Fraction(byte value)
		{
			return new Fraction(value);
		}

		public static implicit operator Fraction(sbyte value)
		{
			return new Fraction(value);
		}

		public static implicit operator Fraction(short value)
		{
			return new Fraction(value);
		}

		public static implicit operator Fraction(int value)
		{
			return new Fraction(value);
		}

		public static implicit operator Fraction(long value)
		{
			return new Fraction(value);
		}

		public static implicit operator Fraction(ushort value)
		{
			return new Fraction(value);
		}

		public static implicit operator Fraction(ulong value)
		{
			return new Fraction(value);
		}

		public static implicit operator Fraction(uint value)
		{
			return new Fraction(value);
		}

		public static implicit operator Fraction(string value)
		{
			return Fraction.Parse(value);
		}

		#endregion Constructors (implicit)

		#region Conversions To (explisit)

		public decimal ToDecimal(IFormatProvider provider)
		{
			decimal value = Convert.ToDecimal(Numerator);
			value = Decimal.Divide(value, Convert.ToDecimal(Denominator));
			value = Decimal.Multiply(value, (IsNegative ? -1.0M : 1.0M));

			return value;
		}

		public double ToDouble(IFormatProvider provider)
		{
			return Convert.ToDouble(ToDecimal(provider));
		}

		public float ToSingle(IFormatProvider provider)
		{
			return Convert.ToSingle(ToDecimal(provider));
		}

		public string ToString(IFormatProvider provider)
		{
			return ToString();
		}

		#region Not suported convetations

		public DateTime ToDateTime(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		public char ToChar(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		public bool ToBoolean(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		public short ToInt16(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		public int ToInt32(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		public long ToInt64(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		public sbyte ToSByte(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		public byte ToByte(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		public ushort ToUInt16(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		public uint ToUInt32(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		public ulong ToUInt64(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		public object ToType(Type conversionType, IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		#endregion Not suported convetations

		public TypeCode GetTypeCode()
		{
			return TypeCode.Object;
		}

		#endregion Conversions To (explisit)

		#region Conversions To (implicit)

		public static implicit operator decimal(Fraction fraction)
		{
			if ((object)fraction == null) throw new ArgumentNullException("fraction");
			return fraction.ToDecimal(null);
		}

		public static implicit operator double(Fraction fraction)
		{
			if ((object)fraction == null) throw new ArgumentNullException("fraction");
			return fraction.ToDouble(null);
		}

		public static implicit operator float(Fraction fraction)
		{
			if ((object)fraction == null) throw new ArgumentNullException("fraction");
			return fraction.ToSingle(null);
		}

		public static implicit operator string(Fraction fraction)
		{
			if ((object)fraction == null) throw new ArgumentNullException("fraction");
			return fraction.ToString(null);
		}

		#endregion Conversions To (implicit)
	}
}