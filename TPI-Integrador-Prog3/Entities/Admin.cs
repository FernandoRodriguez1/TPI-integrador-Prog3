namespace TPI_Integrador_Prog3.Entities
{
    public class Admin : User
    {
        public ICollection<Game> Games { get; set;}
    }
}
