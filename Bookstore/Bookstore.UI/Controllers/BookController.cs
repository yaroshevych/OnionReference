using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookstore.Core;
using Bookstore.UI.Common;

namespace Bookstore.UI.Controllers
{
    public sealed class BookController : LoggingController<BookController>
    {
        private readonly Func<IBookRepository> repositoryFactory;
        private readonly BookService service;

        public BookController(Func<IBookRepository> repositoryFactory, BookService service, ILoggerFactory loggerFactory)
            : base(loggerFactory)
        {
            this.repositoryFactory = repositoryFactory;
            this.service = service;
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
            return View();
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
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Publish(string id)
        {
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
                // TODO: Add update logic here

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
