using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPI_Integrador_Prog3.Entities
{
    public class Client : User
    {
        public Client()
        {
            UserType = Enum.UserType.Client; //Dentro del constructor asignamos el tipo de UserType, propio del Client.
        }
        public ICollection<Game> Games { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }

}