using System.Collections.Generic;
using System;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades { get; set; }
        public string name { get; set; }

        public Book()
        {
            this.grades = new List<double>();
        }

        public Book(string name)
        {
            this.grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            this.grades.Add(grade);
        }

        public void ShowStats()
        {
            var result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;
            foreach (double number in grades)
            {
                result += number;
                highGrade = Math.Max(highGrade, number);
                lowGrade = Math.Min(lowGrade, number);
            }
            result /= grades.Count;
            Console.WriteLine($"The average for {this.name} is {result:N1}.");
            Console.WriteLine($"The highest for {this.name} is {highGrade:N1}.");
            Console.WriteLine($"The lowest for {this.name} is {lowGrade:N1}.");
        }
    }
}