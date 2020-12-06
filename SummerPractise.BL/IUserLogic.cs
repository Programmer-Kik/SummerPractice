using SummerPractise.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractise.BL
{
    public interface IUserLogic
    {
        void Add(string login, string password, string surname, string name, string patronymic, int age);
        List<User> Select();
        User FindUserById(int id);
        User FindUserByLogin(string login);
        void Update(string login, string surname, string name, string patronymic, int age);
    }
}
