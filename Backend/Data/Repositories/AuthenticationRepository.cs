using Core.Domain.Models;
using Core.Repositories.Contracts;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private AuthenticationContext _context;
        public AuthenticationRepository(AuthenticationContext context)
        {
            _context = context ?? throw new ArgumentNullException($"No instance of {nameof(AuthenticationContext)} provided.");
        }
        public async Task<User> GetUserAsync(string userName)
        {
            return await _context.Users
                .Where(u => u.UserName == userName)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UserQuestion>> GetUserQuestionsAsync(string userName)
        {
            User user =  await GetUserAsync(userName);

            IEnumerable <UserQuestion> questions = 
                await _context
                .UserQuestions
                .Include(uq => uq.Question)
                .Where(uq => uq.UserId == user.Id)
                .ToListAsync();
            return questions;
        }
    }
}
