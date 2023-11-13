using System.Data.Entity;
using System.Xml.Linq;
using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.DBContexts;
using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Data.Implementations
{
    public class GameRepository : Repository, IGameRepository
    {
        public GameRepository(DBContexts.GamesContext context) : base(context)
        {

        }
        public IEnumerable<Game> GetAllGames()
        {
            return _context.Games;
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
            var gameToDelete = _context.Games.Find(gameId);
            if (gameToDelete != null)
            {
                _context.Games.Remove(gameToDelete);
                _context.SaveChanges();
            }
        }


        public Game GetGameById(int gameId)
        {
            return _context.Games.Find(gameId);
        }
        public Game GetGameByName(string gamename)
        {
            return _context.Games.SingleOrDefault(p => p.GameName == gamename);
        }
   
    }
}
