using AutoMapper;
using SummerPractise.BL;
using SummerPractise.Entity;
using SummerPractise.PL.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SummerPractise.PL.MVC.Controllers
{
    public class AccountController : Controller
    {
        IUserLogic userLogic;

        public AccountController(IUserLogic userLogic)
        {
            this.userLogic = userLogic;
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(RegistrationMV model)
        {
            if (ModelState.IsValid)
            {
                RegistrationMV user = null;
                var config = new MapperConfiguration(cfg => cfg.CreateMap<User, RegistrationMV>());
                var mapper = new Mapper(config);

                user = mapper.Map<RegistrationMV>(userLogic.FindUserByLogin(model.Login));
                if (user == null)
                {
                    userLogic.Add(model.Login, model.Password, model.Surname, model.Name, model.Patronymic, model.Age);
                    user = mapper.Map<RegistrationMV>(userLogic.FindUserById(model.Id));
                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Пользователь с таким логином уже существует");
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginMV model)
        {
            if (ModelState.IsValid)
            {
                LoginMV user = null;
                var config = new MapperConfiguration(cfg => cfg.CreateMap<User, LoginMV>());
                var mapper = new Mapper(config);

                user = mapper.Map<LoginMV>(userLogic.FindUserByLogin(model.Login));
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}