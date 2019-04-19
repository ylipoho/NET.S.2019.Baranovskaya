namespace Tests
{
    using System;
    using NUnit.Framework;
    using GCD;

    public class Tests
    {
        #region Euclidean methods tests

        [TestCase(12, 4, ExpectedResult = 4)]
        [TestCase(11, 4, ExpectedResult = 1)]
        [TestCase(0, 10, ExpectedResult = 10)]
        [TestCase(13, 0, ExpectedResult = 13)]
        [TestCase(15, 15, ExpectedResult = 15)]
        public int TwoParametersPositiveEuclideanTest(params int[] parameters)
        {
             int result = GCDClass.GetEuclidianGCD(parameters);
            return result;
        }


        [TestCase(12, 4, 60, ExpectedResult = 4)]
        [TestCase(12, 0, 60, ExpectedResult = 12)]
        [TestCase(0, 4, 60, ExpectedResult = 4)]
        [TestCase(12, 0, 0, ExpectedResult = 12)]
        [TestCase(-11, 0, 0, ExpectedResult = 11)]
        [TestCase(13, 14, 25, 60, ExpectedResult = 1)]
        [TestCase(0, 0, 25, 60, ExpectedResult = 5)]
        [TestCase(60, 60, 1, 60, ExpectedResult = 1)]
        [TestCase(-10, -100, 100, 30, ExpectedResult = 10)]
        [TestCase(30, 6, 27, 60, 15, -30, 6, ExpectedResult = 3)]
        public int ThreeOrMoreParametersPositiveEuclideanTest(params int[] parameters)
        {
            return GCDClass.GetEuclidianGCD(parameters);
        }


        public void NullParametersNegativeEuclideanTest(params int[] parameters)
        {
            Assert.Throws<ArgumentNullException>(() => GCDClass.GetEuclidianGCD(null));
        }

        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-10)]
        [TestCase(0, 0)]
        [TestCase(0, 0, 0)]
        public void NegativeTest(params int[] parameters)
        {
            Assert.Throws<ArgumentException>(() => GCDClass.GetEuclidianGCD(parameters));
        }

        #endregion


        #region Stein methods tests 

        [TestCase(12, 4, ExpectedResult = 4)]
        [TestCase(11, 4, ExpectedResult = 1)]
        [TestCase(0, 10, ExpectedResult = 10)]
        [TestCase(13, 0, ExpectedResult = 13)]
        [TestCase(15, 15, ExpectedResult = 15)]
        [TestCase(1, 0, ExpectedResult = 1)]
        public int TwoParametersPositiveSteinTest(params int[] parameters)
        {
            int result = GCDClass.GetSteinGCD(parameters);
            return result;
        }


        [TestCase(12, 4, 60, ExpectedResult = 4)]
        [TestCase(-12, 4, 60, ExpectedResult = 4)]
        [TestCase(12, 0, 60, ExpectedResult = 12)]
        [TestCase(0, 4, 60, ExpectedResult = 4)]
        [TestCase(12, 0, 0, ExpectedResult = 12)]
        [TestCase(-11, 0, 0, ExpectedResult = 11)]
        [TestCase(13, 14, 25, 60, ExpectedResult = 1)]
        [TestCase(0, 0, 25, 60, ExpectedResult = 5)]
        [TestCase(60, 60, 1, 60, ExpectedResult = 1)]
        [TestCase(-10, -100, 100, 30, ExpectedResult = 10)]
        [TestCase(30, 6, 27, 60, 15, 30, 6, ExpectedResult = 3)]
        public int ThreeOrMoreParametersPositiveSteinTest(params int[] parameters)
        {
            return GCDClass.GetSteinGCD(parameters);
        }


        public void NullParametersNegativeSteinTest(params int[] parameters)
        {
            Assert.Throws<ArgumentNullException>(() => GCDClass.GetSteinGCD(null));
        }

        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-10)]
        [TestCase(0, 0)]
        [TestCase(0, 0, 0)]
        public void NegativeSteinTest(params int[] parameters)
        {
            Assert.Throws<ArgumentException>(() => GCDClass.GetSteinGCD(parameters));
        }

        #endregion
    }
}