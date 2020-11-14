using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Contracts
{
    public interface IAuthenticationRepository
    {
        Task<User> GetUserAsync(string userName);
        Task<IEnumerable<UserQuestion>> GetUserQuestionsAsync(string userName);
    }
}
