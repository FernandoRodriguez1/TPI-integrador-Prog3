using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;

namespace TPI_Integrador_Prog3.Data.Interfaces
{
    public interface IUserRepository : IRepository
    {
        void CreateUser(User user);
        User? GetUserById(int userId);
        User? GetUserByEmail(string email);
        BaseResponse ValidateUser(string username, string password);
        User? GetUserByUserName(string username);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
