using booksApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace booksApi.Services
{
    public interface ICategory
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int categoryid);
        ICollection<Category> GetAllCategoriesForABook(int bookid);
        ICollection<Book> GetAllBooksForCategory(int categoryid);
        bool CategoryExists(int categoryid);
    }
}
