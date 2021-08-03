using System.Collections.Generic;
using System.Linq;

namespace Phase_4
{
    public class Student
    {
        public static List<Student> AllStudents { set; get; }
        private List<LessonClass> allLessons = new List<LessonClass>();
        public double Average;
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public int StudentNumber { set; get; }

        public static Student GetStudentWithStudentNumber(int studentNumber)
        {
            return AllStudents.FirstOrDefault(allStudent => allStudent.StudentNumber == studentNumber);
        }

        public void AddLessonToAllLessons(LessonClass lessonClass)
        {
            allLessons.Add(lessonClass);
            CalculateNewAverage();
        }

        private void CalculateNewAverage()
        {
            var sumOfScores = allLessons.Sum(lessonClass => lessonClass.Score);
            Average = sumOfScores / allLessons.Count;
        }
    }
}