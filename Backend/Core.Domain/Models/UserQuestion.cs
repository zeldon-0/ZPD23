using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models
{
    public class UserQuestion
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public string Answer { get; set; }
    }
}
