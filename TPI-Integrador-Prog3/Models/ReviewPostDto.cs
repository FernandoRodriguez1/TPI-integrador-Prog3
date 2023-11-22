namespace TPI_Integrador_Prog3.Models
{
    public class ReviewPostDto
    {
        public int ClientId { get; set; }
        public int GameId { get; set; }
        public string UsernameInReview { get; set; }
        public int UserRatingInReview { get; set; }
        public string UserCommentInReview { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
