using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class InputScanner:IInputScanner
    {
        private readonly InvertedIndex _index;

        public InputScanner(InvertedIndex index)
        {
            this._index = index;
        }


        public IEnumerable<string> GetOrder(string input)
        {
            var inputSplit = SplitInput(input);
            var plusStrings = new List<string>();
            var minusStrings = new List<string>();
            var normalStrings = new List<string>();
            foreach (var s in inputSplit)
            {
                addItemToOneOfThreeArrayLists(s, plusStrings, minusStrings, normalStrings);
            }

            return Processes(_index, plusStrings, minusStrings, normalStrings);
        }

        private static IEnumerable<string> SplitInput(string input)
        {
            return input.Split("(\\s+)");
        }


        private static HashSet<string> Processes(InvertedIndex index, List<string> plusStrings,
            List<string> minusStrings,
            IEnumerable<string> normalStrings)
        {
            var answer = index.Search(plusStrings);

            var toDelete = index.Search(minusStrings);
            var commons = normalStrings.Select(normalString => new List<string> {normalString}).Select(index.Search)
                .ToList();

            answer = index.FindCommonFiles(answer, commons);
            answer = index.DeleteGivenFiles(answer, toDelete);
            return answer;
        }

        private static void addItemToOneOfThreeArrayLists(string iString, ICollection<string> plusStrings,
            ICollection<string> minusStrings,
            ICollection<string> normalStrings)
        {
            var pattern = new Regex("^\\+(.+)$");
            var matcher = pattern.Match(iString);
            var patternTwo = new Regex("^-(.+)$");
            var matcherTwo = patternTwo.Matches(iString);
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