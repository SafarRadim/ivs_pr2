using MathLib;
using NUnit.Framework;
using System;

namespace MathLibTests
{
    public class MathTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AdditionTest()
        {
            // 0 + 0 = 0
            Assert.That(0, Is.EqualTo(MathFuncs.Addition(0.0, 0)).Within(0.000001));
            // 1 + 1 = 2
            Assert.That(2, Is.EqualTo(MathFuncs.Addition(1, 1.0)).Within(0.000001));
            // 1 + 0 = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Addition(1, 0)).Within(0.000001));
            // -1 + 2 = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Addition(-1, 2.0)).Within(0.000001));
            // 1 + (-1) = 0
            Assert.That(0, Is.EqualTo(MathFuncs.Addition(1, -1.0)).Within(0.000001));
            // 1000000000 + 2000000000 = 3000000000
            Assert.That(3000000000, Is.EqualTo(MathFuncs.Addition(1000000000, 2000000000)).Within(0.000001));
            // 1.11 + 2.22 = 3.33
            Assert.That(3.33, Is.EqualTo(MathFuncs.Addition(1.11, 2.22)).Within(0.000001));
            // 1.11 + 0 = 1.11
            Assert.That(1.11, Is.EqualTo(MathFuncs.Addition(1.11, 0)).Within(0.000001));
            // -1.11 + 2.22 = 1.11
            Assert.That(1.11, Is.EqualTo(MathFuncs.Addition(-1.11, 2.22)).Within(0.000001));
            // 1.11 + (-1.11) = 0
            Assert.That(0, Is.EqualTo(MathFuncs.Addition(1.11, -1.11)).Within(0.000001));
            // 1000000000.111111111 + 2000000000.222222222 = 3000000000.333333333
            Assert.That(3000000000.333333333, Is.EqualTo(MathFuncs.Addition(1000000000.111111111, 2000000000.222222222)).Within(0.000001));
            // overflow tests
            Assert.Throws<Exception>(() => MathFuncs.Addition(double.MaxValue, double.MaxValue));
        }

        [Test]
        public void SubtractionTest()
        {
            // 0 - 0 = 0
            Assert.That(0, Is.EqualTo(MathFuncs.Subtraction(0.0, 0)).Within(0.000001));
            // 1 - 1 = 0
            Assert.That(0, Is.EqualTo(MathFuncs.Subtraction(1, 1)).Within(0.000001));
            // 1 - 0 = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Subtraction(1, 0)).Within(0.000001));
            // 1 - 2 = -1
            Assert.That(-1, Is.EqualTo(MathFuncs.Subtraction(1, 2)).Within(0.000001));
            // 0 - (-1) = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Subtraction(0, -1)).Within(0.000001));
            // 1.11 - 1.11 = 0
            Assert.That(0, Is.EqualTo(MathFuncs.Subtraction(1.11, 1.11)).Within(0.000001));
            // 1.11 - 0 = 1.11
            Assert.That(1.11, Is.EqualTo(MathFuncs.Subtraction(1.11, 0)).Within(0.000001));
            // 1.11 - 2.22 = -1.11
            Assert.That(-1.11, Is.EqualTo(MathFuncs.Subtraction(1.11, 2.22)).Within(0.000001));
            // 0 - (-1.11) = 1.11
            Assert.That(1.11, Is.EqualTo(MathFuncs.Subtraction(0, -1.11)).Within(0.000001));
            // 1000000000.111111111 - 2000000000.222222222 = -1000000000.111111111
            Assert.That(-1000000000.111111111, Is.EqualTo(MathFuncs.Subtraction(1000000000.111111111, 2000000000.222222222)).Within(0.000001));
            // overflow tests
            Assert.Throws<Exception>(() => MathFuncs.Subtraction(double.MaxValue, -double.MaxValue));
        }

