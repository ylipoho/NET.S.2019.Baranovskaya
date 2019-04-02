using NUnit.Framework;
using Polynomials;

namespace Tests
{
    public class Tests
    {
       
        [Test]
        public void ToStringTest()
        {
            string expected = "2x^5-3x^4+4x^3+5x^2-6";
            Polynomial polynomial = new Polynomial(2, -3, 4, 5, 0, -6);
            string actual = polynomial.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}