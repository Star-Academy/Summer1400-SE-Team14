using System;
using System.Collections.Generic;

namespace ConsoleApp1
{

    public class InputScannerView
    {
        string backString = "--back";

        public InputScannerView(InvertedIndex index)
        {
            Scanner scanner = new Scanner(System.in);
            InputScanner inputScanner = new InputScanner(index);
            while (true)
            {
                string input = scanner.nextLine();
                if (input.equals(backString)) break;
                showResult(inputScanner.getOrder(input));
            }

            scanner.close();

        }

        private void showResult(List<string> answer)
        {
            foreach (var s in answer)
            {
                Console.Out.WriteLine(s);
            }

        }
    }

}