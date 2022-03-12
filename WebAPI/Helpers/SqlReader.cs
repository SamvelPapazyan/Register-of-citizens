using IBM.Data.Informix;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    /// <summary>
    /// Реализует метод(-ы) считывания данных из БД IBM Informix
    /// </summary>
    public class SqlReader
    {
        /// <summary>
        /// Считывает данные из БД в соответствии с моделью данных Citizen
        /// </summary>
        /// <param name="sql">SQL-запрос SELECT FROM в виде строки</param>
        /// <returns>Возвращает список List объектов модели Citizen cчитанных данных</returns>
        public static List<Citizen> ReadSqlData(string sql)
        {
            List<Citizen> citizensList = new List<Citizen>();

            // Open a connection
            using (IfxConnection conn = new IfxConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
                conn.Open();

                // Create an SQL command
                IfxCommand cmd = new IfxCommand(sql, conn);

                IfxDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Citizen citizen = new Citizen
                    {
                        id = reader.GetInt32(0),
                        lastName = reader.GetString(1),
                        firstName = reader.GetString(2),
                        middleName = reader.GetString(3),
                        birthday = reader.GetString(4)
                    };

                    citizensList.Add(citizen);
                }

                reader.Close();

                conn.Close();
            }

            return citizensList;
        }
    }
}