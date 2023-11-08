using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Services.Interfaces;

namespace TPI_Integrador_Prog3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        // podra eliminar reseña¿?

        private readonly IClientService _clientService;

        ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet]
        public IActionResult GetGames()
        {
            return Ok(_clientService.GetGames());
        }
        [HttpGet("{idGame}")]
        public async Task<ActionResult> GetReviews([FromQuery]int idGame)
        {
            return Ok( await _clientService.GetReviewxGameAsync(idGame));
        }
        [HttpPost]
        public IActionResult AddReviewxGame([FromBody] Review review)
        {
            return Ok(_clientService.AddReviewxGame(review));
        }
        [HttpDelete]
        public Task<ActionResult> DeleteReview(Review review)
        {
            return Ok( _clientService.DeleteReview(review));
        }

    }
}
