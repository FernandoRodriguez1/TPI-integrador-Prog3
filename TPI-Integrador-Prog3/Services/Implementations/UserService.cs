using AutoMapper;
using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;
using TPI_Integrador_Prog3.Services.Interfaces;

namespace TPI_Integrador_Prog3.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly GamesContext _context;

        public UserService(GamesContext context, IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _context = context;
            _userRepository = userRepository;
        }
        public BaseResponse ValidateUser(string username, string password)
        {
            return _userRepository.GetAllUsers();
        }
        public void CreateClient(UserDto userDto)
        {
            var newUser = _mapper.Map<Client>(userDto);
            _userRepository.CreateClient(newUser);
        }
        public void CreateAdmin(UserDto userDto)
        {
            var newUser = _mapper.Map<Admin>(userDto);
            _userRepository.CreateAdmin(newUser);
        }
        public void UpdateUser(int id, UserDto user)
        {
            var existsUser = _userRepository.GetUserById(id);
            if (existsUser == null)
            {
                throw new Exception("Usuario NO encontrado");
            }
            existsUser.UserName = user.UserName;
            existsUser.Email = user.Email;

            _userRepository.UpdateUser(existsUser);
            _userRepository.SaveChanges();
        }
        public bool DeleteUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user != null)
            {
                _userRepository.DeleteUser(user);
                _userRepository.SaveChanges();
                return true;
            }
            return false;
            return _userRepository.GetAllUsers();
        }

        public void CreateClient(UserDto userDto)
        {
            var newUser = _mapper.Map<Client>(userDto);
            _userRepository.CreateClient(newUser);
        }

        public void CreateAdmin(UserDto userDto)
        {
            var newUser = _mapper.Map<Admin>(userDto);
            _userRepository.CreateAdmin(newUser);
        }


        public void UpdateUser(int id , UserDto user)
        {
            var existsUser = _userRepository.GetUserById(id);
            if (existsUser == null)
            {
                throw new Exception("Usuario NO encontrado");
            }
            existsUser.UserName = user.UserName;
            existsUser.Email = user.Email;

            _userRepository.UpdateUser(existsUser);
            _userRepository.SaveChanges();
        }
        public bool DeleteUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user != null)
            {
                _userRepository.DeleteUser(user);
                _userRepository.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteUserByEmail(string email)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user != null)
            {
                _userRepository.DeleteUser(user);
                _userRepository.SaveChanges();
                return true;
            }
            return false;

        }
        public User? GetUserByUserName(string username)
        {
            return _userRepository.GetUserByUserName(username);
        }
        public User? GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public BaseResponse ValidateUser(string email, string password)
        {
            BaseResponse response = new BaseResponse();
            User? userForLogin = _context.Users.SingleOrDefault(u => u.Email == email);
            if (userForLogin != null)
            {
                if (userForLogin.Password == password)
                {
                    response.Result = true;
                    response.Message = "loging Succesfull";
                }
                else
                {
                    response.Result = false;
                    response.Message = "wrong password";
                }
            }
            else
            {
                response.Result = false;
                response.Message = "wrong email";
            }
            return response;
        }
    }
}

