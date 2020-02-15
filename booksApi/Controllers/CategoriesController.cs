using System.Collections.ObjectModel;
using booksApi.Dtos;
using booksApi.Models;
using booksApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace booksApi.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly ICategory _categoryRepostiory;
        public CategoriesController(ICategory categoriesRepository)
        {
            _categoryRepostiory = categoriesRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Category>))]
        [ProducesResponseType(400)]
        public IActionResult GetCategories()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var categories = _categoryRepostiory.GetCategories();
            var categoriesdtos = new Collection<CategoryDto>();
            foreach (var category in categories)
            {
                categoriesdtos.Add(new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name
                });
            }
            return Ok(categoriesdtos);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ICollection<CategoryDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetCategory(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var category = _categoryRepostiory.GetCategory(id);
            // check for null
            if (!_categoryRepostiory.CategoryExists(id)) return NotFound();
            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
            return Ok(categoryDto);
        }

        [HttpGet("book/{bookid}/categories")]
        [ProducesResponseType(200, Type = typeof(ICollection<Book>))]
        [ProducesResponseType(400)]
        public IActionResult GetAllCategoriesForBook(int bookid)
        {
            if (!ModelState.IsValid) return BadRequest();
            var categories = _categoryRepostiory.GetAllCategoriesForABook(bookid);
            //Todo validate if book exist
            var categoriesdtos = new Collection<CategoryDto>();
            foreach (var category in categories)
            {
                categoriesdtos.Add(new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name
                });
            }
            return Ok(categoriesdtos);
        }
        //   Getallbooksforcategory
        //api/countries/categoryId/books
        [HttpGet("{categoryid}/books")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(BookDto))]
        public IActionResult GetAllBooksForCategory(int categoryid)
        {
            if (!_categoryRepostiory.CategoryExists(categoryid)) return NotFound();
            var books = _categoryRepostiory.GetAllBooksForCategory(categoryid);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var bookDtos = new List<BookDto>();

            foreach (var book in books)
            {
                bookDtos.Add(new BookDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Isbn = book.Isbn,
                    DatePublished = book.DatePublished
                });
            }
            return Ok(bookDtos);
        }
    }
}
