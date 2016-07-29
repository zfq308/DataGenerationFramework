using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DataGenerationFramework.Core;
using DataGenerationFramework.Core.GeneratorDataByRepository;

namespace DataGenerationFramework.CoreTests
{
    [TestClass]
    [DeploymentItem("NameGenerator")]
    public class NameGeneratorTest
    {
        [TestMethod]
        [TestCategory("Name Generation")]
        public void GenerateFemaleNameTest()
        {
            //Arrange
            var expected = "Jane";
            var repositoryMock = new Mock<IHumanDataRepository>();
            repositoryMock.Setup(o => o.GetFemaleNames()).Returns(new List<string>() { expected });

            var generator = new HumanDataGenerator(repositoryMock.Object);
            //Act
            var actual = generator.GenerateFemaleName().ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Name Generation")]
        public void GenerateFemaleTitleTest()
        {
            //Arrange
            var expected = "Miss";
            var repositoryMock = new Mock<IHumanDataRepository>();
            repositoryMock.Setup(o => o.GetFemaleTitles()).Returns(new List<string>() { expected });
            repositoryMock.Setup(o => o.GetTitles()).Returns(new List<string>());

            var generator = new HumanDataGenerator(repositoryMock.Object);
            //Act
            var actual = generator.GenerateFemaleTitle();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Name Generation")]
        public void GenerateMaleNameTest()
        {
            //Arrange
            var expected = "John";
            var repositoryMock = new Mock<IHumanDataRepository>();
            repositoryMock.Setup(o => o.GetMaleNames()).Returns(new List<string>() { expected });

            var generator = new HumanDataGenerator(repositoryMock.Object);
            //Act
            var actual = generator.GenerateMaleName();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Name Generation")]
        public void GenerateMaleTitleTest()
        {
            //Arrange
            var expected = "Mr.";
            var repositoryMock = new Mock<IHumanDataRepository>();
            repositoryMock.Setup(o => o.GetMaleTitles()).Returns(new List<string>() { expected });
            repositoryMock.Setup(o => o.GetTitles()).Returns(new List<string>());

            var generator = new HumanDataGenerator(repositoryMock.Object);
            //Act
            var actual = generator.GenerateMaleTitle();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Name Generation")]
        public void GenerateSuffixTest()
        {
            //Arrange
            var expected = "MBA";
            var repositoryMock = new Mock<IHumanDataRepository>();
            repositoryMock.Setup(o => o.GetSuffixes()).Returns(new List<string>() { expected });

            var generator = new HumanDataGenerator(repositoryMock.Object);
            //Act
            var actual = generator.GenerateSuffix();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Name Generation")]
        public void GenerateSurnameTest()
        {
            //Arrange
            var expected = "Smith";
            var repositoryMock = new Mock<IHumanDataRepository>();
            repositoryMock.Setup(o => o.GetSurnames()).Returns(new List<string>() { expected });

            var generator = new HumanDataGenerator(repositoryMock.Object);
            //Act
            var actual = generator.GenerateSurname();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Name Generation")]
        public void GenerateFullFemaleNameTest()
        {
            //Arrange
            var expected = "Ms. Jane Jane Smith MBA";
            var repositoryMock = new Mock<IHumanDataRepository>();
            repositoryMock.Setup(o => o.GetFemaleNames()).Returns(new List<string>() { "Jane" });
            repositoryMock.Setup(o => o.GetFemaleTitles()).Returns(new List<string>() { "Ms." });
            repositoryMock.Setup(o => o.GetTitles()).Returns(new List<string>());
            repositoryMock.Setup(o => o.GetSurnames()).Returns(new List<string>() { "Smith" });
            repositoryMock.Setup(o => o.GetSuffixes()).Returns(new List<string>() { "MBA" });

            var generator = new HumanDataGenerator(repositoryMock.Object);
            //Act
            var actual = generator.GenerateFullName(Gender.Female);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Name Generation")]
        public void GenerateFullMaleNameTest()
        {
            //Arrange
            var expected = "Sir John John Smith MBA";
            var repositoryMock = new Mock<IHumanDataRepository>();
            repositoryMock.Setup(o => o.GetMaleNames()).Returns(new List<string>() { "John" });
            repositoryMock.Setup(o => o.GetMaleTitles()).Returns(new List<string>() { "Sir" });
            repositoryMock.Setup(o => o.GetTitles()).Returns(new List<string>());
            repositoryMock.Setup(o => o.GetSurnames()).Returns(new List<string>() { "Smith" });
            repositoryMock.Setup(o => o.GetSuffixes()).Returns(new List<string>() { "MBA" });

            var generator = new HumanDataGenerator(repositoryMock.Object);
            //Act
            var actual = generator.GenerateFullName(Gender.Male);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
