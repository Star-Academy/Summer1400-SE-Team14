using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Phase_4
{
    public class StudentProcessor
    {
        public StudentProcessor(List<Student> students, List<LessonClass> allLessons)
        {
            DataBase.SetAllStudents(students);
            DataBase.SetLessonsForStudents(allLessons);
            var orderedStudentsByAverage = OrderStudentsByAverage();
            PrintBestThreeStudents((IEnumerable<Student>) orderedStudentsByAverage);
        }

        private static void PrintBestThreeStudents(IEnumerable<Student> orderedStudentsByAverage)
        {
            var topThreeStudents = FindTopThreeStudents(orderedStudentsByAverage);
            foreach (var student in topThreeStudents)
            {
                Console.WriteLine("FirstName: " + student.FirstName + "     LastName: " + student.LastName +
                                  "      Average: " + student.Average);
            }
        }

        private static IEnumerable<Student> FindTopThreeStudents(IEnumerable<Student> orderedStudentsByAverage)
        {
            return orderedStudentsByAverage.Take(3);
        }

        private static IEnumerable OrderStudentsByAverage()
        {
            return DataBase.DataBaseInstance.AllStudents.OrderByDescending(s => s.Average);
        }
    }
}