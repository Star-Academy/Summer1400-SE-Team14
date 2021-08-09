using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1
{
    public class Word
    {
        public static List<Word> AllWords = new List<Word>();

        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] public int Id { set; get; }

        public string NameOfWord { set; get; }

        //    [ForeignKey("Id")]    public List<FileInfo> FilesContainWord { set; get; }
        public List<string> FilesContainWord { set; get; }

        public Word(string nameOfWord)
        {
            this.NameOfWord = nameOfWord;
            AllWords.Add(this);
        }
    }
}