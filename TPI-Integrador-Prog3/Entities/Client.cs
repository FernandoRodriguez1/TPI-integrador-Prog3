using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPI_Integrador_Prog3.Entities
{
    public class Client : User
    {
       [Key]
       public int Id { get; set; }
       public ICollection<Game> Games { get; set; } 
       public ICollection<Review> Reviews { get; set; }

    }
}
