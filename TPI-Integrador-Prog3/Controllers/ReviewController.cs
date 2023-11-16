using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;
using TPI_Integrador_Prog3.Services.Implementations;
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
            var Listt = _reviewService.GetReviewsByGameId(gameId);

            if (Listt.Count() == 0)
            {
                return BadRequest("El juego no contiene Reviews");
            }
            return Ok(_reviewService.GetReviewsByGameId(gameId));
        }
        [HttpPost("CreateReview")]
        public IActionResult CreateReview([FromBody] ReviewDto reviewdto)
        {
            _reviewService.CreateReview(reviewdto);
            return Ok("Review Created");
        }
        [HttpPut("UpdateReview/{reviewid}")]
        public IActionResult UpdateReview(int reviewid, ReviewDto reviewdto)
        {
            if (_reviewService.GetReviewById(reviewid) == null)
            {
                return BadRequest("La review no existe");
            }
            _reviewService.UpdateReview(reviewid, reviewdto);
            return Ok("Review Updated");
        }

        [HttpDelete("DeleteReview/{reviewid}")]
        public IActionResult DeleteReview(int reviewid)
        {
            _reviewService.DeleteReview(reviewid);
            return Ok("Review Deleted");
        }
    }
}

