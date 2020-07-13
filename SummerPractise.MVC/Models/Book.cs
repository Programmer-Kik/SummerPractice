using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SummerPractise.MVC.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string AuthorSurname { get; set; }
        public string AuthorName { get; set; }
        public string AuthorPatronymic { get; set; }

        public ICollection<User> Users { get; set; }

        public Book()
        {
            Users = new List<User>();
        }
    }
}