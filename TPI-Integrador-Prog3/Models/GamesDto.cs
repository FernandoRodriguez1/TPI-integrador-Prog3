using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Models
{
    public class GamesDto
    {
        public string GameName { get; set; }
        public string Gender { get; set; }
        public string Synopsis { get; set; }
        public string Developer { get; set; }

        public DateTime? DepartureDate { get; set; } = DateTime.Now;


    }
}
