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
    public class UserController : Controller
    {
        IUserLogic userLogic;
        public UserController(IUserLogic userLogic)
        {
            this.userLogic = userLogic;
        }
        [Authorize]
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserMV>());
            var mapper = new Mapper(config);
            List<UserMV> users = mapper.Map<List<UserMV>>(userLogic.Select());
            UserMV myUser = users.Find(user => user.Login == User.Identity.Name);
            users.Remove(myUser);
            return View(users);
        }
    }
}