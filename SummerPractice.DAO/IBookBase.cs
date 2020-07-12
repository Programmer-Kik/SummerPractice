using SummerPractice.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.DAO
{
    public interface IBookBase
    {
        void InsertIntoBook(string name, int year);
        void AddAuthorForBook(int authorId, int bookId);
        List<Book> SelectBook();
        void DeleteBook(int id);
        Book FindBookByName(string name);
    }
}