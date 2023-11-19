using Microsoft.EntityFrameworkCore;
using Store.Models.Entities;

namespace Store.Data
{
    public class DataDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO: hide password for security
            optionsBuilder.UseSqlServer("Server=localhost;User Id=sa;Password=QWEasd123;Database=StoreDB;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //relations
        }

        public DbSet<Product> Product { get; set; }
    }
}
