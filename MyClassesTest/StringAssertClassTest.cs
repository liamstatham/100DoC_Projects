using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class StringAssertClassTest : TestBase
    {
        [TestMethod]
        public void ContainsTest()
        {
            string str1 = "Liam Statham";
            string str2 = "Statham";

            StringAssert.Contains(str1, str2);

        }

        [TestMethod]
        public void StartsWith()
        {
            string str1 = "This starts with";
            string str2 = "This doesn't";

            StringAssert.StartsWith(str1, str2);
        }

        [TestMethod]
        public void IsAllLowerCase()
        {
            Regex r = new Regex(@"^([^A-Z])+$");

            StringAssert.Matches("all lower case", r);
        }

        [TestMethod]
        public void IsNotAllLowerCase()
        {
            Regex r = new Regex(@"^([^A-Z])+$");

            StringAssert.DoesNotMatch("All Lower Case", r);
        }
    }
}
