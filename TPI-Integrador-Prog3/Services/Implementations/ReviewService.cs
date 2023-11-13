using TPI_Integrador_Prog3.Data.Implementations;
using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models.Review;
using TPI_Integrador_Prog3.Services.Interfaces;

namespace TPI_Integrador_Prog3.Services.Implementations
{

    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public IEnumerable<Review> GetReviewsByGameId(int gameId)
        {
            return _reviewRepository.GetReviewsByGameId(gameId);
        }
        public List<Review> GetReviews()
        {
            return _reviewRepository.GetAllReviews();
        }

        public void CreateReview(Review review)
        {
            _reviewRepository.CreateReview(review);
        }
        public void UpdateReview(Review review)
        {
            _reviewRepository.UpdateReview(review);
        }
        public void DeleteReview(int reviewId)
        {
            _reviewRepository.DeleteReview(reviewId);
        }

        
    }

}
