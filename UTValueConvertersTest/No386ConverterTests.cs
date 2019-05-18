using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BarTriggerPrint.Model;

namespace UTValueConvertersTest
{
    /// <summary>
    /// No386ConverterTests 的摘要说明
    /// </summary>
    [TestClass]
    public class No386ConverterTests
    {
        private No386Converter convert = new No386Converter();

        public No386ConverterTests()
        {
            //
            //TODO:  在此处添加构造函数逻辑
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性: 
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestConvertYear1()
        {
            Assert.AreEqual("H", convert.GetYearCharString(2017));
        }

        [TestMethod]
        public void TestConvertYear2()
        {
            Assert.AreEqual("R", convert.GetYearCharString(2024));
        }

        [TestMethod]
        public void TestConvertYear3()
        {
            Assert.AreEqual("W", convert.GetYearCharString(2028));
        }

        

        [TestMethod]
        public void TestConvertMonth1()
        {
            Assert.AreEqual("1", convert.GetMonthCharString(1));
        }

        [TestMethod]
        public void TestConvertMonth2()
        {
            Assert.AreEqual("5", convert.GetMonthCharString(5));
        }

        [TestMethod]
        public void TestConvertMonth3()
        {
            Assert.AreEqual("9", convert.GetMonthCharString(9));
        }

        [TestMethod]
        public void TestConvertMonth4()
        {
            Assert.AreEqual("0", convert.GetMonthCharString(10));
        }

        [TestMethod]
        public void TestConvertMonth5()
        {
            Assert.AreEqual("A", convert.GetMonthCharString(11));
        }
        [TestMethod]
        public void TestConvertMonth6()
        {
            Assert.AreEqual("B", convert.GetMonthCharString(12));
        }

        [TestMethod]
        public void TestConvertDay1()
        {
            Assert.AreEqual("01", convert.GetDayCharString(1));
        }
        [TestMethod]
        public void TestConvertDay2()
        {
            Assert.AreEqual("10", convert.GetDayCharString(10));
        }
        [TestMethod]
        public void TestConvertDay3()
        {
            Assert.AreEqual("31", convert.GetDayCharString(31));
        }
       


        [TestMethod]
        public void TestConvertDateTime1()
        {
            DateTime dt = new DateTime(2019, 5, 18);
            Assert.AreEqual("K518", convert.ConvertDate(dt));
        }

        [TestMethod]
        public void TestConvertDateTime2()
        {
            DateTime dt = new DateTime(2017, 11, 13);
            Assert.AreEqual("HA13", convert.ConvertDate(dt));
        }

        [TestMethod]
        public void TestConvertSn1()
        {
            Assert.AreEqual("00001", convert.ConvertSn(1));
        }
        [TestMethod]
        public void TestConvertSn2()
        {
            Assert.AreEqual("00009", convert.ConvertSn(9));
        }
        [TestMethod]
        public void TestConvertSn3()
        {
            Assert.AreEqual("00099", convert.ConvertSn(99));
        }
        [TestMethod]
        public void TestConvertSn4()
        {
            Assert.AreEqual("09999", convert.ConvertSn(9999));
        }
    }
}
