using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class Game
    {
        List<Player> players = new List<Player>();

        LinkedList<string> popQuestions = new LinkedList<string>();
        LinkedList<string> scienceQuestions = new LinkedList<string>();
        LinkedList<string> sportsQuestions = new LinkedList<string>();
        LinkedList<string> rockQuestions = new LinkedList<string>();

        int currentPlayer = 0;
        bool isGettingOutOfPenaltyBox;

        public Game()
        {
            for(int i = 0;i < 50;i++)
            {
                popQuestions.AddLast("Pop Question " + i);
                scienceQuestions.AddLast(("Science Question " + i));
                sportsQuestions.AddLast(("Sports Question " + i));
                rockQuestions.AddLast("Rock Question " + i);
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
                    isGettingOutOfPenaltyBox = true;

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
                    isGettingOutOfPenaltyBox = false;
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
            if(currentCategory() == "Pop")
            {
                Console.WriteLine(popQuestions.First());
                popQuestions.RemoveFirst();
            }
            if(currentCategory() == "Science")
            {
                Console.WriteLine(scienceQuestions.First());
                scienceQuestions.RemoveFirst();
            }
            if(currentCategory() == "Sports")
            {
                Console.WriteLine(sportsQuestions.First());
                sportsQuestions.RemoveFirst();
            }
            if(currentCategory() == "Rock")
            {
                Console.WriteLine(rockQuestions.First());
                rockQuestions.RemoveFirst();
            }
        }

        private String currentCategory()
        {
            if(players[currentPlayer].Places == 0)
                return "Pop";
            if(players[currentPlayer].Places == 4)
                return "Pop";
            if(players[currentPlayer].Places == 8)
                return "Pop";
            if(players[currentPlayer].Places == 1)
                return "Science";
            if(players[currentPlayer].Places == 5)
                return "Science";
            if(players[currentPlayer].Places == 9)
                return "Science";
            if(players[currentPlayer].Places == 2)
                return "Sports";
            if(players[currentPlayer].Places == 6)
                return "Sports";
            if(players[currentPlayer].Places == 10)
                return "Sports";
            return "Rock";
        }

        public bool wasCorrectlyAnswered()
        {
            if(players[currentPlayer].IsPenaltyBox)
            {
                if(isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
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
                else
                {
                    currentPlayer++;
                    if(currentPlayer == players.Count)
                        currentPlayer = 0;
                    return true;
                }
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
