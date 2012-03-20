using System;
using System.Diagnostics;

namespace FractionMath
{
	//TODO: Move format logic to Format or to ToString
	[DebuggerDisplay("{ToString(),nq} ({(double)Numerator/Denominator})")]
	public class Fraction: IComparable<Fraction>, IEquatable<Fraction>, ICloneable, IConvertible
	{
		#region Private fields
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ulong _numerator = 1;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ulong _denominator = 1;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _negative = false;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static char[] _vinculums = { '/', '|', '\\' };
		#endregion

		#region Properties
		public static char[] Vinculums 
		{
			get { return _vinculums; }
		}

		public ulong Numerator
		{
			get { return _numerator; }
			set { _numerator = value; }
		}

		public ulong Denominator
		{
			get { return _denominator; }
			set
			{
				if (value == 0)
				{
					throw new ArgumentOutOfRangeException("value", value.ToString(), "Value must be non-zero integer");
				}
				_denominator = value;
			}
		}

		public bool IsNegative
		{
			get { return _negative; }
			set { _negative = value; }
		} 
		#endregion

		#region Constructors (explicit)
		public Fraction(ulong numerator, ulong denominator, bool isNegative = false)
		{
			if (denominator == 0)
			{
				throw new ArgumentOutOfRangeException("denominator", denominator, "Value must be greater than 0");
			}
			_numerator = numerator;
			_denominator = denominator;
			_negative = isNegative;
			Reduce();
		}

		public Fraction(long numerator, long denominator)
			: this(Convert.ToUInt64(Math.Abs(numerator)), Convert.ToUInt64(Math.Abs(denominator)), numerator < 0) 
		{
		   
		}

		public Fraction(sbyte value)
			: this(Convert.ToUInt64(Math.Abs(value)), 1, value < 0)
		{}

		public Fraction(short value)
			: this(Convert.ToUInt64(Math.Abs(value)), 1, value < 0)
		{}

		public Fraction(int value)
			: this(Convert.ToUInt64(Math.Abs(value)), 1, value < 0)
		{}

		public Fraction(long value)
			: this(Convert.ToUInt64(Math.Abs(value)), 1, value < 0)
		{}

		public Fraction(byte value)
			: this(Convert.ToUInt64(value), 1)
		{}

		public Fraction(ushort value)
			: this(Convert.ToUInt64(value), 1)
		{}

		public Fraction(uint value)
			: this(Convert.ToUInt64(value), 1)
		{}

		public Fraction(ulong value)
			: this(value, 1)
		{}

		public Fraction(decimal number)
		{
			if (Utils.GetSignificantDigitCount(number) >= Utils.GetSignificantDigitCount(Convert.ToDecimal(UInt64.MaxValue)))
			{
				string desc = String.Format("value \'{0}\' cannot be precisely converted to fraction.", number);
				throw new ArgumentException(desc);
			}

			int numberOfZeroes = Utils.GetFractionalDigits(number);
			decimal den = 1;
			for (int i = 0; i < numberOfZeroes; i++)
			{
				den = Decimal.Multiply(den, 10M);
			}
			decimal num = Decimal.Multiply(number, den);

			Debug.Assert(Decimal.Subtract(num, Decimal.Truncate(num)) == 0);

			Numerator = Convert.ToUInt64(Math.Abs(num));
			Denominator = Convert.ToUInt64(Math.Abs(den));
			IsNegative = (number < 0);
			Reduce();
		}

		public Fraction(double number)
			:this(Convert.ToDecimal(number))
		{}

		public Fraction(float number)
			: this(Convert.ToDecimal(number))
		{}

		public Fraction(String str)//Simple 
			: this(Convert.ToDecimal(str))
		{} 

		#endregion

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

		#endregion

		public void Reduce()
		{
			ulong divisor = Utils.GreatestCommonDivisor(Numerator, Denominator);
			Numerator /= divisor;
			Denominator /= divisor;
		}

		static public Fraction Reduce(Fraction fraction)
		{
			if(fraction == null) throw new ArgumentNullException("fraction");
			var fractionReduced = fraction.Clone() as Fraction;
			fractionReduced.Reduce();
			return fractionReduced;
		}

