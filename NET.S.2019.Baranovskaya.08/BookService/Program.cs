namespace BookConsoleApplication
{
    using System;
    using System.Collections.Generic;
    using BookListService;

    public class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book(123, "Николай Некрасов", "Сборник поэм", "Питер", 2016, 102, 23.12);
            Book book2 = new Book(124, "Михаил Булгаков", "Мастер и Маргарита", "АСТ", 2011, 416, 25.05);
            Book book3 = new Book(125, "Федор Достоевский", "Идиот", "Азбука", 2012, 100, 9.44);
            Book book4 = new Book(126, "Николай Гоголь", "Ночь перед Рождеством", "Росмэн-пресс", 2016, 96, 4.53);
            Book book5 = new Book(127, "Евгений Замятин", "Мы", "Азбука", 2018, 288, 9.44);

            BookService bookService = new BookService();

            Console.WriteLine("Try to add the book5 once again...");
            try
            {
                bookService.AddBook(book1);
                bookService.AddBook(book2);
                bookService.AddBook(book3);
                bookService.AddBook(book4);
                bookService.AddBook(book5);
                bookService.AddBook(book5);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            Console.WriteLine("Try to print 5 books...");

            bookService.PrintBookList();

            try
            {
                bookService.RemoveBook(book5);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

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
            List<Book> bookList = bookService.FindBookByTag(BookService.Tag.Name, "Сборник поэм");

            foreach (Book book in bookList)
            {
                Console.WriteLine(book.ToString());
            }

            Console.WriteLine("Try to print 2 book with Year = 2016...");

            List<Book> bookList2 = bookService.FindBookByTag(BookService.Tag.Year, 2016);

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
            Console.ReadKey();
        }
    }
}
