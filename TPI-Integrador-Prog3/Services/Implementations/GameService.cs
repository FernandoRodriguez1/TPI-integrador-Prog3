using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using TPI_Integrador_Prog3.Data.Implementations;
using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.DBContexts;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;
using TPI_Integrador_Prog3.Services.Interfaces;

namespace TPI_Integrador_Prog3.Services.Implementations
{
    public class GameService :  IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;
        public GameService(IGameRepository gamesrepository, IMapper mapper)
        {
            _gameRepository = gamesrepository;
            _mapper = mapper;
        }
        public List<Game> GetAllGames()
        {
            return _gameRepository.GetAllGames().ToList();
        }
        public void CreateGame(GamesDto gamesdto)
        {
            var GameNew = _mapper.Map<Game>(gamesdto);

                _gameRepository.CreateGame(GameNew);
               
        }

        public void UpdateGame(int id, GamesDto gamedto)
        {
            var existsGame = _gameRepository.GetGameById(id);
            if (existsGame == null)
            {
                throw new Exception("Juego NO encontrado");
            }
            existsGame.GameName = gamedto.GameName;
            existsGame.Synopsis = gamedto.Synopsis;
            existsGame.Developer = gamedto.Developer;
            existsGame.Gender = gamedto.Gender;
           
            _gameRepository.UpdateGame(existsGame);
        }

        public void DeleteGame(int gameid)
        {
            _gameRepository.DeleteGame(gameid);
        }

        public Game GetGameById(int gameId)
        {
            return _gameRepository.GetGameById(gameId);
        }
        public Game GetByGameName(string name)
        {
            return _gameRepository.GetGameByName(name);
        }

    }
}
