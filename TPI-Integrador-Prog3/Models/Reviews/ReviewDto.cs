﻿namespace TPI_Integrador_Prog3.Models.Review
{
    public class ReviewDto
    {
        public string GameName { get; set; }
        public string UsernameInReview { get; set; }
        public int UserRatingInReview { get; set; }
        public string UserCommentInReview { get; set; }
        public DateTime CreationDate { get; set; }
    }
}