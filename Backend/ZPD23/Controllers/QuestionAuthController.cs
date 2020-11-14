using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Contracts.Models;
using Core.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class QuestionAuthController : ControllerBase
    {
        IQuestionAuthenticationService _authenticationService;
        public QuestionAuthController(IQuestionAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService ?? throw new ArgumentNullException($"No instance of {nameof(IQuestionAuthenticationService)} provided.");
        }

        [HttpPost]
        public async Task<IActionResult> GetQuestions(UserNameModel authModel)
        {
            IEnumerable<QuestionModel> questions =
                await _authenticationService.GetUserQuestionsAsync(authModel);
            if (!questions.Any())
            {
                return BadRequest();
            }
            return Ok(questions);
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(QuestionAuthModel authModel)
        {
            UserTicketModel ticket =
                await _authenticationService.AuthenticateAsync(authModel);
            if (ticket.Id == 0)
            {
                return BadRequest();
            }
            return Ok(ticket);
        }
    }
}
