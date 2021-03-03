using System;
using Xunit;
using Log_File_Search;
using System.IO;

namespace LogFileSearchTesting
{
    public class LogFileSearchTests
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
        [Fact]
        public void CheckIncorrectFileType()
        {
            var file = "test.csv";
            var log = new OpenFile();

            var result = log.fhand(file);

            Assert.Equal("Wrong file type", result);
        }
        [Fact]
        public void CheckCSVisCreated()
        {
            var file = "5k.txt";
            var log = new OpenFile();

            var result = log.CreateCSV(file);

            Assert.Equal("Created", result);
            DeleteCreatedCSV(file);
        }
        [Fact]
        public void CheckCSValreadyExists()
        {
            var file = "test.txt";
            var log = new OpenFile();

            var result = log.CreateCSV(file);

            Assert.Equal("Exists", result);
            //File exists in
            //C:\Users\Liam_Statham\github\100DoC_Projects\Log File Search\LogFileSearchTesting\bin\Debug\netcoreapp3.1
        }

        [Fact]
        public void CheckHeadingsAreAddedToCSV()
        {
            var filecsv = "5k.csv";
            var log = new OpenFile();  
            var result = log.CSVHeadings(filecsv);

            Assert.Equal("Headings", result);
            DeleteCreatedCSV(filecsv);
        }

        public void DeleteCreatedCSV(string file)
        {
            // should add a try catch here.
            string[] splitname = file.Split('.');
            var csvName = splitname[0];
            var filename = $"{csvName}.csv";
            File.Delete(filename);
            //Deletes file in
            //C:\Users\Liam_Statham\github\100DoC_Projects\Log File Search\LogFileSearchTesting\bin\Debug\netcoreapp3.1
            //test
        }
    }
}
