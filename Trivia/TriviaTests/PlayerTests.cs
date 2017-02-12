using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trivia;
namespace TriviaTests
{
    [TestClass]
    public class PlayerTests
    {
        private Player player;

        [TestInitialize]
        public void Initialize()
        {
            player = new Player("TestPlayer");
        }

        [TestMethod]
        public void EmptyPlayerIsCreated()
        {
            player = new Player("TestName");
            Assert.AreEqual("TestName",player.Name);
            Assert.AreEqual(0,player.Places);
            Assert.AreEqual(0,player.Purses);
            Assert.IsFalse(player.IsPenaltyBox);
        }
    }
}
