using System;
using System.Collections.Generic;
using FractionMath;

namespace Fraction_Calculator
{
	public class FractionConverter : IFractionConverter
	{
		private List<string> _lastEormatErrorsLog = new List<string>();

		public string LastFormatError
		{
			get
			{
				if (_lastEormatErrorsLog.Count > 0)
					return _lastEormatErrorsLog[0]; //From first exception
				return "";
			}
		}

		private void AddErrorToLog(string message)
		{
			char[] lineBreaks = {'\n'};
			foreach(var line in message.Split(lineBreaks,StringSplitOptions.RemoveEmptyEntries))
			{
				_lastEormatErrorsLog.Add(line);
			}
		}

		private void ClearErrorLog()
		{
			_lastEormatErrorsLog.Clear();
		}

		public bool ValidateFractionString(string value)
		{
			ClearErrorLog();
			if (value.Length == 0)
			{
				AddErrorToLog("String is empty");
				return false;
			}
			try
			{
				if (Fraction.Parse(value) != null)
				{
					AddErrorToLog("WTF! Parse returned 'null' value!");
					return true;
				}
				return false;
			}
			catch(Exception e)
			{
				AddErrorToLog(e.Message);

				while(e.InnerException != null)
				{
					e = e.InnerException;
					AddErrorToLog(e.Message);
				}
				return false;
			}
		}


		public Fraction ConvertFractionFromString(string value)
		{
			if (value.Length == 0)
			{
				//AddErrorToLog("String value is empty");
				throw new FormattingnErrorException("String value is empty");
			}
			try
			{
				Fraction fraction = Fraction.Parse(value);
				return fraction;
			}
			catch (Exception e)
			{
				//AddErrorToLog("Error while convert" + e.Message);
				throw new FormattingnErrorException("Error while convert", e);
			}
		}

		public string ConvertStringFromFraction(Fraction value, FractionToStringFormatTypes format = FractionToStringFormatTypes.ToFractional)
		{
			switch (format)
			{
				case FractionToStringFormatTypes.ToDecimal:
					return value.ToDecimal(null).ToString();
					
				case FractionToStringFormatTypes.ToFractional:
					return value.ToString();
					
				default:
					throw new FormattingnErrorException("Unknown format");
			}
		}

	}

	public class FractionConverterConstructor : IFractionConverterConstructor
	{
		public IFractionConverter ConstructFractionConverter()
		{
			return new FractionConverter();
		}
	}
	
}