using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class InvertedIndex 
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

        //static Dictionary<string, List<FileInfo>> indexedWords = new Dictionary<string, List<FileInfo>>();
        private static List<Word> indexedWords = new List<Word>();

        private IInvertedIndex _invertedIndexImplementation;
        // static List<string> files = new List<string>();


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
            foreach (Word keyWord in indexedWords)
            {
                int andis = indexedWords.FindIndex(a => a.NameOfWord.Equals(keyWord.NameOfWord));
                CheckCommandMatcher(word, keyWord.NameOfWord, answer, andis);
            }
        }

        public void CheckCommandMatcher(string word, string key, HashSet<string> answer, int andis)
        {
            Regex rg = new Regex(word);
            Match matcher = rg.Match(key);
            if (matcher.Success)
            {
             //   List<FileInfo> fileInfoList = indexedWords[andis].FilesContainWord;
                List<FilePath> fileInfoList = indexedWords[andis].FilesContainWord;
                if (fileInfoList != null) AddFileNumbers(fileInfoList, answer);
            }
        }


        public void AddFileNumbers(List<FilePath> fileInfoList, HashSet<string> answer)
        {
            foreach (FilePath t in fileInfoList) answer.Add(t.filePath);
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
             Console.WriteLine("**");
            int fileNumber = 0;
            foreach (var filePath in filePaths)
            {
               // files.Add(filePath);
              //  fileNumber++;
                //   Console.WriteLine(filePath);
                Console.WriteLine(filePath);
                ConvertFileToTokens(fileNumber, filePath);
            }
            Console.WriteLine("*#");

            using (var context = new Context())
            {
                foreach (var indexedWord in indexedWords)
                {
                    context.SaveWords.Add(indexedWord);
                }

                context.SaveChanges();
            }
        }

        public void ConvertFileToTokens(int fileNumber, string filePath)
        {
            Console.WriteLine("qq1");
            StreamReader sr = new StreamReader(filePath);
            Console.WriteLine("qq2");
            //    Console.WriteLine("Content of the File");

            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            Console.WriteLine("qq3");
            string str = sr.ReadLine();
            Console.WriteLine("qq4");
            while (str != null)
            {
                Console.WriteLine("qq5");
                ImportWordsInList(str, fileNumber , filePath);
                Console.WriteLine("qq6");
                //     Console.WriteLine(str);
                str = sr.ReadLine();
                Console.WriteLine("qq7");
            }

            sr.Close();
        }

        public void ImportWordsInList(string line, int fileNumber , string filePath)
        {
            foreach (string wordsInFiles in line.Split("\\W+"))
            {
                Console.WriteLine("ww1");
                string wordsInFilesInLower = ConvertToLowerCase(wordsInFiles);
                Console.WriteLine("ww2");
                if (stopWords.Contains(wordsInFilesInLower))
                    continue;
                int flag = 0;
                foreach (var indexedWord in indexedWords)
                {
                    Console.WriteLine("ww3");
                    if (indexedWord.NameOfWord.Equals(wordsInFilesInLower) && !FilePath.AllFilePaths.Contains(filePath))
                    {
                        flag = 1;
                        Console.WriteLine("ww4");
                        List<FilePath> filesList = indexedWord.FilesContainWord;
                        Console.WriteLine("ww5");
                        filesList.Add(new FilePath(filePath));
                        Console.WriteLine("ww6");
                    }
                }

                Console.WriteLine("ww7");
                if (flag == 0)
                {
                    Console.WriteLine("ww8");
                    List<FilePath> filesList = new List<FilePath>();
                    
                    Console.WriteLine("ww9");
                    Word word = new Word(wordsInFilesInLower);
                    Console.WriteLine("ww10");
                    FilePath filePathInstance = new FilePath(filePath);
                    Console.WriteLine(filePathInstance.filePath);
                    word.FilesContainWord.Add(filePathInstance);
                    Console.WriteLine("ww11");
                    indexedWords.Add(word);
                    Console.WriteLine("ww12");
                }
            }
        }

        // public List<string> GetFiles()
        // {
        //     return files;
        // }
    }
}