using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataGenerationFramework.Core;

namespace DataGenerationFramework.CoreTests
{
    [TestClass]
    public class StopWatch2Tests
    {
        [TestMethod]
        public void StopWatchTest1()
        {
            const int iterations = 10;
            var target = new StopWatch2();
            target.Start();
            Assert.IsTrue(target.IsRunning);
            for (int i = 0; i < iterations; i++)
            {
                Thread.Sleep(34);
                target.RestartAndLog();
            }

            target.Stop();

            Assert.IsFalse(target.IsRunning);
        }

        [TestMethod]
        public void AverageTest()
        {
            const int iterations = 10;
            var target = new StopWatch2();
            target.Start();
            Assert.IsTrue(target.IsRunning);
            for (int i = 0; i < iterations; i++)
            {
                Thread.Sleep(34);
                target.RestartAndLog();
                Assert.IsTrue(target.IsRunning);
            }
           
            
            target.Stop();

            Assert.IsFalse(target.IsRunning);

            Assert.IsTrue(target.Average.Accuracy > 10);
            Assert.IsTrue(target.Average.MilliSeconds > 32);
            Assert.IsTrue(target.Average.Ticks > 1000);


        }

        [TestMethod]
        public void MinimumTest()
        {
            const int iterations = 10;
            var target = new StopWatch2();
            target.Start();
            Assert.IsTrue(target.IsRunning);
            for (int i = 0; i < iterations; i++)
            {
                Thread.Sleep(34);
                target.RestartAndLog();
                Assert.IsTrue(target.IsRunning);
            }


            target.Stop();

            Assert.IsFalse(target.IsRunning);

            Assert.IsTrue(target.Minimum.Accuracy > 10);
            Assert.IsTrue(target.Minimum.MilliSeconds > 32);
            Assert.IsTrue(target.Minimum.Ticks > 1000);
        }

        [TestMethod]
        public void MaximumTest()
        {
            const int iterations = 10;
            var target = new StopWatch2();
            target.Start();
            Assert.IsTrue(target.IsRunning);
            for (int i = 0; i < iterations; i++)
            {
                Thread.Sleep(34);
                target.RestartAndLog();
                Assert.IsTrue(target.IsRunning);
            }


            target.Stop();

            Assert.IsFalse(target.IsRunning);

            Assert.IsTrue(target.Maximum.Accuracy > 10);
            Assert.IsTrue(target.Maximum.MilliSeconds > 32);
            Assert.IsTrue(target.Maximum.Ticks > 1000);


        }
    }
}
