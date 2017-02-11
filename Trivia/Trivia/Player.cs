using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    class Player
    {
        string Name { get; }
        int Places { get; set; }
        int purses { get; set; }
        bool IsPenaltyBox { get; set; }

        public Player(string name)
        {
            Name = name;
            Places = 0;
            purses = 0;
            IsPenaltyBox = false;
        }
    }
}
