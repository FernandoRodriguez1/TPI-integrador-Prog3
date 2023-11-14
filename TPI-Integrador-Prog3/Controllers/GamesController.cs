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
    public class GamesController : ControllerBase
    {

        private readonly IGameService _gameService;
        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("{id}")]
        public IActionResult GetGameById(int id)
        {
            return Ok(_gameService.GetGameById(id));
        }

        [HttpPost]
        public IActionResult CreateGame(Game game)
        {
            _gameService.CreateGame(game);
            return Ok("Game Created");
        }

        [HttpPut]
        public IActionResult UpdateGame(Game game)
        {
            _gameService.UpdateGame(game);
            return Ok("Game Updated");
        }

        [HttpDelete]
        public IActionResult DeleteGame(Game game)
        {
            _gameService.DeleteGame(game);
            return Ok("Game Deleted");
        }

    }
}
