using TPI_Integrador_Prog3.DBContexts;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Services.Interfaces;

namespace TPI_Integrador_Prog3.Services.Implementacion
{
    public class AdminService : IAdminService
    {
        private readonly GamesContext _context;
        public AdminService(GamesContext context)
        {
            _context = context;
        }
        public bool DeleteGame(int gameId)
        {
            var game = _context.Games.FirstOrDefault(g => g.Id == gameId);

            if (game != null)
            {
                _context.Games.Remove(game);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteReview(int reviewId)
        {
            var review = _context.Reviews.FirstOrDefault(g => g.Id == reviewId);

            if (review != null)
            {
                _context.Reviews.Remove(review);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
        public List<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }
    }
}
