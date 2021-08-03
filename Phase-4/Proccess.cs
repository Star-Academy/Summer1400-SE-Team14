using System;
using System.Collections.Generic;

namespace Phase_4
{
    public class Proccess
    {
        public Proccess(List<Student> students, List<LessonClass> allLessons)
        {
            foreach (var student in students)
            {
                int studentNumber = student.StudentNumber;
                string firstName = student.FirstName;
                string lastName = student.LastName;
                
                new Student(studentNumber, firstName, lastName);
            }
            foreach (var lessonClass in allLessons)
            {
                int studentNumber = lessonClass.StudentNumber;
                Student student = Student.GetStudentWithStudentNumber(studentNumber);
                student.AddLessonToAllLessons(lessonClass);

            }

            foreach (var student in students)
            {
                Console.Write(student.Average);
            }
        }
    }
}