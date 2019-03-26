using System;
using NUnit.Framework;
using FindNthRoot;

namespace Tests
{
    public class Tests
    {
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001,  2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void PositiveTests(double number, int power, double e, double expected)
        {
            double actual = new FindNthRootClass().FindNthRoot(number, power, e);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(8, 15, -7, -5)]// &lt;-ArgumentOutOfRangeException
        [TestCase(8, 15, -0.6, -0.1)]// &lt;-ArgumentOutOfRangeException
        public void Return_ArgumentOutOfRangeException(double number, int degree, double precision, double expected)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new FindNthRootClass().FindNthRoot(number, degree, precision));
        }
    }
}