using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Models;

namespace Core.Repositories.Contracts
{
    public interface IJournalRepository
    {
        void AddRegistrationEntryAsync(RegistrationJournal entry);
        void AddOperationEntryAsync(OperationJournal entry);
    }
}
