using System;

namespace Log_File_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Please type the log file name:");
            var fname = Console.ReadLine();
            var file = new OpenFile();

            file.fhand(fname);
            file.IntoLines();
            //file.IntoWords();
        }
    }
}
