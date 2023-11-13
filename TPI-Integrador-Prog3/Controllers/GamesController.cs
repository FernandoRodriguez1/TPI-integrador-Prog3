using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;
using TPI_Integrador_Prog3.Services.Implementations;
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
        [HttpGet("GetAllGames")]
        public IActionResult GetAllGames()
        {
            return Ok(_gameService.GetAllGames());
        }
        [HttpGet("GetGameById/{id}")]
        public IActionResult GetGameById(int id)
        {
            return Ok(_gameService.GetGameById(id));
        }

        [HttpPost]
        public IActionResult CreateGame(GamesDto game)
        {
            _gameService.CreateGame(game);
            return Ok("Game Created");
        }

        [HttpPut]
        public IActionResult UpdateGame(int id, GamesDto game)
        {
            _gameService.UpdateGame(id,game);
            return Ok("Game Updated");
        }

        [HttpDelete]
        public IActionResult DeleteGame(int gameid)
        {
            _gameService.DeleteGame(gameid);
            return Ok("Game Deleted");
        }

    }
}
