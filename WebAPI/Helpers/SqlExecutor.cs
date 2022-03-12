using IBM.Data.Informix;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebAPI.Helpers
{
    /// <summary>
    /// Реализует метод(-ы) прямого выполнения передаваемого SQL-запроса к базе данных IBM Informix
    /// </summary>
    public class SqlExecutor
    {
        /// <summary>
        /// Выполняет передаваемый в параметры SQL-запрос к базе данных IBM Informix
        /// </summary>
        /// <param name="sql">SQL-запрос в виде строки</param>
        public static void ExecuteCommand(string sql)
        {
            using (IfxConnection conn = new IfxConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
                conn.Open();

                //Create an IfxCommand that uses the connection
                IfxCommand cmd = new IfxCommand(sql, conn);

                //Execute the command
                cmd.ExecuteNonQuery();

                // Close the connection
                conn.Close();
            }
        }
    }
}