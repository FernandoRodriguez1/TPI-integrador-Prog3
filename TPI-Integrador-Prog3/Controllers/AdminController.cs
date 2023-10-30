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
       
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpDelete("{idReview}")]
        public IActionResult DeleteReview(int reviewId)
        {
            return Ok(_adminService.DeleteReview(reviewId));
        }
        [HttpDelete("{idGame}")]
        public IActionResult DeleteGame(int idGame)
        {
            return Ok(_adminService.DeleteGame(idGame));
        }

    }
}
