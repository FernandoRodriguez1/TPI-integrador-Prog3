using System.ComponentModel.DataAnnotations;

namespace TPI_Integrador_Prog3.Entities
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Username { get; set; }
        [Required]
        public int Password { get; set; }
        public int Email { get; set; }
        public int Description { get; set; }

    }
}
