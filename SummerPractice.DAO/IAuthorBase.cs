using SummerPractice.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.DAO
{
    public interface IAuthorBase
    {
        void InsertIntoAuthor(string surname, string name, string patronymic);
        List<Author> SelectAuthor();
        void DeleteAuthor(int id);
    }
}