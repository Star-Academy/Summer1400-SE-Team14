using System;
using System.Collections.Generic;
using System.Linq;

namespace Phase_4
{
    public class Student
    {
        public static List<Student> AllStudents { set; get; }
        private List<LessonClass> allLessons = new List<LessonClass>();
        public double Average = 0;

        // public Student(Student student)
        // {
        //     FirstName = student.FirstName;
        //     LastName = student.LastName;
        //     Average = 0;
        //     StudentNumber = student.StudentNumber;
        // }
        public Student()
        {
        }

        public Student(int studentNumber, string firstName, string lastName)
        {
            StudentNumber = studentNumber;
            FirstName = firstName;
            LastName = lastName;
            AllStudents.Add(this);
            Average = 0;
        }

        public string FirstName { set; get; }
        public string LastName { set; get; }
        public int StudentNumber { set; get; }

        public static Student GetStudentWithStudentNumber(int studentNumber)
        {
            foreach (var allStudent in AllStudents)
            {
                if (allStudent.StudentNumber == studentNumber) return allStudent;
            }

            return null;
        }

        public void AddLessonToAllLessons(LessonClass lessonClass)
        {
            allLessons.Add(lessonClass);
            CalculateNewAverage();
        }

        private void CalculateNewAverage()
        {
            double sumOfScores = allLessons.Sum(lessonClass => lessonClass.Score);
            Average = sumOfScores / allLessons.Count;
        }
    }
}