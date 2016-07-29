using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataGenerationFramework.Core;
using DataGenerationFramework.Core.GeneratorDataByRepository;

namespace DataGenerationFramework.CoreTests
{
    [TestClass]
    [DeploymentItem("AddressGenerator")]
    public class AddressRepositoryTest
    {
     
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
