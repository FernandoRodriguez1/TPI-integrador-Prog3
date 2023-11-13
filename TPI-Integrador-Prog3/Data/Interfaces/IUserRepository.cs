using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;

namespace TPI_Integrador_Prog3.Data.Interfaces
{
    public interface IUserRepository : IRepository
    {
        
        User? GetUserById(int userId);
        User? GetUserByUserName(string username);
        BaseResponse ValidateUser(string username, string password);
        User? GetUserByEmail(string email);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
