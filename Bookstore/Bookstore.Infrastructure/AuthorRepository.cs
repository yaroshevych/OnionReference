using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bookstore.Core;

namespace Bookstore.Infrastructure
{
    public class AuthorRepository : IAuthorRepository
    {
        public Author Load(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> LoadAll(AuthorQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
