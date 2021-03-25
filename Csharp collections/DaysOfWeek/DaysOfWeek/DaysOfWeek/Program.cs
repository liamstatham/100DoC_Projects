using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaysOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek =
            {
                "Monday",
                "Tuesday",
                "Wedsday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            foreach (string day in daysOfWeek )
            {
                Console.WriteLine(day);
            }

            daysOfWeek[2] = "Wednesday";

            foreach (string day in daysOfWeek)
            {
                Console.WriteLine(day);
            }
        }
    }
}
