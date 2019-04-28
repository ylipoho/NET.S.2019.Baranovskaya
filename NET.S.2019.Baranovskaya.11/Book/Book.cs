// <copyright file="Book.cs" company="companyName">
// Copyright (c) companyName. All rights reserved.
// </copyright>
namespace BookListService
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class that describes the book
    /// </summary>
    public class Book : IComparable, IEquatable<Book>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class
        /// </summary>
        /// <param name="isbn">unique number</param>
        /// <param name="author">author of the book</param>
        /// <param name="name">name of the book</param>
        /// <param name="publishingHouse">publishing house of the book</param>
        /// <param name="year">year of the book</param>
        /// <param name="pageNum">number of pages</param>
        /// <param name="price">price of the book</param>
        public Book(int isbn, string author, string name, string publishingHouse, int year, int pageNum, double price)
        {
            this.ISBN = isbn;
            this.Author = author;
            this.Name = name;
            this.PublishingHouse = publishingHouse;
            this.Year = year;
            this.PageNum = pageNum;
            this.Price = price;
        }

        /// <summary>
        /// Gets unique number of the book
        /// </summary>
        public int ISBN { get; }

        /// <summary>
        /// Gets author of the book
        /// </summary>
        public string Author { get; }

        /// <summary>
        /// Gets name of the book
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets publishing house of the book
        /// </summary>
        public string PublishingHouse { get; }

        /// <summary>
        /// Gets year of the book
        /// </summary>
        public int Year { get; }

        /// <summary>
        /// Gets number of pages 
        /// </summary>
        public int PageNum { get; }

        /// <summary>
        /// Gets or sets price of the book
        /// </summary>
        public double Price { get; set; }
        
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

            return this.ISBN - book.ISBN;
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
            return string.Format(
                "isbn: {0}, author: {1}, name: \"{2}\", publising house: \"{3}\", year: {4}, pages: {5}, price: {6}", 
                this.ISBN, 
                this.Author, 
                this.Name, 
                this.PublishingHouse, 
                this.Year, 
                this.PageNum, 
                this.Price
                );
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
            
            if ((this.ISBN != b.ISBN) || (this.Author != b.Author) || (this.Name != b.Name) || (this.PublishingHouse != b.PublishingHouse) ||
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
            var hashCode = -2110119757;
            hashCode = hashCode * -1521134295 + ISBN.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Author);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PublishingHouse);
            hashCode = hashCode * -1521134295 + Year.GetHashCode();
            hashCode = hashCode * -1521134295 + PageNum.GetHashCode();
            return hashCode;
        }
        
        #endregion
    }
}
