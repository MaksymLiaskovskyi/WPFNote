using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WPFNote.Model
{
    static class registration
    {

        public static void regPerson(string login, string pass)
        {
            SqlConnection conn = DBConnect.DBConnection();
            
        }

    }
}
