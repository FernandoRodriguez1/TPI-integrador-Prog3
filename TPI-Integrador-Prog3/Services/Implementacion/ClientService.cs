using System.Data.Entity;
using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.DBContexts;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Services.Interfaces;

namespace TPI_Integrador_Prog3.Services.Implementacion
{
    public class ClientService : IClientService
    {
        
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _clientRepository.GetAllGames();
        }

        public Client GetClientById(int userId)
        {
            return _clientRepository.GetClientById(userId);
        }

        public IEnumerable<Review> GetReviewsByGameId(int gameId)
        {
            return _clientRepository.GetReviewsByGameId(gameId);
        }

        public void CreateReview(Review review)
        {
            _clientRepository.CreateReview(review);
        }
        public void UpdateReview(Review review)
        {
            _clientRepository.UpdateReview(review);
        }
        public void DeleteReview(Review review)
        {
            _clientRepository.DeleteReview(review);
        }

    }
}
