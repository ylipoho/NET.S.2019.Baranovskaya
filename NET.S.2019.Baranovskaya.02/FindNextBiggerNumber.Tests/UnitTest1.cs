using NUnit.Framework;
using FindNextBigger;

namespace Tests
{
    public class Tests
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = null)]
        [TestCase(20, ExpectedResult = null)]
        public int? FindNextBiggerNumberPositiveTests(int inputNumber)
        {
            return FindNextBiggerNumberClass.FindNextBiggerNumber(inputNumber);            
        }
    }
}