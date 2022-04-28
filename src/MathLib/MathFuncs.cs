using System;

namespace MathLib
{
    public static class MathFuncs
    {
        /// <summary>
        /// Adds two numbers together.
        /// </summary>
        /// <param name="baseNum">first number</param>
        /// <param name="num">number to be added</param>
        /// <returns>result of addition</returns>
        public static double Addition(double baseNum, double num)
        {
            double sum = baseNum + num;

            return sum;
        }

        /// <summary>
        /// Subtracts second number from the first one.
        /// </summary>
        /// <param name="baseNum">number to be subtracted from</param>
        /// <param name="num">number to be subtracted</param>
        /// <returns>result of subtraction</returns>
        public static double Subtraction(double baseNum, double num)
        {
            double sum = baseNum - num;

            return sum;
        }

        /// <summary>
        /// Multiplies the first number by the second one.
        /// </summary>
        /// <param name="baseNum">number to be multiplied</param>
        /// <param name="num">number to be multiplied by</param>
        /// <returns>result of multiplication</returns>
        public static double Multiplication(double baseNum, double num)
        {
            double sum = baseNum * num;

            return sum;
        }

        /// <summary>
        /// Divides the first number by the second one.
        /// </summary>
        /// <param name="baseNum">number to be divided</param>
        /// <param name="num">number to be divided by</param>
        /// <returns>result of division</returns>
        /// <exception cref="Exception">division by zero</exception>
        public static double Division(double baseNum, double num)
        {
            if (num == 0)
            {
                throw new Exception("Divide by zero");
            }

            double sum = baseNum / num;

            return sum;
        }

        /// <summary>
        /// Calculates factorial of given number.
        /// </summary>
        /// <param name="num">number to be calculated</param>
        /// <returns>result of factorial</returns>
        /// <exception cref="Exception">invalid factorial value</exception>
        public static double Factorial(double num)
        {
            if (num == 0) { return 1; }
            if (num < 0 || (num % 1) > 0)
            {
                throw new Exception("Invalid factorial value");
            }

            double sum = 1;
            for (int i = 1; i <= num; i++)
            {
                sum = sum * i;
                if (double.IsInfinity(sum))
                {
                    break;
                }
            }

            return sum;
        }

        /// <summary>
        /// Raises value of the first number to the power of the second number.
        /// Power can be only natural numbers.
        /// </summary>
        /// <param name="baseNum">number to be raised</param>
        /// <param name="power">power to be raised to</param>
        /// <returns>number raised to the power</returns>
        /// <exception cref="Exception">invalid exponent value</exception>
        public static double Exponent(double baseNum, double power)
        {
            if (power == 0) { return 1; }
            if (power < 0 || (power % 1) > 0)
            {
                throw new Exception("Invalid exponent value");
            }

            double sum = baseNum;
            for (int i = 1; i < power; i++)
            {
                sum = sum * baseNum;
                if (double.IsInfinity(sum))
                {
                    break;
                }
            }
            return sum;
        }

        /// <summary>
        /// Calculates the nth root of the number.
        /// </summary>
        /// <param name="baseNum">number to be calculated</param>
        /// <param name="degree">degree of the root</param>
        /// <returns>result of root</returns>
        /// <exception cref="Exception">invalid root degree, negative number under root</exception>
        public static double Root(double baseNum, double degree)
        {
            if (degree%1 > 0 || degree < 1)
            {
                throw new Exception("Invalid root degree");
            }

            if (degree%2 == 0 && baseNum < 0)
            {
                throw new Exception("Number cannot be negative");
            }

            double change = double.MaxValue;
            double precision = 0.000001;

            double x = (baseNum / degree) / degree;
            double last_x = x;

            int iter = 0;

            while (change > precision && iter < 1000)
            {
                x = (((degree - 1) / degree) * last_x) + ((baseNum / degree) * (1 / (Math.Pow(last_x, degree - 1))));
                change = x - last_x;
                if (change < 0)
                {
                    change = -change;
                }
                last_x = x;
                iter++;
            }
            if (double.IsNaN(x)) { x = 0; }
            return x;
        }

        /// <summary>
        /// Calculates second number modulo of the first number.
        /// </summary>
        /// <param name="baseNum">number to be divided</param>
        /// <param name="num">number to be divided by</param>
        /// <returns>remainder of division</returns>
        public static double Modulo(double baseNum, double num)
        {
            if (num == 0) { return baseNum; }

            double sum = baseNum % num;

            return sum;
        }
    }
}
