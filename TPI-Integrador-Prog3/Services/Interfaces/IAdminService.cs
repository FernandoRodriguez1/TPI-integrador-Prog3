using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Services.Interfaces
{
    public interface IAdminService
    {
        public List<Review> GetReviews();
        public bool DeleteReview(int reviewId);
        public bool DeleteGame(int idGame);
    }
}
