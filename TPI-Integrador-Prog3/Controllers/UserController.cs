using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Services.Implementations;
using TPI_Integrador_Prog3.Services.Interfaces;

namespace TPI_Integrador_Prog3.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            var result = _userService.CreateUser(user);
            if (result == null)
            {
                return BadRequest("usuario no encontrado");
            }
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] User user)
        {
            _userService.UpdateUser(user);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteUser(string email)
        {
            _userService.DeleteUserByEmail(email);
            return Ok();
        }
 
        [HttpPost("validate")]
        public IActionResult ValidateUser([FromBody] User user)
        {
            var result = _userService.ValidateUser(user.UserName, user.Password);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet("GetClientByUsername/{username}")]
        public IActionResult GetUserByUserName(string username)
        {
            var result = _userService.GetUserByUserName(username);
            if (result == null)
            {
                return BadRequest("usuario no encontrado");
            }
            return Ok(result);
        }

        [HttpGet("GetClientByEmail{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            var result = _userService.GetUserByEmail(email);
            if (result == null)
            {
                return BadRequest("usuario no encontrado");
            }
            return Ok(result);
        }

    }
}
