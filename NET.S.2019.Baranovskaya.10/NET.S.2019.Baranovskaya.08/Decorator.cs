using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookListService
{
    public abstract class Decorator : AbstractBook
    {
        protected Book _book;

        public Decorator(Book book)
        {
            this._book = book;
        }

        public override string ToString()
        {
            if (_book != null)
            {
                return _book.ToString();
            }

            throw new ArgumentException("Object cannot ne null");
        }
    }
}
