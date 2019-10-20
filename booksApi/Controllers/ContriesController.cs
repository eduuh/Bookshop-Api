using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using booksApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace booksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContriesController : ControllerBase
    {
        private ICountryRepository _contryRepository;

        public ContriesController(ICountryRepository contryRepository)
        {
            _contryRepository = contryRepository;
        }

        //return all the countries  at //api/countries
        [HttpGet]
        public IActionResult GetCountries()
        {
            var countries = _contryRepository.GetCountries().ToList();
            return Ok(countries);
        }


        
    }
}