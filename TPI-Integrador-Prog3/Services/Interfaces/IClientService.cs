using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;

namespace TPI_Integrador_Prog3.Services.Interfaces
{
    public interface IClientService
    {
        Task AddReviewxGame(Review review);
        Task<IEnumerable<Review>> GetReviewxGameAsync(int idGame);
        Task<IEnumerable<Games>> GetGames();
        void DeleteReview(Review review);
        Task<bool> GameExistsAsync(int idGame);
    }
}
