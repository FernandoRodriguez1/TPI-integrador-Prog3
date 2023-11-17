using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;
using TPI_Integrador_Prog3.Services.Interfaces;

namespace TPI_Integrador_Prog3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        private readonly IAuthenticateService _authenticateService;

        public AuthenticateController(IUserService UserService, IConfiguration configuration, IAuthenticateService authenticateService)
        {
            _userService = UserService;
            _config = configuration;
            _authenticateService = authenticateService;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthenticateDto authenticatedto)
        {
            BaseResponse validarUsuarioResult = _authenticateService.ValidateUser(authenticatedto);
            if (validarUsuarioResult.Message == "wrong username")
            {
                return BadRequest(validarUsuarioResult.Message);
            }
            else if (validarUsuarioResult.Message == "wrong password")
            {
                return Unauthorized(); 
            }
            if (validarUsuarioResult.Result)
            {
                User? user = _userService.GetUserByUserName(authenticatedto.UserName); 
                var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"])); 

                var signature = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256); 

                var claimsForToken = new List<Claim>();                        
                claimsForToken.Add(new Claim("sub", user.Id.ToString()));      
                claimsForToken.Add(new Claim("username", user.UserName));
                claimsForToken.Add(new Claim("usertype", user.UserType.ToString()));

                var jwtSecurityToken = new JwtSecurityToken( 
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