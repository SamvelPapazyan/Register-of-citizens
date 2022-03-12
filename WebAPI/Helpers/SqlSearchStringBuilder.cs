using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    /// <summary>
    /// Реализует метод(-ы) формирования строки SQL-запроса
    /// </summary>
    public class SqlSearchStringBuilder
    {
        /// <summary>
        /// Содержит условия, по которым формируется корректный запрос SELECT FROM 
        /// </summary>
        /// <param name="searchCitizen">Экземпляр класса модели данных searchCitizen с интересующими свойствами</param>
        /// <returns>Возвращает SQL-запрос SELECT FROM в виде строки</returns>
        /// <remarks>
        /// Условная конструкции if / else проверяет свойства переданной в параметр метода модели. 
        /// В зависимости от результатов проверки формируется корректная строка SQL-запроса 
        /// </remarks>
        public static string BuildSearchString(SearchCitizen searchCitizen)
        {
            string sql;

            if (!String.IsNullOrEmpty(searchCitizen.middleName))
            {
                sql = string.Format(
                "SELECT * FROM citizens_register " +
                "WHERE birthday >= '{0}' AND birthday <= '{1}' AND last_name = '{2}' AND first_name = '{3}' AND middle_name = '{4}';",
                searchCitizen.startDate, searchCitizen.finishDate, searchCitizen.lastName, searchCitizen.firstName, searchCitizen.middleName
                );
            }
            else if (!String.IsNullOrEmpty(searchCitizen.startDate) & !String.IsNullOrEmpty(searchCitizen.finishDate))
            {
                sql = string.Format(
                "SELECT * FROM citizens_register " +
                "WHERE birthday >= '{0}' AND birthday <= '{1}' AND last_name = '{2}' AND first_name = '{3}';",
                searchCitizen.startDate, searchCitizen.finishDate, searchCitizen.lastName, searchCitizen.firstName
                );
            }
            else
            {
                sql = "SELECT * FROM citizens_register";
            }

            return sql;
        }
    }
}