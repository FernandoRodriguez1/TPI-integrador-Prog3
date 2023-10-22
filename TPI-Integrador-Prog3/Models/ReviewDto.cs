namespace TPI_Integrador_Prog3.Models
{
    public class ReviewDto
    {
        public string UsernameInReview { get; set; }
        public int UserRatingInReview { get; set; }
        public string UserCommentInReview { get; set; }
        public DateTime CreationDate { get; private set; } = DateTime.Now;
    }
}
