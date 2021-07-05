using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessOtherTest : TestBase
    {
        #region Class initialize and clean up methods
        [ClassInitialize()]
        public static void ClassInitialize(TestContext tc)
        {
            //TODO initiaize for all tests in class
            tc.WriteLine("This is the class initialize method");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            //TODO: clean up after all tests in class
        }
        #endregion

        #region TestInitialize Method
        [TestInitialize]
        public void TestInitialize()
        {
            TestContext.WriteLine("In Test initialize method");

            WriteDescription(this.GetType());

            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                SetGoodFileName();
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine("Creating file: " + _GoodFileName);
                    File.AppendAllText(_GoodFileName, "Some text");
                }
            }
        }
        #endregion

        #region Test Cleanup method
        [TestCleanup]
        public void TestCleanup()
        {
            TestContext.WriteLine("In Test Cleanip method");
            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                if (File.Exists(_GoodFileName))
                {
                    TestContext.WriteLine("Deleting file: " + _GoodFileName);
                    File.Delete(_GoodFileName);
                }
            }
        }
        #endregion

        #region FileNameDoesExist simple message method
        [TestMethod]
        public void FileNameDoesExistSimpleMessage()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(_GoodFileName);

            Assert.IsFalse(fromCall,
                "File " + _GoodFileName + " Does not exist.");
        }

        #endregion

        #region AreEqualTest Method
        [TestMethod]
        public void AreEqualTest()
        {
            string str1 = "Liam";
            string str2 = "Liam";

            Assert.AreEqual(str2, str1);
        }
        #endregion

        #region AreEqualCaseTest Method
        [TestMethod]
        public void AreEqualCaseTest()
        {
            string str1 = "Liam";
            string str2 = "liam";

            Assert.AreEqual(str1, str2, true);
        }
        #endregion

        #region AreNotEqualTest Method
        [TestMethod]
        public void AreNotEqualTest()
        {
            string str1 = "Liam";
            string str2 = "James";

            Assert.AreNotEqual(str1, str2);
        }
        #endregion

        #region AreSameObject method
        [TestMethod]
        public void AreSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = x;

            Assert.AreSame(x, y);
        }
        #endregion

        #region AreNotSameObject method
        [TestMethod]
        public void AreNotSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();

            Assert.AreSame(x, y);
        }
        #endregion

    }
}