        [Test]
        public void MultiplicationTest()
        {
            // 0 * 0 = 0
            Assert.That(0, Is.EqualTo(MathFuncs.Multiplication(0.0, 0)).Within(0.000001));
            // 1 * 0 = 0
            Assert.That(0, Is.EqualTo(MathFuncs.Multiplication(1, 0)).Within(0.000001));
            // 2 * 2 = 4
            Assert.That(4, Is.EqualTo(MathFuncs.Multiplication(2, 2)).Within(0.000001));
            // 2 * (-2) = -4
            Assert.That(-4, Is.EqualTo(MathFuncs.Multiplication(2, -2)).Within(0.000001));
            // (-2) * (-2) = 4
            Assert.That(4, Is.EqualTo(MathFuncs.Multiplication(-2, -2)).Within(0.000001));
            // 1.11 * 0 = 0
            Assert.That(0, Is.EqualTo(MathFuncs.Multiplication(1.11, 0)).Within(0.000001));
            // 2.22 * 2.22 = 4.9284
            Assert.That(4.9284, Is.EqualTo(MathFuncs.Multiplication(2.22, 2.22)).Within(0.000001));
            // 2.22 * (-2.22) = -4.9284
            Assert.That(-4.9284, Is.EqualTo(MathFuncs.Multiplication(2.22, -2.22)).Within(0.000001));
            // (-2.22) * (-2.22) = 4.9284
            Assert.That(4.9284, Is.EqualTo(MathFuncs.Multiplication(-2.22, -2.22)).Within(0.000001));
            // 20000.22222 * 20000.22222 = 400008888.849381
            Assert.That(400008888.849381, Is.EqualTo(MathFuncs.Multiplication(20000.22222, 20000.22222)).Within(0.000001));
            // 20000.22222 * (-20000.22222) = -400008888.849381
            Assert.That(-400008888.849381, Is.EqualTo(MathFuncs.Multiplication(20000.22222, -20000.22222)).Within(0.000001));
            // overflow tests
            Assert.Throws<Exception>(() => MathFuncs.Multiplication(double.MaxValue, 1.01));
            Assert.Throws<Exception>(() => MathFuncs.Multiplication(-1.01, double.MaxValue));
            Assert.Throws<Exception>(() => MathFuncs.Multiplication(double.MaxValue, double.MaxValue));
        }

        [Test]
        public void DivisionTest()
        {
            // 1 / 0 = X
            Assert.Throws<Exception>(() => MathFuncs.Division(1, 0));
            // 0 / 1 = 0
            Assert.That(0, Is.EqualTo(MathFuncs.Division(0, 1)).Within(0.000001));
            // 2 / 1 = 2
            Assert.That(2, Is.EqualTo(MathFuncs.Division(2, 1)).Within(0.000001));
            // 2 / 2 = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Division(2, 2)).Within(0.000001));
            // 2 / (-2) = -1
            Assert.That(-1, Is.EqualTo(MathFuncs.Division(2, -2)).Within(0.000001));
            // (-2) / (-2) = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Division(-2, -2)).Within(0.000001));
            // 2 / 0.5 = 4
            Assert.That(4, Is.EqualTo(MathFuncs.Division(2, 0.5)).Within(0.000001));
            // 2.222 / 1.11 = 2
            Assert.That(2.0018018018, Is.EqualTo(MathFuncs.Division(2.222, 1.11)).Within(0.000001));
            // 2.22 / 2.22 = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Division(2.22, 2.22)).Within(0.000001));
            // 2.22 / (-2.22) = -1
            Assert.That(-1, Is.EqualTo(MathFuncs.Division(2.22, -2.22)).Within(0.000001));
            // (-2.22) / (-2.22) = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Division(-2.22, -2.22)).Within(0.000001));
            // 1000000000.111111111 / 20000.2222 = 49999.4445117270
            Assert.That(49999.4445117270, Is.EqualTo(MathFuncs.Division(1000000000.111111111, 20000.2222)).Within(0.000001));
            // overflow tests
            Assert.Throws<Exception>(() => MathFuncs.Division(double.MaxValue, 0.99));
            Assert.Throws<Exception>(() => MathFuncs.Division(double.MaxValue, -0.99));
        }

        [Test]
        public void FactorialTest()
        {
            // Fact(0) = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Factorial(0)).Within(0.000001));
            // Fact(1) = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Factorial(1)).Within(0.000001));
            // Fact(2) = 2
            Assert.That(2, Is.EqualTo(MathFuncs.Factorial(2)).Within(0.000001));
            // Fact(3) = 6
            Assert.That(6, Is.EqualTo(MathFuncs.Factorial(3)).Within(0.000001));
            // Fact(10) = 3628800
            Assert.That(3628800, Is.EqualTo(MathFuncs.Factorial(10)).Within(0.000001));
            // Fact(-5) = X
            Assert.Throws<Exception>(() => MathFuncs.Factorial(-5));
            // Fact(0.5) = X
            Assert.Throws<Exception>(() => MathFuncs.Factorial(0.5));
            // Fact(-0.5) = X
            Assert.Throws<Exception>(() => MathFuncs.Factorial(-0.5));
            // Fact(175) = X
            Assert.Throws<Exception>(() => MathFuncs.Factorial(175));
        }

