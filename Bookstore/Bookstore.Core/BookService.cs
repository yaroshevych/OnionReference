using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bookstore.Core
{
    public class BookService
    {
        private readonly IBookRepository repository;
        private static ILogger logger;
        private readonly string userName;

        public BookService(string context, IBookRepository repository, ILoggerFactory loggerFactory)
        {
            this.repository = repository;
            this.userName = context;

            if (logger == null)
                logger = loggerFactory.Create<BookService>();
        }

        public void PublishBook(string id)
        {
            logger.Trace("+PublishBook({0})", id);

            var book = repository.Load(id);
            book.ReleaseDate = DateTime.UtcNow;
            repository.Save(book);

            logger.Trace("-PublishBook"); // exception will be logged in MVC controller
        }
    }
}
