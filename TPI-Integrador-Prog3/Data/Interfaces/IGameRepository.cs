using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Data.Interfaces
{
    public interface IGameRepository : IRepository
    {
        public IEnumerable<Game> GetAllGames();
        public void CreateGame(Game game);
        public void UpdateGame(Game game);
        public void DeleteGame(int gameid);
        Game GetGameById(int gameId);
        Game GetGameByName(string gamename);

    }
}