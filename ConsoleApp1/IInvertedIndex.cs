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


         void AddFileNumbers(List<FileInfo> fileInfoList, HashSet<string> answer);


         List<string> NormalizeInputWords(List<string> wordsToFind);

         string ConvertToLowerCase(string wordsInFiles);


         void IndexFile(string[] fileDirectory);

         void ConvertFileToTokens(int fileNumber, string filePath);

         void ImportWordsInList(string line, int fileNumber);

         List<string> GetFiles();
    }
}