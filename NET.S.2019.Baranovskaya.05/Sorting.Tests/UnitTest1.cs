using NUnit.Framework;
using Sorting;
using System;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        int[][] actualArray1 = {
            new int[] { 1, 2, 3, 4, 5 }, 
            new int[] { 1, 2, 3, 4, 5 },
            new int[] { 1, 2, 3, 4, 5 }
        };

        int[][] expectedArray1 = {
            new int[] { 1, 2, 3, 4, 5 },
            new int[] { 1, 2, 3, 4, 5 },
            new int[] { 1, 2, 3, 4, 5 }
        };

        int[][] actualArray2 = {
            new int[] { 3, -7, -5, 1 },
            new int[] { 2, 9, 8},
            new int[] { 0 }
        };

        int[][] expectedArrayForSumAscendingSort = {
            new int[] { 3, -7, -5, 1 },
            new int[] { 0 },
            new int[] { 2, 9, 8 }
        };

        int[][] expectedArrayForMinValueAscendingSort = {
            new int[] { 3, -7, -5, 1},
            new int[] { 0 },
            new int[] { 2, 9, 8}
        };

        int[][] expectedArrayForMaxValueAscendingSort = {
            new int[] { 0 },
            new int[] { 3, -7, -5, 1},
            new int[] { 2, 9, 8 }
        };

        int[][] expectedArrayForSumDescendingSort = {
            new int[] { 2, 9, 8 },
            new int[] { 0 },
            new int[] { 3, -7, -5, 1 }
        };

        int[][] expectedArrayForMinValueDescendingSort = {
            new int[] { 2, 9, 8},
            new int[] { 0 },
            new int[] { 3, -7, -5, 1}
        };

        int[][] expectedArrayForMaxValueDescendingSort = {
            new int[] { 2, 9, 8 },
            new int[] { 3, -7, -5, 1},
            new int[] { 0 }
        };

        [Test]
        public void NullParameterNegativeTest()
        {
            Assert.Throws<ArgumentNullException>(() => JaggedArraySortingClass.BubbleSortByRowSum(null, ascending: true));
            Assert.Throws<ArgumentNullException>(() => JaggedArraySortingClass.BubbleSortByRowSum(null, ascending: false));
        }

        [Test]
        public void EmptyArrayNegativeTest()
        {
            Assert.Throws<ArgumentException>(() => JaggedArraySortingClass.BubbleSortByRowSum(new int[][] { }, ascending: true));
            Assert.Throws<ArgumentException>(() => JaggedArraySortingClass.BubbleSortByRowSum(new int[][] { }, ascending: false));
        }

        [Test]
        public void RowSumAscendingSort()
        {
            JaggedArraySortingClass.BubbleSortByRowSum(actualArray1, true);
            Assert.AreEqual(expectedArray1, actualArray1);

            JaggedArraySortingClass.BubbleSortByRowSum(actualArray2, true);
            Assert.AreEqual(expectedArrayForSumAscendingSort, actualArray2);
        }

        [Test]
        public void RowSumDescendingSort()
        {
            JaggedArraySortingClass.BubbleSortByRowSum(actualArray1, false);
            Assert.AreEqual(expectedArray1, actualArray1);

            JaggedArraySortingClass.BubbleSortByRowSum(actualArray2, false);
            Assert.AreEqual(expectedArrayForSumDescendingSort, actualArray2);
        }

        [Test]
        public void RowMinValueAscendingSort()
        {
            JaggedArraySortingClass.BubbleSortByMinRowValue(actualArray1, true);
            Assert.AreEqual(expectedArray1, actualArray1);

            JaggedArraySortingClass.BubbleSortByMinRowValue(actualArray2, true);
            Assert.AreEqual(expectedArrayForMinValueAscendingSort, actualArray2);
        }

        [Test]
        public void RowMinValueDescendingSort()
        {
            JaggedArraySortingClass.BubbleSortByMinRowValue(actualArray1, false);
            Assert.AreEqual(expectedArray1, actualArray1);

            JaggedArraySortingClass.BubbleSortByMinRowValue(actualArray2, false);
            Assert.AreEqual(expectedArrayForMinValueDescendingSort, actualArray2);
        }

        [Test]
        public void RowMaxValueAscendingSort()
        {
            JaggedArraySortingClass.BubbleSortByMaxRowValue(actualArray1, true);
            Assert.AreEqual(expectedArray1, actualArray1);

            JaggedArraySortingClass.BubbleSortByMaxRowValue(actualArray2, true);
            Assert.AreEqual(expectedArrayForMaxValueAscendingSort, actualArray2);
        }

        [Test]
        public void RowMaxValueDescendingSort()
        {
            JaggedArraySortingClass.BubbleSortByMaxRowValue(actualArray1, false);
            Assert.AreEqual(expectedArray1, actualArray1);

            JaggedArraySortingClass.BubbleSortByMaxRowValue(actualArray2, false);
            Assert.AreEqual(expectedArrayForMaxValueDescendingSort, actualArray2);
        }

    }
}