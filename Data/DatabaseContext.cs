using Microsoft.EntityFrameworkCore;
using aspcoremariadb.Models;

namespace aspcoremariadb.Data
{
    public class DatabaseContext : DbContext
    {
     
       public virtual DbSet<Book> Books { get; set; }   

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySql("server=127.0.0.1;port=3306;user=root;password=12345;database=mariatest;")
                .UseLoggerFactory(LoggerFactory.Create(b => b
                .AddConsole()
                .AddFilter(level => level >= LogLevel.Information)))
                .EnableSenstiveDataLogging()
                .EnableDetailedErrors();
        }*/
    }
}
