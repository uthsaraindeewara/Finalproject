using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Final_year_project
{
    public static class DBConnection
    {
        private static string connectionString = "server=localhost;port=3306;user id=root;password=;database=final_project;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
