// using Microsoft.EntityFrameworkCore;
//
// namespace ConsoleApp1
// {
//     public class Context : DbContext
//     {
//         public DbSet<Word> SaveWords { set; get; }
//         private const string ServerAddress = ".";
//         private const string DatabaseName = "IndexWords";
//         
//
//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             optionsBuilder.UseSqlServer(@"Server=" + ServerAddress + ";Database=" + DatabaseName + ";Trusted_Connection=True;");
//         }
//     }
// }