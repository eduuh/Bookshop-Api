using System.Collections.Generic;
using booksApi.Models;

namespace booksApi.Services
{
  public interface IReview
  {
    ICollection<Review> GetReviews();
    Review GetReviewById(int reviewid);
    ICollection<Review> GetReviewsForBook(int bookid);
    Book GetBookOfAReview(int reviewid);
    bool ReviewExist(int reviewid);
  }
}