using SummerPractise.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SummerPractise.DAL
{
    public class UserBase
    {
        private string connectionString = "Data Source=LAPTOP-ST7R1B1J\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";

        public void Add(string login, string password, string surname, string name, string patronymic, int age)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Query<User>("Add_user", new
                    {
                        @login = login,
                        @password = password,
                        @surname = surname,
                        @name = name,
                        @patronymic = patronymic,
                        @age = age
                    }, commandType: CommandType.StoredProcedure) ;
                }
            }
            catch
            {
                throw new Exception("Can not add user!");
            }
        }

        public List<User> Select()
        {
            try
            {
                List<User> users = new List<User>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    users = connection.Query<User>("Select_user").ToList();
                }
                return users;
            }

            catch
            {
                throw new Exception("Error!");
            }
        }

        public User FindUserById(int id)
        {
            try
            {
                User user = new User();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    user = connection.Query<User>("Find_user_by_id", new { @id = id },
                        commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
                return user;
            }
            catch
            {
                throw new Exception("Error!");
            }
        }

        public User FindUserByLogin(string login)
        {
            try
            {
                User user = new User();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    user = connection.Query<User>("Find_user_by_login", new { @login = login }, 
                        commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
                return user;
            }
            catch
            {
                throw new Exception("Error!");
            }
        }

        public void Update(string login, string surname, string name, string patronymic, int age)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Query<User>("Update_user", new
                    {
                        @login = login,
                        @surname = surname,
                        @name = name,
                        @patronymic = patronymic,
                        @age = age
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch
            {
                throw new Exception("Can not update user!");
            }
        }

        /*public User SelectWithBooks(string login)
        {
            try
            {
                List<User> users = new List<User>();
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    users = connection.Query<User>("Select_books_from_user", new
                    {
                        @login = login
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
                return users;
            }
            catch
            {
                throw new Exception("Error!");
            }
        }*/
    }
}