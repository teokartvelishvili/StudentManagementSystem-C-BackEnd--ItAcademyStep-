namespace StudentManagementSystem_C_BackEnd_ItAcademyStep_
{
    using System;
    using System.Collections.Generic;

    namespace StudentManagementSystem
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Create a list to store students
                List<Student> students = new List<Student>();

                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("\nStudent Management System");
                    Console.WriteLine("1. Add a new student");
                    Console.WriteLine("2. View all students");
                    Console.WriteLine("3. Search for a student by roll number");
                    Console.WriteLine("4. Update a student's grade");
                    Console.WriteLine("5. Exit");
                    Console.Write("Enter your choice: ");

                    int choice;
                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                AddStudent(students);
                                break;
                            case 2:
                                ViewAllStudents(students);
                                break;
                            case 3:
                                SearchStudent(students);
                                break;
                            case 4:
                                UpdateGrade(students);
                                break;
                            case 5:
                                exit = true;
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please try again.");
                    }
                }
            }

            static void AddStudent(List<Student> students)
            {
                Console.WriteLine("\nAdding a new student:");
                Console.Write("Enter student's name: ");
                string name = Console.ReadLine();
                Console.Write("Enter student's roll number: ");
                int rollNumber;
                while (!int.TryParse(Console.ReadLine(), out rollNumber))
                {
                    Console.Write("Invalid input. Please enter a valid roll number: ");
                }

                int grade;
                Console.Write("Enter student's grade (1-10): ");
                while (!int.TryParse(Console.ReadLine(), out grade) || grade < 1 || grade > 10)
                {
                    Console.WriteLine("Invalid input. Please enter a valid grade (1-10): ");
                    Console.Write("Enter student's grade (1-10): ");
                }

                Student newStudent = new Student(name, rollNumber, grade);
                students.Add(newStudent);

                Console.WriteLine("\nStudent added successfully!");
            }

            static void UpdateGrade(List<Student> students)
            {
                Console.Write("\nEnter roll number of the student whose grade you want to update: ");
                int rollNumber;
                if (int.TryParse(Console.ReadLine(), out rollNumber))
                {
                    Student student = students.Find(s => s.RollNumber == rollNumber);
                    if (student != null)
                    {
                        int grade;
                        Console.Write("Enter new grade (1-10): ");
                        while (!int.TryParse(Console.ReadLine(), out grade) || grade < 1 || grade > 10)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid grade (1-10): ");
                            Console.Write("Enter new grade (1-10): ");
                        }

                        student.Grade = grade;
                        Console.WriteLine("\nGrade updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid roll number.");
                }
            }
        }

        class Student
        {
            public string Name { get; }
            public int RollNumber { get; }
            public int Grade { get; set; }

            public Student(string name, int rollNumber, int grade)
            {
                Name = name;
                RollNumber = rollNumber;
                Grade = grade;
            }
        }
    }

}
