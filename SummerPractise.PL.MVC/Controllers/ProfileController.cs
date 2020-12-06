using SummerPractise.BL;
using SummerPractise.PL.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SummerPractise.Entity;

namespace SummerPractise.PL.MVC.Controllers
{
    public class ProfileController : Controller
    {
        IUserLogic userLogic;
        public ProfileController(IUserLogic userLogic)
        {
            this.userLogic = userLogic;
        }
        [Authorize]
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserMV>());
            var mapper = new Mapper(config);
            UserMV model = mapper.Map<UserMV>(userLogic.FindUserByLogin(User.Identity.Name));
            return View(model);
        }

        [Authorize]
        public ActionResult UpdateUser()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserMV>());
            var mapper = new Mapper(config);
            UserMV model = mapper.Map<UserMV>(userLogic.FindUserByLogin(User.Identity.Name));
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateUser(UserMV model)
        {
            if (ModelState.IsValid)
            {
                userLogic.Update(model.Login, model.Surname, model.Name, model.Patronymic, model.Age);
                return RedirectToAction("Index", "Profile");
            }
            else
            {
                ModelState.AddModelError("", "Неправильные данные в полях");
            }
            return RedirectToAction("Index", "Profile");
        }
    }
}