using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            var grades = new List<double>() {11.3, 12.3, 20.3, 100.00};
            grades.Add(13.44);


            var result = 0.0;
            var count = 0;

            foreach(var number in grades)
            {
                result += number;
                count += 1;
            }
            var average = result / grades.Count;

            System.Console.WriteLine($"The average is {average:N1}");
            System.Console.WriteLine(result);
            if (args.Length <0) 
            {
                Console.WriteLine($"Hello, {args[0]}!");
            }
            else
            {
                Console.WriteLine("Hello.");
            }
        }
    }
}
