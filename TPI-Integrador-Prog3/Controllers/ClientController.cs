using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Services.Interfaces;

namespace TPI_Integrador_Prog3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        //obtendra las reseñas hechas
        //obtendra todos los clientes
        // podra eliminar reseña¿?

        private readonly IClientService _clientService;

        ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet("{idReview}")]
        public IActionResult GetReviewxGame([FromQuery]int idReview)
        {
            return Ok();
        }
    }
}
