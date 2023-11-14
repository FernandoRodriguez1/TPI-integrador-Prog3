using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Services.Interfaces
{
    public interface IGameService
    {
        void CreateGame(Game game);
        void UpdateGame(Game game);
        void DeleteGame(Game game);
        Game GetGameById(int gameId);

    }
}
