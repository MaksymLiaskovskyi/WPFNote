using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WPFNote.Model
{
    static class enter
    {
        public static bool enterPerson(string login, string pass)
        {
            string textCommand = "SELECT Count(*) FROM users WHERE Login like '" + login + "' AND pass like '"+pass+"'";
            int count = 0;
            using (SqlConnection conn = DBConnect.DBConnection())
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(textCommand, conn))
                {
                    try
                    {
                        count = (int)command.ExecuteScalar(); // получение кол-ва логинов что есть в БД
                    }
                    catch { }
                }

                if (count > 0){         // если логинов больше чем 0 тогда идет вход
                    conn.Close();
                    return true;
                }

                conn.Close();
                return false;

            }
        }
    }
}
