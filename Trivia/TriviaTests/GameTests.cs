using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trivia;
using Moq;

namespace TriviaTests
{
    [TestClass]
    public class GameTests
    {
        private Game _game;

        [TestInitialize]
        public void Initialize()
        {
            _game = new Game();
        }

        [TestMethod]
        public void GameIsPlayable()
        {
            _game.add("Test");
            _game.add("Test2");
            Assert.IsTrue(_game.isPlayable());
        }

        [TestMethod]
        public void CurrentPlayerIsGoingToFirstAfterLast()
        {
            _game.add("T1");
            _game.add("T2");
            _game.add("T3");
            Assert.AreEqual(0,_game.CurrentPlayer);
            _game.CurrentPlayer++;
            Assert.AreEqual(1,_game.CurrentPlayer);
            _game.CurrentPlayer++;
            Assert.AreEqual(2,_game.CurrentPlayer);
            _game.CurrentPlayer++;
            Assert.AreEqual(0,_game.CurrentPlayer);
        }
        
        [TestMethod]
        public void PlayerIsAdded()
        {   //TODO Please check also the name
            _game.add("FlorinTest");
            Assert.AreEqual(1,_game.howManyPlayers());
        }

        [TestMethod]
        public void GameHasAWinner()
        {
            _game.add("T1");
            _game.add("T2");
            _game.add("T3");
            _game.Play();
            Assert.AreEqual(_game.WinningCondition,_game.HighestScore());
        }
    }
}
