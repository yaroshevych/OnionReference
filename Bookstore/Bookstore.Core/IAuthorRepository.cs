using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bookstore.Core
{
    public interface IAuthorRepository
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
