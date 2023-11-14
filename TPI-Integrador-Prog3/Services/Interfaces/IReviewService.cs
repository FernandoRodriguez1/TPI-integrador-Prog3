using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Services.Interfaces
{
    public interface IReviewService
    {
        public IEnumerable<Review> GetReviewsByGameId(int gameId);
        void CreateReview(Review newReview);
        void UpdateReview(Review newReview);
        void DeleteReview(Review newReview);
    }
}
