using System;
using System.Collections.Generic;

namespace Bookstore.Core
{
    public interface IAuthorRepository : IDisposable
    {
        Author Load(string id);
        IEnumerable<Author> LoadAll(AuthorQuery query);
    }

    public class AuthorQuery
    {
        public string Name;
        public string BookName;
    }
}
