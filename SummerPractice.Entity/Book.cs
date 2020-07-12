using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.Entity
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public List<Author> authors;

        public Book(int id, string name, int year)
        {
            Id = id;
            Name = name;
            Year = year;
            authors = new List<Author>();
        }

        public void AddAuthor(Author author)
        {
            authors.Add(author);
        }
    }
}