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
    public class RandomDataTests
    {
        private int[] _numbers = new[] { 1, 2, 3 };

        private enum _days
        {
            Monday
        }

        [TestMethod()]
        public void GetIntTest()
        {
            int value = RandomHelper.GetInt(1, 5);
            if (value > 5 || value < 1) Assert.Fail();

            value = _numbers.Random();
            if (value > 3 || value < 1) Assert.Fail();
        }

        [TestMethod()]
        public void GetDecimalTest()
        {
            decimal value = RandomHelper.GetDecimal(1, 5);
            if (value > 5 || value < 1) Assert.Fail();
        }

        [TestMethod()]
        public void GetEnumTest()
        {
            var result = RandomHelper.GetEnum<_days>();
            Assert.AreEqual<_days>(_days.Monday, result);
        }

        [TestMethod()]
        public void GetSentenceTest()
        {
            var result = RandomHelper.GetSentence();
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
    }
}