using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class MinRowValueComparator : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            int xMin = int.MaxValue, yMin = int.MaxValue;

            foreach (int num in x)
            {
                xMin = Math.Min(xMin, num);
            }

            foreach (int num in y)
            {
                yMin = Math.Min(yMin, num);
            }

            return xMin - yMin;
        }
    }
}
