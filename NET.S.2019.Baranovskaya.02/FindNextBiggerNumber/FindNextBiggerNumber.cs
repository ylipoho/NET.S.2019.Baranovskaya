using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNextBigger
{
    public class FindNextBiggerNumberClass
    {
        /// <summary>
        /// Returns next bigger number that consists of the same digits, if it exists, and counts execution method time
        /// </summary>
        /// <param name="number">input number</param>
        /// <param name="time"> execution method time </param>
        /// <exception cref="ArgumentException">Thrown when parameter is less then zero</exception> 
        /// <returns> next bigger number or null</returns>
        public static int? FindNextBiggerNumberWithCountExecutionTimeByWatch(int number, out long time)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int? result = FindNextBiggerNumber(number);
            watch.Stop();
            time = watch.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// Returns next bigger number that consists of the same digits, if it exists, and counts execution method time
        /// </summary>
        /// <param name="number">input number</param>
        /// <param name="time"> execution method time </param>
        /// <exception cref="ArgumentException">Thrown when parameter is less then zero</exception> 
        /// <returns> next bigger number or null</returns>
        public static int? FindNextBiggerNumberWithCountExecutionTimeByDate(int number, out TimeSpan time)
        {
            var start = DateTime.Now;
            int? result = FindNextBiggerNumber(number);
            time = DateTime.Now - start;
            return result;
        }

        /// <summary>
        /// Returns next bigger number that consists of the same digits, if it exists
        /// </summary>
        /// <param name="num">input number</param>
        /// <exception cref="ArgumentException">Thrown when parameter is less then zero</exception> 
        /// <returns> next bigger number or null</returns>
        public static int? FindNextBiggerNumber(int number)
        {
            if (number <= 0)
                throw new ArgumentException();
            if (number == Int32.MaxValue || number <= 11)
                return null;

            char[] num = number.ToString().ToCharArray();

            bool isFind = false;
            int l = num.Length - 1;

            while (!isFind && (l > 0))
            {
                l--;
                if (num[l] < num[l + 1])
                {
                    isFind = true;
                }
            }
            
            if (!isFind)
            {
                return null;
            }
            else
            {
                // just swap 2 last 
                if (l == num.Length - 2)
                {   
                    char buf = num[l];
                    num[l] = num[l + 1];
                    num[l + 1] = buf;
                }
                else
                {
                    // find  min digit( but more than [l])
                    // and swap them. sort other digits
                    List<char> symbols = new List<char>();

                    for (int j = l + 1; j < num.Length; j++)
                    {
                        symbols.Add(num[j]);
                    }
                    symbols.Sort();

                    int i = 0;
                    bool isStop = false;
                    while (i < symbols.Count && !isStop)
                    {
                        if (symbols[i] > num[l])
                        {
                            char buf = num[l];
                            num[l] = symbols[i];
                            symbols[i] = buf;
                            isStop = true;
                        }
                        i++;
                    }
                    symbols.Sort();
                    int k = 0;
                    for (int j = l + 1; j < num.Length; j++)
                    {
                        num[j] = symbols[k++];
                    }
                }
            }

            if (!Int32.TryParse(new string(num), out int result))
            {
                return null;
            }

            return result;
        }
    }
}
