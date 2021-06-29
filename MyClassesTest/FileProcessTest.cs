using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        [TestMethod]
        public void FileNameDoesExist()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            bool fromCall;
            //Act
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
            fromCall = fp.FileExists(@"C:/Windows/Bogusfile.exe");
            //Assert
            Assert.IsFalse(fromCall);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameIsNullOrEmpty_UsingAttribute()
        {
            //arrange
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
