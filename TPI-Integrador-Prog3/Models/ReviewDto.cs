namespace TPI_Integrador_Prog3.Models
{
    public class ReviewDto
    {
        public int ClientId { get; set; }
        public int GameId { get; set; }
        public string UsernameInReview { get; set; }
        public int UserRatingInReview { get; set; }
        public string UserCommentInReview { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
