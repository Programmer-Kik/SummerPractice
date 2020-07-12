using SummerPractice.DAO;
using SummerPractice.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.BL
{
    public class AuthorLogic
    {
        private IAuthorBase authorBase;

        public AuthorLogic()
        {
            authorBase = new AuthorBase();
        }

        public AuthorLogic(IAuthorBase authorBase)
        {
            this.authorBase = authorBase;
        }

        public void DeleteAuthor(int id)
        {
            authorBase.DeleteAuthor(id);
        }

        public void InsertIntoAuthor(string surname, string name, string patronymic)
        {
            authorBase.InsertIntoAuthor(surname, name, patronymic);
        }

        public List<Author> SelectAuthor()
        {
            return authorBase.SelectAuthor();
        }
    }
}