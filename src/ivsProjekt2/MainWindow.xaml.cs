using MathLib;
using System;
using System.Windows;
using System.Windows.Input;

namespace ivsProjekt2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Vars to store numbers
        double firstNum;
        double secondNum;
        double outNum;
        
        bool computed;      // Used to check if a number should add or overwrite
        bool equated;       // Used to check if the values should be cleared or not
        Operations lastOp;  // Used for working logic

        enum Operations
        {
            addition,
            subtractition,
            multiplication,
            division,
            factorial,
            power,
            root,
            equals
        }

        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown); // So I can capture keyboard presses
        }

        /// =========
        /// 
        /// IO and logic
        /// 
        /// =========


        /// --------------
        /// Function logic
        /// --------------

        /// <summary>
        /// Logic for CE button.
        /// </summary>
        /// Clears current number textbox
        private void CE_logic()
        {
            OutputCurrentNumber.Text = String.Empty;
        }

        /// <summary>
        /// Logic for C button
        /// </summary>
        /// Clears both textboxes + stored vals
        private void C_logic()
        {
            OutputCurrentEquation.Text = String.Empty;
            OutputCurrentNumber.Text = String.Empty;
            firstNum = 0;
            secondNum = 0;
        }

        /// <summary>
        /// Logic for Back button
        /// </summary>
        /// Removes last char from OutputCurrentNumber textbox
        private void back_logic()
        {
            OutputCurrentNumber.Text = OutputCurrentNumber.Text.Remove(OutputCurrentNumber.Text.Length - 1);
        }

        /// <summary>
        /// Logic for Func button
        /// </summary>
        /// Computes func
        private void func_logic()
        {
            /// TODO: Add func_logic()
        }

        /// <summary>
        /// Logic for Root button
        /// </summary>
        /// Needs two numbers
        private void root_logic()
        {
            /// TODO: add root_logic()
        }

        /// <summary>
        /// Logic for Pow button
        /// </summary>
        /// Takes two numbers, first is the base, second is exponent
        private void pow_logic()
        {
            if (String.IsNullOrEmpty(OutputCurrentNumber.Text)
                || OutputCurrentNumber.Text == "inf"
                || computed)
            {
                return;
            }

            secondNum = Double.Parse(OutputCurrentNumber.Text);

            if (firstNum == 0)
            {
                firstNum = secondNum;
                OutputCurrentEquation.Text = secondNum.ToString() + "^";
                OutputCurrentNumber.Text = String.Empty;
            }
            else
            {
                compute_last();
                OutputCurrentEquation.Text = outNum.ToString() + "^";
                OutputCurrentNumber.Text = outNum.ToString();
            }

            lastOp = Operations.power;
        }

        /// <summary>
        /// Logic for Plus button
        /// </summary>
        /// If there is zero stored in first num it replaces
        /// If there is value stored, computes latest equation and adds itself
        private void factorial_logic()
        {
            if (String.IsNullOrEmpty(OutputCurrentNumber.Text)
                || OutputCurrentNumber.Text == "inf"
                || computed)
            {
                return;
            }

            secondNum = Double.Parse(OutputCurrentNumber.Text);

            
            compute_last();
            OutputCurrentEquation.Text = outNum.ToString() + "!";
            OutputCurrentNumber.Text = MathFuncs.Factorial(outNum).ToString();
            
        }

        /// <summary>
        /// Logic for Plus button
        /// </summary>
        /// If there is zero stored in first num it replaces
        /// If there is value stored, computes latest equation and adds itself
        private void plus_logic()
        {
            if (String.IsNullOrEmpty(OutputCurrentNumber.Text)
                || OutputCurrentNumber.Text == "inf"
                || computed)
            {
                return;
            }

            secondNum = Double.Parse(OutputCurrentNumber.Text);

            if (firstNum == 0)
            {
                firstNum = secondNum;
                OutputCurrentEquation.Text = secondNum.ToString() + " +";
                OutputCurrentNumber.Text = String.Empty;
            }
            else
            {
                compute_last();
                OutputCurrentEquation.Text = outNum.ToString() + " +";
                OutputCurrentNumber.Text = outNum.ToString();
            }

            lastOp = Operations.addition;
        }

        /// <summary>
        /// Logic for Minus button
        /// </summary>
        /// If there is zero stored in first num it replaces
        /// If there is value stored, computes latest equation and adds itself
        private void minus_logic()
        {
            if (String.IsNullOrEmpty(OutputCurrentNumber.Text)
                || OutputCurrentNumber.Text == "inf"
                || computed)
            {
                return;
            }

            secondNum = Double.Parse(OutputCurrentNumber.Text);

            if (firstNum == 0)
            {
                firstNum = secondNum;
                OutputCurrentEquation.Text = secondNum.ToString() + " -";
                OutputCurrentNumber.Text = String.Empty;
            }
            else
            {
                compute_last();
                OutputCurrentEquation.Text = outNum.ToString() + " -";
                OutputCurrentNumber.Text = outNum.ToString();
            }

            lastOp = Operations.subtractition;
        }

        /// <summary>
        /// Logic for Multiply button
        /// </summary>
        /// If there is zero stored in first num it replaces
        /// If there is value stored, computes latest equation and adds itself
        private void multiply_logic()
        {
            if (String.IsNullOrEmpty(OutputCurrentNumber.Text)
                || OutputCurrentNumber.Text == "inf"
                || computed)
            {
                return;
            }

            secondNum = Double.Parse(OutputCurrentNumber.Text);

            if (firstNum == 0)
            {
                firstNum = secondNum;
                OutputCurrentEquation.Text = secondNum.ToString() + " *";
                OutputCurrentNumber.Text = String.Empty;
            }
            else
            {
                compute_last();
                OutputCurrentEquation.Text = outNum.ToString() + " *";
                OutputCurrentNumber.Text = outNum.ToString();
            }

            lastOp = Operations.multiplication;
        }
        
        /// <summary>
        /// Logic for Division button
        /// </summary>
        /// If there is zero stored in first num it replaces
        /// If there is value stored, computes latest equation and adds itself
        /// Changes OutputCurrentNumber if division by zero is attempted
        private void division_logic()
        {
            if (String.IsNullOrEmpty(OutputCurrentNumber.Text)
                || OutputCurrentNumber.Text == "inf"
                || computed)
            {
                return;
            }

            secondNum = Double.Parse(OutputCurrentNumber.Text);

            if (secondNum == 0)
            {
                OutputCurrentNumber.Text = "Cannot divide";
                computed = true;
                return;
            }

            if (firstNum == 0)
            {
                firstNum = secondNum;
                OutputCurrentEquation.Text = secondNum.ToString() + " /";
                OutputCurrentNumber.Text = String.Empty;
            }
            else
            {
                compute_last();
                OutputCurrentEquation.Text = outNum.ToString() + " /";
                OutputCurrentNumber.Text = outNum.ToString();
            }
            lastOp = Operations.division;
        }

        /// <summary>
        /// Logic for Plusminus button
        /// </summary>
        /// Parses the current number, multiplies by -1 then rewrites OutputCurrentNumber
        private void plusminus_logic()
        {
            if (String.IsNullOrEmpty(OutputCurrentNumber.Text)
                || OutputCurrentNumber.Text == "inf"
                || computed)
            {
                return;
            }

            OutputCurrentNumber.Text = (Double.Parse(OutputCurrentNumber.Text) * -1).ToString();
        }

        /// <summary>
        /// Logic for Dot button
        /// </summary>
        /// If there is decimal sign present, does nothing
        /// If there is not, it adds it to the next position
        private void dot_logic()
        {
            if (String.IsNullOrEmpty(OutputCurrentNumber.Text)
                || OutputCurrentNumber.Text == "inf"
                || computed)
            {
                return;
            }
            if (OutputCurrentNumber.Text[OutputCurrentNumber.Text.Length - 1] != ',')
            {
                OutputCurrentNumber.Text += ",";
            }
        }
        /// <summary>
        /// Logic for Equals button
        /// </summary>
        /// Computes latest
        /// Sets flags computed and equated for correct logic
        private void equals_logic()
        {
            if (String.IsNullOrEmpty(OutputCurrentNumber.Text)
                || OutputCurrentNumber.Text == "inf")
            {
                return;
            }

            if (!computed)
            {
                secondNum = Double.Parse(OutputCurrentNumber.Text);
            }

            switch (lastOp)
            {
                case Operations.addition:
                    OutputCurrentEquation.Text = firstNum.ToString() + " + " + secondNum.ToString() + " =";
                    outNum = MathFuncs.Addition(firstNum, secondNum);
                    break;

                case Operations.subtractition:
                    OutputCurrentEquation.Text = firstNum.ToString() + " - " + secondNum.ToString() + " =";
                    outNum = MathFuncs.Subtraction(firstNum, secondNum);
                    break;

                case Operations.multiplication:
                    OutputCurrentEquation.Text = firstNum.ToString() + " * " + secondNum.ToString() + " =";
                    outNum = MathFuncs.Multiplication(firstNum, secondNum);
                    break;

                case Operations.division:
                    if (secondNum == 0)
                    {
                        OutputCurrentNumber.Text = "Cannot divide";
                        computed = true;
                        equated = true;
                        return;
                    }
                    OutputCurrentEquation.Text = firstNum.ToString() + " / " + secondNum.ToString() + " =";
                    outNum = MathFuncs.Division(firstNum, secondNum);
                    break;
                case Operations.power:
                    OutputCurrentEquation.Text = firstNum.ToString() + "^" + secondNum.ToString() + " =";
                    outNum = MathFuncs.Exponent(firstNum, secondNum);
                    break;

            }

            firstNum = outNum;
            OutputCurrentNumber.Text = outNum.ToString();
            lastOp = Operations.equals;
            computed = true;
            equated = true;
        }

        /// ------------
        /// number logic
        /// ------------

        /// <summary>
        /// Logic for One button
        /// </summary>
        /// Appends 1 to OutputCurrentNumber
        /// If OutputCurrentNumber is zero, it overwrites it with 1 instead
        private void one_logic()
        {
            check_number();

            if (OutputCurrentNumber.Text == "0")
            {
                OutputCurrentNumber.Text = "1";
                return;
            }

            OutputCurrentNumber.Text += "1";
        }

        /// <summary>
        /// Logic for Two button
        /// </summary>
        /// Appends 2 to OutputCurrentNumber
        /// If OutputCurrentNumber is zero, it overwrites it with 2 instead
        private void two_logic()
        {
            check_number();

            if (OutputCurrentNumber.Text == "0")
            {
                OutputCurrentNumber.Text = "2";
                return;
            }

            OutputCurrentNumber.Text += "2";
        }

        /// <summary>
        /// Logic for Three button
        /// </summary>
        /// Appends 3 to OutputCurrentNumber
        /// If OutputCurrentNumber is zero, it overwrites it with 3 instead
        private void three_logic()
        {
            check_number();

            if (OutputCurrentNumber.Text == "0")
            {
                OutputCurrentNumber.Text = "3";
                return;
            }

            OutputCurrentNumber.Text += "3";
        }

        /// <summary>
        /// Logic for Four button
        /// </summary>
        /// Appends 4 to OutputCurrentNumber
        /// If OutputCurrentNumber is zero, it overwrites it with 4 instead
        private void four_logic()
        {
            check_number();

            if (OutputCurrentNumber.Text == "0")
            {
                OutputCurrentNumber.Text = "4";
                return;
            }

            OutputCurrentNumber.Text += "4";
        }
        
        /// <summary>
        /// Logic for Five button
        /// </summary>
        /// Appends 5 to OutputCurrentNumber
        /// If OutputCurrentNumber is zero, it overwrites it with 5 instead
        private void five_logic()
        {
            check_number();

            if (OutputCurrentNumber.Text == "0")
            {
                OutputCurrentNumber.Text = "5";
                return;
            }

            OutputCurrentNumber.Text += "5";
        }

        /// <summary>
        /// Logic for Six button
        /// </summary>
        /// Appends 6 to OutputCurrentNumber
        /// If OutputCurrentNumber is zero, it overwrites it with 6 instead
        private void six_logic()
        {
            check_number();

            if (OutputCurrentNumber.Text == "0")
            {
                OutputCurrentNumber.Text = "6";
                return;
            }

            OutputCurrentNumber.Text += "6";
        }

        /// <summary>
        /// Logic for Seven button
        /// </summary>
        /// Appends 7 to OutputCurrentNumber
        /// If OutputCurrentNumber is zero, it overwrites it with 7 instead
        private void seven_logic()
        {
            check_number();

            if (OutputCurrentNumber.Text == "0")
            {
                OutputCurrentNumber.Text = "7";
                return;
            }

            OutputCurrentNumber.Text += "7";
        }

        /// <summary>
        /// Logic for Eight button
        /// </summary>
        /// Appends 8 to OutputCurrentNumber
        /// If OutputCurrentNumber is zero, it overwrites it with 8 instead
        private void eight_logic()
        {
            check_number();

            if (OutputCurrentNumber.Text == "0")
            {
                OutputCurrentNumber.Text = "8";
                return;
            }

            OutputCurrentNumber.Text += "8";
        }

        /// <summary>
        /// Logic for Nine button
        /// </summary>
        /// Appends 9 to OutputCurrentNumber
        /// If OutputCurrentNumber is zero, it overwrites it with 9 instead
        private void nine_logic()
        {
            check_number();

            if (OutputCurrentNumber.Text == "0")
            {
                OutputCurrentNumber.Text = "9";
                return;
            }

            OutputCurrentNumber.Text += "9";
        }

        /// <summary>
        /// Logic for Zero button
        /// </summary>
        /// Appends 0 to OutputCurrentNumber
        /// If OutputCurrentNumber is zero, does nothing
        private void zero_logic()
        {
            check_number();

            if (OutputCurrentNumber.Text == "0")
            {
                return;
            }

            OutputCurrentNumber.Text += "0";
        }

        /// =============
        /// 
        /// Function keys handle
        /// 
        /// =============

        private void CE_button_Click(object sender, RoutedEventArgs e)
        {
            CE_logic();
        }

        private void C_button_Click(object sender, RoutedEventArgs e)
        {
            C_logic();
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            back_logic();
        }

        private void func_button_Click(object sender, RoutedEventArgs e)
        {
            func_logic();
        }

        private void root_button_Click(object sender, RoutedEventArgs e)
        {
            root_logic();
        }

        private void pow_button_Click(object sender, RoutedEventArgs e)
        {
            pow_logic();
        }

        private void factorial_button_Click(object sender, RoutedEventArgs e)
        {
            factorial_logic();
        }

        private void plus_button_Click(object sender, RoutedEventArgs e)
        {
            plus_logic();
        }

        private void minus_button_Click(object sender, RoutedEventArgs e)
        {
            minus_logic();
        }

        private void multiply_button_Click(object sender, RoutedEventArgs e)
        {
            multiply_logic();
        }

        private void division_button_Click(object sender, RoutedEventArgs e)
        {
            division_logic();
        }

        private void plusminus_button_Click(object sender, RoutedEventArgs e)
        {
            plusminus_logic();
        }

        private void dot_button_Click(object sender, RoutedEventArgs e)
        {
            dot_logic();
        }

        private void equals_button_Click(object sender, RoutedEventArgs e)
        {
            equals_logic();
        }

        /// ===========
        /// 
        /// Number keys handle
        /// 
        /// ===========

        private void one_button_Click(object sender, RoutedEventArgs e)
        {
            one_logic();
        }

        private void two_button_Click(object sender, RoutedEventArgs e)
        {
            two_logic();
        }

        private void three_button_Click(object sender, RoutedEventArgs e)
        {
            three_logic();
        }

        private void four_button_Click(object sender, RoutedEventArgs e)
        {
            four_logic();
        }

        private void five_button_Click(object sender, RoutedEventArgs e)
        {
            five_logic();
        }

        private void six_button_Click(object sender, RoutedEventArgs e)
        {
            six_logic();
        }

        private void seven_button_Click(object sender, RoutedEventArgs e)
        {
            seven_logic();
        }

        private void eight_button_Click(object sender, RoutedEventArgs e)
        {
            eight_logic();
        }

        private void nine_button_Click(object sender, RoutedEventArgs e)
        {
            nine_logic();
        }

        private void zero_button_Click(object sender, RoutedEventArgs e)
        {
            zero_logic();
        }

        /// =========
        /// 
        /// Keyboard handle
        /// 
        /// =========

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.NumPad1 || e.Key == Key.D1)
            {
                one_logic();
            }

            if (e.Key == Key.NumPad2 || e.Key == Key.D2)
            {
                two_logic();
            }

            if (e.Key == Key.NumPad3 || e.Key == Key.D3)
            {
                three_logic();
            }

            if (e.Key == Key.NumPad4 || e.Key == Key.D4)
            {
                four_logic();
            }

            if (e.Key == Key.NumPad5 || e.Key == Key.D5)
            {
                five_logic();
            }

            if (e.Key == Key.NumPad6 || e.Key == Key.D6)
            {
                six_logic();
            }

            if (e.Key == Key.NumPad7 || e.Key == Key.D7)
            {
                seven_logic();
            }

            if (e.Key == Key.NumPad8 || e.Key == Key.D8)
            {
                eight_logic();
            }

            if (e.Key == Key.NumPad9 || e.Key == Key.D9)
            {
                nine_logic();
            }

            if (e.Key == Key.NumPad0 || e.Key == Key.NumPad0)
            {
                zero_logic();
            }

            if (e.Key == Key.Add)
            {
                plus_logic();
            }

            if (e.Key == Key.Subtract)
            {
                minus_logic();
            }

            if (e.Key == Key.Multiply)
            {
                multiply_logic();
            }

            if (e.Key == Key.Divide)
            {
                division_logic();
            }

            if (e.Key == Key.Enter)
            {
                equals_logic();
            }

            if (e.Key == Key.Back)
            {
                back_logic();
            }

            if (e.Key == Key.Delete)
            {
                C_logic();
            }

            if (e.Key == Key.Decimal)
            {
                dot_logic();
            }
        }
        /// ======
        /// 
        /// Helper
        /// 
        /// ======

        /// <summary>
        /// Clears text boxes if needed
        /// </summary>
        /// If computed flag is true, clears OutputCurrentNumber, sets computed false
        /// If equated flag is true, clears both text boxes and sets firsNum to 0, sets equated false
        private void check_number()
        {
            if (computed)
            {
                OutputCurrentNumber.Text = String.Empty;
                computed = false;
            }

            if (equated)
            {
                OutputCurrentNumber.Text = String.Empty;
                OutputCurrentEquation.Text = String.Empty;
                firstNum = 0;
                equated = false;
            }
        }

        /// <summary>
        /// Computes latest input
        /// </summary>
        /// Based on lastOp computes latest "equation"
        private void compute_last()
        {
            computed = true;
            switch (lastOp)
            {
                case Operations.addition:
                    outNum = MathFuncs.Addition(firstNum, secondNum);
                    firstNum = outNum;
                    break;

                case Operations.subtractition:
                    outNum = MathFuncs.Subtraction(firstNum, secondNum);
                    firstNum = outNum;
                    break;

                case Operations.multiplication:
                    outNum = MathFuncs.Multiplication(firstNum, secondNum);
                    firstNum = outNum;
                    break;

                case Operations.division:
                    outNum = MathFuncs.Division(firstNum, secondNum);
                    firstNum = outNum;
                    break;

                case Operations.power:
                    outNum = MathFuncs.Exponent(firstNum, secondNum);
                    firstNum = outNum;
                    break;

                default:
                    break;
            }
        }
    }
}
