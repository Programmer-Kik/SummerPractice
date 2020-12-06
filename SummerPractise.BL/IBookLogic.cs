using SummerPractise.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractise.BL
{
    public interface IBookLogic
    {
        void Add(string name, int year, string authorSurname, string authorName, string authorPatronymic);
        void Delete(int id);
        List<Book> Select();
        void Update(int id, string name, int year, string authorSurname, string authorName, string authorPatronymic);

    }
}
