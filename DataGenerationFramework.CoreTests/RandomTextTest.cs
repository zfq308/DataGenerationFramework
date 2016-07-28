using System.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataGenerationFramework.Core;

namespace DataGenerationFramework.CoreTests
{
    [TestClass]
    public class RandomTextTest
    {
        /// <summary>
        ///     A test for RandomText Constructor
        /// </summary>
        [TestMethod]
        public void RandomTextConstructorTest()
        {
            var target = new RandomParagraphGeneratorHelper();
            Assert.AreEqual((target.WordList.Length > 5), true, "Default Wordlist was not set correctly.");
        }

        /// <summary>
        ///     A test for RandomText Constructor
        /// </summary>
        [TestMethod]
        public void RandomTextConstructorTest1()
        {
            string[] words = "How Now Brown Cow".Split(' ');
            var target = new RandomParagraphGeneratorHelper(words);
            Assert.AreEqual(target.WordList.Length, words.Length, "Wordlist was not set correctly.");
        }

        /// <summary>
        ///     A test for RandomText Constructor using default words
        ///     result should be greater than zero
        /// </summary>
        [TestMethod]
        public void RandomTextConstructorTest2()
        {
            var target = new RandomParagraphGeneratorHelper();
            Assert.IsTrue(target.WordList.ToString().Length > 0);
        }

        /// <summary>
        ///     A test for AddContentParagraphs
        /// </summary>
        [TestMethod]
        public void AddContentParagraphsTest()
        {
            var target = new RandomParagraphGeneratorHelper("Oh Rose Though art sick the invisible worm".Split(' '));
            const int numberParagraphs = 1;
            const int minSentences = 4;
            const int maxSentences = minSentences;
            const int minWords = 4;
            const int maxWords = minWords;
            target.AddContentParagraphs(numberParagraphs, minSentences, maxSentences, minWords, maxWords);
            string actualOutput = target.ToString().Replace("\n\n", string.Empty).Trim();

            int numberOfSentances = actualOutput.Split('.').Length - 1;
            int numberOfWords = actualOutput.Split(' ').Length / numberOfSentances;

            Assert.AreEqual(minSentences, numberOfSentances, "Incorrect number of sentances generated.");
            Assert.AreEqual(minWords, numberOfWords, "Incorrect number of words generated");
        }
        /// <summary>
        ///     A test for AddContentParagraphs
        /// </summary>
        [TestMethod]
        public void AddContentParagraphsTest2()
        {
            var target = new RandomParagraphGeneratorHelper();
            const int numberParagraphs = 1;
            const int minSentences = 4;
            const int maxSentences = minSentences;
            const int minWords = 4;
            const int maxWords = minWords;
            target.AddContentParagraphs(numberParagraphs, minSentences, maxSentences, minWords, maxWords);
            string actualOutput = target.ToString().Replace("\n\n", string.Empty).Trim();

            int numberOfSentances = actualOutput.Split('.').Length - 1;
            int numberOfWords = actualOutput.Split(' ').Length / numberOfSentances;

            Assert.AreEqual(minSentences, numberOfSentances, "Incorrect number of sentances generated.");
            Assert.AreEqual(minWords, numberOfWords, "Incorrect number of words generated");
        }

        /// <summary>
        /// Check we get some random text back
        /// </summary>
        [TestMethod]
        public void ParameterLessTest1()
        {
            var target = new RandomParagraphGeneratorHelper();
            var actual = target.ToString();
            //length should be greater than 1000 char.
            Assert.IsTrue(actual.Length > 1000);
        }


        /// <summary>
        /// Check we get some random text back
        /// </summary>
        [TestMethod]
        public void ParameterLessTest2()
        {
            var actual = new RandomParagraphGeneratorHelper().ToString();
            //length should be greater than 1000 char.
            Assert.IsTrue(actual.Length > 1000);
        }



        /// <summary>
        /// Check we get some random text back
        /// </summary>
        [TestMethod]
        public void MaxLengthTest1()
        {
            for (int i = 1; i < 1000; i++)
            {
                var target = new RandomParagraphGeneratorHelper(i);
                var actual = target.ToString();
                //length should be greater than i char max
                Assert.IsTrue(actual.Length <= i);
            }

        }

        /// <summary>
        /// Check we get some random text back
        /// </summary>
        [TestMethod]
        public void MaxLengthTest2()
        {
            for (int i = 1; i < 1000; i++)
            {
                var actual = new RandomParagraphGeneratorHelper(i).ToString();
                //length should be greater than i char max
                Assert.IsTrue(actual.Length <= i);
                Assert.IsTrue(actual.Length > 0);
            }

        }

    }
}