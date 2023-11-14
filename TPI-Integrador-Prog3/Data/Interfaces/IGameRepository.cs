using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Data.Interfaces
{
    public interface IGameRepository : IRepository
    {
        void CreateGame(Game game);
        void UpdateGame(Game game);
        void DeleteGame(Game game);
        Game GetGameById(int gameId);

    }
}
