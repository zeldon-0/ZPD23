using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Contracts
{
    public interface IUnitOfWork
    {
        IAuthenticationRepository AuthenticationRepository { get; }
        IJournalRepository JournalRepository { get;  }
        Task Save();
    }
}
