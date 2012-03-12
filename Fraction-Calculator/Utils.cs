using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FractionMath
{
	public class Utils
	{
		static public uint GreatestCommonDivisor(uint a, uint b)
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

		static public uint LeastCommonMultiple(uint a, uint b)
		{
			return (uint) Math.Abs(a * b) / GreatestCommonDivisor(a, b);
		}
	}
}
