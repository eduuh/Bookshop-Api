using System.Collections.Generic;
using booksApi.Models;

namespace booksApi.Services
{
  public interface IAuthor
  {
    ICollection<Author> GetAuthors();
    Author GetAuthor(int reviewid);
    ICollection<Author> GetAuthorsOfABook(int bookid);
    ICollection<Book> GetBooksByAuthor(int authorid);
    bool AuthorExist(int authorid);
  }
}