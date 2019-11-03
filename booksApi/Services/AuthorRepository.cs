using System.Collections.Generic;
using System.Linq;
using booksApi.Models;

namespace booksApi.Services
{
  public class AuthorRepository : IAuthor
  {
    private readonly BookDbContext _context;

    public AuthorRepository( BookDbContext context )
    {
       _context = context;
    }

    public bool AuthorExist(int authorid)
    {
        return _context.Authors.Any(author =>author.Id == authorid);
    }

    public Author GetAuthor(int authorid)
    {
      return _context.Authors.FirstOrDefault(aut => aut.Id == authorid);
    }

    public ICollection<Author> GetAuthors()
    {
     return _context.Authors.ToList();
    }

    public ICollection<Author> GetAuthorsOfABook(int bookid)
    {
      return _context.BookAuthors.Where(ba=>ba.BookId==bookid).Select(a =>a.Author).ToList();
    }

    public ICollection<Book> GetBooksByAuthor(int authorid)
    {
      return _context.BookAuthors.Where(ba => ba.AuthorId == authorid).Select(b => b.Book).ToList();
    }
  }
}