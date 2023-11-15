using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;

namespace TPI_Integrador_Prog3.Services.Interfaces
{
    public interface IUserService
    {
        BaseResponse ValidateUser(string username, string password);
        IEnumerable<User> GetAllUsers();
        void CreateClient(UserDto user);
        void CreateAdmin(UserDto user);
        void UpdateUser(int id, UserDto user);
        bool DeleteUserByEmail(string email);
        bool DeleteUserById(int id);
        User? GetUserByUserName(string username);
        User? GetUserByEmail(string email);
    }
}
