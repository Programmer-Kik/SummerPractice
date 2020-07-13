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
    public class BookBase:IBookBase
    {
        private string connectionString = "Data Source=laptop-st7r1b1j\\sqlexpress;Initial Catalog=Library;Integrated Security=True";

        public void AddAuthorForBook(int authorId, int bookId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Insert_into_authors_of_books";

                    var paramAuthorId = command.CreateParameter();
                    paramAuthorId.DbType = DbType.Int32;
                    paramAuthorId.ParameterName = "@author_id";
                    paramAuthorId.Value = authorId;

                    var paramBookId = command.CreateParameter();
                    paramBookId.DbType = DbType.Int32;
                    paramBookId.ParameterName = "@book_id";
                    paramBookId.Value = bookId;

                    command.Parameters.Add(paramAuthorId);
                    command.Parameters.Add(paramBookId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new Exception("Can't add the book to you!");
            }
        }

        public void DeleteBook(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Delete_book";

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
                throw new Exception("Can't delete the book!");
            }
        }

        public Book FindBookByName(string name)
        {
            try
            {
                Book book = null;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Find_book_by_name";

                    var paramName = command.CreateParameter();
                    paramName.DbType = DbType.String;
                    paramName.ParameterName = "@name";
                    paramName.Value = name;

                    command.Parameters.Add(paramName);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                book = new Book((int)reader["id"], (string)reader["name"],
                                    (int)reader["year"]);
                            }
                        }
                    }
                }

                    return book;
            }
            catch
            {
                throw new Exception("Can't find the book!");
            }
        }

        public void InsertIntoBook(string name, int year)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Insert_into_book";

                    var paramName = command.CreateParameter();
                    paramName.DbType = DbType.String;
                    paramName.ParameterName = "@name";
                    paramName.Value = name;

                    var paramYear = command.CreateParameter();
                    paramYear.DbType = DbType.Int32;
                    paramYear.ParameterName = "@year";
                    paramYear.Value = year;

                    command.Parameters.Add(paramName);
                    command.Parameters.Add(paramYear);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new Exception("Can't add the book!");
            }
        }

        public List<Book> SelectBook()
        {
            try
            {
                List<Book> books = new List<Book>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Select_book";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                books.Add(new Book((int)reader["id"], (string)reader["name"],
                                    (int)reader["year"]));
                            }
                        }
                    }

                    return books;
                }
            }
            catch
            {
                throw new Exception("Error during reading!");
            }
        }
    }
}