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
    }
}