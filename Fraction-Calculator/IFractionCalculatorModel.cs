using System;
using FractionMath;

namespace Fraction_Calculator
{
	[Serializable()]
	public class CalculationErrorException : Exception
	{
		public CalculationErrorException() : base()
		{
		}

		public CalculationErrorException(string message) : base(message)
		{
		}

		public CalculationErrorException(string message, Exception inner) : base(message, inner)
		{
		}

		protected CalculationErrorException(System.Runtime.Serialization.SerializationInfo info,
		                                    System.Runtime.Serialization.StreamingContext context)
		{
		}
	}


	public interface IFractionCalculatorModel
	{
		Fraction Add(Fraction left, Fraction right);

		Fraction Subtract(Fraction left, Fraction right);

		Fraction Multiply(Fraction left, Fraction right);

		Fraction Divide(Fraction left, Fraction right);
	}
}