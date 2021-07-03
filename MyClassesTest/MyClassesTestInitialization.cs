using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesTest
{
    [TestClass]
    public class MyClassesTestInitialization
    {
        [AssemblyInitialize()]
        public static void AssemblyInitialize(TestContext tc)
        {
            // TODO: Initialize for all tsts
            tc.WriteLine("In AssemblyInitialize() method");
        }

        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {
            //TODO: Clean up after all tests
        }
    }
}
