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

        #region FileNameDoesExist Method
        [TestMethod]
        [Description("Check to see if file exists.")]
        [Owner("Liam S")]
        [Priority(1)]
        [TestCategory("No Exception")]
        //[Ignore]
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
        #endregion

        #region FileNameDoesNotExist Method
        [TestMethod]
        [Description("Check to see if file does not exist.")]
        [Owner("Liam S")]
        [TestCategory("No Exception")]
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
        #endregion

        #region FileNameIsNullOrEmpty ExpectedException Method
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Check for a thrown ArgumentNullException using ExpectedException.")]
        [Owner("Liam S")]
        [TestCategory("Exception")]
        public void FileNameIsNullOrEmpty_UsingAttribute()
        {
            //arrange

            TestContext.WriteLine("Checking for a NULL file.");
            FileProcess fp = new FileProcess();
            //act assert
            fp.FileExists("");
        }
        #endregion

        #region FileNameIsNullOrEmpty TryCatch Method
        [TestMethod]
        [Description("Check for a thrown ArgumentNullException using Try catch.")]
        [Owner("Liam S")]
        [TestCategory("Exception")]
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
        #endregion

        #region TimeOutTest Method
        [TestMethod]
        [Timeout(3000)]
        public void SimulateTimeout()
        {
            System.Threading.Thread.Sleep(4000);
        }
        #endregion

        #region AreNumbersEqual Method
        [TestMethod]
        [DataRow(1,1, DisplayName ="First Test (1,1")]
        [DataRow(42,42,DisplayName ="Second Test (42,42)")]
        public void AreNumbersEqual(int num1, int num2)
        {
            Assert.AreEqual(num1, num2);
        }
        #endregion

        #region FileNameUsingDataRow Method
        [TestMethod]
        [DeploymentItem("FileToDeploy.txt")]
        [DataRow(@"C:\Windows\Regedit.exe", DisplayName ="Regedit.exe")]
        [DataRow("FileToDeploy.txt", DisplayName = "Deployment Item: FileToDeploy.txt")]
        public void FileNameUsingDataRow(string fileName)
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            if (!fileName.Contains(@"\"))
            {
                fileName = TestContext.DeploymentDirectory + @"\" + fileName;
            }
            TestContext.WriteLine("Checking file " + fileName);
            fromCall = fp.FileExists(fileName);
            Assert.IsTrue(fromCall);
        }
        #endregion
    }
}
