using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;

namespace TPI_Integrador_Prog3.Services.Interfaces
{
    public interface IGameService
    {
        public List<Game> GetAllGames();
        void CreateGame(GamesDto game);
        void UpdateGame(int id, GamesDto game);
        void DeleteGame(int gameId);
        Game GetGameById(int gameId);

    }
}