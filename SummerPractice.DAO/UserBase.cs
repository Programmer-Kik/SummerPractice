using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummerPractice.Entity;

namespace SummerPractice.DAO
{
    public class UserBase:IUserBase
    {
        private string connectionString = "Data Source=laptop-st7r1b1j\\sqlexpress;Initial Catalog=Library;Integrated Security=True";

        public void AddBookForUser(int userId, int bookId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Insert_into_taken_books_by_user";

                    var paramUserId = command.CreateParameter();
                    paramUserId.DbType = DbType.Int32;
                    paramUserId.ParameterName = "@user_id";
                    paramUserId.Value = userId;

                    var paramBookId = command.CreateParameter();
                    paramBookId.DbType = DbType.Int32;
                    paramBookId.ParameterName = "@book_id";
                    paramBookId.Value = bookId;

                    command.Parameters.Add(paramUserId);
                    command.Parameters.Add(paramBookId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new Exception("Can't add the book for user!");
            }
        }

        public User FindUserById(int id)
        {
            User user = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Find_user_by_id";

                var paramId = command.CreateParameter();
                paramId.DbType = DbType.Int32;
                paramId.ParameterName = "@id";
                paramId.Value = id;

                command.Parameters.Add(paramId);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            user = new User((int)reader["id"], (string)reader["login"], 
                                (string)reader["password"], (string)reader["surname"], 
                                (string)reader["name"], (string)reader["patronymic"], 
                                (DateTime)reader["date_of_birth"]);
                        }
                    }
                }

                return user;
            }
        }

        public void InsertIntoUser(string login, string password, string surname, 
            string name, string patronymic, DateTime dateOfBirth)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Insert_into_user";

                    var paramLogin = command.CreateParameter();
                    paramLogin.DbType = DbType.String;
                    paramLogin.ParameterName = "@login";
                    paramLogin.Value = login;

                    var paramPassword = command.CreateParameter();
                    paramPassword.DbType = DbType.String;
                    paramPassword.ParameterName = "@password";
                    paramPassword.Value = password;

                    var paramSurname = command.CreateParameter();
                    paramSurname.DbType = DbType.String;
                    paramSurname.ParameterName = "@surname";
                    paramSurname.Value = surname;

                    var paramName = command.CreateParameter();
                    paramName.DbType = DbType.String;
                    paramName.ParameterName = "@name";
                    paramName.Value = name;

                    var paramPatronymic = command.CreateParameter();
                    paramPatronymic.DbType = DbType.String;
                    paramPatronymic.ParameterName = "@patronymic";
                    paramPatronymic.Value = patronymic;

                    var paramDateOfBirth = command.CreateParameter();
                    paramDateOfBirth.DbType = DbType.Date;
                    paramDateOfBirth.ParameterName = "@date_of_birth";
                    paramDateOfBirth.Value = dateOfBirth;

                    command.Parameters.Add(paramLogin);
                    command.Parameters.Add(paramPassword);
                    command.Parameters.Add(paramSurname);
                    command.Parameters.Add(paramName);
                    command.Parameters.Add(paramPatronymic);
                    command.Parameters.Add(paramDateOfBirth);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new Exception("Can't add new user!");
            }
        }
    }
}