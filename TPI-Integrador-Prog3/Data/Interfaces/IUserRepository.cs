using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Data.Interfaces
{
    public interface IUserRepository : IRepository
    {
        User? ValidateUser();
        User? GetUserById(int userId);
    }
}
