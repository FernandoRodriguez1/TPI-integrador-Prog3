using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.DBContexts;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;

namespace TPI_Integrador_Prog3.Data.Implementations
{
    public class ReviewRepository : Repository, IReviewRepository
    {
        public ReviewRepository(GamesContext context) : base(context)
        {
        }
        public Review GetReviewById(int reviewid)
        {
            return _context.Reviews.Find(reviewid);
        }
        public IEnumerable<ReviewDto> GetReviewsByGameId(int gameId)
        {
            var reviewsDtoList = _context.Reviews.Where(x=> x.GameId == gameId) //buscamos la review que coincida con el gameId enviado por el endpoint
               .Select(review => new ReviewDto //seleccionamos todas las reviews y devolvemos un dto de cada una 
               {
                   Id = review.Id,
                   GameId = review.GameId,
                   UsernameInReview = review.UserNameInReview,
                   UserCommentInReview = review.UserCommentInReview,
                   CreationDate = review.CreationDate

               })
               .ToList();

            return reviewsDtoList;//retornamos las reviews dtos en formato lista
        }

        public void CreateReview(Review newReview)
        {
            _context.Reviews.Add(newReview);
            _context.SaveChanges();
        }

        public void UpdateReview(Review newReview)
        {
            _context.Update(newReview);
            _context.SaveChanges();
        }
        public void DeleteReview(int reviewId)
        {
            var reviewToDelete = _context.Reviews.Find(reviewId);
            if (reviewToDelete != null)
            {
                _context.Reviews.Remove(reviewToDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<ReviewDto> GetAllReviews()
        {
            var reviewsDtoList = _context.Reviews
                .Select(review => new ReviewDto
                {
                    Id=review.Id,
                    GameId = review.GameId,
                    UsernameInReview = review.UserNameInReview,
                    UserCommentInReview = review.UserCommentInReview,
                    CreationDate = review.CreationDate

                })
                .ToList();

            return reviewsDtoList;
        }


    }
}