using System.Collections.Generic;

namespace ConsoleApp1
{
    public interface ITextNormalizer
    {
        List<string> NormalizeInputWords(List<string> wordsToFind);

        string ConvertToLowerCase(string wordsInFiles);
        void ConvertFileToTokens(int fileNumber, string filePath);
    }
}