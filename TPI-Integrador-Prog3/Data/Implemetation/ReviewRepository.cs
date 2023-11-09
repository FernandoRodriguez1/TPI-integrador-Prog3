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

        public IEnumerable<Review> GetReview(int gameid) => _context.Reviews.Where(g => g.GameId == gameid);
    }
}
