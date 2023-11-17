using TPI_Integrador_Prog3.Models;

namespace TPI_Integrador_Prog3.Services.Interfaces
{
    public interface IAuthenticateService
    {
        BaseResponse ValidateUser(AuthenticateDto authenticationRequestBody);
    }
}
