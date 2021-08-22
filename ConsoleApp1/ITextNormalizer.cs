using System.Collections.Generic;

namespace ConsoleApp1
{
    public interface ITextNormalizer
    {
        List<string> NormalizeInputWords(List<string> wordsToFind);

        string ConvertToLowerCase(string wordsInFiles);
        public void ImportWordsInList(string line, int fileNumber);
    }
}