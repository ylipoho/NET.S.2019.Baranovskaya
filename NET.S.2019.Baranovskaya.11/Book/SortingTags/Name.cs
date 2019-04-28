using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookListService.SortingTags
{
    public class Name : Tag
    {
        public override string ClassName => "Name";

        public override IEnumerable<Book> Sort(List<Book> bookList)
        {
            return bookList.OrderBy(book => book.Name).Select(book => book);
        }
    }
}
