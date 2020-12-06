using SummerPractise.DAL;
using SummerPractise.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractise.BL
{
    public class BookLogic : IBookLogic
    {
        BookBase bookBase;

        public BookLogic()
        {
            bookBase = new BookBase();
        }

        public BookLogic(BookBase bookBase)
        {
            this.bookBase = bookBase;
        }

        public void Add(string name, int year, string authorSurname, string authorName, string authorPatronymic)
        {
            bookBase.Add(name, year, authorSurname, authorName, authorPatronymic);
        }

        public void Delete(int id)
        {
            bookBase.Delete(id);
        }

        public List<Book> Select()
        {
            return bookBase.Select();
        }

        public void Update(int id, string name, int year, string authorSurname, string authorName, string authorPatronymic)
        {
            bookBase.Update(id, name, year, authorSurname, authorName, authorPatronymic);
        }

        public Book FindById(int id)
        {
            return bookBase.FindById(id);
        }
    }
}