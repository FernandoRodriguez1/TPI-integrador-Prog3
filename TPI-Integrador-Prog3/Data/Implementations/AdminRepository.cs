using System.Data.Entity;
using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.DBContexts;
using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Data.Implementations
{
    public class AdminRepository : Repository, IAdminRepository
    {
        public AdminRepository(GamesContext context) : base(context)
        {
        }
       
    }
}