using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomials
{
    public sealed class Polynomial
    {
        private int[] Array { get; }

        public Polynomial(params int[] coeffs)
        {
            Array = new int[coeffs.Length];
            for (int i = 0; i< coeffs.Length; i++)
            {
                Array[i] = coeffs[i];
            }
        }

        public int this [int index]
        {
            get { return Array[index]; }
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation
        /// </summary>
        /// <returns>string representation of the value</returns>
        public override string ToString()
        {
            int length = Array.Length;
            if (length == 0)
            {
                return "";
            }

            if (length == 1)
            {
                return this[0].ToString();
            }
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < length - 1; i++)
            {
                if (this[i] != 0)
                {
                    string sign;
                    if (this[i] > 0) // +
                    {
                        sign = i != 0 ? "+" : "";
                        result.AppendFormat("{0}{1}x^{2}", sign, this[i], (length - i - 1).ToString());
                    }
                    else // -
                    {
                        result.AppendFormat("{0}x^{1}", this[i], (length - i - 1).ToString());
                    }                    
                }
            }
            string lastSign = this[length - 1] > 0 ? "+" : "";
            return result.AppendFormat("{0}{1}", lastSign, this[length - 1]).ToString();

        }
    }
}
