using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NET02._1
{
    public class Book : IEnumerable<Author>
    {
        private const int Length = 1000;
        private string _title;
        private string _isbn;
        private readonly List<Author> _authors;

        public DateTime? Date { get; }

        public string Isbn
        {
            get => _isbn;
            set
            {
                var r = new Regex(@"\d{3}-?\d{1}-?\d{2}-?\d{6}-?\d{1}");
                if(!r.IsMatch(value))
                {
                    throw new ArgumentException("ISBN must consist of digits");
                }

                value = value.Replace("-", "");
                _isbn = value;
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                if(value == null || value.Length > Length)
                {
                    throw new ArgumentException("The name is null or the length exceeds the character limit.");
                }

                _title = value;
            }
        }

        public Book(string title, string isbn, DateTime date, params Author[] authors)
        {
            _authors = new List<Author>();
            Title = title;
            Isbn = isbn;
            Date = date;
            if(authors == null)
            {
                return;
            }
            foreach(var author in authors)
            {
                _authors.Add(author);
            }
        }

        public Book(string title, string isbn, params Author[] authors)
        {
            _authors = new List<Author>();
            Title = title;
            Isbn = isbn;
            if(authors == null)
            {
                return;
            }

            foreach(var author in authors)
            {
                _authors.Add(author);
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Book temp && temp.Isbn == Isbn;
        }

        public override int GetHashCode()
        {
            return Isbn.GetHashCode();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Author> GetEnumerator()
        {
            return _authors.GetEnumerator();
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"Title: {Title}");
            result.AppendLine($"ISBN: {Isbn}");
            result.Append("Author: ");
            foreach(var a in _authors)
            {
                result.Append(a);
            }

            result.AppendLine();
            if(Date != null)
            {
                result.AppendLine($"Date: {Date.Value.ToShortDateString()}");
            }

            return result.ToString();
        }
    }
}