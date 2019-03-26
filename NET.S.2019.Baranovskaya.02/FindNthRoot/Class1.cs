using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNthRoot
{
    public class FindNthRootClass
    {
        /// <summary>
        /// Returns a specified number raised to the specified power 
        /// </summary>
        /// <param name="x">a double-precision floating-point number to be raised to a power</param>
        /// <param name="power">a double-precision floating-point number that specifies a power</param>
        /// <param name="e"> max calculation error</param>
        /// <returns>the number x raised to the given power </returns>
        public double FindNthRoot(double x, int power, double e)
        {
            if (power <= 0 || e <= 0 || ( x<0 && power%2 != 0 ))
                throw new ArgumentOutOfRangeException();
            if (power == 1)
                return x;
            if (x == 1 || x == 2)
                return x;

            double n = power;
            double x0 = x / power;            
            double x1 = (1.0 / power) * ((power - 1) * x0 + x / Math.Pow(x0, power - 1));

            while (Math.Abs(x1 - x0) >= e/2)
            {
                x0 = x1;
                x1 = (1.0 / power) * (((power - 1) * x0 + x / Math.Pow(x0, power - 1)));
            }

            return x1;
        }
    }
}
