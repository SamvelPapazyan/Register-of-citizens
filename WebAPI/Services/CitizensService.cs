using IBM.Data.Informix;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Services
{
    /// <summary>
    /// Содержит методы взаимодействия с базой данных: CREATE, UPDATE, DELETE
    /// </summary>
    public class CitizensService
    {
        /// <summary>
        /// Формирует SQL-запрос INSERT INTO в виде строки и передаёт её на выполнение
        /// </summary>
        /// <param name="citizen">Объект класса модели данных с интересующими свойствами</param>
        /// <remarks>
        /// Свойства передаваемого в параметры метода объекта вставляются в строку SQL-запроса, которая передаётся на выполнение
        /// </remarks>
        public void AddCitizen(Citizen citizen)
        {
            string sql = string.Format(
                "INSERT INTO citizens_register (last_name, first_name, middle_name, birthday) VALUES('{0}', '{1}', '{2}', '{3}')",
                citizen.lastName, citizen.firstName, citizen.middleName, citizen.birthday
                );

            SqlExecutor.ExecuteCommand(sql);
        }

        /// <summary>
        /// Формирует SQL-запрос DELETE FROM в виде строки и передаёт её на выполнение
        /// </summary>
        /// <param name="citizen">Объект класса модели данных с интересующими свойствами</param>
        /// <remarks>
        /// Свойства передаваемого в параметры метода объекта вставляются в строку SQL-запроса, которая передаётся на выполнение
        /// </remarks>
        public void DeleteCitizen(Citizen citizen)
        {
            string sql = string.Format(
               "DELETE FROM citizens_register " +
               "WHERE last_name = '{0}' AND first_name = '{1}' AND middle_name = '{2}' AND birthday = '{3}'; ",
               citizen.lastName, citizen.firstName, citizen.middleName, citizen.birthday
               );

            SqlExecutor.ExecuteCommand(sql);
        }

        /// <summary>
        /// Формирует SQL-запрос UPDATE в виде строки и передаёт её на выполнение
        /// </summary>
        /// <param name="citizen">Объект класса модели данных с интересующими свойствами</param>
        /// <remarks>
        /// Свойства передаваемого в параметры метода объекта вставляются в строку SQL-запроса, которая передаётся на выполнение
        /// </remarks>
        public void UpdateCitizen(Citizen citizen)
        {
            string sql = string.Format(
                "UPDATE citizens_register " +
                "SET(last_name, first_name, middle_name, birthday) = ('{0}', '{1}', '{2}', '{3}') " +
                "WHERE id = {4};",
                citizen.lastName, citizen.firstName, citizen.middleName, citizen.birthday, citizen.id
                );

            SqlExecutor.ExecuteCommand(sql);
        }

    }
}