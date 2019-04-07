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
        
        [Test]
        public void EqualsTest()
        {
            Polynomial p1 = new Polynomial(2, 3, 4);
            Polynomial p2 = new Polynomial(2, 3, 4);
            Polynomial p3 = new Polynomial(4, 5, 6);
            
            Assert.True(p1.Equals(p2));
            Assert.False(p1.Equals(p3));
        }

        [Test]
        public void SumTest()
        {
            Polynomial p1 = new Polynomial(2, 3, 4);
            Polynomial p2 = new Polynomial(-3, 9, 2);
            Polynomial expectedPolynomial = new Polynomial(-1, 12, 6);
            
            Assert.AreEqual(expectedPolynomial, (p1+p2));
        }

        [Test]
        public void SubstractionTest()
        {
            Polynomial p1 = new Polynomial(2, 3, 4);
            Polynomial p2 = new Polynomial(-3, 9, 2);
            Polynomial expectedPolynomial = new Polynomial(5, -6, 2);

            Assert.AreEqual(expectedPolynomial, (p1 - p2));
        }

        [Test]
        public void MultiplicationTest()
        {
            Polynomial p1 = new Polynomial(2, 3, 4);
            double value = 5;
            Polynomial expectedPolynomial = new Polynomial(10, 15, 20);

            Assert.AreEqual(expectedPolynomial, (p1*value));
            Assert.AreEqual(expectedPolynomial, (value*p1));
        }
    }
}