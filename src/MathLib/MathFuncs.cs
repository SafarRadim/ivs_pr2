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
        public static double Factorial()
        {
            double sum = 0;

            return sum;
        }

        public static double Exponent()
        {
            double sum = 0;

            return sum;
        }
        public static double Root()
        {
            double sum = 0;

            return sum;
        }
    }
}
