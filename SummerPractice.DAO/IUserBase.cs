using SummerPractice.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.DAO
{
    public interface IUserBase
    {
        void InsertIntoUser(string login, string password, string surname,
            string name, string patronymic, DateTime dateOfBirth);
        void AddBookForUser(int userId, int bookId);
        User FindUser(string login, string password);
        bool Authorization(string login, string password);
    }
}