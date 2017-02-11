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

        int currentPlayer = 0;

        public Game()
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
            Console.WriteLine(players[currentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if(players[currentPlayer].IsPenaltyBox)
            {
                if(roll % 2 != 0)
                {
                    players[currentPlayer].IsPenaltyBox = false;

                    Console.WriteLine(players[currentPlayer] + " is getting out of the penalty box");
                    players[currentPlayer].Places = players[currentPlayer].Places + roll;
                    if(players[currentPlayer].Places > 11)
                        players[currentPlayer].Places = players[currentPlayer].Places - 12;

                    Console.WriteLine(players[currentPlayer]
                            + "'s new location is "
                            + players[currentPlayer].Places);
                    Console.WriteLine("The category is " + currentCategory());
                    askQuestion();
                }
                else
                {
                    Console.WriteLine(players[currentPlayer] + " is not getting out of the penalty box");
                }

            }
            else
            {

                players[currentPlayer].Places = players[currentPlayer].Places + roll;
                if(players[currentPlayer].Places > 11)
                    players[currentPlayer].Places = players[currentPlayer].Places - 12;

                Console.WriteLine(players[currentPlayer]
                        + "'s new location is "
                        + players[currentPlayer].Places);
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
            switch(players[currentPlayer].Places)
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
            if(players[currentPlayer].IsPenaltyBox)
            {
                currentPlayer++;
                if(currentPlayer == players.Count)
                    currentPlayer = 0;
                return true;
            }
            else
            {
                Console.WriteLine("Answer was corrent!!!!");
                players[currentPlayer].Purses++;
                Console.WriteLine(players[currentPlayer]
                        + " now has "
                        + players[currentPlayer].Purses
                        + " Gold Coins.");

                bool winner = didPlayerWin();
                currentPlayer++;
                if(currentPlayer == players.Count)
                    currentPlayer = 0;

                return winner;
            }
        }

        public bool wrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(players[currentPlayer] + " was sent to the penalty box");
            players[currentPlayer].IsPenaltyBox = true;

            currentPlayer++;
            if(currentPlayer == players.Count)
                currentPlayer = 0;
            return true;
        }


        private bool didPlayerWin()
        {
            return !(players[currentPlayer].Purses == 6);
        }
    }

}
