using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPI_Integrador_Prog3.Entities
{
    public class Games
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string GameName { get; set; }
        public string Gender { get; set; }
        public string Synopsis { get; set; }
        public int GameRating { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Developer { get; set; }
        public string Comments { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<Admin> Admins { get; set; } = new List<Admin>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Client> Clients { get; set; } = new List<Client>();

    }
}
