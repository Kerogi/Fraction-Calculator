using System;

public class Fraction
{
    private int _numerator = 1;
    private int _denominator = 1;
    private bool _negative = false;

    public int Numerator
    {
        get { return _numerator; }
        set { _numerator = value; }
    }

    public int Denominator
    {
        get { return _denominator; }
        set {
                if (value == 0) 
                {
                    throw new ArgumentOutOfRangeException("value", value.ToString(), "Value must be non-zero integer");
                }
                _denominator = value; 
            }
    }

    public bool IsNegative
    {
        get { return _negative; }
        set { _negative = value; }
    }

	public Fraction(int num, int den)
	{
        if(num
        if (den == 0)
        {
            throw new ArgumentOutOfRangeException("value", value.ToString(), "Value mast be greater than 0");
        }
	}
}
