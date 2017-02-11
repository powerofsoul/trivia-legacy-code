using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public static class Extensions
    {
        public static Question ExtractQuestion(this List<Question> questions, Categories category)
        {
            foreach(Question q in questions)
            {
                if(q.category == category)
                {
                    questions.Remove(q);
                    return q;
                }
            }

            throw new QuestionNotFound("Question not Found");
        }
    }
}
