using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Phase_4
{
    public class Process
    {
        public Process(List<Student> students, List<LessonClass> allLessons)
        {
            SetAllStudents(students);
            SetLessonsForStudents(allLessons);
            var orderedStudentsByAverage = OrderStudentsByAverage();
            PrintBestThreeStudents(orderedStudentsByAverage);
        }

        private void PrintBestThreeStudents(IEnumerable orderedStudentsByAverage)
        {
            var i = 0;
            foreach (Student student in orderedStudentsByAverage)
            {
                if (i > 2)
                {
                    break;
                }
                Console.WriteLine("FirstName: " + student.FirstName + "     LastName: " + student.LastName + "      Average: " + student.Average);
                i++;
            }
        }

        private static IEnumerable OrderStudentsByAverage()
        {
            return Student.AllStudents.OrderByDescending(s => s.Average);
        }

        private static void SetLessonsForStudents(List<LessonClass> allLessons)
        {
            foreach (var lessonClass in allLessons)
            {
                var studentNumber = lessonClass.StudentNumber;
                var student = Student.GetStudentWithStudentNumber(studentNumber);
                student.AddLessonToAllLessons(lessonClass);
            }
        }

        private static void SetAllStudents(List<Student> students)
        {
            Student.AllStudents = students;
        }
    }
}