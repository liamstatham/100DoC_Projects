using System;
using Xunit;
using Log_File_Search;

namespace LogFileSearchTesting
{
    public class UnitTest1
    {
        [Fact]
        public void CheckIfFileExists()
        {
            var file = "5k.txt";
            var log = new OpenFile();

            var result = log.fhand(file);

            Assert.Equal(file, result);
        }

        [Fact]
        public void CheckFileDoesntExist()
        {
            var file = "100.txt";
            var log = new OpenFile();

            var result = log.fhand(file);

            Assert.Equal("false", result);

        }
    }
}
