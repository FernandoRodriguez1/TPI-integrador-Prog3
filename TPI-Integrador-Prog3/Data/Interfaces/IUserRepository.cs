using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;

namespace TPI_Integrador_Prog3.Data.Interfaces
{
    public interface IUserRepository : IRepository
    {
        IEnumerable<User> GetAllUsers();
        User? GetUserById(int userId);
        User? GetUserByUserName(string username);
        BaseResponse ValidateUser(AuthenticateDto authenticatedto);
        User? GetUserByEmail(string email);
        void CreateClient(User user);
        void CreateAdmin(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}