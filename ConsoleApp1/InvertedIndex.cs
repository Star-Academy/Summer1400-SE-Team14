using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class InvertedIndex : IInvertedIndex
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

        public HashSet<string> Search(List<string> wordsToFind)
        {
            HashSet<string> answer = new HashSet<string>();
            wordsToFind = NormalizeInputWords(wordsToFind);
            foreach (string word in wordsToFind) FindWordInFiles(word, answer);
            return answer;
        }

        public void FindWordInFiles(string word, HashSet<string> answer)
        {
            foreach (string key in indexedWords.Keys)
            {
                CheckCommandMatcher(word, key, answer);
            }
        }

        public void CheckCommandMatcher(string word, string key, HashSet<string> answer)
        {
            Regex rg = new Regex(word);
            Match matcher = rg.Match(key);
            if (matcher.Success)
            {
                List<FileInfo> fileInfoList = indexedWords[key];
                if (fileInfoList != null) AddFileNumbers(fileInfoList, answer);
            }
        }


        public void AddFileNumbers(List<FileInfo> fileInfoList, HashSet<string> answer)
        {
            foreach (FileInfo t in fileInfoList) answer.Add(files[t.GetFileNumber() - 1]);
        }


        public List<string> NormalizeInputWords(List<string> wordsToFind)
        {
            List<string> returnArrayList = new List<string>();
            foreach (string wordString in wordsToFind)
            {
                returnArrayList.Add(ConvertToLowerCase(wordString));
            }

            return returnArrayList;
        }

        public string ConvertToLowerCase(string wordsInFiles)
        {
            return wordsInFiles.ToLower();
        }


        public void IndexFile(string[] filePaths)
        {
            // string[] filePaths = Directory.GetFiles(@fileDirectory);
            // Console.WriteLine(filePaths);
            int fileNumber = 0;
            foreach (var filePath in filePaths)
            {
                files.Add(filePath);
                fileNumber++;
                //   Console.WriteLine(filePath);
                ConvertFileToTokens(fileNumber, filePath);
            }
        }

        public void ConvertFileToTokens(int fileNumber, string filePath)
        {
            StreamReader sr = new StreamReader(filePath);

            //    Console.WriteLine("Content of the File");

            sr.BaseStream.Seek(0, SeekOrigin.Begin);

            string str = sr.ReadLine();

            while (str != null)
            {
                ImportWordsInList(str, fileNumber);
                //     Console.WriteLine(str);
                str = sr.ReadLine();
            }

            sr.Close();
        }

        public void ImportWordsInList(string line, int fileNumber)
        {
            foreach (string wordsInFiles in line.Split("\\W+"))
            {
                string wordsInFilesInLower = ConvertToLowerCase(wordsInFiles);
                if (stopWords.Contains(wordsInFilesInLower))
                    continue;
                if (indexedWords.ContainsKey(wordsInFilesInLower))
                {
                    List<FileInfo> filesList = indexedWords[wordsInFilesInLower];
                    filesList.Add(new FileInfo(fileNumber));
                }

                if (!indexedWords.ContainsKey(wordsInFilesInLower))
                {
                    List<FileInfo> filesList = new List<FileInfo>();
                    filesList.Add(new FileInfo(fileNumber));
                    indexedWords.Add(wordsInFilesInLower, filesList);
                }
            }
        }

        public List<string> GetFiles()
        {
            return files;
        }
    }
}