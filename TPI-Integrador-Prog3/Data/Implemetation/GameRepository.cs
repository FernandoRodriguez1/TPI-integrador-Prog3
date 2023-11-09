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

        public void AddGame(Games game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();
        }

        public void RemoveGame(Games game)
        {
            _context.Games.Remove(game);
            _context.SaveChanges();
        }
    }
}
