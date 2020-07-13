using SummerPractice.BL;
using SummerPractice.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPL.Models
{
    public class UserModel
    {
        private UserLogic userLogic = new UserLogic();

        private User UserInfo { get; set; }

        public UserModel()
        {
            UserInfo = null;
        }

        public bool Authorization(string login, string password)
        {
            UserInfo = userLogic.FindUser(login, password);
            return UserInfo == null ? false : true;
        }
    }
}