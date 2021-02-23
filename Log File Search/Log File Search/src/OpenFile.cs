using System;
using System.Collections.Generic;
using System.IO;

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
            File = file;
            Name = name;
            return Name;
        }
        public Array IntoLines()
        {
            //Name = name;
            Console.WriteLine($"Your file name is {File}");
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(File))
                {
                    // new instance of a datatable -- to do
                    DataTable(Name);
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Splits the document into words
                        var linesp = line.Split(' ');
                        // passes words from line into method, per line
                        IntoDataTable(linesp);

                    }
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
        public void IntoDataTable(string[] linesp)
        {
            // need to write a method to put words from line into data table
            var bigdate = linesp[0] + ' ' + linesp[1];

            Console.WriteLine(bigdate + ' ' + linesp[3] + ' ' + linesp[4] + ' ' + linesp[5] + ' ' + linesp[8] + ' ' + linesp[9] + ' ' + linesp[10]);
            //var i = 0;
            //var x = Lines.Length;

            //while (i <= x)
            ////{
            ////    Words = Lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            ////    i += 1;
            ////    Console.WriteLine($"{i} : {Words}");
            ////    continue;
            ////}
            //{
            //    List.Add(Lines[i]);
            //    i += 1;
            //    //Console.WriteLine($"{i} : {Words}");
            //}

            // return Words;
        }

        public void DataTable(string Name)
        {
            // need to create a data table
            // splitting on the . removes the dot, so use the sub 0 [0]
            // Try splitting the name
            try
            {
                string[] splitname = Name.Split('.');
                var datatablename = splitname[0];
                Console.WriteLine($"The data table name is: {datatablename}");
                DataTableName = datatablename;
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine($"The file name was missing a . {Name}");
                Console.WriteLine(e.Message);
            }
        }
       // public List<string> List;
        //public string[] Words;
        public string[] Lines;
        public string Name;
        public string File;
        public string DataTableName;
    }
}