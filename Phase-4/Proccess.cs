using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Phase_4
{
    public class Proccess
    {
        public Proccess(List<Student> students, List<LessonClass> allLessons)
        {
           
            Student.AllStudents = students; 
            foreach (var lessonClass in allLessons)
            {
                
                int studentNumber = lessonClass.StudentNumber;
                Student student = Student.GetStudentWithStudentNumber(studentNumber);
                student.AddLessonToAllLessons(lessonClass);

            }

            
            var orderedStudentsByAverage = Student.AllStudents.OrderByDescending(s => s.Average);

            int i = 0;
            foreach (var student in orderedStudentsByAverage)
            {
                if (i > 2)
                {
                    break;
                }
                Console.WriteLine(student.Average);
                i++;
            }
        }
    }
}