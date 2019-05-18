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
            SimpleConverter simpleConverter = new SimpleConverter("MMdd", 4);
            string dtStr = simpleConverter.ConvertDate(new DateTime(2019, 5, 17));
            Assert.AreEqual(dtStr, "0517");
        }

        [TestMethod]
        public void TestNo340Converter1()
        {
            No340Converter converter = new No340Converter();
            string valueStr = converter.ConvertDate(new DateTime(2019, 5, 17));
            Assert.AreEqual(valueStr, "17-05-19");
        }

        [TestMethod]
        public void TestNo340Converter2()
        {
            No340Converter converter = new No340Converter();
            string valueStr = converter.ConvertSn(32543);
            Assert.AreEqual(valueStr, "0032543");
        }


    }
}
