using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            var numbers = new double[3];
            numbers[0] = 11.3;
            numbers[1] = 12.3;
            numbers[2] = 20.3;

            var result = numbers[0] + numbers[1] + numbers[2];
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
