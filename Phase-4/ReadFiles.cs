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
            var unused = new StudentProcessor(students, allLessons);
        }

        private static string ReadLessonsFromFiles()
        {
            const string fileName = "../../../../Phase-4/lessons.json";
            return File.ReadAllText(fileName);
        }


        private static string ReadEveryThingFromFiles()
        {
            const string fileName = "../../../../Phase-4/Students.json";
            return File.ReadAllText(fileName);
        }
        
    }
}