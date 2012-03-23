using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractionMath;

namespace Fraction_Calculator
{
	public class FractionCalculatorController
	{
		public delegate Fraction MathOperation(Fraction leftOperand, Fraction rightOperand);

		private IFractionCalculatorModel _model;
		private IFractionCalculatorView _view;
		private IFractionConverter _converterLeft;
		private IFractionConverter _converterRight;
		private IFractionConverter _converterResult;


		public FractionCalculatorController(IFractionCalculatorModel model, IFractionCalculatorView view,
		                                    IFractionConverterConstructor converterConstructor)
		{
			_model = model;
			_view = view;
			_view.buttonClicked += new ButtonClicked(ViewButtonClicked);

			_converterLeft = converterConstructor.ConstructFractionConverter();
			_converterRight = converterConstructor.ConstructFractionConverter();
			_converterResult = converterConstructor.ConstructFractionConverter();
		}

		private void ViewButtonClicked(ButtonsTypes button)
		{
			switch (button)
			{
				case ButtonsTypes.Plus:
					{
						PerfomMathOperation(_model.Add, _view.LeftOperand, _view.RightOperand);
					}
					break;
				case ButtonsTypes.Minus:
					{
						PerfomMathOperation(_model.Subtract, _view.LeftOperand, _view.RightOperand);
					}
					break;
				case ButtonsTypes.Multiply:
					{
						PerfomMathOperation(_model.Multiply, _view.LeftOperand, _view.RightOperand);
					}
					break;
				case ButtonsTypes.Deivide:
					{
						PerfomMathOperation(_model.Divide, _view.LeftOperand, _view.RightOperand);
					}
					break;
				default:
					throw new ArgumentOutOfRangeException("button");
			}
		}

		private void PerfomMathOperation(MathOperation operation, String leftOperand, String rightOperation)
		{
			_view.ErrorMessage = "";
			_view.Result = "";
			try
			{
				if (!_converterLeft.ValidateFractionString(leftOperand))
				{
					_view.ErrorMessage = "First field: " + _converterLeft.LastFormatError;
					return;
				}
				if (!_converterRight.ValidateFractionString(rightOperation))
				{
					_view.ErrorMessage = "Second field: " + _converterRight.LastFormatError;
					return;
				}

				Fraction leftFraction = _converterLeft.ConvertFractionFromString(leftOperand);
				Fraction rightFraction = _converterLeft.ConvertFractionFromString(rightOperation);

				Fraction resultFraction = operation(leftFraction, rightFraction);

				switch (_view.ResultFormat)
				{
					case ResultFormatTypes.Fractional:
						_view.Result = _converterResult.ConvertStringFromFraction(resultFraction, FractionToStringFormatTypes.ToFractional);
						break;
					case ResultFormatTypes.Decimal:
						_view.Result = _converterResult.ConvertStringFromFraction(resultFraction, FractionToStringFormatTypes.ToDecimal);
						break;
				}
			}
			catch (Exception e)
			{
				_view.ErrorMessage = e.Message;
			}
		}
	}
}