using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public interface IInvertedIndex
    {
        static List<string> stopWords = new List<string>
        {
            "a", "able", "about",
            "across", "after", "all", "almost", "also", "am", "among", "an",
            "and", "any", "are", "as", "at", "be", "because", "been", "but",
            "by", "can", "cannot", "could", "dear", "did", "do", "does",
            "either", "else", "ever", "every", "for", "from", "get", "got",
            "had", "has", "have", "he", "her", "hers", "him", "his", "how",
            "however", "i", "if", "in", "into", "is", "it", "its", "just",
            "least", "let", "like", "likely", "may", "me", "might", "most",
            "must", "my", "neither", "no", "nor", "not", "of", "off", "often",
            "on", "only", "or", "other", "our", "own", "rather", "said", "say",
            "says", "she", "should", "since", "so", "some", "than", "that",
            "the", "their", "them", "then", "there", "these", "they", "this",
            "tis", "to", "too", "twas", "us", "wants", "was", "we", "were",
            "what", "when", "where", "which", "while", "who", "whom", "why",
            "will", "with", "would", "yet", "you", "your"
        };

        static Dictionary<string, List<FileInfo>> indexedWords = new Dictionary<string, List<FileInfo>>();
        static List<string> files = new List<string>();


        public HashSet<string> DeleteGivenFiles(HashSet<string> answer, HashSet<string> deleteFiles)
        {
            
            HashSet<string> common = answer.Intersect(deleteFiles).ToHashSet();

            answer.RemoveWhere(x => common.Contains(x));
            return answer;
        }

        public HashSet<string> FindCommonFiles(HashSet<string> answer, List<HashSet<string>> wordsToFindCommon)
        {
            HashSet<string> commonWords = FindCommonWords(wordsToFindCommon);
            if (answer.Count > 0 && commonWords.Count > 0)
            {
                answer.IntersectWith(commonWords);
                return answer;
            }

            if (answer.Count == 0 && commonWords.Count > 0)
            {
                return commonWords;
            }

            if (answer.Count == 0)
            {
                return new HashSet<string>();
            }

            return answer;
        }


        public HashSet<string> FindCommonWords(List<HashSet<string>> wordsToFindCommon)
        {
            if (wordsToFindCommon.Count <= 0)
            {
                return new HashSet<string>();
            }

            HashSet<string> commonWords = wordsToFindCommon[0];
            if (wordsToFindCommon.Count == 1)
            {
                return commonWords;
            }

            for (int i = 1; i < wordsToFindCommon.Count; i++)
            {
                commonWords.IntersectWith(wordsToFindCommon[i]);
            }

            return commonWords;
        }

        public HashSet<string> search(List<string> wordsToFind)
        {
            HashSet<string> answer = new HashSet<string>();
            wordsToFind = NormalizeInputWords(wordsToFind);
            foreach (string word in wordsToFind) FindWordInFiles(word, answer);
            return answer;
        }

        private List<string> NormalizeInputWords(List<string> wordsToFind)
        {
            List<string> returnArrayList = new List<string>();
            foreach (string wordString in wordsToFind)
            {
                returnArrayList.Add(ConvertToLowerCase(wordString));
            }

            return returnArrayList;
        }

        private string ConvertToLowerCase(string wordsInFiles)
        {
            return wordsInFiles.ToLower();
        }

        private void findWordInFiles(string word, HashSet<string> answer)
        {
            foreach (string key in indexedWords.keySet())
            {
                checkCommandMatcher(word, key, answer);
            }
        }
    }
}