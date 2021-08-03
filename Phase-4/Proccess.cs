using System;
using System.Collections.Generic;

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

            foreach (var student in students)
            {
                Console.WriteLine(student.Average);
            }
        }
    }
}