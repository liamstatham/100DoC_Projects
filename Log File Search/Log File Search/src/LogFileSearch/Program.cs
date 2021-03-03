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

            var name = file.fhand(fname);
            if (name != fname)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine($"Would you like to add {fname} to a CSV file? Y or N");
                var input = Console.ReadLine();
                if (input.ToUpper() == "Y")
                {
                    file.AddToCsv();
                }
                else if (input.ToUpper() == "N")
                {
                    Console.WriteLine("Program ending.");
                }
                else
                {
                    Console.WriteLine($"{input} was invalid.");
                }
            }
            
        }
    }
}
