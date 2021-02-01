using System;
using System.Globalization;
using System.Windows.Forms;
using Calculator.Helpers;
using Calculator.Models;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        private CalculationEnum _calculationMethod;
        public ICalculationModel CalculationModel;
        public readonly ICalculationFormulas CalculationFormulas;
        public const string Error = "Error Occurred";
        public string Input = "";

        public CalculatorForm(ICalculationModel calculationModel, ICalculationFormulas calculationFormulas)
        {
            InitializeComponent();
            CalculationModel = calculationModel;
            CalculationFormulas = calculationFormulas;
        }

        private void Button_0_Click(object sender, EventArgs e)
        {
            Input = "0";
            Input_Box.Text += Input;
        }

        private void Button_1_Click(object sender, EventArgs e)
        {
            Input = "1";
            InputCheck(Input);
        }

        private void Button_2_Click(object sender, EventArgs e)
        {
            Input = "2";
            InputCheck(Input);
        }

        private void Button_3_Click(object sender, EventArgs e)
        {
            Input = "3";
            InputCheck(Input);
        }

        private void Button_4_Click(object sender, EventArgs e)
        {
            Input = "4";
            InputCheck(Input);
        }

        private void Button_5_Click(object sender, EventArgs e)
        {
            Input = "5";
            InputCheck(Input);
        }

        private void Button_6_Click(object sender, EventArgs e)
        {
            Input = "6";
            InputCheck(Input);
        }

        private void Button_7_Click(object sender, EventArgs e)
        {
            Input = "7";
            InputCheck(Input);
        }

        private void Button_8_Click(object sender, EventArgs e)
        {
            Input = "8";
            InputCheck(Input);
        }

        private void Button_9_Click(object sender, EventArgs e)
        {
            Input = "9";
            InputCheck(Input);
        }

        private void Button_Multiply_Click(object sender, EventArgs e)
        {
            if (double.TryParse(Input_Box.Text, out var number))
            {
                CalculationModel.FirstInput = number;
                Input_Box.Text = @"0";
                _calculationMethod = CalculationEnum.Multiply;
            }
            else
                Input_Box.Text = Error;
        }

        private void Button_Divide_Click(object sender, EventArgs e)
        {
            if (double.TryParse(Input_Box.Text, out var number))
            {
                CalculationModel.FirstInput = number;
                Input_Box.Text = @"0";
                _calculationMethod = CalculationEnum.Division;
            }
            else
                Input_Box.Text = Error;
        }

        private void Button_Minus_Click(object sender, EventArgs e)
        {
            if (double.TryParse(Input_Box.Text, out var number))
            {
                CalculationModel.FirstInput = number;
                Input_Box.Text = @"0";
                _calculationMethod = CalculationEnum.Subtract;
            }
            else
                Input_Box.Text = Error;
        }

        private void Button_Plus_Click(object sender, EventArgs e)
        {
            if (double.TryParse(Input_Box.Text, out var number))
            {
                CalculationModel.FirstInput = number;
                Input_Box.Text = @"0";
                _calculationMethod = CalculationEnum.Addition;
            }
            else
                Input_Box.Text = Error;
        }

        private void Button_CE_Click(object sender, EventArgs e)
        {
            //Removes last digit
            Input_Box.Text = string.IsNullOrWhiteSpace(Input_Box.Text) && Input_Box.Text.Length <=0 ? @"0" : Input_Box.Text.Remove(Input_Box.Text.Length - 1);
        }

        private void Button_C_Click(object sender, EventArgs e)
        {
            Input_Box.Text = @"0";
        }

        private void Button_Equal_Click(object sender, EventArgs e)
        {
            if (double.TryParse(Input_Box.Text, out var number))
                CalculationModel.SecondInput = number;
            else
                Input_Box.Text = Error;

            switch (_calculationMethod)
            {
                case CalculationEnum.Addition:
                    var addResult = CalculationFormulas.AddValues(CalculationModel.FirstInput,
                        CalculationModel.SecondInput);
                    Input_Box.Text = addResult;
                    CalculationModel.FirstInput = double.Parse(addResult, CultureInfo.InvariantCulture);
                    break;
                case CalculationEnum.Division:
                    if (Math.Abs(CalculationModel.SecondInput) <= 0)
                        Input_Box.Text = @"Cannot divide by zero";
                    else
                    {
                        var divideResult = CalculationFormulas.DivideValues(CalculationModel.FirstInput,
                            CalculationModel.SecondInput);
                        Input_Box.Text = divideResult;
                        CalculationModel.FirstInput = double.Parse(divideResult, CultureInfo.InvariantCulture);
                    }

                    break;
                case CalculationEnum.Multiply:
                    var multiplyResult = CalculationFormulas.MultiplyValues(CalculationModel.FirstInput,
                        CalculationModel.SecondInput);
                    Input_Box.Text = multiplyResult;
                    CalculationModel.FirstInput = double.Parse(multiplyResult, CultureInfo.InvariantCulture);
                    break;
                case CalculationEnum.Subtract:
                    var subtractResult = CalculationFormulas.SubtractValues(CalculationModel.FirstInput,
                        CalculationModel.SecondInput);
                    Input_Box.Text = subtractResult;
                    CalculationModel.FirstInput = double.Parse(subtractResult, CultureInfo.InvariantCulture);
                    break;
                default:
                    CalculationModel.FirstInput = number;
                    break;
            }
        }

        private void Button_Dot_Click(object sender, EventArgs e)
        {
            Input_Box.Text += @".";
        }

        private void Button_PosNeg_Click(object sender, EventArgs e)
        {
            if (Input_Box.Text.Contains("-"))
                Input_Box.Text = Input_Box.Text.Remove(0, 1);
            else
                Input_Box.Text = @"-" + Input_Box.Text;
        }

        private void Button_Percentage_Click(object sender, EventArgs e)
        {
            if (double.TryParse(Input_Box.Text, out var number))
            {
                CalculationModel.FirstInput = number;
                Input_Box.Text = @"0";
                var result = CalculationFormulas.PercentageCalculate(CalculationModel.FirstInput);
                Input_Box.Text = result;
            }
            else
                Input_Box.Text = Error;
        }

        private void Button_Square_Click(object sender, EventArgs e)
        {
            if (double.TryParse(Input_Box.Text, out var number))
            {
                var convertedValue = number;
                Input_Box.Text = @"0";
                var result = CalculationFormulas.SquareRootCalculate(convertedValue);
                Input_Box.Text = result;
            }
            else
                Input_Box.Text = Error;
        }

        private void Pi_Click(object sender, EventArgs e)
        {
            var result = CalculationFormulas.PiCalculate();
            Input_Box.Text = @"0";
            Input_Box.Text = result;
        }

        private void InputCheck(string input)
        {
            Input = input;

            if (Input_Box.Text == @"0" && Input_Box.Text != null)
                Input_Box.Text = Input;
            else
                Input_Box.Text += Input;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                    Button_0.PerformClick();
                    break;
                case Keys.NumPad1:
                    Button_1.PerformClick();
                    break;
                case Keys.NumPad2:
                    Button_2.PerformClick();
                    break;
                case Keys.NumPad3:
                    Button_3.PerformClick();
                    break;
                case Keys.NumPad4:
                    Button_4.PerformClick();
                    break;
                case Keys.NumPad5:
                    Button_5.PerformClick();
                    break;
                case Keys.NumPad6:
                    Button_6.PerformClick();
                    break;
                case Keys.NumPad7:
                    Button_7.PerformClick();
                    break;
                case Keys.NumPad8:
                    Button_8.PerformClick();
                    break;
                case Keys.NumPad9:
                    Button_9.PerformClick();
                    break;
                case Keys.Add:
                    Button_Plus.PerformClick();
                    break;
                case Keys.Divide:
                    Button_Divide.PerformClick();
                    break;
                case Keys.Multiply:
                    Button_Multiply.PerformClick();
                    break;
                case Keys.Subtract:
                    Button_Minus.PerformClick();
                    break;
                case Keys.Back:
                    Button_CE.PerformClick();
                    break;
                case Keys.Decimal:
                    Button_Dot.PerformClick();
                    break;
                case Keys.Enter:
                    Button_Equal.PerformClick();
                    break;
            }
        }
    }
}
