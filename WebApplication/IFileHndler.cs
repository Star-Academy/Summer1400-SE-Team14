using System.Collections.Generic;

namespace ConsoleApp1
{
    public interface IFileHandler
    {
        void AddFileNumbers(List<FileInfo> fileInfoList, HashSet<string> answer);




        void ImportWordsInList(string line, int fileNumber);

        List<string> GetFiles();
    }
}