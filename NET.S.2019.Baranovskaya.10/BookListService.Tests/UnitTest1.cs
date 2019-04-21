using NUnit.Framework;
using BookListService;
using System.Globalization;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        Book book = new Book(123, "Николай Некрасов", "Сборник поэм", "Питер", 2016, 102, 23.12);

        string expected1 = "isbn: 123, author: Николай Некрасов, name: 'Сборник поэм', publising house: 'Питер', year: 2016, pages: 102, price: 23,12";
        string expected2 = "name: Сборник поэм, author: Николай Некрасов, publishing house: Питер, price: 23.12";
        string expected3 = "ISBN: 123, name: Сборник поэм, publishing house: Питер, year: 2016";
        string expected4 = "ISBN 123. Full description. The book 'Сборник поэм' was written by Николай Некрасов. Was published by 'Питер' publishing house in 2016 year. Number of pages in 'Сборник поэм' is 102. You can buy this book for 23,12";

        [Test]
        public void ToStringTest()
        {
            string actual = book.ToString();
            Assert.AreEqual(expected1, actual);
            
            actual = book.ToString("n a ph pr", new CultureInfo("en-US"));
            Assert.AreEqual(expected2, actual);

            actual = book.ToString("i n ph y", null);
            Assert.AreEqual(expected3, actual);

            DescriptionDecorator dd = new DescriptionDecorator(book);            
            actual = dd.ToString();
            Assert.AreEqual(expected4, actual);
        }
    }
}