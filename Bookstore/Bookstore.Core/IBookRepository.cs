using System;
using System.Collections.Generic;

namespace Bookstore.Core
{
    public interface IBookRepository : IDisposable
    {
        Book Load(string id);
        IEnumerable<Book> LoadAll(BookQuery query);
        void Save(Book book);
    }

    public class BookQuery
    {
        public string Name;
        public DateTime? MinReleaseDate;
        public DateTime? MaxReleaseDate;
    }
}
