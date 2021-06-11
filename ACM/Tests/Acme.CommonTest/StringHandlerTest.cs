using Acme.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Acme.CommonTest
{
    [TestClass]
    public class StringHandlerTest
    {
        [TestMethod]
        public void InsertSpacesTestvalid()
        {
            //Arrange
            var source = "SonicScrewdriver";
            var expected = "Sonic Screwdriver";
            //Act
            var actual = StringHandler.InsertSpaces(source);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertSpacesTestWithExistingSpaces()
        {
            //Arrange
            var source = "Sonic Screwdriver";
            var expected = "Sonic Screwdriver";

            //Act
            var actual = StringHandler.InsertSpaces(source);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
