using System.Collections.Generic;
using System;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade.ToString());
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            string line;

            using (var file = new StreamReader($"{Name}.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    double grade = double.Parse(line);
                    result.Add(grade);
                }
            }

            return result;
        }
    }

    public class InMemoryBook : Book
    {
        private List<double> grades { get; set; }

        public InMemoryBook(string name) : base(name)
        {
            this.grades = new List<double>();
            //this.Name = name;
        }

        // public void AddGrade(char letter)
        // {
        //     switch (letter)
        //     {
        //         case 'A':
        //             AddGrade(90);
        //             break;
        //         case 'B':
        //             AddGrade(80);
        //             break;
        //         case 'C':
        //             AddGrade(70);
        //             break;
        //         case 'D':
        //             AddGrade(60);
        //             break;
        //         case 'F':
        //         default:
        //             AddGrade(0);
        //             break;
        //     }
        // }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                this.grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}! Only values between 0.0 and 100.0 are accepted.");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            for (var index = 0; index < grades.Count; index++)
            {
                result.Add(grades[index]);
            }

            return result;
        }
    }
}