namespace BookConsoleApplication
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using BookListService;
    using BookListService.SortingTags;

    public class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book(123, "Николай Некрасов", "Сборник поэм", "Питер", 2016, 102, 23.12);

            book.ToString();
            DescriptionDecorator dd = new DescriptionDecorator(book1);
            dd.ToString();

            Console.WriteLine(book1.ToString());

            Console.WriteLine(book1.ToString("n a ph pr", new CultureInfo("en-US")));
            Console.WriteLine(book1.ToString("i n ph y", null));

            

            Console.WriteLine("Try to print 5 books...");

            bookService.PrintBookList();


            Book book6 = new Book(128, "Борис Пастернак", "Доктор Живаго", "Азбука", 2013, 608, 9.97);

            Console.WriteLine("Try to remove a book that the book list doesn't contain...");

            try
            {
                bookService.RemoveBook(book6);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            Console.WriteLine("Try to print 1 book with Name = 'Сборник поэм'...");
            List<Book> bookList = bookService.FindBookByTag(new Author(), "Сборник поэм");

            foreach (Book book in bookList)
            {
                Console.WriteLine(book.ToString());
            }

            Console.WriteLine("Try to print 2 book with price = 9,44...");

            List<Book> bookList2 = bookService.FindBookByTag(new Price(), 9.44);

            foreach (Book book in bookList2)
            {
                Console.WriteLine(book.ToString());
            }

            BookService bookService2 = new BookService();

            bookService.SaveBookListStorageFromBinaryFile(@"C:\Users\admin\Documents\GitHub\NET.S.2019.Baranovskaya\NET.S.2019.Baranovskaya.08\books.bin");

            bookService2.LoadBookListStorageFromBinaryFile(@"C:\Users\admin\Documents\GitHub\NET.S.2019.Baranovskaya\NET.S.2019.Baranovskaya.08\books.bin");
            Console.WriteLine();

            Console.WriteLine("Try to print 4 books...");

            bookService2.PrintBookList();

            Console.WriteLine("Try to sort 4 books by price...");

            //List<Book> bookList3 = 
                bookService2.SortBooksByTag(new Price());

            bookService2.PrintBookList();
            Console.ReadKey();
        }
    }
}
