using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bookstore.Core;

namespace Bookstore.Infrastructure
{
    public class BookRepository : IBookRepository
    {
        private static List<Book> books = new List<Book>(new[]
            {
                new Book {Id = "1", Name = "Homemade Halloween Treats", ReleaseDate = DateTime.UtcNow.AddDays(-10), Price = 39},
                new Book {Id = "2", Name = "Shadow: 9", ReleaseDate = DateTime.UtcNow.AddDays(-10), Price = 19.95m},
                new Book {Id = "3", Name = "The Third Wheel", ReleaseDate = DateTime.UtcNow.AddDays(-223), Price = 8},
                new Book {Id = "4", Name = "RUNAWAY HEART", ReleaseDate = DateTime.UtcNow.AddDays(-189), Price = 59.95m},
                new Book {Id = "5", Name = "The Racketeer", ReleaseDate = DateTime.UtcNow.AddYears(-3), Price = 34.99m}
            });

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
