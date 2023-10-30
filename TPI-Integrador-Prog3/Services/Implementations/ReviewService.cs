sing TPI_Integrador_Prog3.Models.Reviews;

namespace TPI_Integrador_Prog3.Services.Implementations
{
    public class ReviewService
    {
        //private readonly IMapper _mapper;
        //private readonly IQuestionRepository _questionRepository;
        //private readonly IMailService _mailService;
        //private readonly IUserRepository _userRepository;
        //private readonly IHttpContextAccessor _httpContext;

        //public QuestionService(IMapper mapper,
        //    IQuestionRepository questionRepository,
        //    IMailService mailService,
        //    IUserRepository userRepository,
        //    IHttpContextAccessor httpContext)
        //{
        //    _mapper = mapper;
        //    _questionRepository = questionRepository;
        //    _mailService = mailService;
        //    _userRepository = userRepository;
        //    this._httpContext = httpContext;
        //}

        public ReviewDto CreateQuestion(ReviewCreate newReviewDto, int userId)
        {
            var newQuestion = _mapper.Map<Entities.Question>(newQuestionDto);

            newQuestion.CreatorStudentId = userId;

            var student = _userRepository.GetUserById(userId);
            var professor = _userRepository.GetUserById(newQuestionDto.ProfessorId);

            _questionRepository.AddQuestion(newQuestion);
            if (_questionRepository.SaveChanges())
                _mailService.Send("Se creó una nueva consulta",
                    $"Usted tiene una nueva consulta asignada por parte del alumno: {student.Name} {student.LastName} ",
                    professor.Email);

            return _mapper.Map<QuestionDto>(newQuestion);
        }

        public QuestionDto? GetQuestion(int questionId)
        {
            var consulta = _questionRepository.GetQuestion(questionId);
            return _mapper.Map<QuestionDto?>(consulta);
        }

        public bool IsQuestionIdValid(int questionId)
        {
            return _questionRepository.IsQuestionIdValid(questionId);
        }
    }
}
