using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using booksApi.Models;

namespace booksApi.Services
{
    public interface ICountry
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int countryId);
        Country GetCountryOfAnAuthor(int authorId);
        ICollection<Author> GetAuthorFromCountry(int countryId);
        bool CountryExist(int countryid);
    }
}
