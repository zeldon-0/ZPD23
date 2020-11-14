using System;
using System.Collections.Generic;
using System.Text;

namespace API.Contracts.Models
{
    public class QuestionAuthModel
    {
        public string UserName { get; set; }
        public IEnumerable<QuestionAnswerModel> QuestionAnswers { get; set; }
    }
}
