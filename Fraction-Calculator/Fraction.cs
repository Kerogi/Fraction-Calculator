﻿using System;
using System.Diagnostics;

namespace FractionMath
{
	//TODO: Move format logic to Format or to ToString
    [DebuggerDisplay("{ToString(),nq} ({(double)Numerator/Denominator})")]
	public class Fraction: IComparable<Fraction>, IEquatable<Fraction>, ICloneable, IConvertible, ICustomFormatter, IFormattable
	{
        #region Private fields
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private uint _numerator = 1;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private uint _denominator = 1;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _negative = false; 
        #endregion

        #region Properties
        public uint Numerator
        {
            get { return _numerator; }
            set { _numerator = value; }
        }

        public uint Denominator
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
        public Fraction(uint numerator, uint denominator, bool isNegative = false)
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
            : this(Convert.ToUInt32(Math.Abs(numerator)), Convert.ToUInt32(Math.Abs(denominator)), numerator < 0) 
        {
           
        } 
        #endregion

		public void Reduce()
		{
			uint divisor = Utils.GreatestCommonDivisor(Numerator, Denominator);
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

        public object Clone()
        {
            return new Fraction(Numerator, Denominator, IsNegative);
        }

        public override String ToString()
        {
            return String.Format("{0}{1}/{2}", IsNegative ? "-" : "", Numerator, Denominator);
        }

		//TODO: write constructors/converters from/to float, double, Dermical, int, string representation
		//TODO: write basic operators: +, -, /, *
		//TODO: implement IFormattable interface

        #region Equality operations
        public override bool Equals(Object other)
        {
            if (other != null && other is Fraction) return this.Equals(other as Fraction);
            return false;
        }

        public bool Equals(Fraction other)
        {
            if (other == null) return false;
            if (IsNegative != other.IsNegative) return false;
            uint lcm = Utils.LeastCommonMultiple(Denominator, other.Denominator);
            return (Numerator * (lcm / Denominator)) == (other.Numerator * (lcm / other.Denominator));
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
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
                double valueThis = Numerator / (double)Denominator;
                double valueOther = other.Numerator / (double)other.Denominator;
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

            int lcm = (int)Utils.LeastCommonMultiple(left.Denominator, right.Denominator);
            return new Fraction(left.Numerator * (lcm / left.Denominator) * (left.IsNegative ? -1 : 1) + right.Numerator * (lcm / right.Denominator) * (right.IsNegative ? -1 : 1), lcm);
        }

        public static Fraction operator -(Fraction left, Fraction right)
        {
            if (left == null) throw new ArgumentNullException("left");
            if (right == null) throw new ArgumentNullException("right");

            int lcm = (int)Utils.LeastCommonMultiple(left.Denominator, right.Denominator);
            return new Fraction(left.Numerator * (lcm / left.Denominator) * (left.IsNegative ? -1 : 1) - right.Numerator * (lcm / right.Denominator) * (right.IsNegative ? -1 : 1), lcm);
        }

        public static Fraction operator *(Fraction left, Fraction right)
        {
            return new Fraction(left.Numerator * right.Numerator, left.Denominator * right.Denominator);
        }

        public static Fraction operator /(Fraction left, Fraction right)
        {
            return new Fraction(left.Numerator * right.Denominator, left.Denominator * right.Denominator);
        } 
        #endregion

		#region Conversions
		public bool ToBoolean(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public byte ToByte(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public char ToChar(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public DateTime ToDateTime(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public decimal ToDecimal(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public double ToDouble(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public short ToInt16(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public int ToInt32(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public long ToInt64(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public sbyte ToSByte(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public float ToSingle(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public string ToString(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public object ToType(Type conversionType, IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public ushort ToUInt16(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public uint ToUInt32(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public ulong ToUInt64(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public string Format(string format, object arg, IFormatProvider formatProvider)
		{
			throw new NotImplementedException();
		}

		public string ToString(string format, IFormatProvider formatProvider)
		{
			throw new NotImplementedException();
		}
		#endregion

        public TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

    }
}
