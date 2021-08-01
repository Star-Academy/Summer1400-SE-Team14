using System.Collections.Generic;

namespace Phase_4
{
    public class Lesson
    {
        public static List<Lesson> AllLessons = new List<Lesson>();
        public int studentNumber { set; get; }
        public string lessonName { set; get; }
        public double score { set; get; }

        public Lesson(int studentNumber, string lessonName, double score)
        {
            this.studentNumber = studentNumber;
            this.lessonName = lessonName;
            this.score = score;
        }
    }
}