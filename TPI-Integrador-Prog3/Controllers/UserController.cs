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
    
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Authorize("Admin")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpPost("CreateClient")]
        [Authorize("All")]
        public IActionResult CreateClient([FromBody] UserDto clientDto)
        {

            _userService.CreateClient(clientDto);
            return StatusCode(201);
        }

        [HttpPost("CreateAdmin")]
        [Authorize("Admin")]
        public IActionResult CreateAdmin([FromBody] UserDto adminDto)
        {

            _userService.CreateAdmin(adminDto);
            return StatusCode(201);
        }
        [HttpPut("{idUser}")]
        [Authorize("Client")]
        public IActionResult UpdateUser(int id, UserDto user)
        {
            _userService.UpdateUser(id, user);
            return Ok();
        }
        [HttpDelete("DeleteUserById/{id}")]
        [Authorize("Admin")]
        public IActionResult DeleteUserById(int id)
        {
            _userService.DeleteUserById(id);
            return Ok("User Delete");
        }
        [HttpDelete("DeleteUserByEmail/{email}")]
        [Authorize("Admin")]
        public IActionResult DeleteUserByEmail(string email)
        {
            _userService.DeleteUserByEmail(email);
            return Ok("User Delete");
        }
        
        [HttpGet("GetClientByUsername/{username}")]
        [Authorize("Admin")]
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
        [Authorize("Admin")]
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