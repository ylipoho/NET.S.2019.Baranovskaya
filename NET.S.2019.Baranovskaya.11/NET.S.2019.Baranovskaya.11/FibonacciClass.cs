using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    /// <summary>
    /// Contains method that calculate Fibonacci sequence
    /// </summary>
    public static class FibonacciClass
    {
        /// <summary>
        /// Returns Fibonacci sequence with a given lenght
        /// </summary>
        /// <param name="num">positive integer number</param>
        /// <returns>Fibonacci sequence</returns>
        /// <exception cref="ArgumentOutOfRangeException">if <see cref="num"/> is negative number</exception>
        public static List<int> GetNumbersFromFibonacciSequence(int num)
        {
            List<int> sequence = new List<int>(num);

            if (num < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (num == 0)
            {
                return sequence;
            }
            
            sequence.Add(1);

            if (num == 1)
            {
                return sequence;
            }

            sequence.Add(1);

            for (int i = 2; i < num; i++)
            {
                int current = sequence[i - 2] + sequence[i - 1];
                sequence.Add(current);
            }

            return sequence;
        }
    }
}
