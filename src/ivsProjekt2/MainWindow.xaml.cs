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
        double firstNum;
        double secondNum;
        double outNum;

        bool computed;
        bool equated;
        Operations lastOp;

        enum Operations
        {
            addition,
            subtractition,
            multiplication,
            division,
            factorial,
            exponent,
            root,
            equals
        }

        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);
        }

        /// =========
        /// 
        /// IO and logic
        /// 
        /// =========


        /// --------------
        /// Function logic
        /// --------------

        private void CE_logic()
        {
            OutputCurrentNumber.Text = String.Empty;
            firstNum = 0;
            secondNum = 0;
        }

        private void C_logic()
        {
            OutputCurrentEquation.Text = String.Empty;
            OutputCurrentNumber.Text = String.Empty;
            firstNum = 0;
            secondNum = 0;
        }

        private void back_logic()
        {
            OutputCurrentNumber.Text = OutputCurrentNumber.Text.Remove(OutputCurrentNumber.Text.Length - 1);
        }

        private void func_logic()
        {
            /// TODO: Add func_logic()
        }

        private void root_logic()
        {
            /// TODO: add root_logic()
        }

        private void pow_logic()
        {
            /// TODO: add pow_logic()
        }

        private void factorial_logic()
        {
            /// TODO: add factorial_logic()
        }

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
                firstNum = outNum;
                computed = true;
            }

            lastOp = Operations.addition;
        }

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
                firstNum = outNum;
                computed = true;
            }

            lastOp = Operations.subtractition;
        }

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
                firstNum = outNum;
                computed = true;
            }

            lastOp = Operations.multiplication;
        }

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
                firstNum = outNum;
                computed = true;
            }
            lastOp = Operations.division;
        }

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

        private void zero_logic()
        {
            check_number();

            if (OutputCurrentNumber.Text == "0")
            {
                OutputCurrentNumber.Text = "0";
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

        private void compute_last()
        {
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
            }
        }
    }
}
