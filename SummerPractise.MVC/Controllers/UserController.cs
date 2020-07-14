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
                        BookId = b.Id,
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

        [Authorize]
        [HttpPost]
        public ActionResult AddBookToUser(Book model)
        {
            string login = User.Identity.Name;
            if(ModelState.IsValid)
            {
                using (Context db = new Context())
                {
                    int userId = db.Users.FirstOrDefault(u => u.Login == login).Id;
                    int bookId = db.Books.FirstOrDefault(b => b.Name == model.Name && b.Year == model.Year).Id;
                    if(db.UserBooks.FirstOrDefault(ub => ub.UserId == userId && ub.BookId == bookId) == null)
                    {
                        db.UserBooks.Add(new UserBook { UserId = userId, BookId = bookId });
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("About");
        }

        [Authorize]
        public ActionResult DeleteBookToUser(int bookId)
        {
            string login = User.Identity.Name;
            if (ModelState.IsValid)
            {
                using (Context db = new Context())
                {
                    int userId = db.Users.FirstOrDefault(u => u.Login == login).Id;
                    UserBook userBook = db.UserBooks.FirstOrDefault(ub => ub.UserId == userId && ub.BookId == bookId);
                    if(userBook != null)
                    {
                        db.UserBooks.Attach(userBook);
                        db.UserBooks.Remove(userBook);
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("About");
        }

        [Authorize]
        public ActionResult UpdateUser()
        {
            User user = null;
            string login = User.Identity.Name;
            using (Context db = new Context())
            {
                user = db.Users.FirstOrDefault(u => u.Login == login);
            }
            return View(user);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateUser(User model)
        {
            User updatedUser = null;
            if(ModelState.IsValid)
            {
                using (Context db = new Context())
                {
                    updatedUser = db.Users.FirstOrDefault(u => u.Id == model.Id);
                    updatedUser.Password = model.Password;
                    updatedUser.Surname = model.Surname;
                    updatedUser.Name = model.Name;
                    updatedUser.Patronymic = model.Patronymic;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("About");
        }
    }
}