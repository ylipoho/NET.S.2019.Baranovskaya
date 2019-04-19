namespace Sorting
{
    using System;

    /// <summary>
    /// Includes sort methods for jagged arrays
    /// </summary>
    static public class JaggedArraySortingClass
    {
        /// <summary>
        /// Gets or sets attributes by witch rows are sorted
        /// </summary>
        private static int[] Tags { get; set; }

        public delegate int MyComparator(int[] x, int[] y);

        /// <summary>
        /// Sorts jagged array by sum of every row
        /// </summary>
        /// <param name="array">input array</param>
        /// <param name="Comparator">delegate that contain compare method</param>
        /// <param name="ascending">true if sort ascending</param>
        /// <exception cref="ArgumentNullException">if input parameter is null reference</exception>
        /// <exception cref="ArgumentException">if input array or Comparator is empty</exception> 
        public static void BubbleSortWithComparator(int[][] array, MyComparator Comparator, bool ascending)
        {
            if (array == null || Comparator == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }            

            for (int j = 0; j < array.Length - 1; j++)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if ((ascending && (Comparator.Invoke(array[i], array[i + 1]) > 0)) || (!ascending && (Comparator.Invoke(array[i], array[i + 1]) < 0)))
                    {
                        int[] buf = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = buf;
                    }
                }
            }
        }


        /// <summary>
        /// Sorts jagged array by sum of every row
        /// </summary>
        /// <param name="array">input array </param>
        /// <param name="ascending">true if sort ascending</param>
        /// <exception cref="ArgumentNullException">if input parameter is null reference</exception>
        /// <exception cref="ArgumentException">if input array is empty</exception>
        public static void BubbleSortByRowSum(int[][] array, bool ascending)
        { 
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }
            
            Tags = SetTagsWithSum(array);

            for (int j = 0; j < array.Length - 1; j++)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if ((ascending && (Tags[i] > Tags[i + 1])) || (!ascending && (Tags[i] < Tags[i + 1])))
                    {
                        int[] buf = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = buf;

                        int buffer = Tags[i + 1];
                        Tags[i + 1] = Tags[i];
                        Tags[i] = buffer;
                    }
                }
            }
        }

        /// <summary>
        /// Sorts jagged array by minimum value of every row
        /// </summary>
        /// <param name="array">input array</param>
        /// <param name="ascending">true if sort ascending</param>
        /// <exception cref="ArgumentNullException">if input parameter is null reference</exception>
        /// <exception cref="ArgumentException">if input array is empty</exception>
        public static void BubbleSortByMinRowValue(int[][] array, bool ascending)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            Tags = SetTagsWithMinValue(array);

            for (int j = 0; j <= array.Length - 2; j++)
            {
                for (int i = 0; i <= array.Length - 2; i++)
                {
                    if ((ascending && (Tags[i] > Tags[i + 1])) || (!ascending && (Tags[i] < Tags[i + 1])))
                    {
                        int[] buf = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = buf;

                        int buffer = Tags[i + 1];
                        Tags[i + 1] = Tags[i];
                        Tags[i] = buffer;
                    }
                }
            }
        }

        /// <summary>
        /// Sorts jagged array by max value of every row
        /// </summary>
        /// <param name="array">input array</param>
        /// <param name="ascending">true if sort ascending</param>
        /// <exception cref="ArgumentNullException">if input parameter is null reference</exception>
        /// <exception cref="ArgumentException">if input array is empty</exception>
        public static void BubbleSortByMaxRowValue(int[][] array, bool ascending)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            Tags = SetTagsWithMaxValue(array);

            for (int j = 0; j <= array.Length - 2; j++)
            {
                for (int i = 0; i <= array.Length - 2; i++)
                {
                    if ((ascending && (Tags[i] > Tags[i + 1])) || (!ascending && (Tags[i] < Tags[i + 1])))
                    {
                        int[] buf = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = buf;

                        int buffer = Tags[i + 1];
                        Tags[i + 1] = Tags[i];
                        Tags[i] = buffer;
                    }
                }
            }
        }
        
        /// <summary>
        /// Sets Tags property with sums of element
        /// </summary>
        /// <param name="array">input array </param>
        /// <returns>sorted array</returns>
        private static int[] SetTagsWithSum(int[][] array)
        {
            int[] sums = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sums[i] += array[i][j];
                }
            }

            return sums;
        }

        /// <summary>
        /// Sets Tags property with min value of every row
        /// </summary>
        /// <param name="array">input array </param>
        /// <returns>sorted array</returns>
        private static int[] SetTagsWithMinValue(int[][] array)
        {
            int[] minimums = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                int min = int.MaxValue;

                for (int j = 0; j < array[i].Length; j++)
                {
                    min = Math.Min(min, array[i][j]);
                }

                minimums[i] = min;
            }

            return minimums;
        }

        /// <summary>
        /// Sets Tags property with max value of every row
        /// </summary>
        /// <param name="array">input array </param>
        /// <returns>sorted array</returns>
        private static int[] SetTagsWithMaxValue(int[][] array)
        {
            int[] maximums = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                int max = int.MinValue;

                for (int j = 0; j < array[i].Length; j++)
                {
                    max = Math.Max(max, array[i][j]);
                }

                maximums[i] = max;
            }

            return maximums;
        }
    }
}