        [Test]
        public void ExponentTest()
        {
            // 0^0 = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Exponent(0, 0)).Within(0.000001));
            // 0^11 = 0
            Assert.That(1, Is.EqualTo(MathFuncs.Exponent(0, 11)).Within(0.000001));
            // 0^-1 = X
            Assert.Throws<Exception>(() => MathFuncs.Exponent(0, -1));
            // 0^0.5 = 0
            Assert.That(0, Is.EqualTo(MathFuncs.Exponent(0, 0.5)).Within(0.000001));
            // 0^-0.5 = X
            Assert.Throws<Exception>(() => MathFuncs.Exponent(0, -0.5));
            // 1^0 = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Exponent(1, 0)).Within(0.000001));
            // 1^11 = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Exponent(1, 11)).Within(0.000001));
            // 1^-1 = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Exponent(1, -1)).Within(0.000001));
            // 1^0.5 = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Exponent(1, 0.5)).Within(0.000001));
            // 1^-0.5 = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Exponent(1, -0.5)).Within(0.000001));
            // 5^0 = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Exponent(5, 0)).Within(0.000001));
            // 5^11 = 48828125
            Assert.That(48828125, Is.EqualTo(MathFuncs.Exponent(5, 11)).Within(0.000001));
            // 5^-1 = 0.2
            Assert.That(0.2, Is.EqualTo(MathFuncs.Exponent(5, -1)).Within(0.000001));
            // 5^0.5 = 2.2360679774998
            Assert.That(2.2360679774998, Is.EqualTo(MathFuncs.Exponent(5, 0.5)).Within(0.000001));
            // 5^-0.5 = 0.44721359549996
            Assert.That(0.44721359549996, Is.EqualTo(MathFuncs.Exponent(5, -0.5)).Within(0.000001));
            // -5^0 = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Exponent(-5, 0)).Within(0.000001));
            // -5^11 = -48828125
            Assert.That(-48828125,Is.EqualTo(MathFuncs.Exponent(-5, 11)).Within(0.000001));
            // -5^-1 = -0.2
            Assert.That(-0.2, Is.EqualTo(MathFuncs.Exponent(-5, -1)).Within(0.000001));
            // -5^0.5 = X
            Assert.Throws<Exception>(() => MathFuncs.Exponent(-5, 0.5));
            // -5^-0.5 = X
            Assert.Throws<Exception>(() => MathFuncs.Exponent(-5, -0.5));
            // 0.5^0 = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Exponent(0.5, 0)).Within(0.000001));
            // 0.5^11 = 0.00048828125
            Assert.That(0.00048828125, Is.EqualTo(MathFuncs.Exponent(0.5, 11)).Within(0.000001));
            // 0.5^-1 = 2
            Assert.That(2, Is.EqualTo(MathFuncs.Exponent(0.5, -1)).Within(0.000001));
            // 0.5^0.5 = 0.70710678118
            Assert.That(0.70710678118, Is.EqualTo(MathFuncs.Exponent(0.5, 0.5)).Within(0.000001));
            // 0.5^-0.5 = 1.41421356237
            Assert.That(1.41421356237, Is.EqualTo(MathFuncs.Exponent(0.5, -0.5)).Within(0.000001));
            // -0.5^0 = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Exponent(-0.5, 0)).Within(0.000001));
            // -0.5^11 = -0.00048828125
            Assert.That(-0.00048828125, Is.EqualTo(MathFuncs.Exponent(-0.5, 11)).Within(0.000001));
            // -0.5^-1 = -2
            Assert.That(-2, Is.EqualTo(MathFuncs.Exponent(-0.5, -1)).Within(0.000001));
            // -0.5^0.5 = X
            Assert.Throws<Exception>(() => MathFuncs.Exponent(-0.5, 0.5));
            // -0.5^-0.5 = X
            Assert.Throws<Exception>(() => MathFuncs.Exponent(-0.5, -0.5));
            // 10 ^ 310 = X
            Assert.Throws<Exception>(() => MathFuncs.Exponent(10, 310));

        }

        [Test]
        public void RootTest()
        {
            Assert.Pass();
        }
    }
}