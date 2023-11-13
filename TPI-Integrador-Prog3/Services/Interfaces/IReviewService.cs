using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Services.Interfaces
{
    public interface IReviewService
    {
        public List<Review> GetReviews();
        public IEnumerable<Review> GetReviewsByGameId(int gameId);
        public void CreateReview(Review review);
        public void UpdateReview(Review review);
        public void DeleteReview(int reviewId);

    }
}
