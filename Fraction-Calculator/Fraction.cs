using System;

namespace FractionMath
{
	public class Fraction: IComparable<Fraction>
	{
		private uint _numerator = 1;
		private uint _denominator = 1;
		private bool _negative = false;

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

		public Fraction(uint numerator, uint denominator, bool isNegative = false)
		{
			if (denominator == 0)
			{
				throw new ArgumentOutOfRangeException("denominator", denominator, "Value mast be greater than 0");
			}
			_numerator = numerator;
			_denominator = denominator;
			_negative = isNegative;
		}

		public void Reduce()
		{
			uint divisor = Utils.GreatestCommonDivisor(Numerator, Denominator);
			Numerator /= divisor;
			Denominator /= divisor;
		}

		static public Fraction Reduce(Fraction bigFraction)
		{
			uint divisor = Utils.GreatestCommonDivisor(bigFraction.Numerator, bigFraction.Denominator);
			return new Fraction(bigFraction.Numerator / divisor, bigFraction.Denominator / divisor, bigFraction.IsNegative);
		}

		public Fraction Copy()
		{
			return new Fraction(Numerator, Denominator, IsNegative);
		}

		public int CompareTo(Fraction other)
		{
			if (Numerator == other.Numerator && Denominator == other.Denominator)
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

		//TODO: write constructors/converters from/to float, double, Dermical, int, string representation
		//TODO: write assignments operator
		//TODO: write basic operators: +, -, /, *
		//TODO: implement IFormattable interface

		/*
		public static Complex operator +(Complex c1, Complex c2)
		{
			return new Complex(c1.real + c2.real, c1.imaginary + c2.imaginary);
		}
		*/
	}
}
