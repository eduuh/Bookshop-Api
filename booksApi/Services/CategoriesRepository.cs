using booksApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace booksApi.Services
{
    public class CategoriesRepository : ICategory
    {
        private readonly BookDbContext _context;
        public CategoriesRepository(BookDbContext bookcontext)
        {
            _context = bookcontext;
        }

        public bool CategoryExists(int categoryId)
        {
            return _context.Categories.Any(c => c.Id == categoryId);
        }
        public ICollection<Category> GetCategories()
        {
            return _context.Categories.OrderBy(c => c.Name).ToList();
        }
        public Category GetCategory(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }
        public ICollection<Category> GetAllCategoriesForABook(int bookid)
        {
            return _context.BookCategories.Where(b => b.BooKId == bookid).Select(c => c.Category).ToList();
        }
        public ICollection<Book> GetAllBooksForCategory(int categoryid)
        {
            return _context.BookCategories.Where(c => c.CategoryId == categoryid).Select(b => b.Book).ToList();
        }
    }
}
