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
    
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("GetAllGames")]
        [Authorize("All")]
        public IActionResult GetAllGames()
        {
            return Ok(_gameService.GetAllGames());
        }

        [HttpGet("GetGameById/{id}")]
        public IActionResult GetGameById(int id)
        {
            if (_gameService.GetGameById(id) == null)
            {
                return BadRequest("El juego no existe");
            }
            return Ok(_gameService.GetGameById(id));
        }

        [HttpPost]
        [Authorize("Admin")]
        public IActionResult CreateGame(GamesDto game)
        {
            _gameService.CreateGame(game);
            return Ok("Game Created");
        }

        [HttpPut]
        [Authorize("Admin")]
        public IActionResult UpdateGame(int id, GamesDto game)
        {
            if (_gameService.GetGameById(id) == null)
            {
                return BadRequest("El juego no existe");
            }
            _gameService.UpdateGame(id, game);
            return Ok("Game Updated");
        }

        [HttpDelete]
        [Authorize("Admin")]
        public IActionResult DeleteGame(int gameid)
        {
            if (_gameService.GetGameById(gameid) == null)
            {
                return BadRequest("El juego no existe");
            }
            _gameService.DeleteGame(gameid);
            return Ok("Game Deleted");
        }

    }
}