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

       
        [TestMethod]
        public void FileNameDoesExist()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            bool fromCall;

            SetGoodFileName();

            if (!string.IsNullOrEmpty(_GoodFileName))
            {
                //Create file
                File.AppendAllText(_GoodFileName, "Some Text");
            }
            //Act
            TestContext.WriteLine(@"Checking File: "+ _GoodFileName);

            fromCall = fp.FileExists(_GoodFileName);
            //Assert

            //Delete file
            if (File.Exists(_GoodFileName))
            {
                File.Delete(_GoodFileName);
            }
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
