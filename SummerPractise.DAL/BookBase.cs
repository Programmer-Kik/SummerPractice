using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SummerPractise.Entity;
using Dapper;

namespace SummerPractise.DAL
{
    public class BookBase
    {
        private string connectionString = "Data Source=LAPTOP-ST7R1B1J\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";

        public void Add(string name, int year, string authorSurname, string authorName, string authorPatronymic)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Query<Book>("Add_book", new
                    {
                        @name = name,
                        @year = year,
                        @authorSurname = authorSurname,
                        @authorName = authorName,
                        @authorPatronymic = authorPatronymic
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch
            {
                throw new Exception("Can not add book!");
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Query<Book>("Delete_book", new { @id = id }, commandType: CommandType.StoredProcedure);
                }
            }
            catch
            {
                throw new Exception("Can not delete book!");
            }
        }

        public List<Book> Select()
        {
            try
            {
                List<Book> books = new List<Book>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    books = connection.Query<Book>("Select_book", new { }, commandType: CommandType.StoredProcedure)
                        .ToList();
                }
                return books;
            }

            catch
            {
                throw new Exception("Error!");
            }
        }

        public void Update(int id, string name, int year, string authorSurname, string authorName, string authorPatronymic)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Query<Book>("Update_book", new
                    {
                        @id = id,
                        @name = name,
                        @year = year,
                        @authorSurname = authorSurname,
                        @authorName = authorName,
                        @authorPatronymic = authorPatronymic
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch
            {
                throw new Exception("Can not update book!");
            }
        }

        public Book FindById(int id)
        {
            try
            {
                Book book = new Book();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    book = connection.Query<Book>("Find_book_by_id", new
                    {
                        @id = id
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
                return book;
            }
            catch
            {
                throw new Exception("Do not find!");
            }
        }
    }
}
