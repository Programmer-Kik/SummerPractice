using SummerPractice.DAO;
using SummerPractice.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.BL
{
    public class BookLogic
    {
        private IBookBase bookBase;

        public BookLogic()
        {
            bookBase = new BookBase();
        }

        public BookLogic(IBookBase bookBase)
        {
            this.bookBase = bookBase;
        }

        public void AddAuthorForBook(int authorId, int bookId)
        {
            bookBase.AddAuthorForBook(authorId, bookId);
        }

        public void DeleteBook(int id)
        {
            bookBase.DeleteBook(id);
        }

        public Book FindBookByName(string name)
        {
            return bookBase.FindBookByName(name);
        }

        public void InsertIntoBook(string name, int year)
        {
            bookBase.InsertIntoBook(name, year);
        }

        public List<Book> SelectBooks()
        {
            return bookBase.SelectBook();
        }
    }
}