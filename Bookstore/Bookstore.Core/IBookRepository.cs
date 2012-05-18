using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bookstore.Core
{
    public interface IBookRepository
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
