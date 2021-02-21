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
            Name = file;
            return Name;
        }
        public Array IntoLines()
        {
            //Name = name;
            Console.WriteLine($"Your file name is {Name}");
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(Name))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Splits the document into lines of text using the env NewLine 
                        Lines = line.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
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
        public void IntoWords()
        {
            Console.WriteLine(Lines);
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
        public List<string> List;
        public string[] Words;
        public string[] Lines;
        public string Name;
    }
}