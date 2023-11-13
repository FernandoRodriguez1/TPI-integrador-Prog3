using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Services.Interfaces;

namespace TPI_Integrador_Prog3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpGet("GetAllReviews")]
        public IActionResult GetReviews()
        {
            return Ok(_reviewService.GetReviews());
        }
        [HttpGet("ReviewsByGameId/{gameId}")]
        public IActionResult GetReviewsByGameId([FromRoute] int gameId)
        {
            return Ok(_reviewService.GetReviewsByGameId(gameId));
        }
        [HttpPost("CreateReview/{gameId}")]
        public IActionResult CreateReview(int gameId, [FromBody] Review review)
        {
            review.GameId = gameId;
            _reviewService.CreateReview(review);
            return Ok();
        }
        [HttpPut("UpdateReview/{gameId}")]
        public IActionResult UpdateReview(int gameId, [FromBody] Review review)
        {
            review.GameId = gameId;
            _reviewService.UpdateReview(review);
            return Ok();
        }

        [HttpDelete("DeleteReview/{gameId}")]
        public IActionResult DeleteReview(int review)
        {
            _reviewService.DeleteReview(review);
            return Ok();
        }
    }
}
    

