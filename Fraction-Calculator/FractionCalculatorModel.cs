using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractionMath;

namespace Fraction_Calculator
{
	internal class FractionCalculatorModel : IFractionCalculatorModel
	{
		public Fraction Add(Fraction left, Fraction right)
		{
			Fraction result = null;
			try
			{
				result = left + right;
			}
			catch (Exception e)
			{
				throw new CalculationErrorException("Error when adding two fractions.", e);
			}
			return result;
		}

		public Fraction Subtract(Fraction left, Fraction right)
		{
			Fraction result = null;
			try
			{
				result = left - right;
			}
			catch (Exception e)
			{
				throw new CalculationErrorException("Error when subtracting two fractions.", e);
			}
			return result;
		}

		public Fraction Multiply(Fraction left, Fraction right)
		{
			Fraction result = null;
			try
			{
				result = left * right;
			}
			catch (Exception e)
			{
				throw new CalculationErrorException("Error when multiplying two fractions.", e);
			}
			return result;
		}

		public Fraction Divide(Fraction left, Fraction right)
		{
			Fraction result = null;
			try
			{
				result = left / right;
			}
			catch (Exception e)
			{
				if (e is DivideByZeroException) throw new CalculationErrorException("Error division by zero.", e);
				throw new CalculationErrorException("Error when dividing two fractions.", e);
			}
			return result;
		}
	}
}