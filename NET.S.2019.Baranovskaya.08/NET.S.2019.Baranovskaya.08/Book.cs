using System;

namespace BookListService
{
    public class Book :IComparable, IEquatable<Book>
    {
        //(ISBN, автор, название, издательство, год издания, количество страниц, цена)

        int ISBN;
        string Author;
        string Name;
        string PublishingHouse;
        int Year;
        int PageNum;
        double Price;

        public Book(int ISBN, string Author, string Name, string PublishingHouse, int Year, int PageNum, double Price)
        {
            this.ISBN = ISBN;
            this.Author = Author;
            this.Name = Name;
            this.PublishingHouse = PublishingHouse;
            this.Year = Year;
            this.PageNum = PageNum;
            this.Price = Price;
        }

        #region interface methods
        /// <summary>
        /// Compares this instance to a Book object and returns an indication of their relative values.
        /// </summary>
        /// <param name="obj">An object to compare, or null</param>
        /// <returns> A signed number indicating the relative values of this instance and value.Return
        /// Value Description Less than zero This instance is less than value. Zero This
        /// instance is equal to value. Greater than zero This instance is greater than value.-or-
        /// value is null.</returns>
        /// <exception cref="ArgumentException">value is not an Book.</exception>
        public int CompareTo(object obj)
        {
            Book book = obj as Book;

            if (book == null)
            {
                throw new ArgumentException();
            }

            return this.ISBN-book.ISBN;
        }
        
        /// <summary>
        /// Determines if the underlying system type of the current System.Type is the same
        /// as the underlying system type of the specified System.Object.
        /// </summary>
        /// <param name="other">object to compare</param>
        /// <returns>true if equals; otherwise, false</returns>
        public bool Equals(Book other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }
            
            if ((this.ISBN != other.ISBN) || (this.Author != other.Author) || (this.Name != other.Name) || (this.PublishingHouse != other.PublishingHouse) ||
                (this.Year != other.Year) || (this.PageNum != other.PageNum) || (this.Price != other.Price))
            {
                return false;
            }

            return true;
        }
        #endregion

        #region Object methods

        /// <summary>
        /// Returns a string representing of Book instance
        /// </summary>
        /// <returns>A System.String representing of Book instance</returns>
        public override string ToString()
        {
            return String.Format("isbn: {0}, author: {1}, name: \"{2}\", publising house: \"{3}\", year: \"{4}\", pages: {5}, price: {6}",
                                 this.ISBN, this.Author, this.Name, this.PublishingHouse, this.Year, this.PageNum, this.Price);
        }

        /// <summary>
        /// Determines if the underlying system type of the current System.Type is the same
        /// as the underlying system type of the specified System.Object.
        /// </summary>
        /// <param name="obj">The object whose underlying system type is to be compared with the underlying
        /// system type of the current System.Type.</param>
        /// <returns>true if the underlying system type of o is the same as the underlying system
        /// type of the current System.Type; otherwise, false. This method also returns false
        /// if the object specified by the o parameter is not a Type.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (!this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            Book b = obj as Book;
            
            if ((this.ISBN != b.ISBN) || (this.Author != b.Author) ||(this.Name != b.Name) || (this.PublishingHouse != b.PublishingHouse) ||
                (this.Year != b.Year) || (this.PageNum != b.PageNum) || (this.Price != b.Price))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Returns the hash code for this instance
        /// </summary>
        /// <returns>The hash code for this instance</returns> 
        public override int GetHashCode()
        {
            int prime = 21;
            int result = 1;

            result = result * prime + this.ISBN.GetHashCode();
            result = result * prime + this.Author.GetHashCode();
            result = result * prime + this.Name.GetHashCode();
            result = result * prime + this.PublishingHouse.GetHashCode();
            result = result * prime + this.Year.GetHashCode();
            result = result * prime + this.PageNum.GetHashCode();
            result = result * prime + this.Price.GetHashCode();

            return result;
        }
        
        #endregion
    }
}
