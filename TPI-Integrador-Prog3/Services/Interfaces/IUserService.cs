using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;

namespace TPI_Integrador_Prog3.Services.Interfaces
{
    public interface IUserService
    {
        BaseResponse ValidateUser(string username, string password);   
        User? GetUserByUserName(string username);
        User? GetUserByEmail(string email);
        int CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
