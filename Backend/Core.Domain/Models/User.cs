using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public IEnumerable<UserQuestion> UserQuestions { get; set; }
        public IEnumerable<RegistrationJournal> RegistrationEntries { get; set; }
        public IEnumerable<OperationJournal> OperationEntries { get; set; }
    }
}
