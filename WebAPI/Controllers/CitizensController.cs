using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using IBM.Data.Informix;
using System.Configuration;
using WebAPI.Models;
using WebAPI.Services;

namespace ProductsApp.Controllers
{
    public class CitizensController : ApiController
    {
        CitizensService _citizensService = new CitizensService();

        [HttpPost]
        public IHttpActionResult AddCitizen([FromBody]WebAPI.Models.Citizen citizen)
        {
            _citizensService.AddCitizen(citizen);

            return Ok();
        }
        
        [HttpPost]
        public IHttpActionResult DeleteCitizen([FromBody]WebAPI.Models.Citizen citizen)
        {
            _citizensService.DeleteCitizen(citizen);

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult UpdateCitizen([FromBody]WebAPI.Models.Citizen citizen)
        {
            _citizensService.UpdateCitizen(citizen);

            return Ok();
        }

    }
}