		public static Fraction Parse(string stringValue)
		{
			if (stringValue == null) throw new ArgumentNullException("stringValue");
			if (stringValue.Length == 0) throw new ArgumentException("String value is empty");
			if (stringValue.IndexOfAny(Fraction.Vinculums) != -1)
			{
				string[] fractionSubparts = stringValue.Split(Fraction.Vinculums);
				if(fractionSubparts.Length>=2)
				{
					long numerator, denominator;
					if (long.TryParse(fractionSubparts[0], out numerator) && long.TryParse(fractionSubparts[1], out denominator))
					{
						return new Fraction(numerator, denominator);
					}
					else
					{
						throw new FormatException(String.Format("Cannot parse \'{0}\' value", stringValue));
					}
				}
				else 
				{
					throw new FormatException(String.Format("Cannot parse \'{0}\' value", stringValue));
				}
			}
			else
			{
				decimal simpleDecimalValue;
				if (Decimal.TryParse(stringValue, out simpleDecimalValue))
				{
					return new Fraction(simpleDecimalValue);
				}
				else 
				{
					throw new FormatException(String.Format("Cannot parse \'{0}\' value", stringValue));
				}

			}
		}

		public object Clone()
		{
			return new Fraction(Numerator, Denominator, IsNegative);
		}

		public override String ToString()
		{
			return String.Format("{0}{1}/{2}", IsNegative ? "-" : "", Numerator, Denominator);
		}

		#region Equality operations
		public override int GetHashCode()
		{
			return (int)(Numerator ^ Denominator) * (IsNegative?-1:1);
		}

		public override bool Equals(Object other)
		{
			if (other == null) return false;
			if (!(other is Fraction)) return false;
			return this.Equals(other as Fraction);
		}

		public bool Equals(Fraction other)
		{
			if (other == null) return false;
			if (IsNegative != other.IsNegative) return false;
			if (Numerator == other.Numerator && Denominator == other.Denominator) return true;
			ulong lcm = Utils.LeastCommonMultiple(Denominator, other.Denominator);
			return (Numerator * (lcm / Denominator)) == (other.Numerator * (lcm / other.Denominator));
		}

		public static bool operator ==(Fraction a, Fraction b)
		{
			if (System.Object.ReferenceEquals(a, b))
			{
				return true;
			}
			
			if (((object)a == null) || ((object)b == null))
			{
				return false;
			}
			return a.Equals(b);
		}

		public static bool operator !=(Fraction a, Fraction b)
		{
			return !(a == b);
		}
		#endregion	
		
		#region Comparison operations
		public int CompareTo(Fraction other)
		{
			if (Numerator == other.Numerator && Denominator == other.Denominator && IsNegative == other.IsNegative)
			{
				return 0;
			}
			else
			{
				double valueThis = Numerator / (double)Denominator * (IsNegative ? -1 : 1);
				double valueOther = other.Numerator / (double)other.Denominator * (other.IsNegative ? -1 : 1);
				if (valueThis > valueOther)
					return 1;
				else
					return -1;
			}
		}

		public static bool operator >(Fraction a, Fraction b)
		{
			return a.CompareTo(b) > 0;
		}

		public static bool operator <(Fraction a, Fraction b)
		{
			return a.CompareTo(b) < 0;
		} 
		#endregion
		
		#region Mathematical operations
		public static Fraction operator -(Fraction fractiontoNegate)
		{
			if (fractiontoNegate == null) throw new ArgumentNullException("fraction");
			Fraction negativeFraction = fractiontoNegate.Clone() as Fraction;
			negativeFraction.IsNegative = !negativeFraction.IsNegative;
			return negativeFraction;
		}      

		public static Fraction operator +(Fraction left, Fraction right)
		{
			if (left == null) throw new ArgumentNullException("left");
			if (right == null) throw new ArgumentNullException("right");

			decimal lcm = Convert.ToDecimal(Utils.LeastCommonMultiple(left.Denominator, right.Denominator));
			decimal leftNumerator = Convert.ToDecimal(left.Numerator * (lcm / left.Denominator)) * (left.IsNegative ? -1 : 1);
			decimal rightNumerator= Convert.ToDecimal(right.Numerator * (lcm / right.Denominator)) * (right.IsNegative ? -1 : 1);
			long resultNumerator = Convert.ToInt64(leftNumerator + rightNumerator);
			return new Fraction(resultNumerator, Convert.ToInt64(Math.Abs(lcm)));
		}

		public static Fraction operator -(Fraction left, Fraction right)
		{
			if (left == null) throw new ArgumentNullException("left");
			if (right == null) throw new ArgumentNullException("right");

			return (left + (-right));
		}

