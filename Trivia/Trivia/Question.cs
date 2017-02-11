using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    class Question
    {
        public enum Categories {Pop, Science, Sport, Rock}

        int Id { get; set; }
        Categories category;
        
        public Question(Categories category, int id)
        {
            Id = id;
            this.category = category;
        }
    }
}
