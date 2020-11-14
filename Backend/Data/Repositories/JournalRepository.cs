using Core.Domain.Models;
using Core.Repositories.Contracts;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class JournalRepository : IJournalRepository
    {
        private AuthenticationContext _context;
        public JournalRepository(AuthenticationContext context)
        {
            _context = context ?? throw new ArgumentNullException($"No instance of {nameof(AuthenticationContext)} provided."); 
        }
        public void AddOperationEntryAsync(OperationJournal entry)
        {
            _context.OperationJournal.Add(entry);
        }

        public void AddRegistrationEntryAsync(RegistrationJournal entry)
        {
            _context.RegistrationJournal.Add(entry);
        }
    }
}
