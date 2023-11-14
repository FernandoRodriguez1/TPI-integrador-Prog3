using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Data.Interfaces
{
    public interface IClientRepository
    {
        public Client? GetClientById(int userId);
        public IEnumerable<Game> GetAllGames();
        public IEnumerable<Review> GetReviewsByGameId(int gameId);
        public void CreateReview(Review review);
        public void UpdateReview(Review review);
        public void DeleteReview(Review review);

    }
}
