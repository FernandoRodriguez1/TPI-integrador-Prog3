using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Data.Interfaces
{
    public interface IGameRepository : IRepository
    {
        Games? GetGames(int gameId);
    }
}
