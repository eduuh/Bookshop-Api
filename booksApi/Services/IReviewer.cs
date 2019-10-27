using System.Collections.Generic;
using booksApi.Models;

namespace booksApi.Services
{
  public interface IReviewer
  {
    ICollection<Reviewer> GetReviewers();
    Reviewer GetReviewer(int reviwerid);
    ICollection<Review> GetReviewsByReviewer(int reviewerid);
    Reviewer GetReviewerOfAReview(int reviewid);
    bool ReviewerExist(int reviewerid);
  }
}