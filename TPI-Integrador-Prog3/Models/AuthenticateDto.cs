using System.ComponentModel.DataAnnotations;

namespace TPI_Integrador_Prog3.Models
{
    public class AuthenticateDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
