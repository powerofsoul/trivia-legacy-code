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
            _game.Add("Test");
            _game.Add("Test2");
            Assert.IsTrue(_game.IsPlayable());
        }
        
        [TestMethod]
        public void PlayerIsAdded()
        {   //TODO Please check also the name
            _game.Add("FlorinTest");
            Assert.AreEqual(1,_game.PlayerAmount());
        }

        [TestMethod]
        public void GameHasAWinner()
        {
            _game.Add("T1");
            _game.Add("T2");
            _game.Add("T3");
            _game.Play();
            Assert.AreEqual(_game.WinningCondition,_game.HighestScore());
        }
    }
}
