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
            modelBuilder.Entity<ProductPhoto>()
                .HasOne(a => a.Product)
                .WithMany(b => b.ProductPhotos)
                .HasForeignKey(a => a.ProductId);

            modelBuilder.Entity<Product>()
               .HasOne(a => a.Category)
               .WithMany(b => b.Products)
               .HasForeignKey(a => a.CategoryId);

            modelBuilder.Entity<Category>()
                .HasOne(a => a.ParentCategory)
                .WithMany(b => b.Categories)
                .HasForeignKey(a => a.ParentCategoryId);
        }

        public virtual DbSet<Category> Category => Set<Category>();
        public virtual DbSet<ParentCategory> ParentCategory => Set<ParentCategory>();
        public virtual DbSet<City> City => Set<City>();
        public virtual DbSet<County> County => Set<County>();
        public virtual DbSet<Neighborhood> Neighborhood => Set<Neighborhood>();
        public virtual DbSet<Order> Order => Set<Order>();
        public virtual DbSet<OrderDetail> OrderDetail => Set<OrderDetail>();
        public virtual DbSet<Product> Product => Set<Product>();
        public virtual DbSet<ProductPhoto> ProductPhoto => Set<ProductPhoto>();

    }
}
