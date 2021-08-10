using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    public static class PreProcessing
    {
        public static string Preprocesses()
        {
            var files = Directory.GetFiles(@"C:\Users\ASUS\RiderProjects\Phase-8\New folder\");
            try
            {
                var index = new InvertedIndex();
                AddFilesToIndexFiles(files, index);
                var unused = new InputScannerView(index);
                return "end";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "an error has happened!";
            }
        }

        private static void AddFilesToIndexFiles(IEnumerable<string> filesList, InvertedIndex index)
        {
            index.IndexFile(filesList);
        }
    }
}