using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    public static class PreProcessing
    {
        public static IEnumerable<string> Preprocesses(string input)
        {
            var files = Directory.GetFiles(@"C:\Users\mjmah\OneDrive\Desktop\Summer1400-SE-Team14-Phase-8\TestProject1\New Folder");
            //C:\Users\mjmah\OneDrive\Desktop\Summer1400-SE-Team14-Phase-8\TestProject1\New Folder
            Console.WriteLine(files);
            try
            {
                var index = new InvertedIndex();
                AddFilesToIndexFiles(files, index);
                return new InputScannerView().start(index, input);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new[] {"an error has happened!"};
            }
        }

        private static void AddFilesToIndexFiles(IEnumerable<string> filesList, InvertedIndex index)
        {
            index.IndexFile(filesList);
        }
    }
}