using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.DBContexts;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;

namespace TPI_Integrador_Prog3.Data.Implemetation
{
    public class UserRepository : Repository , IUserRepository
    {
        public UserRepository(GamesContext context) : base(context) 
        {
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User? GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public BaseResponse ValidateUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.Find(email);
        }

        public User? GetUserByUserName(string username)
        {
            return _context.Users.Find(username);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }
    }
}
