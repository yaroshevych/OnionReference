using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bookstore.Core
{
    public class Book
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Author Author { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
