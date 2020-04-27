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

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            foreach (double grade in grades)
            {
                result.Average += grade;
                result.High = Math.Max(result.High, grade);
                result.Low = Math.Min(result.Low, grade);
            }
            result.Average /= grades.Count;
            return result;
        }
    }
}