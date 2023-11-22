using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;

namespace TPI_Integrador_Prog3.Data.Interfaces
{
    public interface IReviewRepository
    {
        public IEnumerable<ReviewDto> GetReviewsByGameId(int gameId);
        void CreateReview(Review newReview);
        void UpdateReview(Review newReview);
        void DeleteReview(int reviewId);
        Review GetReviewById(int reviewId);
        public IEnumerable<ReviewDto> GetAllReviews();


    }
}