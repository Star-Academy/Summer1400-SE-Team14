using System.Collections.Generic;

namespace ConsoleApp1
{
    public interface ITextNormalizer
    {
        List<string> NormalizeInputWords(List<string> wordsToFind);

        string ConvertToLowerCase(string wordsInFiles);

        void ImportWordsInList(string line, string filePath)
    }
}