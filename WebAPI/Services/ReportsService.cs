using FastReport;
using FastReport.Export.Pdf;
using IBM.Data.Informix;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Services
{
    /// <summary>
    /// Реализует методы для работы с отчётами FastReport.NET
    /// </summary>
    public class ReportsService
    {
        /// <summary>
        /// Формирует запрос на создание отчёта FastReport.NET
        /// </summary>
        /// <param name="searchCitizen">Объект класса модели данных с интересующими свойствами</param>
        /// <remarks>
        /// Формирует SQL-запрос по свойствам передаваемой в параметры модели, 
        /// открывает соединение с базой данных и передаёт их для создания отчёта 
        /// </remarks>
        public void CreateReport(SearchCitizen searchCitizen)
        {
            string sql = SqlSearchStringBuilder.BuildSearchString(searchCitizen);

            using (IfxConnection conn = new IfxConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
                conn.Open();                

                ReportBase report = new ReportBase();
                report.CreateReport(conn, sql);

                // Close the connection
                conn.Close();
            }
        }
    }
}