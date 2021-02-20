using System;
using System.Collections.Generic;
using System.IO;

namespace logfile
{
    public class OpenFile
    {
        public string fhand(string name)
        {
            Name = name;
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
        public Array IntoWords()
        {
            foreach (string item in Lines)
            {
                var i = 0;
                var x = Lines.Length;
                while (i <= x)
                {
                    Words = Lines[i].Split(" ");
                    i += 1;
                    Console.WriteLine($"{i} : {Words}");
                    continue;
                }            
            }
            return Words;
        }
        public string[] Words;
        public string[] Lines;
        public string Name;
    }
}