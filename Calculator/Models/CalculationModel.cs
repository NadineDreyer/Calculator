namespace Calculator.Models
{
    public class CalculationModel
    {
        /// <summary>
        /// The first input from the user
        /// </summary>
        public double FirstInput { get; set; } = 0;

        /// <summary>
        /// The second input from the user
        /// </summary>
        public double SecondInput { get; set; } = 0;

        /// <summary>
        /// The result of input one and two depending on the calculation method
        /// </summary>
        public double ResultValue { get; set; } = 0;
    }
}
