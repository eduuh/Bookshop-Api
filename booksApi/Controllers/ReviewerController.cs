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
        private readonly IReviewer _ireviewerRepository;
        public ReviewerController(IReviewer _reviewerrepo)
        {
            _ireviewerRepository = _reviewerrepo;
        }

        //api/Reviewer/
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
        public IActionResult GetAllReviewers()
        {
            var reviewers = _ireviewerRepository.GetReviewers();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var reviewersdto = new List<ReviewerDto>();
            foreach (var reviewer in reviewers)
            {
                reviewersdto.Add(new ReviewerDto()
                {
                    Id = reviewer.Id,
                    Firstname = reviewer.Firstname,
                    Lastname = reviewer.Lastname
                });
            }
            return Ok(reviewersdto);
        }

        [HttpGet("{reviewerid}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(Reviewer))]
        public IActionResult GetReviewer(int reviewerid)
        {
            if (!_ireviewerRepository.ReviewerExist(reviewerid)) return NotFound();

            var reviewer = _ireviewerRepository.GetReviewer(reviewerid);
            var reviewerdto = new ReviewerDto()
            {
                Id = reviewer.Id,
                Firstname = reviewer.Firstname,
                Lastname = reviewer.Lastname
            };
            return Ok(reviewerdto);
        }

        [HttpGet("{id}/reviews")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public IActionResult GetReviewsByReviewer(int id)
        {
            if (!_ireviewerRepository.ReviewerExist(id)) return NotFound();
            var reviews = _ireviewerRepository.GetReviewsByReviewer(id);
            var reviewsdto = new List<ReviewDto>();
            foreach (var review in reviews)
            {
                reviewsdto.Add(new ReviewDto
                {
                    Id = review.Id,
                    HeadLine = review.HeadLine,
                    Rating = review.Ratings
                });
            }
            return Ok(reviews);
        }

        [HttpGet("{id}/reviewer")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
        public IActionResult GetReviewerOfAReview(int id)
        {
            if (!_ireviewerRepository.ReviewerExist(id)) return NotFound();
            var reviewer = _ireviewerRepository.GetReviewerOfAReview(id);
            var reviewerdto = new ReviewerDto
            {
                Id = reviewer.Id,
                Firstname = reviewer.Firstname,
                Lastname = reviewer.Lastname
            };

            return Ok(reviewerdto);
        }




    }
}