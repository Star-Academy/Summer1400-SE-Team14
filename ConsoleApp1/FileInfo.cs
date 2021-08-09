using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1
{
    public class FileInfo
    {
        public int fileNumber { set; get; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { set; get; }

        public FileInfo()
        {
        }

        public FileInfo(int fileNumber)
        {
            this.fileNumber = fileNumber;
        }

        public int GetFileNumber()
        {
            return fileNumber;
        }
    }
}