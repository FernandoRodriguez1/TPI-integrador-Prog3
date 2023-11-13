using System.Data.Entity;
using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.DBContexts;
using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Data.Implementations
{
    public class ClientRepository : Repository, IClientRepository
    {
        public ClientRepository(GamesContext context) : base(context)
        {
        }

        public Client? GetClientById(int userId)
        {
            return _context.Clients.Find(userId);
        }
        public IEnumerable<Review> GetReviewsByGameId(int gameId)
        {
            return _context.Reviews.Where(r => r.GameId == gameId).ToList();
        }
        public void CreateReview(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }
        public void UpdateReview(Review review)
        {
            _context.Update(review);
            _context.SaveChanges();
        }
        public void DeleteReview(Review review)
        {
            _context.Reviews.Remove(review);
        }
        

    }
}
