using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNthRoot
{
    public class FindNthRootClass
    {

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
