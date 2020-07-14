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
            if (ModelState.IsValid)
            {
                string name = User.Identity.Name;
                using (Context db = new Context())
                {
                    user = db.Users.FirstOrDefault(u => u.Login == name);
                }
            }
            return View(user);
        }

        [Authorize]
        public ActionResult AddBookToUser()
        {
            return View();
        }
    }
}