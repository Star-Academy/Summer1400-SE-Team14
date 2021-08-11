using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1
{
    public class Word
    {
        public Word()
        {
        }

        [Key] 
        public int Id { set; get; }

        public string NameOfWord { get; }

        public HashSet<FilePathClass> FilesContainWord { get; }

        public Word(string nameOfWord)
        {
            FilesContainWord = new HashSet<FilePathClass>();
            NameOfWord = nameOfWord;
        }
    }
}