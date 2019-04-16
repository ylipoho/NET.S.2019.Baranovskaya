using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookListService
{
    public abstract class Tag
    {
        public abstract string ClassName { get; }

        public abstract IEnumerable<Book> Sort(List<Book> bookList);        
    }
}
