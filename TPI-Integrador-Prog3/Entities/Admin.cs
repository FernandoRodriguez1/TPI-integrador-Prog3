namespace TPI_Integrador_Prog3.Entities
{
    public class Admin : User
    {
        //Tendra que editar reseñas
        public ICollection<Review> Reviews { get; set; }

        // Tendra que editar juegos
        public ICollection<Games> Games { get; set;}
    }
}
