using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trivia;

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
    }
}
