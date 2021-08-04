using System.Collections.Generic;

namespace ConsoleApp1
{
    public class InputScanner
    {
        private InvertedIndex index;

        public InputScanner(InvertedIndex index)
        {
            this.index = index;
        }


        public HashSet<string> getOrder(string input)
        {
            string[] inputSplit = splitInput(input);
            List<string> plusStrings = new List<string>();
            List<string> minusStrings = new List<string>();
            List<string> normalStrings = new List<string>();
            foreach (var s in inputSplit)
            {
                addItemToOneOfThreeArrayLists(s, plusStrings, minusStrings, normalStrings);
            }
        
            return processes(index, plusStrings, minusStrings, normalStrings);
        }
    
        private string[] splitInput(string input)
        {
            return input.split("(\\s+)");
        }
    
    
        private HashSet<string> processes(IInvertedIndex index, List<string> plusStrings, List<string> minusStrings,
            List<string> normalStrings)
        {
            HashSet<string> answer = index.search(plusStrings);
            HashSet<string> toDelete = index.search(minusStrings);
            List<HashSet<string>> commons = new List<HashSet<string>>();
            foreach (var normalString in normalStrings)
            {
                List<string> arrayList = new List<string>();
                arrayList.Add(normalString);
                commons.Add(index.search(arrayList));
            }
    
            answer = index.FindCommonFiles(answer, commons);
            answer = index.DeleteGivenFiles(answer, toDelete);
            return answer;
        }
    
        private void addItemToOneOfThreeArrayLists(string iString, List<string> plusStrings, List<string> minusStrings,
            List<string> normalStrings)
        {
            Pattern pattern = Pattern.compile("^\\+(.+)$");
            Matcher matcher = pattern.matcher(iString);
            Pattern pattern1 = Pattern.compile("^-(.+)$");
            Matcher matcher1 = pattern1.matcher(iString);
            if (matcher.find())
            {
                string a = matcher.group(1);
                plusStrings.Add(a);
            }
            else if (matcher1.find())
            {
                string a = matcher1.group(1);
                minusStrings.Add(a);
            }
            else normalStrings.Add(iString);
        }
     }
}