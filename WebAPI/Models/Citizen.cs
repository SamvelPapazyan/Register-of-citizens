using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    /// <summary>
    /// Модель данных гражданина, хранящихся в базе данных
    /// </summary>
    public class Citizen
    {
        public int id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string birthday { get; set; }
    }
}