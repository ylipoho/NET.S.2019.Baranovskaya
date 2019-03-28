using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDC
{
    public class GDCClass
    {

        public int GetEuclidianGDC(params int[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException();

            int result = 1;

            for (int i = 0; i < numbers.Length-1; i++)
            {
                //GetGDCForTwoNumbers?
                // ... 
            }

            return result;
        }


        public int GetSteinGDC(params int[] numbers)
        {
            int result = 1;
                
            return result;
        }

        public int GetEuclidianGDCWithWatch(out int executionTime, params int[] numbers)
        {
            int result = 1;

            return result;
        }

        public int GetSteinGDCWithWatch(out int executionTime, params int[] numbers)
        {
            int result = 1;

            return result;
        }
    }
