using System.Collections.Generic;
using System.Linq;

namespace BookListService
{
    public class Author : Tag
    {
        public override string ClassName => "Author";

        public override IEnumerable<Book> Sort(List<Book> bookList)
        {
            return bookList.OrderBy(book => book.Author).Select(book => book);
        }
    }
}
