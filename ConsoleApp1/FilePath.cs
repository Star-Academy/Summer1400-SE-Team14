using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1
{
    public class FilePath
    {

        public FilePath(string filePath)
        {
            this.filePath = filePath;
            AllFilePaths.Add(filePath);
        }

        public static List<string> AllFilePaths = new List<string>();
        [Key]
        public string filePath { set; get; }
    }
}