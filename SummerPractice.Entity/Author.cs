using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractice.Entity
{
    public class Author
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public Author(int id, string surname, string name, string patronymic)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
        }
    }
}