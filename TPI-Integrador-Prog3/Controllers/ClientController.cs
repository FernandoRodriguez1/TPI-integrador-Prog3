using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Services.Interfaces;

namespace TPI_Integrador_Prog3.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult GetAllGames()
        {
            return Ok(_clientService.GetAllGames());
        }

        [HttpGet("{gameId}/reviews")]
        public IActionResult GetReviewsByGameId([FromRoute]int gameId)
        {
            return Ok(_clientService.GetReviewsByGameId(gameId));
        }

        [HttpPost("/{gameId}/reviews")]
        public IActionResult CreateReview(int gameId, [FromBody] Review review)
        {
            review.GameId = gameId;
            _clientService.CreateReview(review);
            return Ok();
        }

        [HttpPut("{gameId}/reviews")]
        public IActionResult UpdateReview(int gameId, [FromBody] Review review)
        {
            review.GameId = gameId;
            _clientService.UpdateReview(review);
            return Ok();
        }

        [HttpDelete("{gameId}/reviews")]
        public IActionResult DeleteReview(int gameId, [FromBody] Review review)
        {
            review.GameId = gameId;
            _clientService.DeleteReview(review);
            return Ok();
        }

    }
}
