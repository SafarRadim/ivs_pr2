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
        Operations lastOp = Operations.none;  // Used for working logic

        enum Operations
        {
            addition,
            subtractition,
            multiplication,
            division,
            factorial,
            power,
            root,
            equals,
            modulo,
            none
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

        /// ------
        /// Helper
        /// ------

        /// <summary>
        /// Changes font size if OutputCurrentNumber is text
        /// </summary>
        private void checkOutput()
        {
            double val;
            if (!Double.TryParse(OutputCurrentNumber.Text, out val))
            {
                OutputCurrentNumber.FontSize = 18;
            } else
            {
                OutputCurrentNumber.FontSize = 36;
            }
        }

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

            if (OutputCurrentNumber.Text == "inf")
            {
                C_logic();
            }
        }

        /// <summary>
        /// Computes latest input
        /// </summary>
        /// Based on lastOp computes latest "equation"
        private int compute_last()
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
                    if (secondNum == 0)
                    {
                        OutputCurrentNumber.Text = "Cannot divide";
                        checkOutput();
                        computed = true;
                        equated = true;
                        return 1;
                    }
                    outNum = MathFuncs.Division(firstNum, secondNum);
                    firstNum = outNum;
                    break;

                case Operations.power:
                    if (secondNum < 0 || secondNum % 1 != 0)
                    {
                        C_logic();
                        OutputCurrentNumber.Text = "Exponent has to be positive int";
                        checkOutput();
                        equated = true;
                        return 1;
                    }
                    outNum = MathFuncs.Exponent(firstNum, secondNum);
                    firstNum = outNum;
                    break;

                case Operations.factorial:
                    OutputCurrentNumber.Text = String.Empty;
                    break;

                case Operations.modulo:
                    outNum = MathFuncs.Modulo(firstNum, secondNum);
                    break;

                case Operations.root:
                    if (secondNum < 0 || firstNum % 2 == 0)
                    {
                        C_logic();
                        OutputCurrentNumber.Text = "Base number has to be >0";
                        checkOutput();
                        equated = true;
                        return 1;
                    }
                    outNum = MathFuncs.Root(secondNum, firstNum);
                    firstNum = outNum;
                    break;

                default:
                    computed = false;
                    break;
            }
            return 0;
        }

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
            lastOp = Operations.none;
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
            outNum = 0;
            lastOp = Operations.none;
        }

        /// <summary>
        /// Logic for Back button
        /// </summary>
        /// Removes last char from OutputCurrentNumber textbox
        private void back_logic()
        {
            OutputCurrentNumber.Text = OutputCurrentNumber.Text.Remove(OutputCurrentNumber.Text.Length - 1);
            if (OutputCurrentNumber.Text.Length == 0)
            {
                OutputCurrentNumber.Text = "0";
            }
        }

        /// <summary>
        /// Logic for Modulo button
        /// </summary>
        /// Computes modulo
        private void modulo_logic()
        {
            if (String.IsNullOrEmpty(OutputCurrentNumber.Text)
                || OutputCurrentNumber.Text == "inf"
                || computed)
            {
                return;
            }

            secondNum = Double.Parse(OutputCurrentNumber.Text);

            if (firstNum == 0 || Double.IsInfinity(firstNum))
            {
                firstNum = secondNum;
                OutputCurrentEquation.Text = secondNum.ToString("#.#####") + " %";
                OutputCurrentNumber.Text = String.Empty;
            }
            else
            {
                if (compute_last() == 1)
                {
                    return;
                }
                OutputCurrentEquation.Text = outNum.ToString("#.#####") + " %";
                OutputCurrentNumber.Text = outNum.ToString("#.#####");
            }

            lastOp = Operations.modulo;
        }

        /// <summary>
        /// Logic for Root button
        /// </summary>
        /// Needs two numbers
        private void root_logic()
        {
            if (String.IsNullOrEmpty(OutputCurrentNumber.Text)
                || OutputCurrentNumber.Text == "inf"
                || computed)
            {
                return;
            }

            secondNum = Double.Parse(OutputCurrentNumber.Text);


            if (firstNum == 0 || Double.IsInfinity(firstNum))
            {
                if (secondNum % 1 != 0 || secondNum < 0)
                {
                    C_logic();
                    OutputCurrentNumber.Text = "Degree has to be positive int";
                    checkOutput();
                    computed = true;
                    return;
                }
                firstNum = secondNum;
                OutputCurrentEquation.Text = secondNum.ToString("#.#####") + "√";
                OutputCurrentNumber.Text = String.Empty;
            }
            else
            {
                if (secondNum < 0 && firstNum % 2 == 0)
                {
                    OutputCurrentNumber.Text = "Base number has to be >0";
                    checkOutput();
                    computed = true;
                    return;
                }

                if (compute_last() == 1)
                {
                    return;
                }
                OutputCurrentEquation.Text = outNum.ToString("#.#####") + "√";
                OutputCurrentNumber.Text = outNum.ToString("#.#####");
            }

            lastOp = Operations.root;
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


            if (firstNum == 0 || Double.IsInfinity(firstNum))
            {
                firstNum = secondNum;
                OutputCurrentEquation.Text = secondNum.ToString("#.#####") + "^";
                OutputCurrentNumber.Text = String.Empty;
            }
            else
            {
                if (secondNum < 0)
                {
                    OutputCurrentNumber.Text = "Exponent has to be > 0.";
                    checkOutput();
                    computed = true;
                    return;
                }

                if (secondNum % 1 != 0)
                {
                    C_logic();
                    OutputCurrentNumber.Text = "Value has to be int";
                    checkOutput();
                    return;
                }

                if (compute_last() == 1)
                {
                    return;
                }
                OutputCurrentEquation.Text = outNum.ToString("#.#####") + "^";
                OutputCurrentNumber.Text = outNum.ToString("#.#####");

            }

            lastOp = Operations.power;
        }

        /// <summary>
        /// Logic for Factorial button
        /// </summary>
        /// If there is zero stored in first num it replaces
        /// If there is value stored, computes latest equation and adds itself
        private void factorial_logic()
        {
            if (String.IsNullOrEmpty(OutputCurrentNumber.Text)
                || OutputCurrentNumber.Text == "inf")
            {
                return;
            }

            secondNum = Double.Parse(OutputCurrentNumber.Text);

            if (secondNum < 0)
            {
                OutputCurrentNumber.Text = "Value has to be > 0";
                checkOutput();
                return;
            }

            if (compute_last() == 1)
            {
                return;
            }

            if (outNum < 0)
            {
                C_logic();
                OutputCurrentNumber.Text = "Value has to be > 0";
                checkOutput();
                return;
            }

            if (secondNum % 1 != 0)
            {
                C_logic();
                OutputCurrentNumber.Text = "Value has to be int";
                checkOutput();
                return;
            }

            if (outNum == 0 || Double.IsInfinity(firstNum))
            {
                OutputCurrentEquation.Text = secondNum.ToString("#.#####") + "!";
                firstNum = MathFuncs.Factorial(secondNum);
                OutputCurrentNumber.Text = firstNum.ToString("#.#####");
            }
            else
            {
                OutputCurrentEquation.Text = outNum.ToString("#.#####") + "!";
                outNum = MathFuncs.Factorial(outNum);
                OutputCurrentNumber.Text = outNum.ToString("#.#####");
                firstNum = outNum;
            }

            computed = false;
            lastOp = Operations.factorial;

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

            if (firstNum == 0 || Double.IsInfinity(firstNum))
            { 
                firstNum = secondNum;
                OutputCurrentEquation.Text = secondNum.ToString("#.#####") + " +";
                OutputCurrentNumber.Text = String.Empty;
            }
            else
            {
                if (compute_last() == 1)
                {
                    return;
                }
                OutputCurrentEquation.Text = outNum.ToString("#.#####") + " +";
                OutputCurrentNumber.Text = outNum.ToString("#.#####");
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

            if (firstNum == 0 || Double.IsInfinity(firstNum))
            {
                firstNum = secondNum;
                OutputCurrentEquation.Text = secondNum.ToString("#.#####") + " -";
                OutputCurrentNumber.Text = String.Empty;
            }
            else
            {
                if (compute_last() == 1)
                {
                    return;
                }
                OutputCurrentEquation.Text = outNum.ToString("#.#####") + " -";
                OutputCurrentNumber.Text = outNum.ToString("#.#####");
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

            if (firstNum == 0 || Double.IsInfinity(firstNum))
            {
                firstNum = secondNum;
                OutputCurrentEquation.Text = secondNum.ToString("#.#####") + " *";
                OutputCurrentNumber.Text = String.Empty;
            }
            else
            {
                if (compute_last() == 1)
                {
                    return;
                }
                OutputCurrentEquation.Text = outNum.ToString("#.#####") + " *";
                OutputCurrentNumber.Text = outNum.ToString("#.#####");
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
                checkOutput();
                computed = true;
                return;
            }

            if (firstNum == 0 || Double.IsInfinity(firstNum))
            {
                firstNum = secondNum;
                OutputCurrentEquation.Text = secondNum.ToString("#.#####") + " /";
                OutputCurrentNumber.Text = String.Empty;
            }
            else
            {
                if (compute_last() == 1)
                {
                    return;
                }
                OutputCurrentEquation.Text = outNum.ToString("#.#####") + " /";
                OutputCurrentNumber.Text = outNum.ToString("#.#####");
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
            if (OutputCurrentNumber.Text == "0")
            {
                return;
            }
            OutputCurrentNumber.Text = (Double.Parse(OutputCurrentNumber.Text) * -1).ToString("#.#####");
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

            if (lastOp == Operations.equals)
            {
                return;
            }

            switch (lastOp)
            {
                case Operations.addition:
                    OutputCurrentEquation.Text = firstNum.ToString("#.#####") + " + " + secondNum.ToString("#.#####") + " =";
                    outNum = MathFuncs.Addition(firstNum, secondNum);
                    break;

                case Operations.subtractition:
                    OutputCurrentEquation.Text = firstNum.ToString("#.#####") + " - " + secondNum.ToString("#.#####") + " =";
                    outNum = MathFuncs.Subtraction(firstNum, secondNum);
                    break;

                case Operations.multiplication:
                    OutputCurrentEquation.Text = firstNum.ToString("#.#####") + " * " + secondNum.ToString("#.#####") + " =";
                    outNum = MathFuncs.Multiplication(firstNum, secondNum);
                    break;

                case Operations.division:
                    if (secondNum == 0)
                    {
                        OutputCurrentNumber.Text = "Cannot divide";
                        checkOutput();
                        computed = true;
                        equated = true;
                        return;
                    }
                    OutputCurrentEquation.Text = firstNum.ToString("#.#####") + " / " + secondNum.ToString("#.#####") + " =";
                    outNum = MathFuncs.Division(firstNum, secondNum);
                    break;
                
                case Operations.power:
                    if (secondNum < 0 || secondNum % 1 != 0)
                    {
                        C_logic();
                        OutputCurrentNumber.Text = "Exponent has to be positive int";
                        checkOutput();
                        equated = true;
                        return;
                    } 
                    OutputCurrentEquation.Text = firstNum.ToString("#.#####") + "^" + secondNum.ToString("#.#####") + " =";
                    outNum = MathFuncs.Exponent(firstNum, secondNum);
                    break;

                case Operations.factorial:
                    OutputCurrentNumber.Text = outNum.ToString("#.#####") + "! =";
                    if (secondNum < 0)
                    {
                        C_logic();
                        OutputCurrentNumber.Text = "Value has to be > 0.";
                        checkOutput();
                        equated = true;
                        return;
                    }                    
                    outNum = MathFuncs.Factorial(firstNum);
                    break;

                case Operations.root:
                    OutputCurrentEquation.Text = firstNum.ToString("#.#####") + "√" + secondNum.ToString("#.#####") + " =";
                    if (secondNum < 0 && firstNum % 2 == 0 )
                    {
                        OutputCurrentNumber.Text = "Base number has to be >0";
                        checkOutput();
                        computed = true;
                        return;
                    }
                    outNum = MathFuncs.Root(secondNum, firstNum);
                    break;

                case Operations.modulo:
                    OutputCurrentEquation.Text = firstNum.ToString("#.#####") + " % " + secondNum.ToString("#.#####") + " =";
                    outNum = MathFuncs.Modulo(firstNum, secondNum);
                    break;

                default:
                    break;

            }

            OutputCurrentNumber.Text = outNum.ToString("#.#####");
            lastOp = Operations.equals;
            firstNum = 0;
            secondNum = 0;
            outNum = 0;
            computed = true;
            equated = true;
        }

        /// ------------
        /// number logic
        /// ------------
        
        /// <summary>
        /// Adds num to output or replaces it when its 0
        /// </summary>
        /// <param name="num"> Number string </param>
        private void updateNumberOutput(string num)
        {
            check_number();

            if (OutputCurrentNumber.Text == "0" || lastOp == Operations.factorial)
            {
                lastOp = Operations.none;
                OutputCurrentNumber.Text = num;
                return;
            }

            OutputCurrentNumber.Text += num;
            checkOutput();
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
            modulo_logic();
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
            updateNumberOutput("1");
        }

        private void two_button_Click(object sender, RoutedEventArgs e)
        {
            updateNumberOutput("2");
        }

        private void three_button_Click(object sender, RoutedEventArgs e)
        {
            updateNumberOutput("3");
        }

        private void four_button_Click(object sender, RoutedEventArgs e)
        {
            updateNumberOutput("4");
        }

        private void five_button_Click(object sender, RoutedEventArgs e)
        {
            updateNumberOutput("5");
        }

        private void six_button_Click(object sender, RoutedEventArgs e)
        {
            updateNumberOutput("6");
        }

        private void seven_button_Click(object sender, RoutedEventArgs e)
        {
            updateNumberOutput("7");
        }

        private void eight_button_Click(object sender, RoutedEventArgs e)
        {
            updateNumberOutput("8");
        }

        private void nine_button_Click(object sender, RoutedEventArgs e)
        {
            updateNumberOutput("9");
        }

        private void zero_button_Click(object sender, RoutedEventArgs e)
        {
            updateNumberOutput("0");
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
                updateNumberOutput("1");
            }

            if (e.Key == Key.NumPad2 || e.Key == Key.D2)
            {
                updateNumberOutput("2");
            }

            if (e.Key == Key.NumPad3 || e.Key == Key.D3)
            {
                updateNumberOutput("3");
            }

            if (e.Key == Key.NumPad4 || e.Key == Key.D4)
            {
                updateNumberOutput("4");
            }

            if (e.Key == Key.NumPad5 || e.Key == Key.D5)
            {
                updateNumberOutput("5");
            }

            if (e.Key == Key.NumPad6 || e.Key == Key.D6)
            {
                updateNumberOutput("6");
            }

            if (e.Key == Key.NumPad7 || e.Key == Key.D7)
            {
                updateNumberOutput("7");
            }

            if (e.Key == Key.NumPad8 || e.Key == Key.D8)
            {
                updateNumberOutput("8");
            }

            if (e.Key == Key.NumPad9 || e.Key == Key.D9)
            {
                updateNumberOutput("9");
            }

            if (e.Key == Key.NumPad0 || e.Key == Key.NumPad0)
            {
                updateNumberOutput("0");
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
    }
}
