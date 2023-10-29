using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.Data.Implementations
{
    public class ClientRepository
    {
        public StudentRepository(StudentsQuestionsContext context) : base(context)
        {
        }

        public ICollection<Review> GetClientReviews(int clientId) =>
            _context.Students.Include(a => a.SubjectsAttended).ThenInclude(m => m.Professors).Where(a => a.Id == studentId)
            .Select(a => a.SubjectsAttended).FirstOrDefault() ?? new List<Subject>();

        
    }

}
