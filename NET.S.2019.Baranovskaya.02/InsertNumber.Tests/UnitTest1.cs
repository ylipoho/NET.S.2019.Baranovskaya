using Microsoft.VisualStudio.TestTools.UnitTesting;
using InsertNumber;
using System;

namespace InsertNumber.Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Get_Negative_i_Return_ArgumentExceptionTest()
        {
            Assert.ThrowsException<ArgumentException>(() => new InsertNumberClass().InsertNumber(8, 15, -2, 8));
        }

        [TestMethod]
        public void Get_Negative_j_Return_ArgumentExceptionTest()
        {
            Assert.ThrowsException<ArgumentException>(() => new InsertNumberClass().InsertNumber(8, 15, 2, -8));
        }

        [TestMethod]
        public void Get_i_More_Then_j_Return_ArgumentExceptionTest()
        {
            Assert.ThrowsException<ArgumentException>(() => new InsertNumberClass().InsertNumber(8, 15, 8, 2));
        }


        [TestMethod]
        public void Get_8_15_3_8_Return_120_Test()
        {
            int expected = 120;
            int actual = new InsertNumberClass().InsertNumber(8, 15, 3, 8);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Get_15_15_0_0_Return_15_Test()
        {
            int expected = 15;
            int actual = new InsertNumberClass().InsertNumber(15, 15, 0, 0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Get_8_15_0_0_Return_9_Test()
        {
            int expected = 9;
            int actual = new InsertNumberClass().InsertNumber(8, 15, 0, 0);
            Assert.AreEqual(expected, actual);
        }
    }
}
