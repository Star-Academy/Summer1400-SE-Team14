using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class InvertedIndex
    {
        private readonly List<string> _stopWords = new List<string>
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

        private readonly List<Word> _indexedWords = new List<Word>();


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


        private HashSet<string> FindCommonWords(List<HashSet<string>> wordsToFindCommon)
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
            var answer = new HashSet<string>();
            wordsToFind = NormalizeInputWords(wordsToFind);
            foreach (string word in wordsToFind) FindWordInFiles(word, answer);


            return answer;
        }

        private void FindWordInFiles(string word, HashSet<string> answer)
        {
            foreach (var keyWord in _indexedWords)
            {
                var antis = _indexedWords.FindIndex(a => a.NameOfWord.Equals(keyWord.NameOfWord));
                CheckCommandMatcher(word, keyWord.NameOfWord, answer, antis);
            }
        }

        private void CheckCommandMatcher(string word, string key, HashSet<string> answer, int antis)
        {
            var rg = new Regex(word);
            var matcher = rg.Match(key);
            if (!matcher.Success) return;
            var fileInfoList = _indexedWords[antis].FilesContainWord;
            if (fileInfoList != null) AddFileNumbers(fileInfoList, answer);
        }


        private static void AddFileNumbers(HashSet<FilePathClass> fileInfoList, HashSet<string> answer)
        {
            foreach (FilePathClass t in fileInfoList) answer.Add(t.FilePath);
        }


        private List<string> NormalizeInputWords(List<string> wordsToFind)
        {
            return wordsToFind.Select(ConvertToLowerCase).ToList();
        }

        private static string ConvertToLowerCase(string wordsInFiles)
        {
            return wordsInFiles.ToLower();
        }


        public void IndexFile(IEnumerable<string> filePaths)
        {
            foreach (var filePath in filePaths)
            {
                ConvertFileToTokens(filePath);
            }

            using var context = new Context();
            context.Database.EnsureCreated();
            foreach (var indexedWord in _indexedWords)
            {
                context.SaveWords.Add(indexedWord);
            }

            context.SaveChanges();
        }

        private void ConvertFileToTokens(string filePath)
        {
            var sr = new StreamReader(filePath);

            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            var str = sr.ReadLine();
            while (str != null)
            {
                ImportWordsInList(str, filePath);
                str = sr.ReadLine();
            }

            sr.Close();
        }

        private void ImportWordsInList(string line, string filePath)
        {
            foreach (var wordsInFiles in line.Split(" "))
            {
                // Console.WriteLine(wordsInFiles);
                var wordsInFilesInLower = ConvertToLowerCase(wordsInFiles);
                if (_stopWords.Contains(wordsInFilesInLower))
                {
                    continue;
                }

                if (CheckContainByIndexWords(wordsInFilesInLower) != null)
                {
                    var filesList = CheckContainByIndexWords(wordsInFilesInLower).FilesContainWord;
                    filesList.Add(new FilePathClass(filePath));
                }
                else
                {
                    var word = new Word(wordsInFilesInLower);
                    var filePathInstance = new FilePathClass(filePath);
                    word.FilesContainWord.Add(filePathInstance);
                    _indexedWords.Add(word);
                }
            }
        }

        private Word CheckContainByIndexWords(string wordName)
        {
            return _indexedWords.FirstOrDefault(indexedWord => indexedWord.NameOfWord.Equals(wordName));
        }
    }
}