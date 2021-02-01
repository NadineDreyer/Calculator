namespace Calculator.Models
{
    public interface ICalculationModel
    {
        /// <summary>
        /// The first input from the user
        /// </summary>
         double FirstInput { get; set; }

        /// <summary>
        /// The second input from the user
        /// </summary>
         double SecondInput { get; set; }
    }
}
