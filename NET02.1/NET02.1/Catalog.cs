using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NET02._1
{
    public class Catalog : IEnumerable<Book>
    {
        private readonly Dictionary<string, Book> _books;

        public Catalog()
        {
            _books = new Dictionary<string, Book>();
        }

        public Catalog(Dictionary<string, Book> books)
        {
            if(books.Count == 0)
            {
                throw new ArgumentException("Value cannot be an empty collection.");
            }

            _books = books;
        }

        public Book this[string isbn]
        {
            get
            {
                CheckIsbn(ref isbn);
                return _books[isbn];
            }
        }

        public void Add(Book book)
        {
            _books.Add(book.Isbn, book);
        }

        public void CheckIsbn(ref string isbn)
        {
            var r = new Regex(@"\d{3}-?\d{1}-?\d{2}-?\d{6}-?\d{1}");

            if(!r.IsMatch(isbn))
            {
                throw new ArgumentException("ISBN does not match the format.");
            }

            isbn = isbn.Replace("-", "");
        }

        public IEnumerable<Book> GetBooksByFirstNameLastName(string firstName, string lastName)
        {
            var temp = new Author(firstName, lastName);
            return from book in _books
                from author in book.Value
                where author.Equals(temp)
                select book.Value;
        }

        public IEnumerable<Book> GetBooksSortedByDate()
        {
            return from book in _books.Values
                orderby book.Date descending
                select book;
        }

        public IEnumerable<(Author, int)> GetTupleAuthorAndNumber()
        {
            return from book in _books
                from author in book.Value
                group author by author
                into newTuple
                select (newTuple.Key, newTuple.Count());
        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach(var book in _books.OrderBy(bookValue => bookValue.Value.Title)) yield return book.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _books.GetEnumerator();
        }
    }
}