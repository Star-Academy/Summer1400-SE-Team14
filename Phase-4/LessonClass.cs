using System;
using System.Collections.Generic;

namespace Phase_4
{
    public class LessonClass
    {
        public static List<LessonClass> AllLessons = new List<LessonClass>();
        public int StudentNumber { set; get; }
        public string Lesson { set; get; }
        public double Score { set; get; }
       
    }
}