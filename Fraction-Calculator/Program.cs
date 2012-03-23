using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FractionMath;

namespace Fraction_Calculator
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var view = new FractionCalculatorView();
			var model = new FractionCalculatorModel();
			var formatFabric = new FractionConverterConstructor();

			var controller = new FractionCalculatorController(model, view, formatFabric);

			Application.Run(view);
		}
	}
}
