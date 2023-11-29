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
            _userService = UserService;//Hacemos la inyección del servicio de usuario.
            _config = configuration; //Hacemos la inyección para poder usar el appsettings.json.
            _authenticateService = authenticateService;//Inyectamos el autenticador.
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthenticateDto authenticatedto)
        {
            BaseResponse validarUsuarioResult = _authenticateService.ValidateUser(authenticatedto);//El método post devolverá una Respuesta mockeada, alojada en los models.
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

                var signature = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256); //Hasheamos la Secret Key + la Payload + el Header.

                var claimsForToken = new List<Claim>();  //Creamos una lista de Claims (Requisitos) 
                //Son piezas de informacíon necesarias para concretar la creación del Token y la autorización.                       
                claimsForToken.Add(new Claim("sub", user.Id.ToString()));      
                claimsForToken.Add(new Claim("username", user.UserName));
                claimsForToken.Add(new Claim("usertype", user.UserType.ToString()));

                var jwtSecurityToken = new JwtSecurityToken(  //Creamos el token con todo lo necesario para que funcione.
                    _config["Authentication:Issuer"],
                    _config["Authentication:Audience"],
                    claimsForToken,
                    DateTime.UtcNow,//Aca le podriamos pasar un tiempo en el cual entrara en validez el token, asi de esta forma entrara de manera inmediata a ser vigente.
                    DateTime.UtcNow.AddHours(1), //Le damos una hora de validez al token.
                    signature);

                string tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);//Escribimos el token mediante el método WriteToken().
                return Ok(tokenToReturn); //Devolvemos el TOKEN al pegarle al endpoint.
            }
            return BadRequest();
        }
    }
}