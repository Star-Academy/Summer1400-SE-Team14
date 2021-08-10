using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1
{
    public class Word
    {
        public static List<Word> AllWords = new List<Word>();

        [Key] public int Id { set; get; }

        public string NameOfWord { set; get; }

        public HashSet<FilePath> FilesContainWord { set; get; }

        public Word(string nameOfWord)
        {
            FilesContainWord = new HashSet<FilePath>();
            this.NameOfWord = nameOfWord;
            AllWords.Add(this);
        }
    }
}