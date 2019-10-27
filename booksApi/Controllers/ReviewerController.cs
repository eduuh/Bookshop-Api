using System.Collections.Generic;
using booksApi.Dtos;
using booksApi.Models;
using booksApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace booksApi.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ReviewerController : ControllerBase
    {
    private IReviewer _ireviewerRepository;
    public ReviewerController(IReviewer _reviewerrepo)
    {
      _ireviewerRepository = _reviewerrepo;
    }

    //api/Reviewer/
    [HttpGet]
    [ProducesResponseType(400)]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
    public IActionResult GetAllReviewers(){
      var reviewers =_ireviewerRepository.GetReviewers();
      if(!ModelState.IsValid) return BadRequest(ModelState);
      var reviewersdto = new List<ReviewerDto>();
      foreach (var reviewer in reviewers)
      {
        reviewersdto.Add(new ReviewerDto(){
            Id = reviewer.Id,
            Firstname = reviewer.Firstname,
            Lastname = reviewer.Lastname
        });
      }
      return Ok(reviewersdto);
    }
     
    [HttpGet("{reviewerid}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
    public IActionResult GetReviewer(int reviewerid){
     if(!_ireviewerRepository.ReviewerExist(reviewerid)) return NotFound();

      var reviewer = _ireviewerRepository.GetReviewer(reviewerid);
      var reviewerdto = new ReviewerDto()
      {
        Id = reviewer.Id,
        Firstname = reviewer.Firstname,
        Lastname = reviewer.Lastname
      };
      return Ok(reviewerdto);
    }

//    [HttpGet]
//    public IActionResult GetReviewerofAReview(int review){
//        //Todo -> 
//    }
   
   


  }
}