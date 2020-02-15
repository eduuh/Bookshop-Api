using System.Collections.Generic;
using System.Linq;
using booksApi.Models;

namespace booksApi.Services
{
    public class BookRepository : IBook
    {
        private readonly BookDbContext _context;
        public BookRepository(BookDbContext context)
        {
            _context = context;
        }
        public bool BookExist(int bookid)
        {
            return _context.Books.Any(b => b.Id == bookid);
        }

        public bool BookExist(string isbn)
        {
            return _context.Books.Any(b => b.Isbn == isbn);
        }

        public Book GetBook(int bookid)
        {
            return _context.Books.FirstOrDefault(b => b.Id == bookid);
        }

        public Book GetBook(string isbn)
        {
            return _context.Books.FirstOrDefault(b => b.Isbn == isbn);
        }

        public decimal GetBookRating(int bookid)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public bool IsDuplicateISbn(string isbn, string bookisbn)
        {
            throw new System.NotImplementedException();
        }
    }
}