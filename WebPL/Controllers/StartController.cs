using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPL.Models;

namespace WebPL.Controllers
{
    public class StartController : Controller
    {
        private UserModel userModel = new UserModel();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Authorization()
        {
            string login = (string)ViewData["login"];
            string password = (string)ViewData["password"];

            if(userModel.Authorization(login, password))
            {
                return RedirectToAction("Main");
            }
            return View();
        }

        public ActionResult Registration()
        {
            return RedirectToAction("Registration");
        }

    }
}