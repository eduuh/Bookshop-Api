using System.Collections.Generic;
using booksApi.Models;

namespace booksApi.Services
{
  public interface IBook
  {
    ICollection<Book> GetBooks();
    Book GetBook(int bookid);
    Book GetBook(string isbn);
    decimal GetBookRating(int bookid);
    bool BookExist(int bookid);
    bool BookExist(string isbn);
    bool IsDuplicateISbn(string isbn,string bookisbn);
  }
}