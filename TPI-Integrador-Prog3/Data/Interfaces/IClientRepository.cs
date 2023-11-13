using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Data.Interfaces
{
    public interface IClientRepository
    {
        public Client? GetClientById(int userId);
       
    }
}
