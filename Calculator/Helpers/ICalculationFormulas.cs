namespace Calculator.Helpers
{
    public interface ICalculationFormulas
    {
        string AddValues(double firstInput, double secondInput);

        string DivideValues(double firstInput, double secondInput);

        string MultiplyValues(double firstInput, double secondInput);

        string SubtractValues(double firstInput, double secondInput);

        string PercentageCalculate(double firstInput);

        string SquareRootCalculate(double firstInput);

        string PiCalculate();
    }
}
