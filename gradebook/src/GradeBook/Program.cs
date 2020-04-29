using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Scott's grade book");
            book.GradeAdded += OnGradeAdded;
            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book named \"{book.Name}\",");
            Console.WriteLine($"the average is {stats.Average:N1},");
            Console.WriteLine($"the highest is {stats.High:N1},");
            Console.WriteLine($"the lowest is {stats.Low:N1},");
            Console.WriteLine($"and the letter grade is {stats.Letter:N1}.");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Please enter a grade (from 0 to 100 or q to quit): ");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    double grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }

            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine($"A grade was added.");
        }
    }
}
