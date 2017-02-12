using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public enum Categories { Pop, Science, Sport, Rock }

    public class Question
    {
        public int Id { get; private set; }
        public Categories category;
        
        public Question(Categories category, int id)
        {
            Id = id;
            this.category = category;
        }

        public override String ToString()
        {
            return $"{category.ToString()} Question {Id}";
        }
    }

    public class QuestionNotFound:Exception {
        public QuestionNotFound() : base("Question not found") { }
        public QuestionNotFound(string message) : base(message) { }
        public QuestionNotFound(string message,Exception inner) : base(message,inner) { }
    }
}
