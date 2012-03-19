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
