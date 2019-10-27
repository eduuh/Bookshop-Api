using System.Net.Mime;
using System.Collections.Generic;
using booksApi.Models;
using System.Linq;

namespace booksApi.Services
{
  public class ReviewerRepository : IReviewer
  {
    private BookDbContext _context;
    public ReviewerRepository(BookDbContext context)
    {
      _context = context;
    }
    public Reviewer GetReviewer(int reviwerid)
    {
     return _context.Reviewers.FirstOrDefault(reviewer =>reviewer.Id ==reviwerid);
    }

    public Reviewer GetReviewerOfAReview(int reviewid)
    {
      var reviewerid = _context.Reviews.Where(reviw => reviw.Id == reviewid).Select(r => r.Reviewer.Id).First();
      return _context.Reviewers.FirstOrDefault(rev => rev.Id == reviewerid);
    }

    public ICollection<Reviewer> GetReviewers()
    {
      return _context.Reviewers.ToList();
    }

    public ICollection<Review> GetReviewsByReviewer(int reviewerid)
    {
       return _context.Reviews.Where(review => review.Reviewer.Id ==reviewerid).ToList();
    }

    public bool ReviewerExist(int reviewerid)
    {
      return _context.Reviewers.Any(rev => rev.Id ==reviewerid);
    }
  }
}