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
                    // add functionality for adding to database
                    Console.WriteLine($"Would you like to add {fname} to a datatable? Y or N");
                    var inputN = Console.ReadLine();
                    if (inputN.ToUpper() == "Y")
                    {
                        Console.WriteLine("Adding to datatable...");
                        file.AddToDataTable();

                        // Functionality to filter datatable
                        Console.WriteLine($"Would you like to filter to the Datatable? Y or N");
                        Console.WriteLine("If N, DataTable will be written to CSV.");
                        var input2 = Console.ReadLine();
                        if (input2.ToUpper() == "Y")
                        {
                            Console.WriteLine("How would you like to filter: Type 1 for User or 2 for URL");
                            Console.WriteLine("You can filter a name using a full or part of a SynergyTrak Username");
                            Console.WriteLine("You can filter the URL for full or part Instance or Container Master ID's. (Internal ID only)"); 
                            var selector = Console.ReadLine();
                            if(selector == "1" || selector == "2")
                            {
                                Console.WriteLine($"Option: {selector} selected.");
                                Console.WriteLine("Enter your search term, do not use spaces as they are trimmed.");
                                var search = Console.ReadLine();

                                Console.WriteLine($"Attempting to filter by: {search}...");
                                file.SearchTerm(selector, search);

                            }
                            else
                            {
                                Console.WriteLine($"{selector} was invalid.");
                                Environment.Exit(0);
                            }
                        }
                        else if (input.ToUpper() == "N")
                        {
                            file.AddToCsv();
                        }
                        else
                        {
                            Console.WriteLine($"{input2} was invalid.");
                            Environment.Exit(0);
                        }
                    }
                    else if (input.ToUpper() == "N")
                    {
                        Console.WriteLine("Program ending.");
                    }
                    else
                    {
                        Console.WriteLine($"{inputN} was invalid.");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.WriteLine($"{input} was invalid.");
                    Environment.Exit(0);
                }
            }
            
        }
    }
}
