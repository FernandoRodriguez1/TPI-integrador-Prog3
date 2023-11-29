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
        public bool SaveChanges() //Aplicamos el método del contrato, guarda los cambios en la base de datos si hay un cambio devuelve "true".
        {
            return (_context.SaveChanges() >= 0);//Ejecutamos el método con nuestra variable de instancia que tiene la inyección de dependencia.
        }
    }
}
