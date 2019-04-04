using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    /// <summary>
    /// Includes method for GDC calculating
    /// </summary>
    public class GCDClass
    {
        /// <summary>
        /// Returns GCD for two or more integer numbers using Euclidean algorithm
        /// </summary>
        /// <param name="numberArray">input array of integer numbers</param>
        /// <returns>great common divisor</returns>
        /// <exception cref="ArgumentException"> if both parameters are zero </exception>
        public static int GetEuclidianGCD(params int[] numberArray)
        {
            if (numberArray == null)
            {
                throw new ArgumentNullException();
            }

            if (numberArray.Length < 2)
            {
                throw new ArgumentException();
            }

            List<int> numbers = new List<int>();

            for (int i = 0; i < numberArray.Length; i++)
            {
                if (numberArray[i] == 1)
                {
                    return 1;
                }

                if (numberArray[i] != 0)
                {
                    numbers.Add(numberArray[i]);
                }
            }

            if (numbers.Count == 0)
            {
                throw new ArgumentException();
            }

            if (numbers.Count == 1)
            {
                return Math.Abs(numbers[0]);
            }

            int gdc = GetEuclideanGCDForTwoNumbers(numbers[0], numbers[1]);
            
            for (int i = 2; i < numbers.Count; i++)
            {
                if (numbers[i] == 0)
                {
                    continue;
                }

                if (gdc != 1)
                {
                    gdc = GetEuclideanGCDForTwoNumbers(gdc, numbers[i]);
                }
                else
                {
                    break;
                }
            }

            return gdc;
        }

        /// <summary>
        /// Returns GCD for two or more integer numbers
        /// </summary>
        /// <param name="numberArray">input array of integer numbers</param>
        /// <returns>great common divisor</returns>
        /// <exception cref="ArgumentException"> if both parameters are zero </exception>
        public static int GetSteinGCD(params int[] numberArray)
        {
            if (numberArray == null)
            {
                throw new ArgumentNullException();
            }

            if (numberArray.Length < 2)
            { 
                throw new ArgumentException();
            }
            
            List<int> numbers = new List<int>();

            for (int i = 0; i < numberArray.Length; i++)
            {
                if (numberArray[i] == 1)
                {
                    return 1;
                }

                if (numberArray[i] != 0)
                {
                    numbers.Add(numberArray[i]);
                }
            }

            if (numbers.Count == 0)
            {
                throw new ArgumentException();
            }

            if (numbers.Count == 1)
            {
                return Math.Abs(numbers[0]);
            }

            int gdc = GetSteinGCDForTwoNumbers(numbers[0], numbers[1]);

            for (int i = 2; i < numbers.Count; i++)
            {
                if (numbers[i] == 0)
                {
                    continue;
                }

                if (gdc != 1)
                {
                    gdc = GetSteinGCDForTwoNumbers(gdc, numbers[i]);
                }
                else
                {
                    break;
                }
            }

            return gdc;
        }

        /// <summary>
        /// Calculates GCD for two or more integer numbers using Euclidean algorithm. Out parameter returns method execution time
        /// </summary>
        /// <param name="executionTime">method execution time in milliseconds</param>
        /// <param name="numbers">input numbers for calculation</param>
        /// <returns>GCD for two or more integer numbers </returns>
        public static int GetEuclidianGDDWithWatch(out long executionTime, params int[] numbers)
        {
            GetEuclidianGCD(numbers);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int result = GetEuclidianGCD(numbers);
            watch.Stop();
            executionTime = watch.ElapsedMilliseconds;
            
            return result;
        }

        /// <summary>
        /// Calculates GCD for two or more integer numbers using Stein algorithm. Out parameter returns method execution time
        /// </summary>
        /// <param name="executionTime">method execution time in milliseconds</param>
        /// <param name="numbers">input numbers for calculation</param>
        /// <returns>GCD for two or more integer numbers </returns>
        public static int GetSteinGCDWithWatch(out long executionTime, params int[] numbers)
        {
            GetSteinGCD(numbers);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int result = GetSteinGCD(numbers);
            watch.Stop();
            executionTime = watch.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// Returns GCD for two integer numbers using Euclidean algorithm
        /// </summary>
        /// <param name="a">first 32-bits integer number</param>
        /// <param name="b">second 32-bits integer number</param>
        /// <returns>great common divisor</returns>
        private static int GetEuclideanGCDForTwoNumbers(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == b)
            {
                return a;
            }

            if (a > b && a % b == 0)
            {
                return b;
            }

            if (b > a && b % a == 0)
            {
                return a;
            }

            int buf;

            while (b != 0)
            {
                buf = a % b;
                a = b;
                b = buf;
            }

            return a;
        }

        /// <summary>
        /// Returns GCD for two integer numbers using Stein algorithm
        /// </summary>
        /// <param name="a">first 32-bits integer number</param>
        /// <param name="b">second 32-bits integer number</param>
        /// <returns>great common divisor</returns>
        private static int GetSteinGCDForTwoNumbers(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == b)
            {
                return a;
            }

            int shift;

            /* Вычисление shift = lg K, где K — наибольшая степень 2, на которую делятся без остатка a и b. */
            for (shift = 0; ((a | b) & 1) == 0; ++shift)
            {
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
            {
                a >>= 1;
            }
            
            do
            {
                while ((b & 1) == 0)
                {
                    b >>= 1;
                }
                
                if (a < b)
                {
                    b -= a;
                }
                else
                {
                    int diff = a - b;
                    a = b;
                    b = diff;
                }

                b >>= 1;
            }
            while (b != 0);

            return a << shift;
        }
    }
}