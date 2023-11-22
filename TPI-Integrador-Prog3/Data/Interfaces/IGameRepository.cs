using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;

namespace TPI_Integrador_Prog3.Data.Interfaces
{
    public interface IGameRepository : IRepository
    {
        public List<GamesDto> GetAllGames();
        public void CreateGame(Game game);
        public void UpdateGame(Game game);
        public void DeleteGame(int gameid);
        Game GetGameById(int gameId);
        

    }
}