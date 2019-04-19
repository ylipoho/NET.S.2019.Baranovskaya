namespace Tests
{
    using System;
    using NUnit.Framework;
    using Sorting;

    public class Tests
    {
        private int[][] actualArray1 = 
        {
            new int[] { 1, 2, 3, 4, 5 },
            new int[] { 1, 2, 3, 4, 5 },
            new int[] { 1, 2, 3, 4, 5 }
        };

        private int[][] expectedArray1 = 
            {
            new int[] { 1, 2, 3, 4, 5 },
            new int[] { 1, 2, 3, 4, 5 },
            new int[] { 1, 2, 3, 4, 5 }
        };

        private int[][] actualArray2 = 
        {
            new int[] { 3, -7, -5, 1 },
            new int[] { 2, 9, 8 },
            new int[] { 0 }
        };

        private int[][] expectedArrayForSumAscendingSort = 
        {
            new int[] { 3, -7, -5, 1 },
            new int[] { 0 },
            new int[] { 2, 9, 8 }
        };

        private int[][] expectedArrayForMinValueAscendingSort = 
        {
            new int[] { 3, -7, -5, 1 },
            new int[] { 0 },
            new int[] { 2, 9, 8 }
        };

        private int[][] expectedArrayForMaxValueAscendingSort = 
        {
            new int[] { 0 },
            new int[] { 3, -7, -5, 1 },
            new int[] { 2, 9, 8 }
        };

        private int[][] expectedArrayForSumDescendingSort = 
        {
            new int[] { 2, 9, 8 },
            new int[] { 0 },
            new int[] { 3, -7, -5, 1 }
        };

        private int[][] expectedArrayForMinValueDescendingSort = 
        {
            new int[] { 2, 9, 8 },
            new int[] { 0 },
            new int[] { 3, -7, -5, 1 }
        };

        private int[][] expectedArrayForMaxValueDescendingSort = 
        {
            new int[] { 2, 9, 8 },
            new int[] { 3, -7, -5, 1 },
            new int[] { 0 }
        };
        
        [Test]
        public void NullParameterNegativeTest()
        {
            JaggedArraySortingClass.MyComparator comp = new MinRowValueComparator().Compare;

            Assert.Throws<ArgumentNullException>(() => JaggedArraySortingClass.BubbleSortWithComparator(null, comp, ascending: true));
            Assert.Throws<ArgumentNullException>(() => JaggedArraySortingClass.BubbleSortWithComparator(null, comp, ascending: false));
        }

        [Test]
        public void EmptyArrayNegativeTest()
        {
            JaggedArraySortingClass.MyComparator comp = new MinRowValueComparator().Compare;

            Assert.Throws<ArgumentException>(() => JaggedArraySortingClass.BubbleSortWithComparator(new int[][] { }, comp, ascending: true));
            Assert.Throws<ArgumentException>(() => JaggedArraySortingClass.BubbleSortWithComparator(new int[][] { }, comp, ascending: false));
        }
        
        [Test]
        public void NullComparatorNegativeTest()
        {
            JaggedArraySortingClass.MyComparator comp = null; 

            Assert.Throws<ArgumentNullException>(() => JaggedArraySortingClass.BubbleSortWithComparator(actualArray1, comp, ascending: true));
            Assert.Throws<ArgumentNullException>(() => JaggedArraySortingClass.BubbleSortWithComparator(actualArray1, comp, ascending: false));
        }

        [Test]
        public void RowSumAscendingSort()
        {
            JaggedArraySortingClass.MyComparator comp = new RowSumComparator().Compare;

            JaggedArraySortingClass.BubbleSortWithComparator(actualArray1, comp, true);
            Assert.AreEqual(expectedArray1, actualArray1);

            JaggedArraySortingClass.BubbleSortWithComparator(actualArray2, comp, true);
            Assert.AreEqual(expectedArrayForSumAscendingSort, actualArray2);
        }
        
        [Test]
        public void RowSumDescendingSort()
        {
            JaggedArraySortingClass.MyComparator comp = new RowSumComparator().Compare;

            JaggedArraySortingClass.BubbleSortWithComparator(actualArray1, comp, false);
            Assert.AreEqual(expectedArray1, actualArray1);

            JaggedArraySortingClass.BubbleSortWithComparator(actualArray2, comp, false);
            Assert.AreEqual(expectedArrayForSumDescendingSort, actualArray2);
        }

        [Test]
        public void RowMinValueAscendingSort()
        {
            JaggedArraySortingClass.MyComparator comp = new MinRowValueComparator().Compare;

            JaggedArraySortingClass.BubbleSortWithComparator(actualArray1, comp, true);
            Assert.AreEqual(expectedArray1, actualArray1);

            JaggedArraySortingClass.BubbleSortWithComparator(actualArray2, comp, true);
            Assert.AreEqual(expectedArrayForMinValueAscendingSort, actualArray2);
        }

        [Test]
        public void RowMinValueDescendingSort()
        {
            JaggedArraySortingClass.MyComparator comp = new MinRowValueComparator().Compare;

            JaggedArraySortingClass.BubbleSortWithComparator(actualArray1, comp, false);
            Assert.AreEqual(expectedArray1, actualArray1);

            JaggedArraySortingClass.BubbleSortWithComparator(actualArray2, comp, false);
            Assert.AreEqual(expectedArrayForMinValueDescendingSort, actualArray2);
        }

        [Test]
        public void RowMaxValueAscendingSort()
        {
            JaggedArraySortingClass.MyComparator comp = new MaxRowValueComparator().Compare;

            JaggedArraySortingClass.BubbleSortWithComparator(actualArray1, comp, true);
            Assert.AreEqual(expectedArray1, actualArray1);

            JaggedArraySortingClass.BubbleSortWithComparator(actualArray2, comp, true);
            Assert.AreEqual(expectedArrayForMaxValueAscendingSort, actualArray2);
        }

        [Test]
        public void RowMaxValueDescendingSort()
        {
            JaggedArraySortingClass.MyComparator comp = new MaxRowValueComparator().Compare;

            JaggedArraySortingClass.BubbleSortWithComparator(actualArray1, comp, false);
            Assert.AreEqual(expectedArray1, actualArray1);

            JaggedArraySortingClass.BubbleSortWithComparator(actualArray2, comp, false);
            Assert.AreEqual(expectedArrayForMaxValueDescendingSort, actualArray2);
        }
    }
}