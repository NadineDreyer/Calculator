using System;
using System.Globalization;

namespace Calculator.Helpers
{
    public class CalculationFormulas :ICalculationFormulas
    {
        public string AddValues(double firstInput, double secondInput)
        {
            var result = firstInput + secondInput;
            return Convert.ToString(result, CultureInfo.InvariantCulture);
        }

        public string DivideValues(double firstInput, double secondInput)
        {
            var result = firstInput / secondInput;
            return Convert.ToString(result, CultureInfo.InvariantCulture);
        }

        public string MultiplyValues(double firstInput, double secondInput)
        {
            var result = firstInput * secondInput;
            return Convert.ToString(result, CultureInfo.InvariantCulture);
        }

        public string SubtractValues(double firstInput, double secondInput)
        {
            var result = firstInput - secondInput;
            return Convert.ToString(result, CultureInfo.InvariantCulture);
        }

        public string PercentageCalculate(double firstInput)
        {
            var result = firstInput / 100;
            return Convert.ToString(result, CultureInfo.InvariantCulture);
        }

        public string SquareRootCalculate(double firstInput)
        {
            var result = Math.Sqrt(firstInput);
            return Convert.ToString(result, CultureInfo.InvariantCulture);
        }

        public string PiCalculate()
        {
            const double result = Math.PI;
            return Convert.ToString(result, CultureInfo.InvariantCulture);
        }
    }
}
