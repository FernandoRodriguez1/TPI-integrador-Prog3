using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;

namespace TPI_Integrador_Prog3.Services.Interfaces
{
    public interface IUserService
    {
        BaseResponse ValidateUser(string username, string password);
        int CreateUser(User user);
        void UpdateUser(User user);
        public bool DeleteUserByEmail(string email);
        User? GetUserByUserName(string username);
        User? GetUserByEmail(string email);
    }
}
