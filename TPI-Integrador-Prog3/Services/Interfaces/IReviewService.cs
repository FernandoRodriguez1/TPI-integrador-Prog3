using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;

namespace TPI_Integrador_Prog3.Services.Interfaces
{
    public interface IReviewService
    {
        Review GetReviewById(int id);
        IEnumerable<Review> GetReviews();
        public List<Review> GetReviewsByGameId(int gameId);
        void CreateReview(ReviewDto reviewdto);
        void UpdateReview(int id, ReviewDto reviewdto);
        void DeleteReview(int reviewId);

    }
}