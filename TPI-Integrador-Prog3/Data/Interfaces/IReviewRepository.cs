using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Data.Interfaces
{
    public interface IReviewRepository
    {
        public IEnumerable<Review> GetReviewsByGameId(int gameId);
        void CreateReview(Review newReview);
        void UpdateReview(Review newReview);
        void DeleteReview(int reviewId);
        Review GetReviewById(int reviewId);
        public List<Review> GetAllReviews();

       
    }
}
