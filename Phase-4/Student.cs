using System.Collections.Generic;

namespace Phase_4
{
    public class Student
    {
        private static List<Student> AllStudents = new List<Student>();
        private List<Lesson> allLessons = new List<Lesson>();
        public string firstName { set; get; }
        public string lastName { set; get; }
        public int studentNumber { set; get; }

        public Student(string firstName, string lastName, int studentNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.studentNumber = studentNumber;
            AllStudents.Add(this);
        }
    }
}