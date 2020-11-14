using API.Contracts.Models;
using Core.Domain.Models;
using Core.Repositories.Contracts;
using Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class PasswordAuthenticationService : IPasswordAuthenticationService
    {
        private IUnitOfWork _unitOfWork;
        public PasswordAuthenticationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException($"No instance of {nameof(IUnitOfWork)} provided.");
        }
        public async Task<UserTicketModel> AuthenticateAsync(PasswordAuthModel authModel)
        {
            User user = await _unitOfWork
                .AuthenticationRepository
                .GetUserAsync(authModel.UserName);
            if(user == null)
            {
                return new UserTicketModel { Id = 0 };
            }
            string providedPassword = authModel.Password;
            string actualPassword = user.Password;
            if (providedPassword == actualPassword)
            {
                _unitOfWork.JournalRepository
                    .AddRegistrationEntryAsync(
                    new RegistrationJournal
                    {
                        UserId = user.Id
                    }
                    );
                _unitOfWork.JournalRepository
                    .AddOperationEntryAsync(
                    new OperationJournal
                    {
                        UserId = user.Id,
                        LoginSuccess = true
                    }
                    );
                await _unitOfWork.Save();
                return new UserTicketModel
                {
                    Id = user.Id,
                    UserName = user.UserName
                };
            }
            _unitOfWork.JournalRepository
                .AddOperationEntryAsync(
                new OperationJournal
                {
                    UserId = user.Id,
                    LoginSuccess = false
                }
                );
            return new UserTicketModel { Id = 0};
        }
        private string CipherPassword(string password)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(char character in password)
            {
                int newCode = (int)Math.Log((int)character);
                stringBuilder.Append((char)newCode);
            }
            return stringBuilder.ToString();
        }

    }
}
