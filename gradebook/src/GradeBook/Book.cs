using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        List<double> _grades { get; set; }

        public Book()
        {
            _grades = new List<double>();
        }

        public Book(List<double> grades)
        {
            _grades = grades;
        }
        public void AddGrade(double grade)
        {
            _grades.Add(grade);
        }
    }
}