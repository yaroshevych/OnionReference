using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookstore.Core;
using Bookstore.UI.Common;
using Bookstore.UI.Models;

namespace Bookstore.UI.Controllers
{
    public sealed class BookController : LoggingController<BookController>
    {
        private readonly Func<IBookRepository> repositoryFactory;
        private readonly Func<string, BookService> serviceFactory; // DI framework will use proper constructor

        public BookController(Func<IBookRepository> repositoryFactory, Func<string, BookService> serviceFactory, ILoggerFactory loggerFactory)
            : base(loggerFactory)
        {
            this.repositoryFactory = repositoryFactory;
            this.serviceFactory = serviceFactory;
        }

        public ActionResult Index()
        {
            using (var repository = repositoryFactory())
            {
                var books = repository.LoadAll(null);
                return View(books);
            }
        }

        public ActionResult Details(string id)
        {
            using (var repository = repositoryFactory())
            {
                var book = repository.Load(id);
                return View(book);
            }
        }

        public ActionResult Discount(string id)
        {
            using (var repository = repositoryFactory())
            {
                var book = repository.Load(id);
                var service = new DiscountService();
                var price = service.GetDiscount(book);

                return View(new BookDiscount {Id = book.Id, Name = book.Name, Price = book.Price, DiscountedPrice = price});
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                book.Id = Guid.NewGuid().ToString();

                using (var repository = repositoryFactory())
                    repository.Save(book);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Publish(string id)
        {
            var service = serviceFactory(System.Threading.Thread.CurrentPrincipal.Identity.Name);
            service.PublishBook(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            using (var repository = repositoryFactory())
                return View(repository.Load(id));
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            try
            {
                using (var repository = repositoryFactory())
                    repository.Save(book);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
