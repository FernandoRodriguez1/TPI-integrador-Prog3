using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;
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
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpPost("CreateClient")]
        public IActionResult CreateClient([FromBody] UserDto clientDto)
        {

            _userService.CreateClient(clientDto);
            return StatusCode(201);
        }

        [HttpPost("CreateAdmin")]
        public IActionResult CreateAdmin([FromBody] UserDto adminDto)
        {

            _userService.CreateAdmin(adminDto);
            return StatusCode(201);
        }


        [HttpPut("{idUser}")]
        public IActionResult UpdateUser(int id,UserDto user)
        {
            _userService.UpdateUser(id,user);
            return Ok();
        }

        [HttpDelete("DeleteUserById/{id}")]
        public IActionResult DeleteUserById(int id)
        {
            _userService.DeleteUserById(id);
            return Ok("User Delete");
        }

        [HttpDelete("DeleteUserByEmail/{email}")]
        public IActionResult DeleteUserByEmail(string email)
        {
            _userService.DeleteUserByEmail(email);
            return Ok("User Delete");
        }
 
        //[HttpPost("validate")]
        //public IActionResult ValidateUser([FromBody] User user)
        //{
        //    var result = _userService.ValidateUser(user.UserName, user.Password);
        //    if (result == null)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(result);
        //}

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
