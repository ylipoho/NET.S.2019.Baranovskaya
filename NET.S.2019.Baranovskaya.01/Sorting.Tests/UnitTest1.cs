using System;
using NUnit.Framework;
using Sorting;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [TestCase(new int[] { 2, 0, 3, 1, 5 }, new int[] { 0, 1, 2, 3, 5 })]
        [TestCase(new int[] { 2, 2, 2, 2 }, new int[] { 2, 2, 2, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, new int[] { -5, -4, -3, -2, -1 })]
        public void SortArrayUsingQuickSortTest(int[] initial, int[] expected)
        {
            // Arrange
            SortingClass class1 = new SortingClass();
            // Act
            int[] actual = class1.QuickSort(initial);
            // Assert
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void NullArgumentQuickSortTest()
        {
            SortingClass class1 = new SortingClass();
            Assert.Throws<ArgumentNullException>(() => class1.QuickSort(null));
        }

        [Test]
        public void EmptyArrayQuickSortTest()
        {
            SortingClass class1 = new SortingClass();
            Assert.Throws<ArgumentException>(() => class1.QuickSort(new int[] { }));
        }

        [TestCase(new int[] { 2, 0, 3, 1, 5 }, new int[] { 0, 1, 2, 3, 5 })]
        [TestCase(new int[] { 2, 2, 2, 2 }, new int[] { 2, 2, 2, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, new int[] { -5, -4, -3, -2, -1 })]
        public void SortArrayUsingMergeSortTest(int[] initial, int[] expected)
        {
            // Arrange
            SortingClass class1 = new SortingClass();
            // Act
            int[] actual = class1.MergeSort(initial);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NullArgumentMergeSortTest()
        {
            SortingClass class1 = new SortingClass();
            Assert.Throws<ArgumentNullException>(() => class1.MergeSort(null));
        }

        [Test]
        public void EmptyArrayMergeSortTest()
        {
            SortingClass class1 = new SortingClass();
            Assert.Throws<ArgumentException>(() => class1.MergeSort(new int[] { }));
        }

    }
}