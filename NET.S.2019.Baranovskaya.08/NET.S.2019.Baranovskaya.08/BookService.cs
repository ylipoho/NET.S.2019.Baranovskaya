using System;
using System.Collections.Generic;

namespace BookListService
{
    public class BookService
    {
        List<Book> bookList;

        public bool AddBook(Book book)
        {
            if (!FindBook(book))
            { 
                // add
            }
            else
            {
                return false;
            }

            return true;
        }
        
        public bool RemoveBook(Book book)
        {
            return true;
        }

        public bool FindBook(Book book)
        {
            return true;
        }

        public Book FindBookByTag(/*one of parameters*/)
        {
            throw new NotImplementedException();
        }

        public void SortBooksByTag(/*one oа parameter*/)
        {

        }


    }
}
