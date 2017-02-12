using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class Game
    {
        List<Player> Players = new List<Player>();
        List<Question> Questions = new List<Question>();

        public int WinningCondition { get; private set; } = 6;

        private int currentPlayer;

        public int CurrentPlayer
        {
            get { return currentPlayer; }
            set
            {
                if(value == Players.Count)
                    currentPlayer = 0;
                else
                    currentPlayer = value;
            }
        }


        public Game()
        {
            LoadQuestion();
        }

        public void Play()
        {
            Random rand = new Random();

            while(HighestScore() < WinningCondition)
            {
                Roll(rand.Next(5) + 1);

                if(rand.Next(9) == 7)
                {
                    WrongAnswer();             
                }
                else
                {
                    CorrectAnswer();
                }
            } 

        }

        private void LoadQuestion()
        {
            for(int i = 0;i < 50;i++)
            {
                Questions.Add(new Question(Categories.Pop,i));
                Questions.Add(new Question(Categories.Science,i));
                Questions.Add(new Question(Categories.Sport,i));
                Questions.Add(new Question(Categories.Rock,i));
            }
        }

        public bool IsPlayable()
        {
            return (PlayerAmount() >= 2);
        }

        public bool Add(String playerName)
        {
            Players.Add(new Player(playerName));

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + Players.Count);
            return true;
        }

        public int PlayerAmount()
        {
            return Players.Count;
        }

        public void Roll(int roll)
        {
            Console.WriteLine(Players[CurrentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if(Players[CurrentPlayer].IsPenaltyBox)
            {
                if(roll % 2 != 0)
                {
                    Players[CurrentPlayer].MoveToPenalityBox();

                    Players[CurrentPlayer].Places = Players[CurrentPlayer].Places + roll;
                    if(Players[CurrentPlayer].Places > 11)
                        Players[CurrentPlayer].Places = Players[CurrentPlayer].Places - 12;

                    Console.WriteLine(Players[CurrentPlayer]
                            + "'s new location is "
                            + Players[CurrentPlayer].Places);
                    Console.WriteLine("The category is " + CurrentCategory());
                    AskQuestion();
                }
                else
                {
                    Console.WriteLine(Players[CurrentPlayer] + " is not getting out of the penalty box");
                }

            }
            else
            {

                Players[CurrentPlayer].Places = Players[CurrentPlayer].Places + roll;
                if(Players[CurrentPlayer].Places > 11)
                    Players[CurrentPlayer].Places = Players[CurrentPlayer].Places - 12;

                Console.WriteLine(Players[CurrentPlayer]
                        + "'s new location is "
                        + Players[CurrentPlayer].Places);
                Console.WriteLine("The category is " + CurrentCategory());
                AskQuestion();
            }

        }

        private void AskQuestion()
        {
            switch(CurrentCategory())
            {
                case Categories.Pop:
                    Console.WriteLine(Questions.ExtractQuestion(Categories.Pop));
                    break;
                case Categories.Science:
                    Console.WriteLine(Questions.ExtractQuestion(Categories.Pop));
                    break;
                case Categories.Sport:
                    Console.WriteLine(Questions.ExtractQuestion(Categories.Pop));
                    break;
                case Categories.Rock:
                    Console.WriteLine(Questions.ExtractQuestion(Categories.Pop));
                    break;
            }
        }

        private Categories CurrentCategory()
        {
            switch(Players[CurrentPlayer].Places)
            {
                case 0:
                case 4:
                case 8:
                    return Categories.Pop;
                case 1:
                case 5:
                case 9:
                    return Categories.Science;
                case 2:
                case 6:
                case 10:
                    return Categories.Sport;
                default:
                    return Categories.Rock;

            }
        }

        public bool CorrectAnswer()
        {
            if(Players[CurrentPlayer].IsPenaltyBox)
            {
                CurrentPlayer++;
                return true;
            }
            else
            {
                Console.WriteLine("Answer was corrent!!!!");
                Players[CurrentPlayer].Purses++;
                Console.WriteLine(Players[CurrentPlayer]
                        + " now has "
                        + Players[CurrentPlayer].Purses
                        + " Gold Coins.");

                bool winner = Players[CurrentPlayer].Purses != 6;
                CurrentPlayer++;

                return winner;
            }
        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Players[CurrentPlayer].MoveToPenalityBox();

            CurrentPlayer++;
            return true;
        }

        public int HighestScore()
        {
            return Players.Max(s => s.Purses);
        }
    }

}
