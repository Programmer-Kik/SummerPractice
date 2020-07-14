using SummerPractise.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SummerPractise.MVC.Controllers
{
    public class UserController : Controller
    {
        [Authorize]
        public ActionResult About()
        {
            User user = null;
            List<Book> books = null;
            List<UserBook> userBooks = null;
            if (ModelState.IsValid)
            {
                string name = User.Identity.Name;
                using (Context db = new Context())
                {
                    user = db.Users.FirstOrDefault(u => u.Login == name);
                    books = db.Books.ToList();
                    userBooks = db.UserBooks.Where(ub => ub.UserId == user.Id).ToList();
                }
                userBooks = userBooks.Join(books,
                    ub => ub.BookId,
                    b => b.Id,
                    (ub, b) => new UserBook
                    {
                        UserId = ub.UserId,
                        BookId = ub.BookId,
                        Book = new Book
                        {
                            Name = b.Name,
                            Year = b.Year,
                            AuthorSurname = b.AuthorSurname,
                            AuthorName = b.AuthorName,
                            AuthorPatronymic = b.AuthorPatronymic
                        }
                    }).ToList();
            }
            ViewBag.books = userBooks;
            return View(user);
        }

        [Authorize]
        public ActionResult AddBookToUser()
        {
            return View();
        }


    }
}