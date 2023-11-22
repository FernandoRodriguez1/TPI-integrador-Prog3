using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;

namespace TPI_Integrador_Prog3.Services.Interfaces
{
    public interface IReviewService
    {
        Review GetReviewById(int id);
        IEnumerable<ReviewDto> GetReviews();
        public List<ReviewDto> GetReviewsByGameId(int gameId);
        void CreateReview(ReviewPostDto reviewdto);
        void UpdateReview(int id, ReviewPostDto reviewdto);
        void DeleteReview(int reviewId);

    }
}