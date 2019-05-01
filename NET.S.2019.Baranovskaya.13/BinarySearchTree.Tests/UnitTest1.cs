using NUnit.Framework;
using BinarySearchTreeTask;
using BookListService;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Initialize()
        {
            Book book1 = new Book(123, "Николай Некрасов", "Сборник поэм", "Питер", 2016, 102, 23.12);
            Book book2 = new Book(124, "Михаил Булгаков", "Мастер и Маргарита", "АСТ", 2011, 416, 25.05);
            Book book3 = new Book(125, "Федор Достоевский", "Идиот", "Азбука", 2012, 100, 9.44);
            Book book4 = new Book(126, "Николай Гоголь", "Ночь перед Рождеством", "Росмэн-пресс", 2016, 96, 4.53);
            Book book5 = new Book(127, "Евгений Замятин", "Мы", "Азбука", 2018, 288, 9.44);
            
            Point point1, point2;
            point1.x = 2;
            point1.y = 7;

            point2.x = 13;
            point2.y = 4;
            

            expectedIntList1 = new List<int>() { 4, 2, 1, 3, 6, 5, 7 };
            expectedIntList2 = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            expectedIntList3 = new List<int>() { 1, 3, 2, 5, 7, 6, 4 };

            expectedStringList = new List<string>() { "abc", "cda", "dca", "adc", "asc" };
            expectedBookList = new List<Book>() { book1, book2, book3, book4, book5 };
            expectedPointList = new List<Point>() { point1, point2 };
        }

        struct Point
        {
            public int x;
            public int y;
        }

        List<int> actualIntList, expectedIntList1, expectedIntList2, expectedIntList3;
        List<string> expectedStringList;
        List<Book> expectedBookList; 
        List<Point> expectedPointList; 

        BinarySearchTree<int> IntTree;
        BinarySearchTree<string> StringTree;
        BinarySearchTree<Book> BookTree;
        BinarySearchTree<Point> PointTree;

        /*[Test]
        public void IntTreeTest()
        {
            IntTree = new BinarySearchTree<int>(new List<int>() { 4, 2, 3, 6, 7, 1, 5 }, null);

            Assert.AreEqual(expectedIntList1, IntTree.PostorderTraversal());
            Assert.AreEqual(expectedIntList2, IntTree.InorderTraversal());
            Assert.AreEqual(expectedIntList3, IntTree.PreorderTraversal());
        }

        [Test]
        public void StringTreeTest()
        {
            Assert.AreEqual(expectedIntList, StringTree.InorderTraversal());
            Assert.AreEqual(expectedIntList, StringTree.PreorderTraversal());
            Assert.AreEqual(expectedIntList, StringTree.PostorderTraversal());
        }

        [Test]
        public void BookTreeTest()
        {
            Assert.AreEqual(expectedIntList, BookTree.InorderTraversal());
            Assert.AreEqual(expectedIntList, BookTree.PreorderTraversal());
            Assert.AreEqual(expectedIntList, BookTree.PostorderTraversal());
        }

        [Test]
        public void PointTreeTest()
        {
            Assert.AreEqual(expectedIntList, PointTree.InorderTraversal());
            Assert.AreEqual(expectedIntList, PointTree.PreorderTraversal());
            Assert.AreEqual(expectedIntList, PointTree.PostorderTraversal());
        }*/
    }
}