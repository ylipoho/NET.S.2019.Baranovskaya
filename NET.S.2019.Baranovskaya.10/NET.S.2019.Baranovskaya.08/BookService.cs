namespace BookListService
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Contains method for the Book class
    /// </summary>
    public class BookService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookService"/> class
        /// </summary>
        public BookService()
        {
            this.BookListStorage = new List<Book>();
        }
        
        private List<Book> BookListStorage { get; set; }
        
        /// <summary>
        /// Initializes a BookListStorage property from binary file
        /// </summary>
        /// <param name="path">file path</param>
        public void LoadBookListStorageFromBinaryFile(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    // bookListStorage.Clear();
                    while (br.PeekChar() > -1)
                    {
                        int isbn = br.ReadInt32();
                        string author = br.ReadString();
                        string name = br.ReadString();
                        string publishingHouse = br.ReadString();
                        int year = br.ReadInt32();
                        int pageNum = br.ReadInt32();
                        double price = br.ReadDouble();
                        this.BookListStorage.Add(new Book(isbn, author, name, publishingHouse, year, pageNum, price));
                    }
                }
            }            
        }

        /// <summary>
        /// Save a BookListStorage to binary file
        /// </summary>
        /// <param name="path">file path</param>
        public void SaveBookListStorageFromBinaryFile(string path)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                foreach (Book book in this.BookListStorage)
                {
                    bw.Write(book.ISBN);
                    bw.Write(book.Author);
                    bw.Write(book.Name);
                    bw.Write(book.PublishingHouse);
                    bw.Write(book.Year);
                    bw.Write(book.PageNum);
                    bw.Write(book.Price);
                }
            }
        }
        
        /// <summary>
        /// Displays a book list on the console
        /// </summary>
        public void PrintBookList()
        {
            if (this.BookListStorage.Count == 0)
            {
                Console.WriteLine("Book list is empty.");
            }
            else
            {
                foreach (Book book in this.BookListStorage)
                {
                    Console.WriteLine(book.ToString());
                }
            }
        }
               
        /// <summary>
        /// Find all books with given string parameter
        /// </summary>
        /// <param name="tag">type of searching parameter</param>
        /// <param name="parameter">given parameter</param>
        /// <returns>list of all matches</returns>
        public List<Book> FindBookByTag(Tag tag, string parameter)
        {
            List<Book> resultList = new List<Book>();

            foreach (Book book in this.BookListStorage)
            {
                if ((tag.ClassName.CompareTo("Author") == 0) && (book.Author.CompareTo(parameter) == 0))
                {
                    resultList.Add(book);
                }

                if ((tag.ToString().CompareTo("Name") == 0) && (book.Name.CompareTo(parameter) == 0))
                {
                    resultList.Add(book);
                }
            }

            return resultList;
        }

        /// <summary>
        /// Find all books with given double parameter
        /// </summary>
        /// <param name="tag">type of searching parameter</param>
        /// <param name="parameter">input double value for searching</param>
        /// <returns>list of all matches</returns>
        public List<Book> FindBookByTag(Tag tag, double parameter)
        {
            List<Book> resultList = new List<Book>();

            foreach (Book book in this.BookListStorage)
            {
                if (tag.ClassName.CompareTo("price") == 0 && Math.Abs(book.Price - parameter) < 0.02)
                {
                    resultList.Add(book);
                }
            }

            return resultList;
        }

        /// <summary>
        /// Sorts book by given tag
        /// </summary>
        /// <param name="tag">given tag</param>
        public void SortBooksByTag(Tag tag)
        {
            BookListStorage = tag.Sort(BookListStorage).ToList();
        }
        
        /// <summary>
        /// Adds given book to the book list
        /// </summary>
        /// <param name="book">book for adding</param>
        /// <returns>true if book was added</returns>
        /// <exception cref="ArgumentException">if given book already exists in the book list</exception>
        public bool AddBook(Book book)
        {
            int? index;

            if ((index = this.FindBook(book)) == null)
            {
                this.BookListStorage.Add(book);
                return true;
            }

            throw new ArgumentException("Already exists.");
        }

        /// <summary>
        /// Removes given book from the book list
        /// </summary>
        /// <param name="book">book for removing</param>
        /// <returns>true if book was removed</returns>
        /// <exception cref="ArgumentException">if book list doesn't contain given book</exception>
        public bool RemoveBook(Book book)
        {
            int? index;

            if ((index = this.FindBook(book)) != null)
            {
                this.BookListStorage.Remove(this.BookListStorage[(int)index]);
                return true;
            }

            throw new ArgumentException("Doesn't contain this book.");
        }

        /// <summary>
        /// Finds given book in the book list 
        /// </summary>
        /// <param name="book">book for searching</param>
        /// <returns>index of book, if list contains this book; otherwise, null</returns>
        private int? FindBook(Book book)
        {
            for (int i = 0; i < this.BookListStorage.Count; i++)
            {
                if (book.Equals(this.BookListStorage[i]))
                {
                    return i;
                }
            }

            return null;
        }
    }
}
