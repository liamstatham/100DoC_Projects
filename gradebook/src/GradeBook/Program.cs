using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Liam's GradeBook");
            book.GradeAdded += OnGradeAdded;

            var done = false;

            while (!done)
            {
                System.Console.WriteLine("Please enter a grade or 'q' to quit.");
                var input = Console.ReadLine();

                if(input =="q")
                {
                    done = true;
                    continue;
                }
                try
                {
                var grade = double.Parse(input);
                book.AddGrade(grade);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }

            var stats = book.GetStatistics();
            System.Console.WriteLine($"The highest grade is {stats.High}");
            System.Console.WriteLine($"The average is {stats.Average:N1}");
            System.Console.WriteLine($"The lowest grade is {stats.Low}");
            System.Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }

    }



}