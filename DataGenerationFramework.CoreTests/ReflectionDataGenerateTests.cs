using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataGenerationFramework.Core.Tests
{
    public class testclass
    {
        public int Bla { get; set; }
        public int Id { get; set; }
        public String Name { get; set; }
        public string CompanyName { get; set; }

        public bool TestFlag { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateOnly { get; set; }

    }

    [TestClass()]
    public class ReflectionDataGenerateTests
    {
        [TestMethod()]
        public void ForClassTest()
        {
            ReflectionDataGenerate.ForClass<testclass>().Property(f => f.TestFlag);
            ReflectionDataGenerate.ForClass<testclass>().Property(f => f.Bla).IsUnique(false).UseMin(12).UseMax(123333);
            ReflectionDataGenerate.ForClass<testclass>().Property(f => f.Id).IsUnique(true).UseMin(12).UseMax(550);
            ReflectionDataGenerate.ForClass<testclass>().Property(f => f.CompanyName).SetStringTypeEnum(EnumStringType.Business_ChineseCompanyName);
            ReflectionDataGenerate.ForClass<testclass>().Property(f => f.Name).SetStringTypeEnum(EnumStringType.RandomChineseString,23,100);
            ReflectionDataGenerate.ForClass<testclass>().Property(f => f.Date).Range(DateTime.Now.AddDays(-100), DateTime.Now.AddDays(150));
            ReflectionDataGenerate.ForClass<testclass>().Property(f => f.DateOnly).Range(DateTime.Now.AddDays(-100), DateTime.Now.AddDays(150)).DateOnly(true);

            var items = ReflectionDataGenerate.Items<testclass>(500);
        }
    }
}