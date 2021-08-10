using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class InputScanner
    {
        private InvertedIndex index;

        public InputScanner(InvertedIndex index)
        {
            this.index = index;
        }


        public HashSet<string> GetOrder(string input)
        {
            IEnumerable<string> inputSplit = SplitInput(input);
            List<string> plusStrings = new List<string>();
            List<string> minusStrings = new List<string>();
            List<string> normalStrings = new List<string>();
            foreach (var s in inputSplit)
            {
             //   Console.WriteLine(s+"**************************");
                addItemToOneOfThreeArrayLists(s, plusStrings, minusStrings, normalStrings);
            }

            return processes(index, plusStrings, minusStrings, normalStrings);
        }

        private static IEnumerable<string> SplitInput(string input)
        {
            return input.Split("(\\s+)");
        }


        private HashSet<string> processes(InvertedIndex index, List<string> plusStrings, List<string> minusStrings,
            List<string> normalStrings)
        {
           // Console.WriteLine(plusStrings[0]+"+++");

            HashSet<string> answer = index.Search(plusStrings);
          //  Console.WriteLine(answer+"**************************");

            HashSet<string> toDelete = index.Search(minusStrings);
            List<HashSet<string>> commons = new List<HashSet<string>>();
            foreach (var normalString in normalStrings)
            {
                List<string> arrayList = new List<string>();
                arrayList.Add(normalString);
                commons.Add(index.Search(arrayList));
            }

            answer = index.FindCommonFiles(answer, commons);
            answer = index.DeleteGivenFiles(answer, toDelete);
            return answer;
        }

        private void addItemToOneOfThreeArrayLists(string iString, List<string> plusStrings, List<string> minusStrings,
            List<string> normalStrings)
        {
            Regex pattern = new Regex("^\\+(.+)$");
            Match matcher = pattern.Match(iString);
            Regex patternTwo = new Regex("^-(.+)$");
            MatchCollection matcherTwo = patternTwo.Matches(iString);
            if (matcher.Success)
            {
                var toAdd = matcher.Value;
                plusStrings.Add(toAdd);
            }
            else if (matcherTwo.Count > 0)
            {
                var toAdd = matcherTwo[0].Value;
                minusStrings.Add(toAdd);
            }
            else normalStrings.Add(iString);
        }
    }
}