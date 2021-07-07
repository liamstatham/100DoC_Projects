using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MyClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessDataDriven : TestBase
    {

        [TestMethod()]
        public void FileExistsTestFromDB()
        {
            FileProcess fp = new FileProcess();
            bool fromCall = false;
            bool testFailed = false;
            string fileName;
            bool expectedValue;
            bool causesException;
            string sql = "SELECT * FROM Tests.FileProcessTest";
            string conn = TestContext.Properties["ConnectionString"].ToString();

            //Load data from SQL server
            LoadDataTable(sql, conn);

            if (TestDataTable != null)
            {
                //Loop through all rows in table
                foreach (DataRow row in TestDataTable.Rows)
                {
                    fileName = row["FileName"].ToString();
                    expectedValue = Convert.ToBoolean(row["ExpectedValue"]);
                    causesException = Convert.ToBoolean(row["CausesException"]);

                    try
                    {
                        // see if file exists
                        fromCall = fp.FileExists(fileName);
                    }
                    catch (ArgumentNullException)
                    {
                        // see if a null value was expected
                        if (!causesException)
                        {
                            testFailed = true;
                        }
                    }
                    catch (Exception)
                    {
                        testFailed = true;
                    }

                    TestContext.WriteLine("Testing File: '{0}', Expected Value: '{1}', Actual Value: '{2}', Result: '{3}'", fileName, expectedValue, fromCall, (expectedValue == fromCall ? "Success" : "Failed"));

                    //Check assertion
                    if (expectedValue != fromCall)
                    {
                        testFailed = true;
                    }
                }
                if (testFailed)
                {
                    Assert.Fail("Data driven tests have failed, Check additonal output for details.");
                }
            }

        }
    }
}
