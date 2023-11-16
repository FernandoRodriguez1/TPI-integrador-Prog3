using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Services.Interfaces;

namespace TPI_Integrador_Prog3.Services.Implementations
{
    public class ClientService : IClientService
    {

        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Client GetClientById(int userId)
        {
            return _clientRepository.GetClientById(userId);
        }


    }
}