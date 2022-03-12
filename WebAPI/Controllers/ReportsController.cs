using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    public class ReportsController : ApiController
    {
        ReportsService reportsService = new ReportsService();

        [HttpPost]
        public IHttpActionResult PrintReport([FromBody]WebAPI.Models.SearchCitizen searchCitizen)
        {
            reportsService.CreateReport(searchCitizen);

            return Ok();
        }
    }
}
