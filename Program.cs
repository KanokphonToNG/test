using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentGradeSystem
{
    // 🔹 Abstract Class (Abstraction)
    abstract class Person
    {
        public string Name { get; set; }
        public abstract void ShowInfo();
    }

    // 🔹 Student (Inheritance + Polymorphism)
    class Student : Person
    {
        public string StudentID { get; set; }
        public double Score { get; set; }
        public string Grade { get; set; }

        public Student(string id, string name, double score)
        {
            StudentID = id;
            Name = name;
            Score = score;
            Grade = GradeCalculator.CalculateGrade(score);
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"{StudentID} - {Name} | Score: {Score} | Grade: {Grade}");
        }
    }

    // 🔹 Subject Class
    class Subject
    {
        public string SubjectID { get; set; }
        public string SubjectName { get; set; }
        public List<Student> Students { get; set; }

        public Subject(string id, string name)
        {
            SubjectID = id;
            SubjectName = name;
            Students = new List<Student>();
        }

        public void AddStudent(Student s)
        {
            Students.Add(s);
        }

        public void ShowAllStudents()
        {
            Console.WriteLine($"\n📘 Subject: {SubjectName}");
            foreach (var s in Students)
            {
                s.ShowInfo();
            }
        }

        public void ShowStats()
        {
            if (Students.Count == 0) return;

            double max = Students.Max(s => s.Score);
            double min = Students.Min(s => s.Score);
            double avg = Students.Average(s => s.Score);

            Console.WriteLine("\n📊 Statistics");
            Console.WriteLine($"Max Score: {max}");
            Console.WriteLine($"Min Score: {min}");
            Console.WriteLine($"Average: {avg:F2}");
        }
    }

    // 🔹 Grade Calculator
    class GradeCalculator
    {
        public static string CalculateGrade(double score)
        {
            if (score >= 80) return "A";
            else if (score >= 75) return "B+";
            else if (score >= 70) return "B";
            else if (score >= 65) return "C+";
            else if (score >= 60) return "C";
            else if (score >= 55) return "D+";
            else if (score >= 50) return "D";
            else return "F";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Student Grade Management System ===");

            // 🔹 เปิดวิชา
            Console.Write("Enter Subject ID: ");
            string subID = Console.ReadLine();

            Console.Write("Enter Subject Name: ");
            string subName = Console.ReadLine();

            Subject subject = new Subject(subID, subName);

            while (true)
            {
                Console.WriteLine("\n1. Add Student");
                Console.WriteLine("2. Show All Students");
                Console.WriteLine("3. Show Statistics");
                Console.WriteLine("4. Exit");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Student ID: ");
                    string id = Console.ReadLine();

                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Score: ");
                    double score = double.Parse(Console.ReadLine());

                    Student s = new Student(id, name, score);
                    subject.AddStudent(s);

                    Console.WriteLine("✅ Added Successfully!");
                }
                else if (choice == "2")
                {
                    subject.ShowAllStudents();
                }
                else if (choice == "3")
                {
                    subject.ShowStats();
                }
                else if (choice == "4")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("❌ Invalid choice");
                }
            }
        }
    }
}