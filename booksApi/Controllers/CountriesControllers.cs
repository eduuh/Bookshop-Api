using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using booksApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace booksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesControllers: Controller
    {
        private ICountryRepository _countryRepository;

        public CountriesControllers(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        //return all the countries  at //api/countries
        [HttpGet]
        public IActionResult GetCountries()
        {
            var countries = _countryRepository.GetCountries().ToList();
            return Ok(countries);
        }
    }
}
