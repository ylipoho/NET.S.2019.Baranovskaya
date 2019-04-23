using NUnit.Framework;
using BinarySearch;
using System.Collections.Generic;
using System;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        List<int> ints = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 9, 10, 12 };
        List<double> doubles = new List<double>() { 1.23, 2.45, 8.10, 10.222, 17.8 };
        List<string> strings = new List<string>() { "a", "b", "s", "t", "w" };
        
        [Test]
        public void NegativeTests()
        {
            Assert.Throws<ArgumentNullException>(() => BinarySearchClass<int>.FindNumber(ints, 3,  null));
            Assert.Throws<ArgumentNullException>(() => BinarySearchClass<int>.FindNumber(null, 3, new Comparators()));
            Assert.Throws<ArgumentNullException>(() => BinarySearchClass<int>.FindNumber(new List<int> { }, 3, new Comparators()));
        }


        public void PositiveTests()
        {
            int actual = BinarySearchClass<double>.FindNumber(doubles, 2.45, new Comparators());
            int expected = 1;
            Assert.AreEqual(expected, actual);

            actual = BinarySearchClass<int>.FindNumber(ints, 3, new Comparators());
            expected = 2;
            Assert.AreEqual(expected, actual);

            actual = BinarySearchClass<string>.FindNumber(strings, "w", new Comparators());
            expected = 4;
            Assert.AreEqual(expected, actual);
        }

        
    }
}