using System;
using System.Diagnostics;

namespace FractionMath
{
	[DebuggerDisplay("{ToString(),nq} ({ToDecimal(null)})")]
	public partial class Fraction : IComparable<Fraction>, IEquatable<Fraction>, ICloneable
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

		#endregion Private fields

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

		#endregion Properties

		#region Constructors (explicit an significant)

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

		#endregion Constructors (explicit an significant)

		public void Reduce()
		{
			ulong divisor = Utils.GreatestCommonDivisor(Numerator, Denominator);
			Numerator /= divisor;
			Denominator /= divisor;
		}

		static public Fraction Reduce(Fraction fraction, bool clone = false)
		{
			if (fraction == null) throw new ArgumentNullException("fraction");
			var fractionReduced = fraction;
			if (clone)
				fractionReduced = (fraction.Clone() as Fraction);

			fractionReduced.Reduce();
			return fractionReduced;
		}

		public static Fraction Parse(string stringValue)
		{
			if (stringValue == null) throw new ArgumentNullException("stringValue");
			if (stringValue.Length == 0) throw new ArgumentException("String value is empty");
			string[] fractionSubparts = stringValue.Split(Fraction.Vinculums);
			if (fractionSubparts.Length >= 2)
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
			return (int)(Numerator ^ Denominator) * (IsNegative ? -1 : 1);
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
			return CompareTo(other) == 0;
		}

		public static bool operator ==(Fraction left, Fraction right)
		{
			if (System.Object.ReferenceEquals(left, right))
			{
				return true;
			}

			if (((object)left == null) || ((object)right == null))
			{
				return false;
			}
			return left.Equals(right);
		}

		public static bool operator !=(Fraction left, Fraction right)
		{
			return !(left == right);
		}

		#endregion Equality operations

		#region Comparison operations

		public int CompareTo(Fraction other)
		{
			if ((object)other == null) throw new ArgumentNullException("other");
			if (IsNegative == other.IsNegative && Numerator == other.Numerator && Denominator == other.Denominator)
			{
				return 0;
			}
			else
			{
				ulong lcm = Utils.LeastCommonMultiple(Denominator, other.Denominator);
				var selfNumerator = Numerator * ((decimal)lcm / Denominator) * (IsNegative ? -1 : 1);
				var otherNumerator = other.Numerator * ((decimal)lcm / other.Denominator) * (other.IsNegative ? -1 : 1);

				return selfNumerator.CompareTo(otherNumerator);
			}
		}

		public static bool operator >(Fraction left, Fraction right)
		{
			return left.CompareTo(right) > 0;
		}

		public static bool operator <(Fraction left, Fraction right)
		{
			return left.CompareTo(right) < 0;
		}

		#endregion Comparison operations

		#region Mathematical operations

		public static Fraction operator -(Fraction fractiontoNegate)
		{
			if ((object)fractiontoNegate == null) throw new ArgumentNullException("fraction");
			Fraction negativeFraction = fractiontoNegate.Clone() as Fraction;
			negativeFraction.IsNegative = !negativeFraction.IsNegative;
			return negativeFraction;
		}

		public static Fraction operator +(Fraction left, Fraction right)
		{
			if ((object)left == null || (object)right == null) throw new ArgumentNullException("left or right");

			decimal lcm = Convert.ToDecimal(Utils.LeastCommonMultiple(left.Denominator, right.Denominator));
			decimal leftNumerator = Convert.ToDecimal(left.Numerator * (lcm / left.Denominator)) * (left.IsNegative ? -1 : 1);
			decimal rightNumerator = Convert.ToDecimal(right.Numerator * (lcm / right.Denominator)) * (right.IsNegative ? -1 : 1);
			long resultNumerator = Convert.ToInt64(leftNumerator + rightNumerator);
			return new Fraction(resultNumerator, Convert.ToInt64(Math.Abs(lcm)));
		}

		public static Fraction operator -(Fraction left, Fraction right)
		{
			if ((object)left == null || (object)right == null) throw new ArgumentNullException("left or right");

			return (left + (-right));
		}

		public static Fraction operator *(Fraction left, Fraction right)
		{
			if ((object)left == null || (object)right == null) throw new ArgumentNullException("left or right");

			int sign = (left.IsNegative ? -1 : 1) * (right.IsNegative ? -1 : 1);

			return new Fraction(left.Numerator * right.Numerator, left.Denominator * right.Denominator, sign < 0);
		}

		public static Fraction operator /(Fraction left, Fraction right)
		{
			if ((object)left == null || (object)right == null) throw new ArgumentNullException("left or right");

			int sign = (left.IsNegative ? -1 : 1) * (right.IsNegative ? -1 : 1);

			return new Fraction(left.Numerator * right.Denominator, left.Denominator * right.Numerator, sign < 0);
		}

		#endregion Mathematical operations
	}
}