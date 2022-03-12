using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    public class SearchCitizenController : ApiController
    {
        SearchCitizenService _searchCitizenService = new SearchCitizenService();
       
        [HttpGet]
        public IHttpActionResult GetAllCitizens()
        {
            var citizensList = _searchCitizenService.GetAllCitizens();

            return Ok(citizensList);
        }

        [HttpPost]
        public IHttpActionResult SearchCitizens([FromBody] Models.SearchCitizen searchCitizen)
        {
            var citizensList = _searchCitizenService.SerchCitizens(searchCitizen);

            if (citizensList.Count == 0)
            {
                return BadRequest("По вашему запросу ничего не найдено");
            }

            return Ok(citizensList);
        } 

    }
}
