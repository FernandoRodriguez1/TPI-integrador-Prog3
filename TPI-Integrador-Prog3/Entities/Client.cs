namespace TPI_Integrador_Prog3.Entities
{
    public class Client : User
    {
       //Tendra que valorar juegos

       public ICollection<Games> Games { get; set; } = new List<Games>();
       public ICollection<Review> Reviews { get; set; } = new List<Review>();

    }
}
