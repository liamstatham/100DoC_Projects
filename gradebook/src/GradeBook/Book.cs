using System;
using System.Collections.Generic;

namespace GradeBook
{
       public class Book
    {
            public Book(string name)
            {
                grades = new List<double>();
                Name = name;
            }
            public void AddGrade(double grade)
            {
                if(grade <= 100 && grade >= 0)
                {
                    grades.Add(grade);
                }
                else
                {
                    System.Console.WriteLine("Invalid value");
                }
                
            }

            public Statistics GetStatistics()
            {
                var result = new Statistics();
                result.Average = 0.0;
                result.High = double.MinValue;
                result.Low = double.MaxValue;

               
                for(var index = 0; index < grades.Count; index += 1)
                    {
                        result.High = Math.Max(grades[index], result.High);
                        result.Low = Math.Min(grades[index], result.Low);
                        result.Average += grades[index];
                    } 
                result.Average /= grades.Count;

                return result;
            }

            private List<double> grades;
            public string Name;
    }
}