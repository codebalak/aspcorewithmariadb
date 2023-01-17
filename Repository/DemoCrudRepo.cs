using aspcoremariadb.Models;
using aspcoremariadb.Repository;
using aspcoremariadb.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace aspcoremariadb.Repository
{
    public class DemoCrudRepo
    {
        string connStr;
        private MySqlConnection con;
       

        public DemoCrudRepo()
        {
            DBConfig d = new DBConfig();
            connStr = d.GetConnecttionString();
        }

        public List<Book> GetAllDetails()
        {
            DBConfig d = new DBConfig();
            connStr = d.GetConnecttionString();
            List<Book> list = new List<Book>();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                // Perform database operations

                MySqlCommand cmd = new MySqlCommand("select * from book ", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Book()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Title = reader["title"].ToString(),
                            Author = reader["author"].ToString(),
                            Description = reader["description"].ToString()

                        });
                    }

                    conn.Close();
                }

                return list;
            }
        }

                
        public bool AddBooks(Book book)
        {
            con = new MySqlConnection(connStr);
            con.Open();
            
            String queryString = "insert into book(title,author,description) values (@title, @author, @description)";
            MySqlCommand command  = new MySqlCommand(queryString, con);
            command.Parameters.AddWithValue("@title",book.Title);
            command.Parameters.AddWithValue("@author", book.Author);
            command.Parameters.AddWithValue("@description", book.Description);
            command.ExecuteReader();
            con.Close();
            return true;
        }

        public bool UpdateBook(Book book)
        {
            con = new MySqlConnection(connStr);
            con.Open();

            String queryString = "update book set title=@title,author=@author,description=@description where id=@id";
            MySqlCommand command = new MySqlCommand(queryString, con);
            command.Parameters.AddWithValue("@title", book.Title);
            command.Parameters.AddWithValue("@author", book.Author);
            command.Parameters.AddWithValue("@description", book.Description);
            command.Parameters.AddWithValue("@id", book.Id);
            command.ExecuteReader();
            con.Close();
            return true;
        }

        public bool Destroy(int id)
        {
            try
            {
                con = new MySqlConnection(connStr);
                con.Open();

                String queryString = "delete from book  where id=@id";
                MySqlCommand command = new MySqlCommand(queryString, con);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteReader();
                con.Close();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }


        public List<Book> GetSingleBook(int id)
        {
            /*DBConfig d = new DBConfig();
            connStr = d.GetConnecttionString();*/
            List<Book> list = new List<Book>();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                // Perform database operations

                MySqlCommand cmd = new MySqlCommand("select * from book where id=@id", conn);
                cmd.Parameters.AddWithValue("@id",id);
                
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Book()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Title = reader["title"].ToString(),
                            Author = reader["author"].ToString(),
                            Description = reader["description"].ToString()


                        });
                    }

                    conn.Close();
                }

                return list;
            }
        }
    }
}
