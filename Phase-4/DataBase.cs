using System.Collections.Generic;
using System.Linq;

namespace Phase_4
{
    public class DataBase
    {
        public static List<Student> AllStudents { set; get; }

        public static void SetAllStudents(List<Student> students)
        {
            DataBase.AllStudents = students;
        }

        
        public static Student GetStudentWithStudentNumber(int studentNumber)
        {
            return DataBase.AllStudents.FirstOrDefault(allStudent => allStudent.StudentNumber == studentNumber);
        }
        public static void SetLessonsForStudents(List<LessonClass> allLessons)
        {
            foreach (var lessonClass in allLessons)
            {
                var studentNumber = lessonClass.StudentNumber;
                var student = DataBase.GetStudentWithStudentNumber(studentNumber);
                student.AddLessonToAllLessons(lessonClass);
            }
        }
    }
}