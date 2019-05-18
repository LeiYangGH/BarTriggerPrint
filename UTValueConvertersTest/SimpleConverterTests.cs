using BarTriggerPrint.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTValueConvertersTest
{
    [TestClass]

    public class SimpleConverterTests
    {

        [TestMethod]
        public void TestSimpleConverter()
        {
            SimpleConverter simpleConverter = new SimpleConverter();
            string dtStr = simpleConverter.ConvertDate(new DateTime(2019, 5, 17));
            Assert.AreEqual(dtStr, "0517");
        }

       
    }
}
