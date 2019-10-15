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

        public static bool regPerson(string login, string pass)
        {
            string textCommand = "SELECT Count(*) FROM users WHERE Login like '" + login +"'";
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

                if (count > 0) // если логинов больше чем 0 тогда прекращаем код(а на выходе предупреждение)
                {
                    conn.Close();
                    return false;
                }

                textCommand = "INSERT INTO Users (login, pass) values(@login, @pass)";

                using(SqlCommand command1 = new SqlCommand(textCommand,conn))
                {
                    command1.Parameters.AddWithValue("@login", login);
                    command1.Parameters.AddWithValue("@pass", pass);
                    command1.ExecuteNonQuery();
                }

                conn.Close();
                return true;

            }
        }

    }
}
