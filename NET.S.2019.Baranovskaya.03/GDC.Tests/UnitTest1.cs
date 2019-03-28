using NUnit.Framework;
using GDC;

namespace Tests
{
    public class Tests
    {
        [TestCase(12, 4, ExpectedResult = 4)]
        public int TwoParametersPositiveTest(params int[] parameters)
        {
        }

        [TestCase(12, 4, 60, ExpectedResult = 4)]
        public int ThreeParametersPositiveTest(params int[] parameters)
        {
        }
    }
}