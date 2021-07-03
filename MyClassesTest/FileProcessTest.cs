using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;
using System.IO;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest : TestBase
    {
        private const string BAD_FILE_NAME = @"C:\NotExists.bad";

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
        [TestInitialize]
        public void TestInitialize()
        {
            TestContext.WriteLine("In Test initialize method");
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

        [TestMethod]
        public void FileNameDoesExist()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            bool fromCall;

            //Act
            TestContext.WriteLine(@"Checking File: "+ _GoodFileName);

            fromCall = fp.FileExists(_GoodFileName);
            //Assert

            Assert.IsTrue(fromCall);
        }
        [TestMethod]
        public void FileNameDoesNotExist()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            bool fromCall;
            //Act
            TestContext.WriteLine("Checking File " + BAD_FILE_NAME);
            fromCall = fp.FileExists(BAD_FILE_NAME);
            //Assert
            Assert.IsFalse(fromCall);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameIsNullOrEmpty_UsingAttribute()
        {
            //arrange

            TestContext.WriteLine("Checking for a NULL file.");
            FileProcess fp = new FileProcess();
            //act assert
            fp.FileExists("");
        }
        [TestMethod]
        public void FileNameIsNullOrEmpty_UsingTryCatch()
        {
            //arrange
            FileProcess fp = new FileProcess();
            //act
            TestContext.WriteLine("Checking for a NULL file.");
            try
            {
                fp.FileExists("");
            }
            catch (ArgumentNullException)
            {
                // test was a success
                return;
            }
            //fail test
            Assert.Fail("Call to FileExists() did not throw an ArgumentNullException");
        }
    }
}
