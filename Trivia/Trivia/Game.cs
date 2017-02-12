using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class Game
    {
        List<Player> players = new List<Player>();
        List<Question> questions = new List<Question>();

        public int WinningCondition { get; private set; } = 6;

        private int currentPlayer;

        public int CurrentPlayer
        {
            get { return currentPlayer; }
            set
            {
                if(value == players.Count)
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
            bool aWiner = false;
            do
            {

                roll(rand.Next(5) + 1);

                if(rand.Next(9) == 7)
                {
                    aWiner =  wrongAnswer();
                }
                else
                {
                    aWiner = wasCorrectlyAnswered();
                }
            } while(aWiner);

        }

        private void LoadQuestion()
        {
            for(int i = 0;i < 50;i++)
            {
                questions.Add(new Question(Categories.Pop,i));
                questions.Add(new Question(Categories.Science,i));
                questions.Add(new Question(Categories.Sport,i));
                questions.Add(new Question(Categories.Rock,i));
            }
        }

        public bool isPlayable()
        {
            return (howManyPlayers() >= 2);
        }

        public bool add(String playerName)
        {
            players.Add(new Player(playerName));

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + players.Count);
            return true;
        }

        public int howManyPlayers()
        {
            return players.Count;
        }

        public void roll(int roll)
        {
            Console.WriteLine(players[CurrentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if(players[CurrentPlayer].IsPenaltyBox)
            {
                if(roll % 2 != 0)
                {
                    players[CurrentPlayer].MoveToPenalityBox();

                    players[CurrentPlayer].Places = players[CurrentPlayer].Places + roll;
                    if(players[CurrentPlayer].Places > 11)
                        players[CurrentPlayer].Places = players[CurrentPlayer].Places - 12;

                    Console.WriteLine(players[CurrentPlayer]
                            + "'s new location is "
                            + players[CurrentPlayer].Places);
                    Console.WriteLine("The category is " + currentCategory());
                    askQuestion();
                }
                else
                {
                    Console.WriteLine(players[CurrentPlayer] + " is not getting out of the penalty box");
                }

            }
            else
            {

                players[CurrentPlayer].Places = players[CurrentPlayer].Places + roll;
                if(players[CurrentPlayer].Places > 11)
                    players[CurrentPlayer].Places = players[CurrentPlayer].Places - 12;

                Console.WriteLine(players[CurrentPlayer]
                        + "'s new location is "
                        + players[CurrentPlayer].Places);
                Console.WriteLine("The category is " + currentCategory());
                askQuestion();
            }

        }

        private void askQuestion()
        {
            switch(currentCategory())
            {
                case Categories.Pop:
                    Console.WriteLine(questions.ExtractQuestion(Categories.Pop));
                    break;
                case Categories.Science:
                    Console.WriteLine(questions.ExtractQuestion(Categories.Pop));
                    break;
                case Categories.Sport:
                    Console.WriteLine(questions.ExtractQuestion(Categories.Pop));
                    break;
                case Categories.Rock:
                    Console.WriteLine(questions.ExtractQuestion(Categories.Pop));
                    break;
            }
        }

        private Categories currentCategory()
        {
            switch(players[CurrentPlayer].Places)
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

        public bool wasCorrectlyAnswered()
        {
            if(players[CurrentPlayer].IsPenaltyBox)
            {
                CurrentPlayer++;
                return true;
            }
            else
            {
                Console.WriteLine("Answer was corrent!!!!");
                players[CurrentPlayer].Purses++;
                Console.WriteLine(players[CurrentPlayer]
                        + " now has "
                        + players[CurrentPlayer].Purses
                        + " Gold Coins.");

                bool winner = players[CurrentPlayer].Purses != 6;
                CurrentPlayer++;

                return winner;
            }
        }

        public bool wrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            players[CurrentPlayer].MoveToPenalityBox();

            CurrentPlayer++;
            return true;
        }
        
        public int HighestScore()
        {
            return players.Max(s => s.Purses);
        }
    }

}
