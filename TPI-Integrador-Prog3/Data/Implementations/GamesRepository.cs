using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Data.Implementations
{
    public class GamesRepository
    {
        public GamesRepository(StudentsQuestionsContext context) : base(context)
        {
        }
        public ICollection<Games> GetGamesReviews(int gamesId) =>
           _context.Students.Include(a => a.SubjectsAttended).ThenInclude(m => m.Professors).Where(a => a.Id == gamesId)
           .Select(a => a.SubjectsAttended).FirstOrDefault() ?? new List<Review>();

        public Games? GetGameById(int gameId)
        {
            return _context.Games.Find(gameId);
        }
    }
}
