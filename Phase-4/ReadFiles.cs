using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Phase_4
{
    public class ReadFiles
    {
        int holdStudentNumber;
        string holdFirstName;
        string holdLastName;

        public ReadFiles()
        {
            ProcessFiles();
        }

        public void ProcessFiles()
        {
            // string fileName = "C:\\Users\\ASUS\\RiderProjects\\Phase-4\\Phase-4\\Students.json";
            string fileName = "C:\\Users\\mjmah\\OneDrive\\Desktop\\new\\Phase-4\\Students.json";
            string jsonString = File.ReadAllText(fileName);
            List<Student> students = JsonSerializer.Deserialize<List<Student>>(jsonString);


            fileName = "C:\\Users\\mjmah\\OneDrive\\Desktop\\new\\Phase-4\\lessons.json";
            jsonString = File.ReadAllText(fileName);
            List<LessonClass> allLessons = JsonSerializer.Deserialize<List<LessonClass>>(jsonString);
            new Proccess(students, allLessons);
            
        }
    }
}