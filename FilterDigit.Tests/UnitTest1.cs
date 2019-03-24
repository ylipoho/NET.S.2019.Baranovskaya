using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using FilterDigit;
using System;

namespace FilterDigit.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetNullListReturnArgumentNullException()
        {
            FilterDigitClass class1 = new FilterDigitClass();
            List<int> inputList = null;
            int digit = 3;
            Assert.ThrowsException<ArgumentNullException>(() => class1.FilterDigit(inputList, digit)); 
        }

        [TestMethod]
        public void GetNegativeDigitReturnArgumentException()
        {
            FilterDigitClass class1 = new FilterDigitClass();
            List<int> inputList = new List<int> {13, 4, 2, 6, 7, 24, 67};
            int digit = -3;
            Assert.ThrowsException<ArgumentException>(() => class1.FilterDigit(inputList, digit));
        }

        [TestMethod]
        public void GetDigitMoreThen9ReturnArgumentException()
        {
            FilterDigitClass class1 = new FilterDigitClass();
            List<int> inputList = new List<int> { 13, 4, 2, 6, 7, 24, 67 };
            int digit = 12;
            Assert.ThrowsException<ArgumentException>(() => class1.FilterDigit(inputList, digit));
        }

        [TestMethod]
        public void PositiveTest()
        {
            // Arrange
            FilterDigitClass class1 = new FilterDigitClass();
            List<int> inputList = new List<int> { 13, 4,  -4, -2, 6, -7, 24, 67, 45, 278, 0, -3  };
            int digit = 4;
            List<int> expected = new List<int> { 4, -4, 24, 45 };
            // Act
            List<int> actual = class1.FilterDigit(inputList, digit);
            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
