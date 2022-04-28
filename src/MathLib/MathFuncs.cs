using System;

namespace MathLib
{
    public static class MathFuncs
    {
        public static double Addition(double baseNum, double num)
        {
            double sum = baseNum + num;

            return sum;
        }

        public static double Subtraction(double baseNum, double num)
        {
            double sum = baseNum - num;

            return sum;
        }

        public static double Multiplication(double baseNum, double num)
        {
            double sum = baseNum * num;

            return sum;
        }

        public static double Division(double baseNum, double num)
        {
            if (num == 0)
            {
                throw new Exception("Divide by zero");
            }

            double sum = baseNum / num;

            return sum;
        }

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

        public static double Modulo(double baseNum, double num)
        {
            if (num == 0) { return baseNum; }

            double sum = baseNum % num;

            return sum;
        }
    }
}
