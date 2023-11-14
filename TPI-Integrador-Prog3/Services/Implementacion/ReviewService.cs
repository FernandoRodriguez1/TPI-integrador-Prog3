using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models.Review;
using TPI_Integrador_Prog3.Services.Interfaces;

namespace TPI_Integrador_Prog3.Services.Implementacion
{

    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewService(IReviewRepository reviewRepository) 
        { 
            _reviewRepository = reviewRepository;
        }
        public void CreateReview(Review newReview)
        {
            _reviewRepository.CreateReview(newReview);
        }

        public void DeleteReview(Review newReview)
        {
            _reviewRepository.DeleteReview(newReview);
        }

        public IEnumerable<Review> GetReviewsByGameId(int gameId)
        {
            return _reviewRepository.GetReviewsByGameId(gameId);
        }

        public void UpdateReview(Review newReview)
        {
            _reviewRepository.UpdateReview(newReview);
        }
    }
    
}
