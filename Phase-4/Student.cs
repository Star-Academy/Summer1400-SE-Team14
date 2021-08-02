using System;
using System.Collections.Generic;

namespace Phase_4
{
    public class Student
    {
        public static List<Student> AllStudents { set; get; }
        private List<LessonClass> allLessons = new List<LessonClass>();
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public int StudentNumber { set; get; }
        
    }
}