using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;

namespace TPI_Integrador_Prog3.Services.Interfaces
{
    public interface IClientService
    {
        Task AddReviewxGame(Review review);
        List<Review> GetReviewxGame(int idGame);
        List<Games> GetGames();
    }
}
