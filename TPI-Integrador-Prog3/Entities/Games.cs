using Microsoft.VisualBasic;

namespace TPI_Integrador_Prog3.Entities
{
    public class Games
    {
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Client> Clients { get; set; }

    }
}
