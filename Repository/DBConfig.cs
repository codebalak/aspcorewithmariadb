using System.Configuration;

namespace aspcoremariadb.Repository
{
    public class DBConfig
    {
        public  string connStr;
        public string  GetConnecttionString() {

            string connStr = "server=127.0.0.1;user=root;database=studentdb;port=3306;password=12345;";

            return connStr;
        }

    }
}
