using TPI_Integrador_Prog3.DBContexts;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Services.Interfaces;

namespace TPI_Integrador_Prog3.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly GamesContext _context;
        public AdminService(GamesContext context)
        {
            _context = context;
        }


    }
}