		public static Fraction operator *(Fraction left, Fraction right)
		{
			if (left == null) throw new ArgumentNullException("left");
			if (right == null) throw new ArgumentNullException("right");

			int sign = (left.IsNegative ? -1 : 1) * (right.IsNegative ? -1 : 1);

			return new Fraction(left.Numerator * right.Numerator, left.Denominator * right.Denominator, sign < 0);
		}

		public static Fraction operator /(Fraction left, Fraction right)
		{
			if (left == null) throw new ArgumentNullException("left");
			if (right == null) throw new ArgumentNullException("right");

			int sign = (left.IsNegative ? -1 : 1) * (right.IsNegative ? -1 : 1);

			return new Fraction(left.Numerator * right.Denominator, left.Denominator * right.Numerator, sign < 0);
		} 
		#endregion

		#region Conversions To (explisit)
		public bool ToBoolean(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		public char ToChar(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		public DateTime ToDateTime(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

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

		public short ToInt16(IFormatProvider provider)
		{
			return Convert.ToInt16(ToDecimal(provider));
		}

		public int ToInt32(IFormatProvider provider)
		{
			return Convert.ToInt32(ToDecimal(provider));
		}

		public long ToInt64(IFormatProvider provider)
		{
			return Convert.ToInt64(ToDecimal(provider));
		}

		public sbyte ToSByte(IFormatProvider provider)
		{
			return Convert.ToSByte(ToDecimal(provider));
		}

		public float ToSingle(IFormatProvider provider)
		{
			return Convert.ToSingle(ToDecimal(provider));
		}

		public string ToString(IFormatProvider provider)
		{
			return ToString();
		}

		public object ToType(Type conversionType, IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public byte ToByte(IFormatProvider provider)
		{
			return Convert.ToByte(Math.Abs(ToDecimal(provider)));
		}

		public ushort ToUInt16(IFormatProvider provider)
		{
			return Convert.ToUInt16(Math.Abs(ToDecimal(provider)));
		}

		public uint ToUInt32(IFormatProvider provider)
		{
			return Convert.ToUInt32(Math.Abs(ToDecimal(provider)));
		}

		public ulong ToUInt64(IFormatProvider provider)
		{
			return Convert.ToUInt64(Math.Abs(ToDecimal(provider)));
		}

		public TypeCode GetTypeCode()
		{
			return TypeCode.Object;
		}
		
		#endregion

		#region Conversions To (implicit)

		public static implicit operator Decimal(Fraction fraction)
		{
			if (fraction == null) throw new ArgumentNullException("fraction");
			return fraction.ToDecimal(null);
		}

		public static implicit operator double(Fraction fraction)
		{
			if (fraction == null) throw new ArgumentNullException("fraction");
			return fraction.ToDouble(null);
		}

		public static implicit operator float(Fraction fraction)
		{
			if (fraction == null) throw new ArgumentNullException("fraction");
			return fraction.ToSingle(null);
		}

		public static implicit operator byte(Fraction fraction)
		{
			if (fraction == null) throw new ArgumentNullException("fraction");
			return fraction.ToByte(null);
		}

		public static implicit operator sbyte(Fraction fraction)
		{
			if (fraction == null) throw new ArgumentNullException("fraction");
			return fraction.ToSByte(null);
		}

		public static implicit operator short(Fraction fraction)
		{
			if (fraction == null) throw new ArgumentNullException("fraction");
			return fraction.ToInt16(null);
		}

		public static implicit operator int(Fraction fraction)
		{
			if (fraction == null) throw new ArgumentNullException("fraction");
			return fraction.ToInt32(null);
		}

		public static implicit operator long(Fraction fraction)
		{
			if (fraction == null) throw new ArgumentNullException("fraction");
			return fraction.ToInt64(null);
		}

		public static implicit operator ushort(Fraction fraction)
		{
			if (fraction == null) throw new ArgumentNullException("fraction");
			return fraction.ToUInt16(null);
		}

		public static implicit operator uint(Fraction fraction)
		{
			if (fraction == null) throw new ArgumentNullException("fraction");
			return fraction.ToUInt32(null);
		}

		public static implicit operator ulong(Fraction fraction)
		{
			if (fraction == null) throw new ArgumentNullException("fraction");
			return fraction.ToUInt64(null);
		}

		public static implicit operator string(Fraction fraction)
		{
			if (fraction == null) throw new ArgumentNullException("fraction");
			return fraction.ToString(null);
		}

		#endregion



	}
}
