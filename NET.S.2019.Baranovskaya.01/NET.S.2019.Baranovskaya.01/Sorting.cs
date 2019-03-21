using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    /// <summary>
    /// This class contains functions for sorting one-dimensional integer arrays
    /// </summary>
    public class SortingClass
    {
        /// <summary>
        /// Recursive merge sort function
        /// </summary>
        /// <param name="array">initial array</param>
        /// <exception cref="ArgumentNullException">Thrown when parameter is null reference</exception> 
        /// <exception cref="ArgumentException">Thrown when parameter is empty array</exception> 
        /// <returns>sorted integer array</returns>
        public int[] MergeSort(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length == 0)
                throw new ArgumentException();
            if (array.Length == 1)
                return array;

            int pivotElement = array.Length / 2;
            int[] firstPart = array.Take(pivotElement).ToArray();
            int[] secondPart = array.Skip(pivotElement).ToArray();
            return Merge(MergeSort(firstPart), MergeSort(secondPart));
        }

        /// <summary>
        /// Merging two integer arrays 
        /// </summary>
        /// <param name="array1">first array part</param>
        /// <param name="array2">second array part</param>
        /// <returns>merged integer array</returns>
        int[] Merge(int[] array1, int[] array2)
        {
            int a = 0, b = 0;
            int[] merged = new int[array1.Length + array2.Length];
            for (int i = 0; i < array1.Length + array2.Length; i++)
            {
                if (b < array2.Length && a < array1.Length)
                    if (array1[a] > array2[b] && b < array2.Length)
                        merged[i] = array2[b++];
                    else
                        merged[i] = array1[a++];
                else
                    if (b < array2.Length)
                    merged[i] = array2[b++];
                else
                    merged[i] = array1[a++];
            }
            return merged;
        }


        /// <summary>
        /// Sorts array using quick sort
        /// </summary>
        /// <param name="array">initial array</param>
        /// <exception cref="ArgumentNullException">Thrown when parameter is null reference</exception> 
        /// <exception cref="ArgumentException">Thrown when parameter is empty array</exception> 
        /// <returns> sorted integer array </returns>
        public int[] QuickSort(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length == 0)
                throw new ArgumentException();

            QuickSort(ref array, 0, array.Length - 1);
            return array;
        }

        /// <summary>
        /// Recursive quick sort function
        /// </summary>
        /// <param name="array">initial array</param>
        /// <param name="lowIndex">first index</param>
        /// <param name="highIndex">last index</param>
        void QuickSort(ref int[] array, int lowIndex, int highIndex)
        {
            int i = lowIndex;
            int j = highIndex;
            int pivotElement = array[lowIndex + (highIndex - lowIndex) / 2];

            while (i <= j)
            {
                while (array[i] < pivotElement)
                    i++;
                while (array[j] > pivotElement)
                    j--;
                if (i <= j)
                {
                    int buf = array[i];
                    array[i] = array[j];
                    array[j] = buf;
                    i++;
                    j--;
                }
            };

            if (lowIndex < j)
                QuickSort(ref array, lowIndex, j);
            if (i < highIndex)
                QuickSort(ref array, i, highIndex);
        }

    }
}
