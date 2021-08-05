using System;
using System.IO;

namespace ConsoleApp1
{

    public class PreProcessing
    {
        static string invalidPathString = "INVALID PATH!";

        public static string Preprocesses()
        {

            //TODO
            string[] files = Directory.GetFiles(@"C:\\Users\\ASUS\\RiderProjects\\Phase-5\\EnglishData\\", "*.txt");
            
            try
            {
                IInvertedIndex index = new InvertedIndex();
                // if (filesList == null) return "INVALID FILE LIST!";
                // else
                // {
                    addFilesToIndexFiles(files, index);
                    new InputScannerView(index);
                    return "end";
                // }
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

