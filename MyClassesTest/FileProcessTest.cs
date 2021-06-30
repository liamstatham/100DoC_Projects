using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:\NotExists.bad";

        public TestContext TestContext { get; set; }
        [TestMethod]
        public void FileNameDoesExist()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            bool fromCall;
            //Act
            TestContext.WriteLine(@"Checking File C:/Windows/Regedit.exe ");

            fromCall = fp.FileExists(@"C:/Windows/Regedit.exe");
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
