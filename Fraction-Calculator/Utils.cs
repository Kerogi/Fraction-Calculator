using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FractionMath
{
	public class Utils
	{
		static public ulong GreatestCommonDivisor(ulong a, ulong b)
		{
			while (a != 0 && b != 0)
			{
				if (a > b)
					a %= b;
				else
					b %= a;
			}

			if (a == 0)
				return b;
			else
				return a;
		}

		static public ulong LeastCommonMultiple(ulong a, ulong b)
		{
			return (ulong) Math.Abs((decimal)a * b) / GreatestCommonDivisor(a, b);
		}

		public static int GetFractionalDigits(Decimal number)
		{
			return (Decimal.GetBits(number)[3] >> 16) & 0x7fff;
		}

		public static int GetFractionalDigits(double number)
		{
			return GetFractionalDigits(Convert.ToDecimal(number));
		}

		public static int GetSignificantDigitCount(decimal value)
		{
			int[] bits = decimal.GetBits(value);

			if (value >= 1M || value <= -1M)
			{
				int highPart = bits[2];
				int middlePart = bits[1];
				int lowPart = bits[0];

				decimal num = new decimal(lowPart, middlePart, highPart, false, 0);

				int exponent = (int)Math.Ceiling(Math.Log10((double)num));

				return exponent;
			}
			else
			{
				int scalePart = bits[3];
				int exponent = (scalePart & 0x00FF0000) >> 16;

				return exponent + 1;
			}
		}

		/* deprecated
		public static int GetFractionalDigits(double number)
		{
			double denominator = 1;
			int numbersAfterDot = 0;
			for (numbersAfterDot = 0; numbersAfterDot < 29; numbersAfterDot++)
			{
				double remainder = (number*denominator) % denominator;
				double fractionPartOfReminder = remainder - Math.Floor(remainder);
				if (fractionPartOfReminder <= double.Epsilon)
				{
				   break;
				}
				denominator *= 10.0; // power in i ==> deniminator^i
			}
			return numbersAfterDot;
		}
		*/
	}
}
