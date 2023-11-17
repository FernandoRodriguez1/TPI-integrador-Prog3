using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.Models;
using TPI_Integrador_Prog3.Services.Interfaces;

namespace TPI_Integrador_Prog3.Services.Implementations
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticateService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public BaseResponse ValidateUser(AuthenticateDto authenticatedto)
        {
            if (string.IsNullOrEmpty(authenticatedto.UserName) || string.IsNullOrEmpty(authenticatedto.Password)) 
                return null;

            return _userRepository.ValidateUser(authenticatedto);
        }
    }
}
