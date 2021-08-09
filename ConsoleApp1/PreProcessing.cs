using System;
using System.IO;

namespace ConsoleApp1
{
    public class PreProcessing
    {
        static string invalidPathString = "INVALID PATH!";

        public static string Preprocesses()
        {
            string[] files = Directory.GetFiles(@"C:\Users\ASUS\RiderProjects\newPhase-5Clone\TestProject1\");
            Console.WriteLine("1!!");
            try
            {
                Console.WriteLine("2!!");

                InvertedIndex index = new InvertedIndex();
                Console.WriteLine("3!!");

                addFilesToIndexFiles(files, index);
                Console.WriteLine("4!!");

                new InputScannerView(index);
                Console.WriteLine("5!!");

                return "end";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return "an error has happened!";
            }
        }

        private static void addFilesToIndexFiles(string[] filesList, InvertedIndex index)
        {
            index.IndexFile(filesList);
        }
    }
}