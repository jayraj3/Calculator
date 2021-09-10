using System;
using System.Data;
using System.Text.RegularExpressions;

namespace Calculator.Core.Calculators
{
    public class ExpressionCalculator : ICalculators
    {
        public double Calculate(string expression)
        {
            // Check for computation sign in the begining
            Regex CheckBegining = new Regex(@"^[+-/*%]");
            if (CheckBegining.IsMatch(expression))
            {
                expression = expression.Remove(0, 1);
            }
            // Check for computation sign in th end
            Regex CheckEnding = new Regex(@"[+-/*%]$");
            if (CheckEnding.IsMatch(expression))
            {
                expression = expression.Remove(expression.Length-1, 1);
            }


            var dataTable = new DataTable();
            var value = dataTable.Compute(expression, "");
            return Convert.ToDouble(value);
        }
    }
}
