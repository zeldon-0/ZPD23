using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models
{
    public class RegistrationJournal
    {
        public Guid Id { get; set; } = new Guid();
        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
    }
}
