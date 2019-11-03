using booksApi.Models;
using System.Collections.Generic;

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
