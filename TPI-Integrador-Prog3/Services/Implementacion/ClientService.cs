using TPI_Integrador_Prog3.DBContexts;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;
using TPI_Integrador_Prog3.Services.Interfaces;

namespace TPI_Integrador_Prog3.Services.Implementacion
{
    public class ClientService : IClientService
    {
        private readonly GamesContext _context;
        public ClientService(GamesContext context)
        {
            _context = context;
        }

        public async Task AddReviewxGame(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync(); 
        }


        public List<Review> GetReviewxGame(int idGame)
        {
            return  _context.Reviews.Where(g => g.GameId == idGame).ToList();
        }

        public List<Games> GetGames()
        {
            return _context.Games.ToList();
        }
    }
}
