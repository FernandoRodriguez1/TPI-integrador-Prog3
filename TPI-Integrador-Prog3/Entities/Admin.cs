namespace TPI_Integrador_Prog3.Entities
{
    public class Admin : User
    {
        public Admin()
        {
            UserType = Enum.UserType.Admin; //Dentro del constructor asignamos el UserType propio del Admin.
        }
    }
}
