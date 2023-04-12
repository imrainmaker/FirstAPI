using DAL.Models;
using Microsoft.EntityFrameworkCore;
using DAL.Context.Config;

namespace DAL.Context
{
    public class DataContext : DbContext
    {
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=forma-VDI1202\TFTIC;"
                                        + "Database=DB_First_API;" 
                                        + "Trusted_Connection=True;"
                                        + "TrustServerCertificate=True;");
        }
    }
}
