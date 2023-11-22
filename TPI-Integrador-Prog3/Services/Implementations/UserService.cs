using AutoMapper;
using System.Text.RegularExpressions;
using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.DBContexts;
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
        public IEnumerable<UserDto> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
        public void CreateClient(UserDto userDto)
        {
            // Verifica la contraseña antes de crear el cliente
            if (!ValidatePassword(userDto.Password))
            {
                throw new Exception("The password does not meet the requirements. it must have at least one number and one special character");
            }

            var newUser = _mapper.Map<Client>(userDto);
            _userRepository.CreateClient(newUser);
        }
        public void CreateAdmin(UserDto userDto)
        {
            if (!ValidatePassword(userDto.Password))
            {
                throw new Exception("The password does not meet the requirements.");
            }

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
            if (!ValidatePassword(user.Password))
            {
                throw new Exception("The password does not meet the requirements.");
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
        static bool ValidatePassword(string password)
        {
            // Verifica la longitud de la contraseña
            if (password.Length <= 6 && password.Length >= 12)
            {
                return false;
            }
            // verifica que no tenga espacios
            if (password.Contains(" "))
            {
                return false;
            }
            // verifica que tenga al menos una mayúscula
            if (!Regex.IsMatch(password, "[A-Z]"))
            {
                return false;
            }
            // Verifica al menos un carácter
            if (!Regex.IsMatch(password, "[a-zA-Z]"))
            {
                return false;
            }

            // Verifica al menos un número
            if (!Regex.IsMatch(password, "[0-9]"))
            {
                return false;
            }

            // Verifica al menos un carácter especial
            if (!Regex.IsMatch(password, "[!@#$%^&*(),.?\":{}|<>]"))
            {
                return false;
            }

            // Si ha pasado todas las verificaciones
            return true;
        }

    }
}