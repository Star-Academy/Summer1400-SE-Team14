using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1
{
    public abstract class FileInfo
    {
        private int FileNumber { set; get; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { set; get; }

        protected FileInfo()
        {
        }

        protected FileInfo(int fileNumber)
        {
            this.FileNumber = fileNumber;
        }

        public int GetFileNumber()
        {
            return FileNumber;
        }
    }
}