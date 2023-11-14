using TPI_Integrador_Prog3.Data.Implemetation;
using TPI_Integrador_Prog3.DBContexts;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Services.Interfaces;

namespace TPI_Integrador_Prog3.Services.Implementacion
{
    public class GameService : GameRepository , IGameService
    {
        public GameService(GamesContext context) : base(context) 
        {

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

        public void DeleteGame(Game game)
        {
            _context.Games.Remove(game);
            _context.SaveChanges();
        }

        public Game GetGameById(int gameId)
        {
            return _context.Games.Find(gameId);
        }


    }
}
