using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trivia;

namespace TriviaTests
{
    [TestClass]
    public class QuestionTests
    {
        [TestMethod]
        public void QuestionIsCreatedSuccesfuly()
        {
            Question question = new Question(Question.Categories.Pop,10);
            Assert.AreEqual(Question.Categories.Pop,question.category);
            Assert.AreEqual(10,question.Id);
        }
    }
}
