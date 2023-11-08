using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Data.Interfaces
{
    public interface IReviewRepository
    {
        void CreateReview(Review newReview);

        Review? GetReview(int reviewId);
    }
}
