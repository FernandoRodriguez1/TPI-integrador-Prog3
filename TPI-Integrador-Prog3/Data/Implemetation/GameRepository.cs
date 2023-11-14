using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.DBContexts;
using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Data.Implemetation
{
    public class GameRepository : Repository , IGameRepository 
    {
        public GameRepository(GamesContext context) : base(context) 
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
