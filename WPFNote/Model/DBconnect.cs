using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WPFNote.Model
{
    class DBConnect
    {
        public static SqlConnection DBConnection()
        {

        string dataSource = "WIN-GGLQ1C0V4DE";
        string dataBase = "WPFNote";

        return SQLConnect.DBConnect(dataSource, dataBase);
        }
    }
}
