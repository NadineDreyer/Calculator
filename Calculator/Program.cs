using System;
using System.Windows.Forms;
using Calculator.Helpers;
using Calculator.Models;

namespace Calculator
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalculatorForm(new CalculationModel(), new CalculationFormulas()));
        }
    }
}
