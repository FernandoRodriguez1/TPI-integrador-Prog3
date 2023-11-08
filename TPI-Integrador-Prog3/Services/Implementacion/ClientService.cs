using System.Data.Entity;
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


        public async Task<IEnumerable<Review>> GetReviewxGameAsync(int idGame)
        {
            return await _context.Reviews.Where(g => g.GameId == idGame).ToListAsync();
        }

        public async Task<IEnumerable<Games>> GetGames()
        {
            return await _context.Games.ToListAsync();
        }
        public async Task<bool> GameExistsAsync(int idGame)
        {
            return await _context.Games.AnyAsync(c => c.Id == idGame);
        }

        public void DeleteReview(Review review)
        {
            _context.Reviews.Remove(review);
        }
    }
}
