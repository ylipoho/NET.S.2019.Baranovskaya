using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterDigit
{
    public class FilterDigitClass
    {

        public  List<int> FilterDigit(List<int> numbers, int digit)
        {
            if (numbers == null)
                throw new ArgumentNullException();            
            if (digit > 9 || digit < 0)
                throw new ArgumentException();
            List<int> result = new List<int>();
            foreach (int number in numbers)
            {
                int item = Math.Abs(number);
                while (item > 0)
                {
                    if (item % 10 == digit)
                    {
                        result.Add(number);
                        break;
                    }
                    item /=10;
                }
            }
            return result;
        }
    }
}
