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
    public class AuthorBase:IAuthorBase
    {
        private string connectionString = "Data Source=laptop-st7r1b1j\\sqlexpress;Initial Catalog=Library;Integrated Security=True";

        public void DeleteAuthor(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Delete_author";

                    var paramId = command.CreateParameter();
                    paramId.DbType = DbType.Int32;
                    paramId.ParameterName = "@id";
                    paramId.Value = id;

                    command.Parameters.Add(paramId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new Exception("Can't delete the author!");
            }
        }

        public void InsertIntoAuthor(string surname, string name, string patronymic)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Insert_into_author";

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

                    command.Parameters.Add(paramSurname);
                    command.Parameters.Add(paramName);
                    command.Parameters.Add(paramPatronymic);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new Exception("Can't add the author!");
            }
        }

        public List<Author> SelectAuthor()
        {
            try
            {
                List<Author> authors = new List<Author>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Select_author";

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                authors.Add(new Author((int)reader["id"], (string)reader["surname"],
                                    (string)reader["name"], (string)reader["patronymic"]));
                            }
                        }
                    }

                    return authors;
                }
            }
            catch
            {
                throw new Exception("Error during reading!");
            }
        }
    }
}