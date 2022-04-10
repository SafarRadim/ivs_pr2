using MathLib;
using NUnit.Framework;

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
            Assert.That(0, Is.EqualTo(MathFuncs.Addition(0.0, 0)).Within(0.0000000001));
            // 1 + 1 = 2
            Assert.That(2, Is.EqualTo(MathFuncs.Addition(1, 1.0)).Within(0.0000000001));
            // 1 + 0 = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Addition(1, 0)).Within(0.0000000001));
            // -1 + 2 = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Addition(-1, 2.0)).Within(0.0000000001));
            // 1 + (-1) = 0
            Assert.That(0, Is.EqualTo(MathFuncs.Addition(1, -1.0)).Within(0.0000000001));
            // 1000000000 + 2000000000 = 3000000000
            Assert.That(3000000000, Is.EqualTo(MathFuncs.Addition(1000000000, 2000000000)).Within(0.0000000001));
            // 1.11 + 2.22 = 3.33
            Assert.That(3.33, Is.EqualTo(MathFuncs.Addition(1.11, 2.22)).Within(0.0000000001));
            // 1.11 + 0 = 1.11
            Assert.That(1.11, Is.EqualTo(MathFuncs.Addition(1.11, 0)).Within(0.0000000001));
            // -1.11 + 2.22 = 1.11
            Assert.That(1.11, Is.EqualTo(MathFuncs.Addition(-1.11, 2.22)).Within(0.0000000001));
            // 1.11 + (-1.11) = 0
            Assert.That(0, Is.EqualTo(MathFuncs.Addition(1.11, -1.11)).Within(0.0000000001));
            // 1000000000.111111111 + 2000000000.222222222 = 3000000000.333333333
            Assert.That(3000000000.333333333, Is.EqualTo(MathFuncs.Addition(1000000000.111111111, 2000000000.222222222)).Within(0.0000000001));
            // overflow tests
            Assert.That(MathFuncs.Addition(double.MaxValue, 1), Throws.Exception);
            Assert.That(MathFuncs.Addition(1, double.MaxValue), Throws.Exception);
            Assert.That(MathFuncs.Addition(double.MaxValue-1, double.MaxValue-1), Throws.Exception);
        }

        [Test]
        public void SubtractionTest()
        {
            // 0 - 0 = 0
            Assert.That(0, Is.EqualTo(MathFuncs.Subtraction(0.0, 0)).Within(0.0000000001));
            // 1 - 1 = 0
            Assert.That(0, Is.EqualTo(MathFuncs.Subtraction(1, 1)).Within(0.0000000001));
            // 1 - 0 = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Subtraction(1, 0)).Within(0.0000000001));
            // 1 - 2 = -1
            Assert.That(-1, Is.EqualTo(MathFuncs.Subtraction(1, 2)).Within(0.0000000001));
            // 0 - (-1) = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Subtraction(0, -1)).Within(0.0000000001));
            // 1.11 - 1.11 = 0
            Assert.That(0, Is.EqualTo(MathFuncs.Subtraction(1.11, 1.11)).Within(0.0000000001));
            // 1.11 - 0 = 1.11
            Assert.That(1.11, Is.EqualTo(MathFuncs.Subtraction(1.11, 0)).Within(0.0000000001));
            // 1.11 - 2.22 = -1.11
            Assert.That(-1.11, Is.EqualTo(MathFuncs.Subtraction(1.11, 2.22)).Within(0.0000000001));
            // 0 - (-1.11) = 1.11
            Assert.That(1.11, Is.EqualTo(MathFuncs.Subtraction(0, -1.11)).Within(0.0000000001));
            // 1000000000.111111111 - 2000000000.222222222 = -1000000000.111111111
            Assert.That(-1000000000.111111111, Is.EqualTo(MathFuncs.Subtraction(1000000000.111111111, 2000000000.222222222)).Within(0.0000000001));
            // overflow tests
            Assert.That(MathFuncs.Subtraction(double.MaxValue, -1), Throws.Exception);
            Assert.That(MathFuncs.Subtraction(-1, double.MaxValue), Throws.Exception);
            Assert.That(MathFuncs.Subtraction(double.MaxValue, -double.MaxValue), Throws.Exception);
        }

        [Test]
        public void MultiplicationTest()
        {
            // 0 * 0 = 0
            Assert.That(0, Is.EqualTo(MathFuncs.Multiplication(0.0, 0)).Within(0.0000000001));
            // 1 * 0 = 0
            Assert.That(0, Is.EqualTo(MathFuncs.Multiplication(1, 0)).Within(0.0000000001));
            // 2 * 2 = 4
            Assert.That(4, Is.EqualTo(MathFuncs.Multiplication(2, 2)).Within(0.0000000001));
            // 2 * (-2) = -4
            Assert.That(-4, Is.EqualTo(MathFuncs.Multiplication(2, -2)).Within(0.0000000001));
            // (-2) * (-2) = 4
            Assert.That(4, Is.EqualTo(MathFuncs.Multiplication(-2, -2)).Within(0.0000000001));
            // 1.11 * 0 = 0
            Assert.That(0, Is.EqualTo(MathFuncs.Multiplication(1.11, 0)).Within(0.0000000001));
            // 2.22 * 2.22 = 4.9284
            Assert.That(4.9284, Is.EqualTo(MathFuncs.Multiplication(2.22, 2.22)).Within(0.0000000001));
            // 2.22 * (-2.22) = -4.9284
            Assert.That(-4.9284, Is.EqualTo(MathFuncs.Multiplication(2.22, -2.22)).Within(0.0000000001));
            // (-2.22) * (-2.22) = 4.9284
            Assert.That(4.9284, Is.EqualTo(MathFuncs.Multiplication(-2.22, -2.22)).Within(0.0000000001));
            // 20000.22222 * 20000.22222 = 400008888.8493817284
            Assert.That(400008888.8493817284, Is.EqualTo(MathFuncs.Multiplication(20000.22222, 20000.22222)).Within(0.0000000001));
            // 20000.22222 * (-20000.22222) = -400008888.8493817284
            Assert.That(-400008888.8493817284, Is.EqualTo(MathFuncs.Multiplication(20000.22222, -20000.22222)).Within(0.0000000001));
            // overflow tests
            Assert.That(MathFuncs.Multiplication(double.MaxValue, 1.01), Throws.Exception);
            Assert.That(MathFuncs.Multiplication(-1.01, double.MaxValue), Throws.Exception);
            Assert.That(MathFuncs.Multiplication(double.MaxValue, double.MaxValue), Throws.Exception);
        }

        [Test]
        public void DivisionTest()
        {
            // 1 / 0 = X
            Assert.That(MathFuncs.Division(1, 0), Throws.Exception);
            // 0 / 1 = 0
            Assert.That(0, Is.EqualTo(MathFuncs.Division(0, 1)).Within(0.0000000001));
            // 2 / 1 = 2
            Assert.That(2, Is.EqualTo(MathFuncs.Division(2, 1)).Within(0.0000000001));
            // 2 / 2 = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Division(2, 2)).Within(0.0000000001));
            // 2 / (-2) = -1
            Assert.That(-1, Is.EqualTo(MathFuncs.Division(2, -2)).Within(0.0000000001));
            // (-2) / (-2) = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Division(-2, -2)).Within(0.0000000001));
            // 2 / 0.5 = 4
            Assert.That(4, Is.EqualTo(MathFuncs.Division(2, 0.5)).Within(0.0000000001));
            // 2.222 / 1.11 = 2
            Assert.That(2.0018018018, Is.EqualTo(MathFuncs.Division(2.222, 1.11)).Within(0.0000000001));
            // 2.22 / 2.22 = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Division(2.22, 2.22)).Within(0.0000000001));
            // 2.22 / (-2.22) = -1
            Assert.That(-1, Is.EqualTo(MathFuncs.Division(2.22, -2.22)).Within(0.0000000001));
            // (-2.22) / (-2.22) = 1
            Assert.That(1, Is.EqualTo(MathFuncs.Division(-2.22, -2.22)).Within(0.0000000001));
            // 1000000000.111111111 / 20000.2222 = 49999.4445117270
            Assert.That(49999.4445117270, Is.EqualTo(MathFuncs.Division(1000000000.111111111, 20000.2222)).Within(0.0000000001));
            // overflow tests
            Assert.That(MathFuncs.Division(double.MaxValue, 0.99), Throws.Exception);
            Assert.That(MathFuncs.Division(-0.99, double.MaxValue), Throws.Exception);
        }

        [Test]
        public void FactorialTest()
        {
            Assert.Pass();
        }

        [Test]
        public void ExponentTest()
        {
            Assert.Pass();
        }

        [Test]
        public void RootTest()
        {
            Assert.Pass();
        }
    }
}