using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractionMath;

namespace Fraction_Calculator
{
	public enum FractionToStringFormatTypes
	{
		ToDecimal,
		ToFractional
	}

	[Serializable()]
	public class FormattingnErrorException : Exception
	{
		public FormattingnErrorException() : base() { }

		public FormattingnErrorException(string message) : base(message) { }

		public FormattingnErrorException(string message, Exception inner) : base(message, inner) { }

		protected FormattingnErrorException(System.Runtime.Serialization.SerializationInfo info,
											System.Runtime.Serialization.StreamingContext context) { }
	}


	public interface IFractionConverter
	{
		bool ValidateFractionString(string value);
		Fraction ConvertFractionFromString(string value);
		string ConvertStringFromFraction(Fraction value, FractionToStringFormatTypes format = FractionToStringFormatTypes.ToFractional);
		string LastFormatError { get; }
	}

	public interface IFractionConverterConstructor
	{
		IFractionConverter ConstructFractionConverter();
	}
}
