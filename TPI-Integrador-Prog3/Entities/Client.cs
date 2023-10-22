namespace TPI_Integrador_Prog3.Entities
{
    public class Client : User
    {
       //Tendra que valorar juegos

       public ICollection<Review> Reviews { get; set; } = new List<Review>();

    }
}
