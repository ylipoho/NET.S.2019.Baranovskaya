using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookListService
{
    public class DescriptionDecorator : Decorator
    {
        public DescriptionDecorator(Book book) : base(book)
        {

        }

        public override string ToString()
        {
            return string.Format("ISBN {0}. Full description. The book '{1}' was written by {2}. Was published by '{3}' publishing house "+
                                "in {4} year. Number of pages in '{1}' is {5}. You can buy this book for {6}", this._book.ISBN, this._book.Name, this._book.Author,
                                            this._book.PublishingHouse, this._book.Year, this._book.PageNum, this._book.Price);
        }
    }
}
