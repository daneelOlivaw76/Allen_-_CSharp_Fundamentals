using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Scott's grade book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);

            var stats = book.GetStatistics();

            Console.WriteLine($"The average for {book.name} is {stats.Average:N1}.");
            Console.WriteLine($"The highest for {book.name} is {stats.High:N1}.");
            Console.WriteLine($"The lowest for {book.name} is {stats.Low:N1}.");
        }
    }
}
