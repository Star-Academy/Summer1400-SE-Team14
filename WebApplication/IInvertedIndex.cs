using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public interface IInvertedIndex
    {
         HashSet<string> DeleteGivenFiles(HashSet<string> answer, HashSet<string> deleteFiles);

         HashSet<string> FindCommonFiles(HashSet<string> answer, List<HashSet<string>> wordsToFindCommon);


         HashSet<string> FindCommonWords(List<HashSet<string>> wordsToFindCommon);

         HashSet<string> Search(List<string> wordsToFind);

         void FindWordInFiles(string word, HashSet<string> answer);
         void CheckCommandMatcher(string word, string key, HashSet<string> answer);

         void IndexFile(string[] fileDirectory);

       
    }
}