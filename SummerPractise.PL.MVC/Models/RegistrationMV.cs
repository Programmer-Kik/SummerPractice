using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SummerPractise.PL.MVC.Models
{
    public class RegistrationMV
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }
    }
}