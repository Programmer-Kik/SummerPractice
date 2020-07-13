using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SummerPractise.MVC.Models
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection")
        {
            if (!Database.Exists())
            {
                Database.Create();
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}