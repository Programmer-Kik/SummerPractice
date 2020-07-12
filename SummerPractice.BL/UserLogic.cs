using SummerPractice.DAO;
using SummerPractice.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.BL
{
    public class UserLogic
    {
        private IUserBase userBase;

        public UserLogic()
        {
            userBase = new UserBase();
        }

        public UserLogic(IUserBase userBase)
        {
            this.userBase = userBase;
        }

        public void AddBookForUser(int userId, int bookId)
        {
            userBase.AddBookForUser(userId, bookId);
        }

        public User FindUserById(int id)
        {
            return userBase.FindUserById(id);
        }

        public void InsertIntoUser(string login, string password, string surname,
            string name, string patronymic, DateTime dateOfBirth)
        {
            userBase.InsertIntoUser(login, password, surname, name, patronymic, dateOfBirth);
        }

        public bool Authorization(string login, string password)
        {
            return userBase.Authorization(login, password);
        }
    }
}