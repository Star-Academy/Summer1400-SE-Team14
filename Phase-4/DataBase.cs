using System.Collections.Generic;
using System.Linq;

namespace Phase_4
{
    public class DataBase
    {
        public List<Student> AllStudents { set; get; }

        public static readonly DataBase DataBaseInstance = new DataBase();

        public static void SetAllStudents(List<Student> students)
        {
            DataBaseInstance.AllStudents = students;
        }

        
        public static Student GetStudentWithStudentNumber(int studentNumber)
        {
            return DataBaseInstance.AllStudents.FirstOrDefault(allStudent => allStudent.StudentNumber == studentNumber);
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