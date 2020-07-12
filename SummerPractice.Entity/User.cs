using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Book> books;

        public User(int id, string login, string password, string surname, 
            string name, string patronymic, DateTime dateOfBirth)
        {
            Id = id;
            Login = login;
            Password = password;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            DateOfBirth = dateOfBirth;
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }
    }
}