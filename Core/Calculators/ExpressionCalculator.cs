using System;
using System.Data;


namespace Calculator.Core.Calculators
{
    public class ExpressionCalculator : ICalculators
    {
        public double Calculate(string expression)
        {
            var dataTable = new DataTable();
            var value = dataTable.Compute(expression, "");
            return Convert.ToDouble(value);
        }
    }
}
