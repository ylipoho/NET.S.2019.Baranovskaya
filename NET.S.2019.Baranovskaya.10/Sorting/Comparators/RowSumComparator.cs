using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class RowSumComparator : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            int xSum = 0, ySum = 0;

            foreach (int num in x)
            {
                xSum += num;
            }

            foreach(int num in y)
            {
                ySum += num;
            }

            return xSum - ySum;
        }
    }
}
