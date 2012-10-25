using System;

namespace Bookstore.Core
{
    public interface IBook
    {
        string Id { get; }
        string Name { get; }
        decimal Price { get; }
        Author Author { get; }
        DateTime ReleaseDate { get; }
    }

    public class Book : IBook
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Author Author { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
