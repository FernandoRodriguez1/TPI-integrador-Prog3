using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;
using TPI_Integrador_Prog3.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TPI_Integrador_Prog3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateControllerr : ControllerBase
    {
        public IUserService _userService;
        public IConfiguration _config;
        public AuthenticateControllerr(IConfiguration config,IUserService userService)
        {
            _userService = userService;
            _config = config;
        }
        [HttpPost]
        public IActionResult Auth([FromBody] CredentialsDto credentialsDto)
        {
            BaseResponse validateUserResult = _userService.ValidateUser(credentialsDto.UserName, credentialsDto.Password);
            if (validateUserResult.Message == "wrong email")
            {
                return BadRequest(validateUserResult.Message);
            }
            else if (validateUserResult.Message == "wrong password")
            {
                return Unauthorized();
            }
            if (validateUserResult.Result)
            {
                //generacion del token
                User user = _userService.GetUserByUserName(credentialsDto.UserName);
                //Paso 2: Crear el token
                var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"])); //Traemos la SecretKey del Json. agregar antes: using Microsoft.IdentityModel.Tokens;

                var signature = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

                //Los claims son datos en clave->valor que nos permite guardar data del usuario.
                var claimsForToken = new List<Claim>();
                claimsForToken.Add(new Claim("sub", user.Id.ToString())); //"sub" es una key estándar que significa unique user identifier, es decir, si mandamos el id del usuario por convención lo hacemos con la key "sub".
                claimsForToken.Add(new Claim("email", user.Email));
                claimsForToken.Add(new Claim("username", user.UserName));
                claimsForToken.Add(new Claim("role", user.UserType)); //Debería venir del usuario

                var jwtSecurityToken = new JwtSecurityToken( //agregar using System.IdentityModel.Tokens.Jwt; Acá es donde se crea el token con toda la data que le pasamos antes.
                    _config["Authentication:Issuer"],
                    _config["Authentication:Audience"],
                    claimsForToken,
                    DateTime.UtcNow,
                    DateTime.UtcNow.AddHours(1),
                    signature);

                string tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                return Ok(tokenToReturn);
            }
            return BadRequest();
        }

    }
}
