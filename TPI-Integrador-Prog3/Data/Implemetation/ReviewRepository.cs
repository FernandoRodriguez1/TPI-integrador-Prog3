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

        public IEnumerable<Review> GetReviewsByGameId(int gameId)
        {
            return _context.Reviews.Where(r => r.GameId == gameId).ToList();
        }

        public void CreateReview(Review newReview)
        {
            _context.Reviews.Add(newReview);
        }

        public void UpdateReview(Review newReview)
        {
            _context.Update(newReview);
            _context.SaveChanges();
        }
        public void DeleteReview(Review newReview)
        {
            _context.Reviews.Remove(newReview);
        }
        
    }
}
