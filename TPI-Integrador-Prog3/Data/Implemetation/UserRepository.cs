using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.DBContexts;
using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Data.Implemetation
{
    public class UserRepository : Repository , IUserRepository
    {
        public UserRepository(GamesContext context) : base(context) 
        {
        }

        public User? GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public User? ValidateUser()
        {
            throw new NotImplementedException();
        }
    }
}
