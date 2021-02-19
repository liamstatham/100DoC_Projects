using System;

namespace logfile
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Please type the log file name:");
            var fname = Console.ReadLine();

            var fhand = new OpenFile(fname);
        }
    }

    
}
