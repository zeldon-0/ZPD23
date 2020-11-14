using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public IEnumerable<UserQuestion> UserQuestions { get; set; }
    }
}
