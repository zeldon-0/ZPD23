using API.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Contracts
{
    public interface IQuestionAuthenticationService
    {
        Task<IEnumerable<QuestionModel>> GetUserQuestionsAsync(UserNameModel userName);
        Task<UserTicketModel> AuthenticateAsync(QuestionAuthModel authModel);
    }
}
