using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fraction_Calculator;

namespace Fraction_Calculator
{
	public partial class FractionCalculatorView : Form, IFractionCalculatorView
	{
		public FractionCalculatorView()
		{
			InitializeComponent();
		}

		private void btnPlus_Click(object sender, EventArgs e)
		{
			buttonClicked(ButtonsTypes.Plus);
		}

		private void btnMinus_Click(object sender, EventArgs e)
		{
			buttonClicked(ButtonsTypes.Minus);
		}

		private void btnMuliply_Click(object sender, EventArgs e)
		{
			buttonClicked(ButtonsTypes.Multiply);
		}

		private void btnDivide_Click(object sender, EventArgs e)
		{
			buttonClicked(ButtonsTypes.Deivide);
		}

		public string LeftOperand
		{
			get { return textBox1.Text; }
		}

		public string RightOperand
		{
			get { return textBox2.Text; }
		}

		public string Result
		{
			set { textBox3.Text = value; }
		}

		public string ErrorMessage
		{
			set 
			{
				string onLineMessage = value.Replace('\r', '.').Replace('\n', ' ');
				toolStripStatusLabel1.Text = onLineMessage;
			}
		}

		public event ButtonClicked buttonClicked;

		public ResultFormatTypes ResultFormat
		{
			get { return (checkBox1.Checked) ? ResultFormatTypes.Decimal : ResultFormatTypes.Fractional; }
		}
	}
}