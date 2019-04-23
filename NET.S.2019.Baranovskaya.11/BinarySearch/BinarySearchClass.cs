using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public static class BinarySearchClass<T>
    {
        /// <summary>
        /// Finds given element in given list
        /// </summary>
        /// <param name="inputList">input list for searching</param>
        /// <param name="element">desired element</param>
        /// <param name="comparater">element comparison rule</param>
        /// <returns></returns>
        public static int FindNumber(List<T> inputList, T element, IComparer<T> comparater)
        {
            if (inputList == null || comparater == null)
            {
                throw new ArgumentNullException();
            }

            if (inputList.Count == 0)
            {
                throw new ArgumentException();
            }
            
            int leftIndex = 0, rightIndex = inputList.Count, middle = 0;

            while (leftIndex <= rightIndex)
            {
                middle = (leftIndex + rightIndex) / 2;

                if (comparater.Compare(element, inputList[middle]) == 0)
                {
                    return middle;
                }

                if (comparater.Compare(element, inputList[middle]) > 0)
                {
                    leftIndex = middle + 1;
                }
                else
                {
                    rightIndex = middle - 1;
                }
            }

            return middle;
        }       
    }
}
