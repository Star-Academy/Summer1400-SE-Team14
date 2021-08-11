﻿using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class InputScannerView
    {
        private const string BackString = "--back";

        public InputScannerView(IInvertedIndex index)
        {

            var inputScanner = new InputScanner(index);
            while (true)
            {
                var input = Console.ReadLine();
                if (string.Equals(input, BackString)) break;
                ShowResult(inputScanner.GetOrder(input));
            }
        }

        private static void ShowResult(IEnumerable<string> answer)
        {
            foreach (var s in answer)
            {
                Console.Out.WriteLine(s);
            }
        }
    }
}