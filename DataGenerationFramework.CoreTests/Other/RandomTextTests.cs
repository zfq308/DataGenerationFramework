using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataGenerationFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerationFramework.Core.Tests
{
    [TestClass()]
    public class RandomTextTests
    {
        [TestMethod()]
        public void AddContentParagraphsTest()
        {
            string[] words = { "anemone", "wagstaff", "man", "the", "for", "and", "a", "with", "bird", "fox" };
            RandomParagraphGeneratorHelper text = new RandomParagraphGeneratorHelper(words);
            text.AddContentParagraphs(2, 2, 4, 5, 12);
            Console.Write(text.Content);
        }
    }
}