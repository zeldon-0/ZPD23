using API.Contracts.Models;
using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Contracts
{
    public interface IPasswordAuthenticationService
    {
        Task<UserTicketModel> AuthenticateAsync(PasswordAuthModel authModel);

    }
}
