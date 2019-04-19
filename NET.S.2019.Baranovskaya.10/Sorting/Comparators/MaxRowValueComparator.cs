using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class MaxRowValueComparator : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            int xMax = int.MinValue, yMax = int.MinValue;

            foreach (int num in x)
            {
                xMax = Math.Max(xMax, num);
            }

            foreach (int num in y)
            {
                yMax = Math.Max(yMax, num);
            }

            return xMax - yMax;
        }
    }
}
