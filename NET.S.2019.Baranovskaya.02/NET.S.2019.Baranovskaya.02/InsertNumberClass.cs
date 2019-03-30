using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNumber
{
    public class InsertNumberClass
    {
        /// <summary>
        /// Return number with changed bits
        /// </summary>
        /// <param name="number1">number for insertion bits</param>
        /// <param name="number2">number for getting bits</param>
        /// <param name="i">start position for getting bits</param>
        /// <param name="j">final position for getting bits</param>
        /// <returns></returns>
        public int InsertNumber(int number1, int number2, int i, int j)
        {
            if (i < 0 || j < 0 || i>j || i > 31 || j > 31)
                throw new ArgumentException();

            int bitNum = j - i + 1;
            int mask = 0;
            for (int k = 0; k < bitNum; k++)
            {
                mask <<= 1;
                mask |= 1;
            }

            // get bits from the second number
            int a = number2 & mask;

            for (int k = 0; k < i; k++)
            {
                mask <<= 1;
                a <<= 1;
            }
            
            // insert bits into the first number
            return (number1 & ~mask) | a;
        }
    }
}
