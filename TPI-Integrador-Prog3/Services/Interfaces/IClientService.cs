using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;

namespace TPI_Integrador_Prog3.Services.Interfaces
{
    public interface IClientService
    {
        public Client GetClientById(int userId);
        public IEnumerable<Game> GetAllGames();
        public IEnumerable<Review> GetReviewsByGameId(int gameId);
        public void CreateReview(Review review);
        public void UpdateReview(Review review);
        public void DeleteReview(Review review);


    }
}
