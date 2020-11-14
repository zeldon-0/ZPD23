using API.Contracts.Models;
using Core.Domain.Models;
using Core.Repositories.Contracts;
using Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class QuestionAuthenticationService : IQuestionAuthenticationService
    {
        private IUnitOfWork _unitOfWork;
        public QuestionAuthenticationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException($"No instance of {nameof(IUnitOfWork)} provided.");
        }
        public async Task<UserTicketModel> AuthenticateAsync(QuestionAuthModel authModel)
        {
            List<UserQuestion> userQuestions = (await _unitOfWork
                .AuthenticationRepository
                .GetUserQuestionsAsync(authModel.UserName)
                ).ToList();

            bool loginFailed = false;
            foreach(var questionAnswer in authModel.QuestionAnswers)
            {
                UserQuestion userQuestion =
                    userQuestions
                    .FirstOrDefault(uq => uq.QuestionId == questionAnswer.Id);
                if (questionAnswer.Answer != userQuestion.Answer)
                {
                    loginFailed = true;
                    break;
                }
            }
            if (loginFailed)
            {
                _unitOfWork.JournalRepository
                .AddOperationEntryAsync(
                new OperationJournal
                {
                    UserId = userQuestions[0].UserId,
                    LoginSuccess = false
                }
                );
                await _unitOfWork.Save();
                return new UserTicketModel { Id = 0 };
            }
            _unitOfWork.JournalRepository
                .AddRegistrationEntryAsync(
                new RegistrationJournal
                {
                    UserId = userQuestions[0].UserId
                }
                );
            _unitOfWork.JournalRepository
                .AddOperationEntryAsync(
                new OperationJournal
                {
                    UserId = userQuestions[0].UserId,
                    LoginSuccess = true
                }
                );
            await _unitOfWork.Save();
            return new UserTicketModel 
            { 
                Id = userQuestions[0].UserId,
                UserName = authModel.UserName
            };
        }

        public async Task<IEnumerable<QuestionModel>> GetUserQuestionsAsync(UserNameModel userName)
        {
            IEnumerable<UserQuestion> userQuestions = await _unitOfWork
                .AuthenticationRepository
                .GetUserQuestionsAsync(userName.UserName);
            List<int> questionNumbers = new List<int>();
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                int value = random.Next(0, 9);
                while(questionNumbers.Any(num => num == value))
                {
                    value = random.Next(0, 9); 
                }
                questionNumbers.Add(value);
            }

            return userQuestions.Select(uq => 
                new QuestionModel
                {
                    Id = uq.QuestionId,
                    Value = uq.Question.Value
                });
        }
    }
}
