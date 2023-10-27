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
            public string Description { get; set; }
            [ForeignKey("AdminId")]
            public Admin Admin { get; set; }
            public int ProfessorId { get; set; }
            [ForeignKey("CreatorClientId")]
            public Client Client { get; set; }
            public int ClientId { get; set; }
            [ForeignKey("GameId")]
            public Games NameGame { get; set; }
            public int GameId { get; set; }
            public DateTime CreationDate { get; set; }
            //opcional
            public DateTime LastModificationDate { get; set; }
            public ICollection<Games> Games { get; set; } = new List<Games>();

    }
}
