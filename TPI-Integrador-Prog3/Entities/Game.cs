using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPI_Integrador_Prog3.Entities
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string GameName { get; set; }
        public string Gender { get; set; }
        public string Synopsis { get; set; }
        public int GameRating { get; set; }
        public DateTime? DepartureDate { get; set; }
        public string Developer { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public int ClientId { get; set; }
        [ForeignKey("ReviewId")]
        public Review Review { get; set; }
        public int ReviewId { get; set; }

        public ICollection<Review> Reviews { get; set; }

    }
}
