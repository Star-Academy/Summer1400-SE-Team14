using System;
using System.IO;

namespace ConsoleApp1
{
    public class PreProcessing
    {
        static string invalidPathString = "INVALID PATH!";

        public static string Preprocesses()
        {
            string[] files = Directory.GetFiles(@"..\..\..\..\TestProject1\");

            try
            {
                IInvertedIndex index = new InvertedIndex();

                addFilesToIndexFiles(files, index);
                new InputScannerView(index);
                return "end";
            }
            catch (Exception e)
            {
                return "an error has happened!";
            }
        }

        private static void addFilesToIndexFiles(string[] filesList, IInvertedIndex index)
        {
            index.IndexFile(filesList);
        }
    }
}