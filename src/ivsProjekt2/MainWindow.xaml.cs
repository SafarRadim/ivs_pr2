using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MathLib;

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

        enum Operations{
            addition,
            subtractition,
            multiplication,
            division,
            factorial,
            exponent,
            root
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        /// =============
        /// 
        /// Function keys
        /// 
        /// =============

        private void CE_button_Click(object sender, RoutedEventArgs e)
        {
            OutputCurrentNumber.Text = String.Empty;
            firstNum = 0;
            secondNum = 0;
        }

        private void C_button_Click(object sender, RoutedEventArgs e)
        {
            OutputCurrentEquation.Text = String.Empty;
            OutputCurrentNumber.Text = String.Empty;
            firstNum = 0;
            secondNum = 0;
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            OutputCurrentNumber.Text = OutputCurrentNumber.Text.Remove(OutputCurrentNumber.Text.Length - 1);
        }

        private void func_button_Click(object sender, RoutedEventArgs e)
        {
            /// TODO: Add func_button_Click logic 
        }
        
        private void root_button_Click(object sender, RoutedEventArgs e)
        {
            /// TODO: add root_button_Click logic
        }

        private void pow_button_Click(object sender, RoutedEventArgs e)
        {
            /// TODO: add pow_button_Click logic
        }

        private void factorial_button_Click(object sender, RoutedEventArgs e)
        {
            /// TODO: add factorial_button_Click logic
        }

        private void plus_button_Click(object sender, RoutedEventArgs e)
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
                lastOp = Operations.addition;
            } 
            else
            {
                outNum = MathFuncs.Addition(firstNum, secondNum);
                OutputCurrentEquation.Text = outNum.ToString() + " +";
                OutputCurrentNumber.Text = outNum.ToString();
                firstNum = outNum;
                computed = true;
            }
        }

        private void minus_button_Click(object sender, RoutedEventArgs e)
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
                lastOp = Operations.subtractition;
            }
            else
            {
                outNum = MathFuncs.Subtraction(firstNum, secondNum);
                OutputCurrentEquation.Text = outNum.ToString() + " -";
                OutputCurrentNumber.Text = outNum.ToString();
                firstNum = outNum;
                computed = true;
            }
        }

        private void multiply_button_Click(object sender, RoutedEventArgs e)
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
                lastOp = Operations.multiplication;
            }
            else
            {
                outNum = MathFuncs.Multiplication(firstNum, secondNum);
                OutputCurrentEquation.Text = outNum.ToString() + " *";
                OutputCurrentNumber.Text = outNum.ToString();
                firstNum = outNum;
                computed = true;
            }
        }

        private void division_button_Click(object sender, RoutedEventArgs e)
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
                lastOp = Operations.division;
            }
            else
            {
                outNum = MathFuncs.Division(firstNum, secondNum);
                OutputCurrentEquation.Text = outNum.ToString() + " /";
                OutputCurrentNumber.Text = outNum.ToString();
                firstNum = outNum;
                computed = true;
            }
        }

        private void plusminus_button_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(OutputCurrentNumber.Text)
                 || OutputCurrentNumber.Text == "inf"
                 || computed)
            {
                return;
            }

            OutputCurrentNumber.Text = (Double.Parse(OutputCurrentNumber.Text) * -1).ToString();
        }

        private void dot_button_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(OutputCurrentNumber.Text)
                || OutputCurrentNumber.Text == "inf"
                || computed)
            {
                return;
            }

            OutputCurrentNumber.Text += ",";
        }

        private void equals_button_Click(object sender, RoutedEventArgs e)
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
            computed = true;
            equated = true;

        }

        /// ===========
        /// 
        /// Number keys
        /// 
        /// ===========

        private void one_button_Click(object sender, RoutedEventArgs e)
        {
            check_number();

            if (OutputCurrentNumber.Text == "0")
            {
                OutputCurrentNumber.Text = "1";
                return;
            }

            OutputCurrentNumber.Text += "1";
        }

        private void two_button_Click(object sender, RoutedEventArgs e)
        {
            check_number();

            if (OutputCurrentNumber.Text == "0")
            {
                OutputCurrentNumber.Text = "2";
                return;
            }

            OutputCurrentNumber.Text += "2";
        }

        private void three_button_Click(object sender, RoutedEventArgs e)
        {
            check_number();

            if (OutputCurrentNumber.Text == "0")
            {
                OutputCurrentNumber.Text = "3";
                return;
            }

            OutputCurrentNumber.Text += "3";
        }

        private void four_button_Click(object sender, RoutedEventArgs e)
        {
            check_number();

            if (OutputCurrentNumber.Text == "0")
            {
                OutputCurrentNumber.Text = "4";
                return;
            }

            OutputCurrentNumber.Text += "4";
        }

        private void five_button_Click(object sender, RoutedEventArgs e)
        {
            check_number();

            if (OutputCurrentNumber.Text == "0")
            {
                OutputCurrentNumber.Text = "5";
                return;
            }

            OutputCurrentNumber.Text += "5";
        }

        private void six_button_Click(object sender, RoutedEventArgs e)
        {
            check_number();

            if (OutputCurrentNumber.Text == "0")
            {
                OutputCurrentNumber.Text = "6";
                return;
            }

            OutputCurrentNumber.Text += "6";
        }

        private void seven_button_Click(object sender, RoutedEventArgs e)
        {
            check_number();

            if (OutputCurrentNumber.Text == "0")
            {
                OutputCurrentNumber.Text = "7";
                return;
            }

            OutputCurrentNumber.Text += "7";
        }

        private void eight_button_Click(object sender, RoutedEventArgs e)
        {
            check_number();

            if (OutputCurrentNumber.Text == "0")
            {
                OutputCurrentNumber.Text = "8";
                return;
            }

            OutputCurrentNumber.Text += "8";
        }

        private void nine_button_Click(object sender, RoutedEventArgs e)
        {
            check_number();

            if (OutputCurrentNumber.Text == "0")
            {
                OutputCurrentNumber.Text = "9";
                return;
            }

            OutputCurrentNumber.Text += "9";
        }

        private void zero_button_Click(object sender, RoutedEventArgs e)
        {
            check_number();

            if (OutputCurrentNumber.Text == "0")
            {
                OutputCurrentNumber.Text = "0";
                return;
            }

            OutputCurrentNumber.Text += "0";
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
    }
}
