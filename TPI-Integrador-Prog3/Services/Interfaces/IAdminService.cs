using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Services.Interfaces
{
    public interface IAdminService
    {
        public void GetReviewxGame(int idGame);
        public void DeleteReview(Games games);
        public void DeleteGame(int idGame);
    }
}
