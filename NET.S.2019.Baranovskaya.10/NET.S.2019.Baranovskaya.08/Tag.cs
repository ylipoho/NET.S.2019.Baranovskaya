namespace BookListService
{
    using System.Collections.Generic;

    public abstract class Tag
    {
        public abstract string ClassName { get; }

        public abstract IEnumerable<Book> Sort(List<Book> bookList);        
    }
}
