using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class InputScannerView
    {
        private const string BackString = "--back";

        public InputScannerView()
        {
            
        }

        private static void ShowResult(IEnumerable<string> answer)
        {
            foreach (var s in answer)
            {
                Console.Out.WriteLine(s);
            }
        }

        public IEnumerable<string> start(InvertedIndex index, string input)
        {
            var inputScanner = new InputScanner(index);
            Console.WriteLine(input+")))))))))");
            return inputScanner.GetOrder(input);
        }
    }
}