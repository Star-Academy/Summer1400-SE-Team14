using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public interface IInvertedIndex
    {
        public HashSet<string> DeleteGivenFiles(HashSet<string> answer, HashSet<string> deleteFiles);

        public HashSet<string> FindCommonFiles(HashSet<string> answer, List<HashSet<string>> wordsToFindCommon);


        public HashSet<string> FindCommonWords(List<HashSet<string>> wordsToFindCommon);

        public HashSet<string> Search(List<string> wordsToFind);

        public void FindWordInFiles(string word, HashSet<string> answer);

        public void CheckCommandMatcher(string word, string key, HashSet<string> answer, int andis);
        public void AddFileNumbers(List<FileInfo> fileInfoList, HashSet<string> answer);


        public List<string> NormalizeInputWords(List<string> wordsToFind);

        public string ConvertToLowerCase(string wordsInFiles);


        public void IndexFile(string[] fileDirectory);

        public void ConvertFileToTokens(int fileNumber, string filePath);

        public void ImportWordsInList(string line, int fileNumber);

        public List<string> GetFiles();
    }
}