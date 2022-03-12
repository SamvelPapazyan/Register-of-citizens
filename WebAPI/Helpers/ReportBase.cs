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

namespace WebAPI.Helpers
{
    /// <summary>
    /// Реализует виртуальный метод, создающий отчёт FastReport.NET
    /// </summary>
    public class ReportBase
    {
        /// <summary>
        /// Виртуальный метод, по умолчанию создающий отчёт FastReport.NET в формате Pdf
        /// </summary>
        /// <param name="conn">Открытое подключение к базе данных</param>
        /// <param name="sql">Сформированный SQL-запрос для выборки отображаемых в отчёте данных</param>
        public virtual void CreateReport(IfxConnection conn, string sql)
        {
            using (var dataAdapter = new IfxDataAdapter(sql, conn))
            {
                DataSet data = new DataSet();
                
                dataAdapter.Fill(data, "citizens_register");
                data.DataSetName = "Data";

                Report report = new Report();
                
                report.Load("C:/Users/zhkh.stazher/Desktop/samvel/WebAPI/Reports/CitizensRegister.frx");
                report.UseFileCache = true;
                report.RegisterData(data, "citizens_register");

                //report.GetDataSource("Register").Enabled = true;
                
                report.Prepare();
                
                var rand = new Random();
                string folder = string.Format(
                    "C:/Users/zhkh.stazher/Desktop/samvel/Отчеты/Отчёт_№_{0}.pdf",
                    rand.Next(1, 100)
                    );

                PDFExport pdf = new PDFExport();

                using (var fileStream = File.Open(folder, FileMode.CreateNew)) 
                {
                    report.Export(pdf, fileStream);

                    fileStream.Flush();
                    fileStream.Close();
                }
            }
        }
    }
}