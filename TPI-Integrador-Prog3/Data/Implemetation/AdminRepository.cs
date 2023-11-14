using System.Data.Entity;
using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.DBContexts;
using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Data.Implemetation
{
    public class AdminRepository : Repository, IAdminRepository
    {
        public AdminRepository(GamesContext context) : base(context)
        {
        }
        public List<Review> GetReviewsxGame(int gameId)
        {
            var game = _context.Games
                .Include(g => g.Reviews) // Encuentra las reviews hechas por juego
                .FirstOrDefault(g => g.Id == gameId); // Busca el juego por su ID

            if (game != null)
            {
                return game.Reviews.ToList(); // Devuelve la lista de reviews del juego
            }

            return new List<Review>(); // Retorna una lista vacía si el juego no se encontró
        }
        public Game? RemoveGameById(int gameId)
        {
            var game = _context.Games.Find(gameId); // Busca el juego por su ID
            if (game != null)
            {
                _context.Games.Remove(game); // Elimina el juego de la base de datos
            }   
            return game; // Retorna el juego eliminado (o null si no se encontró)
        }
        public Review? RemoveReviewById(int reviewId)
        {
            var review = _context.Reviews.Find(reviewId);
            if (review != null)
            {
                _context.Reviews.Remove(review);
            }
            return review;
        }
    }
}
