using System;
using System.Collections.Generic;
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
                Name = name;
                return Name;
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
        public void CreateCSV(string Name)
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
                    }
                    // need to write file headings
                    using (FileStream fs = new FileStream(DataFile, FileMode.Append, FileAccess.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            var headings = "Created" + "," + "Method" + "," + "UriStem" + "," + "UriQuery" + "," + "IP" + "," + "UserAgent" + "," + "URL";
                            sw.WriteLine(headings);
                        }
                    }

                }
                else
                {
                    Console.WriteLine($"File {CsvName}.csv already exits.");
                }

            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine($"The file name was missing a . {Name}");
                Console.WriteLine(e.Message);
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
            var userAgent = linesp[9];
            var url = linesp[10];

            var lineToWrite = bigdate + "," + method + "," + uriStem + "," + uriQuery + "," + ip + "," + userAgent + "," + url;

            using (FileStream fs = new FileStream(DataFile, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(lineToWrite);
                }
            }
        }


        // public List<string> List;
        //public string[] Words;
        public string[] Lines;
        public string Name;
        public string FileH;
        public string CsvName;
    }
}