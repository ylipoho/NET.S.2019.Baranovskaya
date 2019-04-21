using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookListService.SortingTags
{
    public class Price : Tag
    {
        public override string ClassName => "Price";

        public override IEnumerable<Book> Sort(List<Book> bookList)
        {
            return bookList.OrderBy(book => book.Price).Select(book => book);
        }
    }
}
