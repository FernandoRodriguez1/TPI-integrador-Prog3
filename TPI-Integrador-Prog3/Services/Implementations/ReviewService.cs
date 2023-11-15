using AutoMapper;
using TPI_Integrador_Prog3.Data.Implementations;
using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;

using TPI_Integrador_Prog3.Services.Interfaces;

namespace TPI_Integrador_Prog3.Services.Implementations
{

    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public List<Review> GetReviewsByGameId(int gameId)
        {
            return _reviewRepository.GetReviewsByGameId(gameId).ToList();
        }
        public IEnumerable<Review> GetReviews()
        {
            return _reviewRepository.GetAllReviews();
        }

        public void CreateReview(ReviewDto reviewdto)
        {
            var ReviewNew = _mapper.Map<Review>(reviewdto);

            _reviewRepository.CreateReview(ReviewNew);
        }
        public void UpdateReview(int reviewid, ReviewDto reviewdto)
        {
            var existsReview = _reviewRepository.GetReviewById(reviewid);
            if (existsReview == null)
            {
                throw new Exception("Review NO encontrada");
            }
            existsReview.GameId = reviewdto.GameId;
            existsReview.ClientId = existsReview.ClientId;
            existsReview.UserNameInReview= reviewdto.UsernameInReview;
            existsReview.UserCommentInReview = reviewdto.UserCommentInReview;
            existsReview.UserRatingInReview = reviewdto.UserRatingInReview;
            existsReview.CreationDate = reviewdto.CreationDate;

            _reviewRepository.UpdateReview(existsReview);
        }
        public void DeleteReview(int reviewId)
        {
            _reviewRepository.DeleteReview(reviewId);
        }

        public Review GetReviewById(int id)
        {
            return _reviewRepository.GetReviewById(id);
        }

       
        
    }

}
