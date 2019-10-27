using System.Collections.Generic;
using booksApi.Models;

namespace booksApi.Services
{
  public interface IBook
  {
    ICollection<Book> GetBooks();
    Book GetBook(int bookid);
    Book GetBook(string isbn);
    bool IsDuplicateISbn(string isbn);

    decimal GetBookRating();
    ICollection<Author> GetAuthorsOfABook(int bookid);
    ICollection<Book> GetBooksByAuthor(int authorid);
    bool BookExist(int bookid);
  }
}