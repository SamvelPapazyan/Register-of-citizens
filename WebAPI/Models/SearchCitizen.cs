using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    /// <summary>
    /// Модель для поиска гражданина по ФИО и диапазону даты рождения 
    /// </summary>
    public class SearchCitizen
    {
        public int id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string startDate { get; set; }
        public string finishDate { get; set; }

        public static implicit operator SearchCitizen(Citizen v)
        {
            throw new NotImplementedException();
        }
    }
}