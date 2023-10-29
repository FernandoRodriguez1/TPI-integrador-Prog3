using System.ComponentModel.DataAnnotations;

namespace TPI_Integrador_Prog3.Models.Reviews
{
    public class ReviewCreate
    {
        [Required]
        public string UsernameInReview { get; set; }
        [Required]
        public string UserCommentInReview { get; set; }
        [Required]
        public int UserRatingInReview { get; set; }
        [Required]
        public int GameId { get; set; }
    }
}
