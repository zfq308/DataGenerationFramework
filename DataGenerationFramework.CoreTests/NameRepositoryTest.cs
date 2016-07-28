using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataGenerationFramework.Core;

namespace DataGenerationFramework.CoreTests
{
    [TestClass]
    [DeploymentItem("NameGenerator")]
    public class NameRepositoryTest
    {
        [TestMethod]
        [TestCategory("Name Repository")]
        public void GetMaleNamesTest()
        {
            //Assemble
            var target = new NameRepository();
            int actual;
            //Act
            actual = target.GetMaleNames().Count;
            //Assert
            Assert.AreNotEqual(0, actual);
        }

        [TestMethod]
        [TestCategory("Name Repository")]
        public void GetFemaleNamesTest()
        {
            //Assemble
            var target = new NameRepository();
            int actual;
            //Act
            actual = target.GetFemaleNames().Count;
            //Assert
            Assert.AreNotEqual(0, actual);
        }

        [TestMethod]
        [TestCategory("Name Repository")]
        public void GetSurnamesTest()
        {
            //Assemble
            var target = new NameRepository();
            int actual;
            //Act
            actual = target.GetSurnames().Count;
            //Assert
            Assert.AreNotEqual(0, actual);
        }


        [TestMethod]
        [TestCategory("Name Repository")]
        public void GetMaleTitlesTest()
        {
            //Assemble
            var target = new NameRepository();
            int actual;
            //Act
            actual = target.GetMaleTitles().Count;
            //Assert
            Assert.AreNotEqual(0, actual);
        }


        [TestMethod]
        [TestCategory("Name Repository")]
        public void GetFemaleTitlesTest()
        {
            //Assemble
            var target = new NameRepository();
            int actual;
            //Act
            actual = target.GetFemaleTitles().Count;
            //Assert
            Assert.AreNotEqual(0, actual);
        }


        [TestMethod]
        [TestCategory("Name Repository")]
        public void GetTitlesTest()
        {
            //Assemble
            var target = new NameRepository();
            int actual;
            //Act
            actual = target.GetTitles().Count;
            //Assert
            Assert.AreNotEqual(0, actual);
        }


        [TestMethod]
        [TestCategory("Name Repository")]
        public void GetSuffixesTest()
        {
            //Assemble
            var target = new NameRepository();
            int actual;
            //Act
            actual = target.GetSuffixes().Count;
            //Assert
            Assert.AreNotEqual(0, actual);
        }
    }
}
