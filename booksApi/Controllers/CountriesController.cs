using System.Collections.Generic;
using System.Linq;
using booksApi.Dtos;
using booksApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace booksApi.Controllers
{
  [Route("/api/[controller]")]
  [ApiController]
  public class CountriesController : ControllerBase
  {
    private ICountry _countryRepository;

    public CountriesController(ICountry countryRepository)
    {
      _countryRepository = countryRepository;
    }
    //return all the countries  at //api/countries
    [HttpGet]
    [ProducesResponseType(400)]
    [ProducesResponseType(200, Type = typeof(IEnumerable<CountryDto>))]
    public IActionResult GetCountries()
    {
      var countries = _countryRepository.GetCountries().ToList();
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var countriesDto = new List<CountryDto>();
      foreach (var country in countries)
      {
        countriesDto.Add(new CountryDto
        {
          Id = country.Id,
          Name = country.Name
        });
      }
      return Ok(countriesDto);
    }

    //api/countries/countryId
    [HttpGet("{countryId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(200, Type = typeof(CountryDto))]
    public IActionResult GetCountry(int countryId)
    {
      if (!_countryRepository.CountryExist(countryId))
        return NotFound();
      var country = _countryRepository.GetCountry(countryId);
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var countryDto = new CountryDto
      {
        Id = country.Id,
        Name = country.Name
      };
      return Ok(countryDto);
    }
    //api/countries/authors/authorId
    [HttpGet("authors/{authorId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(200, Type = typeof(CountryDto))]
    public IActionResult GetCountryOfAnthor(int authorId)
    {
      //TODO - Validate the author exists
      var country = _countryRepository.GetCountryOfAnAuthor(authorId);
      if (!ModelState.IsValid)
        return BadRequest(ModelState);
      var countryDto = new CountryDto
      {
        Id = country.Id,
        Name = country.Name
      };
      return Ok(countryDto);
    }
    //   Get authors from a country
    //api/countries/countryId/authors
    [HttpGet("{countryid}/authors")]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(200, Type = typeof(CountryDto))]
    public IActionResult GetAuthorsFromACountry(int countryid){
     if(!_countryRepository.CountryExist(countryid)) return NotFound();
      var authors = _countryRepository.GetAuthorFromCountry(countryid);

      if(!ModelState.IsValid)
        return BadRequest(ModelState);
      var authorsDtos = new List<AuthorDto>();

      foreach (var author in authors)
      {
        authorsDtos.Add(new AuthorDto
        {
          Id = author.Id,
          Firstname = author.FirstName,
          Lastname = author.Lastname
        });
      }
      return Ok(authorsDtos);
    }
  }
}
