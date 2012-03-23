using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fraction_Calculator
{
	public enum ResultFormatTypes { Fractional, Decimal };

	public enum ButtonsTypes { Plus, Minus, Multiply, Deivide };

	public delegate void ButtonClicked(ButtonsTypes button);

	public interface IFractionCalculatorView
	{
		String LeftOperand { get; }

		String RightOperand { get; }

		String Result { set; }

		ResultFormatTypes ResultFormat { get; }

		String ErrorMessage { set; }

		event ButtonClicked buttonClicked;
	}
}