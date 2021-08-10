using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1
{
    public class FilePathClass
    {

        public FilePathClass()
        {
        }

        public FilePathClass(string filePath)
        {
            this.FilePath = filePath;
            AllFilePaths.Add(filePath);
        }

        private static readonly HashSet<string> AllFilePaths = new HashSet<string>();
        [Key]
        public string FilePath { get; }
    }
}