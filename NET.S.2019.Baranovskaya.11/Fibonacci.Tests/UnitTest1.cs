namespace Tests
{
    using System;
    using System.Collections.Generic;
    using Fibonacci;
    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        private List<int> expectedList1 = new List<int>() { 1 };
        private List<int> expectedList2 = new List<int>() { 1, 1 };
        private List<int> expectedList3  = new List<int>() { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765 };
        
        [Test]
        public void GetNegativeNumber_ReturnsArgumentOutOfRangeException_GetNumbersFromFibonacciSequence()
        {
            int num = -3;
            Assert.Throws<ArgumentOutOfRangeException>(() => FibonacciClass.GetNumbersFromFibonacciSequence(num));
        }

        [Test]
        public void GetZero_ReturnsEmptyList_GetNumbersFromFibonacciSequence()
        {
            int num = 0;
            Assert.AreEqual(new List<int>(), FibonacciClass.GetNumbersFromFibonacciSequence(num));
        }

        [Test]
        public void PositiveTests_GetNumbersFromFibonacciSequence()
        {
            int num = 1;
            List<int> actual1 = FibonacciClass.GetNumbersFromFibonacciSequence(num);
            Assert.AreEqual(expectedList1, actual1);

            num = 2;
            List<int> actual2 = FibonacciClass.GetNumbersFromFibonacciSequence(num);
            Assert.AreEqual(expectedList2, actual2);

            num = 20;
            List<int> actual3 = FibonacciClass.GetNumbersFromFibonacciSequence(num);
            Assert.AreEqual(expectedList3, actual3);
        }
    }
}