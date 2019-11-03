using System.Collections.Generic;
using booksApi.Dtos;
using booksApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace booksApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BooksController : ControllerBase
  {
    private readonly IBook _bookrepository;
    public BooksController(IBook _bookrepo)
    {
      _bookrepository = _bookrepo;
    }
    [HttpGet]
    [ProducesResponseType(400)]
    [ProducesResponseType(200, Type=typeof(IEnumerable<BookDto>))]
    public IActionResult GetAllBooks(){

      var books = _bookrepository.GetBooks();
      if(!ModelState.IsValid) return BadRequest(ModelState);
      var booksdto = new List<BookDto>();
      foreach (var book in books)
      {
        booksdto.Add(new BookDto
        {
          Id = book.Id,
          Title = book.Title,
          Isbn = book.isbn,
          DatePublished = book.DatePublished
        });
      }
      return Ok(booksdto);
    }

    [HttpGet("{bookid}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(200, Type=typeof(IEnumerable<BookDto>))]
    public IActionResult GetBook(int bookid){
      if(!_bookrepository.BookExist(bookid))return NotFound();
      var book = _bookrepository.GetBook(bookid);
      if(!ModelState.IsValid) return BadRequest(ModelState);
    
        var bookdto =new BookDto
        {
          Id = book.Id,
          Title = book.Title,
          Isbn = book.isbn,
          DatePublished = book.DatePublished
        };
      
      return Ok(bookdto);
    }
    [HttpGet("isbn/{isbn}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
    public IActionResult GetBook(string isbn)
    {
      if (!_bookrepository.BookExist(isbn)) return NotFound();
      var book = _bookrepository.GetBook(isbn);
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var bookdto = new BookDto
      {
        Id = book.Id,
        Title = book.Title,
        Isbn = book.isbn,
        DatePublished = book.DatePublished
      };

      return Ok(bookdto);
    }
  }
}