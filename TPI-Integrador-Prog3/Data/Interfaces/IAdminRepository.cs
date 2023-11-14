using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Data.Interfaces
{
    public interface IAdminRepository
    {
        Game? RemoveGameById(int gamesId);
        Review? RemoveReviewById(int reviewId);
        List<Review> GetReviewsxGame(int gameId);
    }
}
