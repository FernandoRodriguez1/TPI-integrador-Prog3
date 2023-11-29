using System.Data.Entity;
using System.Xml.Linq;
using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.DBContexts;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;

namespace TPI_Integrador_Prog3.Data.Implementations
{
    public class GameRepository : Repository, IGameRepository
    {
        public GameRepository(DBContexts.GamesContext context) : base(context)
        {

        }
        public List<GamesDto> GetAllGames()
        {

            var gamesDtoList = _context.Games //Agarramos los juegos
                .Select(game => new GamesDto //Seleccionamos por cada juego, el dto para que obtenga solo los datos que queremos
                {
                    GameName = game.GameName,
                    Gender = game.Gender,
                    Developer = game.Developer,
                    Synopsis = game.Synopsis,
                    GameRating = game.GameRating,
                    DepartureDate = game.DepartureDate,
                })
                .ToList();

            return gamesDtoList; //Retornamos todos los juegos en una lista de dtos
        }

        public void CreateGame(Game game)
        {

            _context.Games.Add(game);
            _context.SaveChanges();

        }

        public void UpdateGame(Game game)
        {
            _context.Update(game);
            _context.SaveChanges();

        }

        public void DeleteGame(int gameId)
        {
            var gameToDelete = _context.Games.Find(gameId); //obtenemos el juego por la id
            if (gameToDelete != null) //verificamos si es nulo es decir si no existe
            {
                _context.Games.Remove(gameToDelete); //lo borramos de una forma fisica
                _context.SaveChanges();
            }
        }
        public Game GetGameById(int gameId)
        {
            return _context.Games.Find(gameId);
        }
      

    }
}