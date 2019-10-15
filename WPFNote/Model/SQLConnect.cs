using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WPFNote.Model
{
    class SQLConnect
    {
        public static SqlConnection DBConnect(string datasource, string database, string username, string password)
        {
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Integrated Security=True;User ID=" + username + ";Password=" + password;

            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }

        public static SqlConnection DBConnect(string datasource, string database)
        {
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Integrated Security=True;";

            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }
    }
}
