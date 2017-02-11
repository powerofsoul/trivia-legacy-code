using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    class Question
    {
        public enum Category {Pop, Science, Sport, Rock}

        int Id { get; set; }
        Category category;
        
        public Question(Category category, int id)
        {
            Id = id;
            this.category = category;
        }
    }
}
