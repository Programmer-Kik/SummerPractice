using SummerPractise.DAL;
using SummerPractise.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractise.BL
{
    public class UserLogic : IUserLogic
    {
        private UserBase userBase;

        public UserLogic()
        {
            userBase = new UserBase();
        }

        public UserLogic(UserBase userBase)
        {
            this.userBase = userBase;
        }

        public void Add(string login, string password, string surname, string name, string patronymic, int age)
        {
            userBase.Add(login, password, surname, name, patronymic, age);
        }

        public List<User> Select()
        {
            return userBase.Select();
        }

        public User FindUserById(int id)
        {
            return userBase.FindUserById(id);
        }

        public User FindUserByLogin(string login)
        {
            return userBase.FindUserByLogin(login);
        }

        public void Update(string login, string surname, string name, string patronymic, int age)
        {
            userBase.Update(login, surname, name, patronymic, age);
        }
    }
}