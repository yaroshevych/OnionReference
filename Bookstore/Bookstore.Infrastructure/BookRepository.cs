using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bookstore.Core;

namespace Bookstore.Infrastructure
{
    public class BookRepository : IBookRepository
    {
        private static List<Book> books = new List<Book>(new[] { new Book { Id = "1", Name = "Test", ReleaseDate = DateTime.UtcNow.AddDays(-10) }, new Book { Id = "2", Name = "Test2", ReleaseDate = DateTime.UtcNow.AddDays(-10) } });

        public Book Load(string id)
        {
            var result = books.FirstOrDefault(b => b.Id == id);

            if (result != null)
                return result;

            throw new ArgumentException("Book " + id + " not found.");
        }

        public IEnumerable<Book> LoadAll(BookQuery query)
        {
            System.Threading.Thread.Sleep(1000);
            return books;
        }

        public void Save(Book book)
        {
            var existing = books.FirstOrDefault(b => b.Id == book.Id);

            if (existing != null)
            {
                existing.Author = book.Author;
                existing.Name = book.Name;
                existing.ReleaseDate = book.ReleaseDate;
            }
            else
            {
                if (string.IsNullOrEmpty(book.Id))
                    book.Id = (new Guid()).ToString().Replace("-", "");

                books.Add(book);
            }
        }

        public void Dispose()
        {
        }
    }
}
