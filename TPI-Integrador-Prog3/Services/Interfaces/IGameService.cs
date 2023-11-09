using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Services.Interfaces
{
    public interface IGameService
    {
        void AddGame(Games game);
        void RemoveGame(Games game);
    }
}
