using System.Data.Entity;
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

        public Games? GetGames(int gameId)
        {
            return _context.Games
                .Include(g => g.Reviews)
                .FirstOrDefault(c => c.Id == gameId);
        }
    }
}
