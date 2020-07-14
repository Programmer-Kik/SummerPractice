using SummerPractise.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SummerPractise.MVC.Controllers
{
    public class BookController : Controller
    {
        [Authorize]
        public ActionResult Books()
        {
            ICollection<Book> books = null;
            if(ModelState.IsValid)
            {
                using (Context db = new Context())
                {
                    books = db.Books.ToList();
                }
            }
            ViewBag.books = books;
            return View();
        }

        [Authorize]
        public ActionResult AddBook()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddBook(Book model)
        {
            if(ModelState.IsValid)
            {
                using (Context db = new Context())
                {
                    db.Books.Add(model);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Books");
        }

        [Authorize]
        public ActionResult DeleteBook(int id)
        {
            if(ModelState.IsValid)
            {
                using (Context db = new Context())
                {
                    Book book = db.Books.FirstOrDefault(b => b.Id == id);
                    db.Books.Remove(book);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Books");
        }

        [Authorize]
        public ActionResult UpdateBook(int id)
        {
            Book book = null;
            using (Context db = new Context())
            {
                book = db.Books.FirstOrDefault(b => b.Id == id);
            }
            return View(book);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateBook(Book model)
        {
            Book updatedBook = null;
            if (ModelState.IsValid)
            {
                using (Context db = new Context())
                {
                    updatedBook = db.Books.FirstOrDefault(b => b.Id == model.Id);
                    updatedBook.Name = model.Name;
                    updatedBook.Year = model.Year;
                    updatedBook.AuthorSurname = model.AuthorSurname;
                    updatedBook.AuthorName = model.AuthorName;
                    updatedBook.AuthorPatronymic = model.AuthorPatronymic;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Books");
        }
    }
}