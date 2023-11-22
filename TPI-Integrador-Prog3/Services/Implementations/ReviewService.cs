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
        private readonly IUserRepository _userRepository;
        public ReviewService(IReviewRepository reviewRepository,IUserRepository userRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public List<ReviewDto> GetReviewsByGameId(int gameId)
        {
            return _reviewRepository.GetReviewsByGameId(gameId).ToList();
        }
        public IEnumerable<ReviewDto> GetReviews()
        {
            return _reviewRepository.GetAllReviews();
        }

        public void CreateReview(ReviewPostDto reviewdto)
        {

            if (reviewdto.UsernameInReview != null)
            {
                var ReviewNew = _mapper.Map<Review>(reviewdto);
                
                _reviewRepository.CreateReview(ReviewNew);
            }
            
        }
        public void UpdateReview(int reviewid, ReviewPostDto reviewdto)
        {
            var existsReview = _reviewRepository.GetReviewById(reviewid);
            if (existsReview == null)
            {
                throw new Exception("Review NO encontrada");
            }
            
            existsReview.GameId = reviewdto.GameId;
            existsReview.UserNameInReview = reviewdto.UsernameInReview;
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