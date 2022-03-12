using IBM.Data.Informix;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Services
{
    /// <summary>
    /// Содержит методы чтения из базы данных: SELECT FROM 
    /// </summary>
    public class SearchCitizenService
    {
        /// <summary>
        /// Реализует чтение всех столбцов и всех строк из базы данных
        /// </summary>
        /// <returns>Возвращает список всех граждан List<Citizen></returns>
        public List<Citizen> GetAllCitizens()
        {
            string sql = "SELECT * FROM citizens_register";

            var citizensList = SqlReader.ReadSqlData(sql);

            return citizensList;
        }

        /// <summary>
        /// Реализует чтение данных граждан в указанном диапазоне даты рождения
        /// </summary>
        /// <param name="searchCitizen">Экземпляр класса модели данных searchCitizen с интересующими свойствами</param>
        /// <returns>Возвращает список List объектов модели Citizen с гражданами в указанном диапазоне даты рождения</returns>
        public List<Citizen> SerchCitizens(SearchCitizen searchCitizen)
        {
            string sql = SqlSearchStringBuilder.BuildSearchString(searchCitizen);

            var citizensList = SqlReader.ReadSqlData(sql);

            return citizensList;
        }

    }
}