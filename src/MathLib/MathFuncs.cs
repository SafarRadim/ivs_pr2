using System;

namespace MathLib
{
    public static class MathFuncs
    {
        public static double Addition(double baseNum, double num)
        {
            double sum = baseNum + num;
            if (double.IsInfinity(sum))
            {
                throw new Exception("Value is too high");
            }

            return sum;
        }

        public static double Subtraction(double baseNum, double num)
        {
            double sum = baseNum - num;
            if (double.IsInfinity(sum))
            {
                throw new Exception("Value is too high");
            }

            return sum;
        }

        public static double Multiplication(double baseNum, double num)
        {
            double sum = baseNum * num;
            if (double.IsInfinity(sum))
            {
                throw new Exception("Value is too high");
            }

            return sum;
        }
        public static double Division(double baseNum, double num)
        {
            if (num == 0)
            {
                throw new Exception("Divide by zero");
            }

            double sum = baseNum / num;
            if (double.IsInfinity(sum))
            {
                throw new Exception("Value is too high");
            }

            return sum;
        }
        public static double Factorial(double num)
        {
            if (num == 0) { return 1; }
            if (num < 0 || (num%1) > 0)
            {
                throw new Exception("Invalid factorial value");
            }

            double sum = 1;
            for (int i = 1; i <= num; i++)
            {
                sum = sum * i;
                if (double.IsInfinity(sum))
                {
                    throw new Exception("Value is too high");
                }
            }

            return sum;
        }

        public static double Exponent(double baseNum, double power)
        {
            double sum = 0;

            return sum;
        }
        public static double Root(double baseNum, double degree)
        {
            double sum = 0;

            return sum;
        }
    }
}
