using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Core.Calculators
{
    public interface ICalculators
    {
        double Calculate(string expression);
    }
    internal interface IRestCall
    {
        string ConvertCurrency(string fromCurrency, string toCurrency, double value);
    }
}
