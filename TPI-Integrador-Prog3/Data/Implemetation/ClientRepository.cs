using System.Data.Entity;
using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.DBContexts;
using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Data.Implemetation
{
    public class ClientRepository : Repository , IClientRepository
    {
        public ClientRepository(GamesContext context) : base(context) 
        {
        }

        public Client? GetClientById(int userId) => _context.Clients.Find(userId);

    }
}
