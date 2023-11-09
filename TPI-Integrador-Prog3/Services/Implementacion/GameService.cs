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

        public void AddGame(Games game)
        {
            _context.Games.Add(game);
        }

        public void RemoveGame(Games game)
        {
            _context.Games.Remove(game);
        }
    }
}
