using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.DBContexts;
using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Data.Implementations
{
    public class ReviewRepository : Repository, IReviewRepository
    {
        public ReviewRepository(GamesContext context) : base(context)
        {
        }
        public Review GetReviewById(int reviewid)
        {
            return _context.Reviews.Find(reviewid);
        }
        public IEnumerable<Review> GetReviewsByGameId(int gameId)
        {
            return _context.Reviews.Where(r => r.GameId == gameId).ToList();
        }

        public void CreateReview(Review newReview)
        {
            _context.Reviews.Add(newReview);
            _context.SaveChanges();
        }

        public void UpdateReview(Review newReview)
        {
            _context.Update(newReview);
            _context.SaveChanges();
        }
        public void DeleteReview(int reviewId)
        {
            var reviewToDelete = _context.Reviews.Find(reviewId);
            if (reviewToDelete != null)
            {
                _context.Reviews.Remove(reviewToDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return _context.Reviews.ToList();
        }


    }
}