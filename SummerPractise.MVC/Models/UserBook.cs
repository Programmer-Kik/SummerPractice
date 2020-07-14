using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SummerPractise.MVC.Models
{
    public class UserBook
    {

        public int UserId { get; set; }
        public int BookId { get; set; }

        public Book Book { get; set; }
        public User User { get; set; }
    }
}