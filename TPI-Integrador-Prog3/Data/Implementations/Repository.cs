using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.DBContexts;

namespace TPI_Integrador_Prog3.Data.Implementations
{
    public class Repository : IRepository
    {
        internal readonly GamesContext _context;

        public Repository(GamesContext context)
        {
            this._context = context;
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
