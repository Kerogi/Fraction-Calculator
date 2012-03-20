using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FractionMath;

namespace Fraction_Calculator
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		public void PrintError(string message)
		{
			toolStripStatusLabel1.Text = message;
		}

		public void ClearError()
		{
			toolStripStatusLabel1.Text = "";
		}

		private bool ValidateField(string fieldName, string fieldValue, out Fraction validatedValue)
		{
			validatedValue = null;
			if (fieldValue.Length == 0) 
			{
				PrintError(fieldName+": field is empty");
				return false;
			}
			try
			{
				Fraction fraction = Fraction.Parse(fieldValue);
				validatedValue = fraction;
				return true;
			}
			catch (Exception e)
			{
				PrintError(fieldName+": "+e.Message);
				return false;
			}
		}

		private string FormatResult(Fraction result)
		{
			if (checkBox1.Checked || result.Denominator == 1)
			{
				return result.ToDecimal(null).ToString("G30");
			}
			else
			{
				return result.ToString(null);
			}
		}

		private void btnPlus_Click(object sender, EventArgs e)
		{
			ClearError();
			Fraction a = null;
			Fraction b = null;
			if (ValidateField("First field", textBox1.Text, out a) 
				&& ValidateField("Second field", textBox2.Text, out b))
			{
				try
				{
					textBox3.Text = FormatResult(a + b);
				}
				catch (Exception expt)
				{
					PrintError(expt.Message);
				}
			}
		}

		private void btnMinus_Click(object sender, EventArgs e)
		{
			ClearError();
			Fraction a = null;
			Fraction b = null;
			if (ValidateField("First field", textBox1.Text, out a)
				&& ValidateField("Second field", textBox2.Text, out b))
			{
				try
				{
					textBox3.Text = FormatResult(a - b);
				}
				catch (Exception expt)
				{
					PrintError(expt.Message);
				}
			}
		}

		private void btnMuliply_Click(object sender, EventArgs e)
		{
			ClearError();
			Fraction a = null;
			Fraction b = null;
			if (ValidateField("First field", textBox1.Text, out a)
				&& ValidateField("Second field", textBox2.Text, out b))
			{
				try
				{
					textBox3.Text = FormatResult(a * b);
				}
				catch (Exception expt)
				{
					PrintError(expt.Message);
				}
			}
		}

		private void btnDivide_Click(object sender, EventArgs e)
		{
			ClearError();
			Fraction a = null;
			Fraction b = null;
			if (ValidateField("First field", textBox1.Text, out a)
				&& ValidateField("Second field", textBox2.Text, out b))
			{
				try
				{
					textBox3.Text = FormatResult(a / b);
				}
				catch (Exception expt)
				{
					PrintError(expt.Message);
				}
			}
		}
	}
}
