using MySql.Data.MySqlClient;
using aspcoremariadb.Data;
using aspcoremariadb.Models;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using System.Collections.Generic;

namespace aspcoremariadb.Repository
{
    public class UserRepo
    {
        public string connStr;
        private MySqlConnection con;
       
        public UserRepo() 
        {
            DBConfig db = new DBConfig();

            connStr = db.GetConnecttionString();
        }

                public bool Registeration(User User)
        {
            try
            {
                con = new MySqlConnection(connStr);
                con.Open();
                String queryString = "insert into users(name,email,password) values (@uname,@email,@password)";
                MySqlCommand command = new MySqlCommand(queryString, con);
                command.Parameters.AddWithValue("@uname", User.Name);
                command.Parameters.AddWithValue("@email", User.Email);
                command.Parameters.AddWithValue("@password",User.Password);
                command.ExecuteReader();
                con.Close();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public List<User> IsUserExist(User User)
        {
            List<User> list = new List<User>();
            try
            {
                con = new MySqlConnection(connStr);
                con.Open();
                String queryString = "select *from users where email=@email";
                MySqlCommand command = new MySqlCommand(queryString, con);
                command.Parameters.AddWithValue("@email", User.Email);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new User()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Email = reader["email"].ToString(),
                            Password = reader["password"].ToString()

                        });
                    }

               }
                con.Close();
             
            }
            catch (Exception ex)
            {
                //throw ex.Source = "Internal Error";
            }
            return list;
        }


    }
}
