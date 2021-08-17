using System.Collections.Generic;
using System.Linq;

namespace Phase_4
{
    public class Student
    {
        private List<LessonClass> allLessons = new List<LessonClass>();
        public double Average;
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public int StudentNumber { set; get; }

       

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