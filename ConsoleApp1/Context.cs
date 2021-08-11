using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    public class Context : DbContext
    {
        public DbSet<Word> SaveWords { set; get; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=IndexWords;Trusted_Connection=True;");
        }
    }
}