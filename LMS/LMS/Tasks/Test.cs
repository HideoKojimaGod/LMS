using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    class Test
    {
        List<Question> Questions;

        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }

        public void DeleteQuestion(Question question)
        {
            Questions.Remove(question);
        }

        public void ChangeQuestion(Question newQuestion, Question oldQuestion)
        {
            Questions[Questions.IndexOf(oldQuestion)] = newQuestion;
        }
    }
}
