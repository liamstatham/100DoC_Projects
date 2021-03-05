using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Log_File_Search
{
    public class OpenFile
    {
        public string fhand(string name)
        {
            string dir = Directory.GetCurrentDirectory();
            Console.WriteLine(dir);
            string dir1 = @"C:\Users\Liam_Statham\github\100DoC_Projects\Log File Search\Log File Search\";
            string file = dir1 + name;
            FileH = file;
            var result = File.Exists(FileH);
            if(result == true)
            {
                var extension = Path.GetExtension(FileH);
                if(extension == ".txt")
                {
                    Name = name;
                    return Name;
                }
                else
                {
                    Console.WriteLine($"File: {name} is not a .txt file.");
                    Name = "Wrong file type";
                    return Name;
                }
            }
            else
            {
                Console.WriteLine($"File: {name} does not exist in this directory.");
                Name = "false";
                return Name;
            }
        }
        public Array AddToCsv()
        {
            //Name = name;
            Console.WriteLine($"Your file name is {FileH}");
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(FileH))
                {
                    // new instance of a datatable -- to do
                    CreateCSV(Name);
                    Console.WriteLine($"Lines are being appended to {CsvName}.csv.");
                    CSVHeadings(CsvName);
                    string line;
                    var count = 0;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {

                        // Splits the document into words
                        var linesp = line.Split(' ');
                        // Checks to see if the first character is a number (only releavant lines start with a date)
                        char stringFirstChar = linesp[0].ToCharArray().ElementAt(0);
                        Boolean result = char.IsNumber(stringFirstChar);
                        if (result == true)
                        {
                            // passes words from line into method, per line
                            IntoCSV(linesp);
                            count += 1;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    Console.WriteLine($"{count} lines have been added to csv {CsvName}.csv.");
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            
            return Lines;
        }
        public string CreateCSV(string Name)
        {
            // need to create a data table
            // splitting on the . removes the dot, so use the sub 0 [0]
            // Try splitting the name
            try
            {
                string[] splitname = Name.Split('.');
                var csvName = splitname[0];
                Console.WriteLine($"The data table name is: {csvName}");
                CsvName = csvName;
                var DataFile = CsvName + ".csv";
                if (File.Exists($"{CsvName}.csv") != true)
                {
                    using (var writer = File.OpenWrite($"{CsvName}.csv"))
                    {
                        Console.WriteLine($"File {CsvName}.csv has been created.");
                        return "Created";
                    }
                }
                else
                {
                    Console.WriteLine($"File {CsvName}.csv already exits.");
                    return "Exists";
                }

            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine($"The file name was missing a . {Name}");
                Console.WriteLine(e.Message);
                return Name;
            }
        }

        public string CSVHeadings(string csvName)
        {
            try
            {
                var DataFile = csvName + ".csv";
                // need to write file headings
                using (FileStream fs = new FileStream(DataFile, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        var headings = "Created" + "," + "Method" + "," + "UriStem" + "," + "UriQuery" + "," + "IP" + "," + "User" + "," + "URL";
                        sw.WriteLine(headings);
                        return "Headings";
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine($"The headings could not be writted to {CsvName}.csv");
                Console.WriteLine(e.Message);
                return "Failed";
            }
        }

        public void IntoCSV(string[] linesp)
        {
            var DataFile = CsvName + ".csv";
            // need to write a method to put words from line into data table
            // split linesp into human readable vars
            var bigdate = linesp[0] + ' ' + linesp[1];
            var method = linesp[3];
            var uriStem = linesp[4];
            var uriQuery = linesp[5];
            var ip = linesp[8];
            var user = linesp[7];
            var url = linesp[10];

            var lineToWrite = bigdate + "," + method + "," + uriStem + "," + uriQuery + "," + ip + "," + user + "," + url;

            using (FileStream fs = new FileStream(DataFile, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(lineToWrite);
                }
            }
        }

        public void CreateDataTable()
        {
            try
            {
                var logFileDT = new MemoryData();
                logFileDT.CreateTable();
                Console.WriteLine($"Data table {logFileDT} has been created.");
                //LogFileDT = logFileDT;
                //return logFileDT;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // breaking after data table created. need to step through.
        public void AddToDataTable()
        {
            //Name = name;
            Console.WriteLine($"Your file name is {FileH}");
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(FileH))
                {
                    // new instance of a datatable -- to do
                    CreateDataTable();
                    
                    //Console.WriteLine($"Lines are being appended to {CsvName}.csv.");
                    //CSVHeadings(CsvName);
                    string line;
                    var count = 0;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {

                        // Splits the document into words
                        var linesp = line.Split(' ');
                        // Checks to see if the first character is a number (only releavant lines start with a date)
                        char stringFirstChar = linesp[0].ToCharArray().ElementAt(0);
                        Boolean result = char.IsNumber(stringFirstChar);
                        if (result == true)
                        {
                            // passes words from line into method, per line
                            //DataTable table = LogFileDT;
                            // need to 
                            MemoryData.InsertLogs(LogFileDT, linesp);
                            count += 1;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    Console.WriteLine($"{count} lines have been added to csv {CsvName}.csv.");
                    MemoryData.ShowTable(LogFileDT);
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public void ShowDataTable(DataTable logTable)
        {
            MemoryData.ShowTable(logTable);
        }

        // public List<string> List;
        //public string[] Words;
        //public DataTable LogFileDT;
        public DataTable LogFileDT;
        public string[] Lines;
        public string Name;
        public string FileH;
        public string CsvName;
    }
}