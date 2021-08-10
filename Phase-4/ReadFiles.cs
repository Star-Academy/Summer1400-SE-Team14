using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Phase_4
{
    public static class ReadFiles
    {
        
        public static void ProcessFiles()
        {
            var jsonString = ReadEveryThingFromFiles();
            var students = JsonSerializer.Deserialize<List<Student>>(jsonString);
            jsonString = ReadLessonsFromFiles();
            var allLessons = JsonSerializer.Deserialize<List<LessonClass>>(jsonString);
            var unused = new Process(students, allLessons);
        }

        private static string ReadLessonsFromFiles()
        {
            // fileName = "C:\\Users\\ASUS\\RiderProjects\\Phase-4\\Phase-4\\lessons.json";
            const string fileName = "C:\\Users\\mjmah\\OneDrive\\Desktop\\new\\Phase-4\\lessons.json";
            return File.ReadAllText(fileName);
        }


        private static string ReadEveryThingFromFiles()
        {
            // string fileName = "C:\\Users\\ASUS\\RiderProjects\\Phase-4\\Phase-4\\Students.json";
            const string fileName = "C:\\Users\\mjmah\\OneDrive\\Desktop\\new\\Phase-4\\Students.json";
            return File.ReadAllText(fileName);
        }
        
    }
}