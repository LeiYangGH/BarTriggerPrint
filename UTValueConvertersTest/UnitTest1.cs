using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UTValueConvertersTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(3 * 3, 9);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(3 + 3, 6);
        }
    }
}
