using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Scott's grade book");

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

            var stats = book.GetStatistics();

            Console.WriteLine($"The average for {book.Name} is {stats.Average:N1}.");
            Console.WriteLine($"The highest for {book.Name} is {stats.High:N1}.");
            Console.WriteLine($"The lowest for {book.Name} is {stats.Low:N1}.");
            Console.WriteLine($"The letter grade for {book.Name} is {stats.Letter:N1}.");
        }
    }
}
