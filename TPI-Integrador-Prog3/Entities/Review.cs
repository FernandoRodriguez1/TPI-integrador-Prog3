using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TPI_Integrador_Prog3.Entities
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public int? ClientId { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }
        public int GameId { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
