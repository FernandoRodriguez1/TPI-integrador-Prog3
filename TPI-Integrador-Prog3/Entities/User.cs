using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TPI_Integrador_Prog3.Enum;

namespace TPI_Integrador_Prog3.Entities
{
    public abstract class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [Required]
        public UserType UserType { get; set; } = UserType.Client;


    }
}
