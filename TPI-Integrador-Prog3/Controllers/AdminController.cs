using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Services.Interfaces;

namespace TPI_Integrador_Prog3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        // ver si debe tener un get y un delete u otro metodo a implementar.
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("{idGame}")]
        public IActionResult GetReviewxGame([FromQuery] int idGame)
        {
            return Ok();
        }
        [HttpDelete("{idReview}")]
        public IActionResult DeleteReview(Games games)
        {
            return Ok();
        }
        [HttpDelete("{idGame}")]
        public IActionResult DeleteGame(int idGame)
        {
            return Ok();
        }

    }
}
