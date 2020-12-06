using AutoMapper;
using SummerPractise.BL;
using SummerPractise.Entity;
using SummerPractise.PL.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SummerPractise.PL.MVC.Controllers
{
    public class BookController : Controller
    {
        IBookLogic bookLogic;
        public BookController(IBookLogic bookLogic)
        {
            this.bookLogic = bookLogic;
        }
        [Authorize]
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookMV>());
            var mapper = new Mapper(config);
            List<BookMV> books = mapper.Map<List<BookMV>>(bookLogic.Select());
            
            return View(books);
        }

        [Authorize]
        public ActionResult CreateBook()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateBook(BookMV model)
        {
            if (ModelState.IsValid)
            {
                bookLogic.Add(model.Name, model.Year, model.AuthorSurname, model.AuthorName, model.AuthorPatronymic);
                return RedirectToAction("Index", "Book");
            }
            else
            {
                ModelState.AddModelError("", "Неправильные данные в полях");
            }
            return RedirectToAction("Index", "Book");
        }

        [Authorize]
        public ActionResult DeleteBook(int id)
        {
            bookLogic.Delete(id);
            return RedirectToAction("Index", "Book");
        }

        [Authorize]
        public ActionResult UpdateBook(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookMV>());
            var mapper = new Mapper(config);
            BookMV model = mapper.Map<BookMV>(bookLogic.FindById(id));
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateBook(BookMV model)
        {
            if (ModelState.IsValid)
            {
                bookLogic.Update(model.Id, model.Name, model.Year, model.AuthorSurname, model.AuthorName, model.AuthorPatronymic);
                return RedirectToAction("Index", "Book");
            }
            else
            {
                ModelState.AddModelError("", "Неправильные данные в полях");
            }
            return RedirectToAction("Index", "Book");
        }
    }
}