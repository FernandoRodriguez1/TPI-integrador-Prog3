using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TPI_Integrador_Prog3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        //obtendra todas las reseñas hechas hasta el momento
        [HttpGet("{responseId}", Name = "GetResponse")]
        public ActionResult<ResponseDto> GetQuestion(int responseId)
        {
            var response = _responseService.GetResponse(responseId);

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateReview(int JuegoId, ResponseForCreationDto newReviewForCreation)
        {
            if (!_questionService.IsQuestionIdValid(questionId))
                return NotFound($"Question Id not found: {questionId.ToString()}");
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userId = int.Parse(userIdClaim);

            var newResponse = _responseService.CreateResponse(newResponseForCreation, questionId, userId);

            return CreatedAtRoute(
                "GetResponse",
                new { questionId = questionId, responseId = newResponse.Id },
                newResponse);
        }
    }
}
    

