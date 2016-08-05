using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataGenerationFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DataGenerationFramework.Core.Tests
{


    public class foo
    {
        public string A { get; set; }
        public string B { get; set; }
    }
    [TestClass()]
    public class RandomHelperTests
    {
        [TestMethod()]
        public void GetListElementTest()
        {
            List<foo> list = new List<foo>();

            for (int i = 0; i < 1000; i++)
            {
                list.Add(new foo() { A = i.ToString(), B = (i + 200).ToString() });
            }

            for (int i = 0; i < 100; i++)
            {
               var item= RandomHelper.GetListElement<foo>(list);
                Debug.WriteLine(item.A + "  " + item.B);
            }
           
        }
    }
}