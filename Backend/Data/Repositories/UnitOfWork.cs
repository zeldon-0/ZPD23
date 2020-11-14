using Core.Repositories.Contracts;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AuthenticationContext _context;
        public UnitOfWork(IAuthenticationRepository authenticationRepository,
            IJournalRepository journalRepository,
            AuthenticationContext context)
        {
            AuthenticationRepository = authenticationRepository ?? throw new ArgumentNullException($"No instance of {nameof(IAuthenticationRepository)} provided.");
            JournalRepository = journalRepository ?? throw new ArgumentNullException($"No instance of {nameof(IJournalRepository)} provided.");
            _context = context ?? throw new ArgumentNullException($"No instance of {nameof(AuthenticationContext)} provided.");
        }
        public IAuthenticationRepository AuthenticationRepository { get; }
        public IJournalRepository JournalRepository { get; }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
