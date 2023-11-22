using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.DBContexts;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;

namespace TPI_Integrador_Prog3.Data.Implementations
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(GamesContext context) : base(context)
        {
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var usersDtoList = _context.Users
                .Select(user => new UserDto
                {
                    
                    UserName = user.UserName,
                    Email = user.Email,
                    Password = String.Empty,
                    
                })
                .ToList();

            return usersDtoList;
        }

        public void CreateClient(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void CreateAdmin(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User? GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public BaseResponse ValidateUser(AuthenticateDto authenticatedto)
        {
            BaseResponse response = new BaseResponse();
            User? user  = _context.Users.SingleOrDefault(u => u.UserName == authenticatedto.UserName);
            if (user != null)
            {
                if (user.Password == authenticatedto.Password)
                {
                    response.Result = true;
                    response.Message = "Logged In";
                }
                else
                {
                    response.Result = false;
                    response.Message = "Incorrect Password";
                }
            }
            else
            {
                response.Result = false;
                response.Message = "Incorrect Email";
            }
            return response;
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }
        public User? GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(e => e.Email == email);
        }

        public User? GetUserByUserName(string username)
        {
            return _context.Users.SingleOrDefault(u => u.UserName == username);
        }
    }
}