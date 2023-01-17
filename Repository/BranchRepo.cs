using aspcoremariadb.Data;
using aspcoremariadb.Models;
using aspcoremariadb.Repository;
using System.Drawing;
using MySql.Data.MySqlClient;

namespace aspcoremariadb.Repository
{
    public class BranchRepo
    {
        public string connStr;
        private MySqlConnection con;
        public BranchRepo() 
        {
            DBConfig db = new DBConfig();  

            connStr = db.GetConnecttionString();
        }

        public List<Branch> GetAllDetails()
        {
            
            List<Branch> list = new List<Branch>();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                // Perform database operations

                MySqlCommand cmd = new MySqlCommand("select * from Branch ", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Branch()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            branch_name = reader["branch_name"].ToString(),

                        });
                    }

                    conn.Close();
                }

                return list;
            }
        }


        public bool AddBranchs(Branch Branch)
        {
            con = new MySqlConnection(connStr);
            con.Open();

            String queryString = "insert into Branch(branch_name) values (@branch_name)";
            MySqlCommand command = new MySqlCommand(queryString, con);
            command.Parameters.AddWithValue("@branch_name", Branch.branch_name);
            command.ExecuteReader();
            con.Close();
            return true;
        }

        public bool UpdateBranch(Branch Branch)
        {
            con = new MySqlConnection(connStr);
            con.Open();

            String queryString = "update branch set branch_name=@branch_name where id=@id";
            MySqlCommand command = new MySqlCommand(queryString, con);
            command.Parameters.AddWithValue("@branch_name", Branch.branch_name);
            command.Parameters.AddWithValue("@id", Branch.Id);
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

                String queryString = "delete from branch  where id=@id";
                MySqlCommand command = new MySqlCommand(queryString, con);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteReader();
                con.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public List<Branch> GetSingleBranch(int id)
        {
            /*DBConfig d = new DBConfig();
            connStr = d.GetConnecttionString();*/
            List<Branch> list = new List<Branch>();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                // Perform database operations

                MySqlCommand cmd = new MySqlCommand("select * from branch where id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Branch()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            branch_name = reader["branch_name"].ToString(),



                        });
                    }

                    conn.Close();
                }

                return list;
            }
        }


    }
}
