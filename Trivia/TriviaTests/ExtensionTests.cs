using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trivia;
using System.Collections.Generic;
using System.Linq;

namespace TriviaTests
{
    [TestClass]
    public class ExtensionTests
    {
        [TestMethod]
        public void ExtractQuestionRemoveQuestion()
        {
            List<Question> questions = new List<Question>();
            for(int i = 0;i < 50;i++)
            {
                questions.Add(new Question(Categories.Pop,i));
                questions.Add(new Question(Categories.Science,i));
                questions.Add(new Question(Categories.Sport,i));
                questions.Add(new Question(Categories.Rock,i));
            }

            questions.ExtractQuestion(Categories.Pop);
            Assert.AreEqual(49,questions.Count(s=>s.category==Categories.Pop));
            Assert.AreEqual(50,questions.Count(s => s.category == Categories.Science));
            Assert.AreEqual(50,questions.Count(s => s.category == Categories.Sport));
            Assert.AreEqual(50,questions.Count(s => s.category == Categories.Rock));

        }
    }
}
