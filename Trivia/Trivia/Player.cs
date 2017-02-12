using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class Player
    {
        public string Name { get; }
        public int Places { get; set; }
        public int Purses { get; set; }
        public bool IsPenaltyBox { get; set; }

        public Player(string name)
        {
            Name = name;
            Places = 0;
            Purses = 0;
            IsPenaltyBox = false;
        }

        public void MoveToPenalityBox()
        {
            Console.WriteLine(this + " was sent to the penalty box");
            IsPenaltyBox = true;
        }
        
        public void MoveOutOfPenalityBox()
        {
            Console.WriteLine(this + " is getting out of the penalty box");
            IsPenaltyBox = false;
        }
    }
}
