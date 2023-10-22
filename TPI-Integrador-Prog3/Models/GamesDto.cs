namespace TPI_Integrador_Prog3.Models
{
    public class GamesDto
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public string Gender { get; set; }
        public string Synopsis { get; set; }
        public int GameRating { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Developer { get; set; }
        public string Comments { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
