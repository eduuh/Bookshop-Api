using System.Collections.Generic;
using System.Linq;
using booksApi.Models;

namespace booksApi.Services
{
  public class CountryRepository : ICountry
    {
        private BookDbContext _countryContext;

        public CountryRepository(BookDbContext countryContext)
        {
            _countryContext = countryContext;
        }

        // Input validation code 
        public bool CountryExist(int countryid)
        {
            return _countryContext.Countries.Any(c => c.Id == countryid);
        }

        public ICollection<Author> GetAuthorFromCountry(int countryId)
        {
            return _countryContext.Authors.Where(c => c.Country.Id == countryId).ToList();
        }

        public ICollection<Country> GetCountries()
        {
            return _countryContext.Countries.OrderBy(c => c.Name).ToList();
        }

        public Country GetCountry(int countryId)
        {
            return _countryContext.Countries.FirstOrDefault(c => c.Id == countryId);
        }

        public Country GetCountryOfAnAuthor(int authorId)
        {
            return _countryContext.Authors.Where(a => a.Id == authorId).Select(c => c.Country).FirstOrDefault();
        }

    }
}
