using System.Data.Entity;
using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.DBContexts;
using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Data.Implemetation
{
    public class ReviewRepository : Repository , IReviewRepository
    {
        public ReviewRepository(GamesContext context) : base(context)
        {
        }

        public void CreateReview(Review newReview)
        {
            _context.Reviews.Add(newReview);
        }

        public Review? GetReview(int reviewId)
        {
            return _context.Reviews
                .Include(r => r.Client)
                .FirstOrDefault(c => c.Id == reviewId);
        }
    }
}
