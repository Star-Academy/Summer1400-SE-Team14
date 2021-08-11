using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class InputScanner
    {
        private IInvertedIndex index;

        public InputScanner(IInvertedIndex index)
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
                AddItemToOneOfThreeArrayLists(s, plusStrings, minusStrings, normalStrings);
            }

            return Processes(index, plusStrings, minusStrings, normalStrings);
        }

        private static IEnumerable<string> SplitInput(string input)
        {
            return input.Split("(\\s+)");
        }


        private HashSet<string> Processes(IInvertedIndex index, List<string> plusStrings, List<string> minusStrings,
            List<string> normalStrings)
        {
            HashSet<string> answer = index.Search(plusStrings);
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

        private static void AddItemToOneOfThreeArrayLists(string iString, List<string> plusStrings, List<string> minusStrings,
            ICollection<string> normalStrings)
        {
            var pattern = new Regex("^\\+(.+)$");
            var matcher = pattern.Matches(iString);
            var patternTwo = new Regex("^-(.+)$");
            var matcherTwo = patternTwo.Matches(iString);
            if (matcher.Count > 0)
            {
                var toAdd = matcher[0].Value;
                plusStrings.Add(toAdd);
            }
            else if (matcherTwo.Count > 0)
            {
                var toAdd = matcherTwo[0].Value;
                minusStrings.Add(toAdd);
            }
            else
            {
                normalStrings.Add(iString);
            }
        }
    }
}