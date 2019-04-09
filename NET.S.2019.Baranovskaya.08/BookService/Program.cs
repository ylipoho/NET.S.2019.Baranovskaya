using System;
using BookListService;

namespace BookConsoleApplication
{
    class Program
    {
        // 1. print list
        // 2. add book
        // 3. remove book
        // 4. find book by tag
        // 5. sort books by tag
        // 6. exit

        static void Main(string[] args)
        {
            string answer = String.Empty;

            while (answer != "5")
            {
                int answerNumber;
                
                if (int.TryParse(answer, out answerNumber))
                {
                    switch (answerNumber)
                    {
                        case 1:
                            Console.WriteLine("Please, enter ISBN, author, name, publishing house, year, num of pages and price separated by space:");
                            string bookInfo = Console.ReadLine();
                            string[] bookStrings = bookInfo.Split(' ');

                            if (int.TryParse(bookStrings[0], out int isbn) && int.TryParse(bookStrings[4], out int year) &&
                                int.TryParse(bookStrings[5], out int pageNum) && int.TryParse(bookStrings[6], out int price))
                            {
                                Book book = new Book(isbn, bookStrings[1], bookStrings[2], bookStrings[3], year,
                                     pageNum, price);
                                if (new BookListService.BookService().AddBook(book))
                                {
                                    Console.WriteLine("Done.");
                                }
                                else
                                {
                                    Console.WriteLine("Already exist.");
                                }
                            }
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        default:
                            Console.WriteLine("Please, enter number from 1 to 5.");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Please, enter number from 1 to 5.");
                }
            }
            Console.WriteLine("Press any key for exit...");
            Console.ReadKey();
        }
    }
}
