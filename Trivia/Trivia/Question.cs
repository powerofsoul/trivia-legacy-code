using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class Question
    {
        public enum Categories {Pop, Science, Sport, Rock}

        public int Id { get; private set; }
        public Categories category;
        
        public Question(Categories category, int id)
        {
            Id = id;
            this.category = category;
        }
    }
}
