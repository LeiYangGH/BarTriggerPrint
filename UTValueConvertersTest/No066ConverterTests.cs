using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BarTriggerPrint.Model;

namespace UTValueConvertersTest
{
    /// <summary>
    /// No066ConverterTests 的摘要说明
    /// </summary>
    [TestClass]
    public class No066ConverterTests
    {
        private No066Converter convert = new No066Converter();
        public No066ConverterTests()
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
            Assert.AreEqual("4", convert.GetYearCharString(2014));
        }

        [TestMethod]
        public void TestConvertYear2()
        {
            Assert.AreEqual("9", convert.GetYearCharString(2019));
        }

        [TestMethod]
        public void TestConvertYear3()
        {
            Assert.AreEqual("A", convert.GetYearCharString(2020));
        }

        [TestMethod]
        public void TestConvertYear4()
        {
            Assert.AreEqual("E", convert.GetYearCharString(2024));
        }

        [TestMethod]
        public void TestConvertYear5()
        {
            Assert.AreEqual("H", convert.GetYearCharString(2027));
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
            Assert.AreEqual("A", convert.GetMonthCharString(10));
        }

        [TestMethod]
        public void TestConvertMonth5()
        {
            Assert.AreEqual("C", convert.GetMonthCharString(12));
        }


        [TestMethod]
        public void TestConvertDay1()
        {
            Assert.AreEqual("1", convert.GetDayCharString(1));
        }
        [TestMethod]
        public void TestConvertDay2()
        {
            Assert.AreEqual("6", convert.GetDayCharString(6));
        }
        [TestMethod]
        public void TestConvertDay3()
        {
            Assert.AreEqual("9", convert.GetDayCharString(9));
        }
        [TestMethod]
        public void TestConvertDay4()
        {
            Assert.AreEqual("0", convert.GetDayCharString(10));
        }
        [TestMethod]
        public void TestConvertDay5()
        {
            Assert.AreEqual("A", convert.GetDayCharString(11));
        }
        [TestMethod]
        public void TestConvertDay6()
        {
            Assert.AreEqual("P", convert.GetDayCharString(26));
        }
        [TestMethod]
        public void TestConvertDay7()
        {
            Assert.AreEqual("U", convert.GetDayCharString(31));
        }


        [TestMethod]
        public void TestConvertDateTime1()
        {
            DateTime dt = new DateTime(2019, 5, 18);
            Assert.AreEqual("95H", convert.ConvertToValue<DateTime>(dt));
        }

        [TestMethod]
        public void TestConvertDateTime2()
        {
            DateTime dt = new DateTime(2017, 11, 13);
            Assert.AreEqual("7BC", convert.ConvertToValue<DateTime>(dt));
        }

        [TestMethod]
        public void TestConvertSn1()
        {
            Assert.AreEqual("001", convert.ConvertToValue<int>(1));
        }
        [TestMethod]
        public void TestConvertSn2()
        {
            Assert.AreEqual("009", convert.ConvertToValue<int>(9));
        }
        [TestMethod]
        public void TestConvertSn3()
        {
            Assert.AreEqual("099", convert.ConvertToValue<int>(99));
        }
        [TestMethod]
        public void TestConvertSn4()
        {
            Assert.AreEqual("999", convert.ConvertToValue<int>(999));
        }
    }
}
