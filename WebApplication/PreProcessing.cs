using System;
using System.IO;

namespace ConsoleApp1
{
    public class PreProcessing
    {
        static string invalidPathString = "INVALID PATH!";

        public static string Preprocesses(string input)
        {
            string[] files = Directory.GetFiles(@"\..\..\..\Phase-52\TestProject1\");

            try
            {
                IInvertedIndex index = new InvertedIndex();

                addFilesToIndexFiles(files, index);
                var inputScanner = new InputScanner(index);
                var result = inputScanner.GetOrder(input);
                
                var answer = "";
                foreach (var s in result)
                {
                    answer += s;
                    answer += "\n";
                }

                return answer;
            }
            catch (Exception e)
            {
                return "an error has happened!"+e.Message;
            }
        }

        private static void addFilesToIndexFiles(string[] filesList, IInvertedIndex index)
        {
            index.IndexFile(filesList);
        }
    }
}