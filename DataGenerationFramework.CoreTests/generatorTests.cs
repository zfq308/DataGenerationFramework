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
    public class generatorTests
    {
        [TestMethod()]
        public void generatorTest()
        {
            var gen = new generator(0); //use a specific number to have optionally have repeatable results

            //for (int i = 0; i < 1000; i++)
            //{
            //    var newperson = new DataModels.Person()
            //    {
            //        FirstName = gen.firstName(),
            //        LastName = gen.surName(),
            //        Gender = gen.random("M", "F"),
            //        Age = gen.integer(10, 100)
            //    };
            //}
        }

     
    }
}