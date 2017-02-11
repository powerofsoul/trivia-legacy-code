using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class Player
    {
        public string Name { get; }
        public int Places { get; protected set; }
        public int Purses { get; protected set; }
        public bool IsPenaltyBox { get; protected set; }

        public Player(string name)
        {
            Name = name;
            Places = 0;
            Purses = 0;
            IsPenaltyBox = false;
        }
    }
}
