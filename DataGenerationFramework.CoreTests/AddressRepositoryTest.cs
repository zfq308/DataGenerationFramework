using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataGenerationFramework.Core;

namespace DataGenerationFramework.CoreTests
{
    [TestClass]
    [DeploymentItem("AddressGenerator")]
    public class AddressRepositoryTest
    {
        [TestMethod]
        [TestCategory("Address Repository")]
        public void GetAdjectivesTest()
        {
            //Assemble
            var target = new AddressRepository();
            int actual;
            //Act
            actual = target.GetAdjectives().Count;
            //Assert
            Assert.AreNotEqual(0, actual);
        }

        [TestMethod]
        [TestCategory("Address Repository")]
        public void GetNounsTest()
        {
            //Assemble
            var target = new AddressRepository();
            int actual;
            //Act
            actual = target.GetNouns().Count;
            //Assert
            Assert.AreNotEqual(0, actual);
        }

        [TestMethod]
        [TestCategory("Address Repository")]
        public void GetStreetTypesTest()
        {
            //Assemble
            var target = new AddressRepository();
            int actual;
            //Act
            actual = target.GetStreetTypes().Count;
            //Assert
            Assert.AreNotEqual(0, actual);
        }

        [TestMethod]
        [TestCategory("Address Repository")]
        public void GetSubTypesTest()
        {
            //Assemble
            var target = new AddressRepository();
            int actual;
            //Act
            actual = target.GetSubTypes().Count;
            //Assert
            Assert.AreNotEqual(0, actual);
        }

        [TestMethod]
        [TestCategory("Address Repository")]
        public void GetZipCodeInfoTest()
        {
            //Assemble
            var target = new AddressRepository();
            int actual;
            //Act
            actual = target.GetZipCodeInfo().Count;
            //Assert
            Assert.AreNotEqual(0, actual);
        }
    }
}
