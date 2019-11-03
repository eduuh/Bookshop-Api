using System.Collections.Generic;
using booksApi.Dtos;
using booksApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace booksApi.Controllers
{
  [Route("/api/[controller]")]
  [ApiController]
  public class AuthorsController : ControllerBase
  {
    private readonly IAuthor _authorrepo;

    public AuthorsController(IAuthor authorrepo)
    {
      _authorrepo = authorrepo;
    }
    [HttpGet]
    [ProducesResponseType(400)]
    [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorDto>))]
    public IActionResult GetAuthors()
    {
      var authors = _authorrepo.GetAuthors();
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var authorsdtos = new List<AuthorDto>();
      foreach (var author in authors)
      {
        authorsdtos.Add(new AuthorDto
        {
          Id = author.Id,
          Firstname = author.FirstName,
          Lastname = author.Lastname
        });
      }
      return Ok(authorsdtos);
    }
    [HttpGet("{authorid}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(200, Type = typeof(AuthorDto))]
    public IActionResult GetAuthor(int authorid)
    {
      //Todo validate for does not exist
      var author = _authorrepo.GetAuthor(authorid);
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var authordto = new AuthorDto
      {
        Id = author.Id,
        Firstname = author.FirstName,
        Lastname = author.Lastname
      };
      return Ok(authordto);
    }
    [HttpGet("book/{bookid}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
  [ProducesResponseType(200, Type=typeof(IEnumerable<AuthorDto>))]
  public IActionResult GetAuthorofABook(int bookid){
      //Todo check if bookexist

      var authors = _authorrepo.GetAuthorsOfABook(bookid);
      if(!ModelState.IsValid) return BadRequest(ModelState);
      var authorsdto = new List<AuthorDto>();
      foreach (var author in authors)
      {
        authorsdto.Add(new AuthorDto()
        {
          Id = author.Id,
          Firstname = author.FirstName,
          Lastname = author.Lastname
        });
      }
      return Ok(authorsdto);
    }


  }
}