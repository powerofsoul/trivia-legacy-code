using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Trivia;
namespace TriviaTests
{
    [TestClass]
    public class GameRunnerTests
    {
        [TestMethod, Timeout(2000)]
        public void TheGameIsEnding()
        {
            GameRunner.Main(new string[0]);
            Assert.AreEqual(0,0);
        }
    }
}
