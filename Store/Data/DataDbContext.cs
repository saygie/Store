using Microsoft.EntityFrameworkCore;
using Store.Models.Entities;

namespace Store.Data
{
    public class DataDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO: hide password for security
            optionsBuilder.UseSqlServer("Server=localhost,1433;User Id=sa;Password=123QWEasd;Database=StoreDB;TrustServerCertificate=True;MultipleActiveResultSets=true");
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

            modelBuilder.Entity<BasketItem>()
                .HasOne(a => a.Basket)
                .WithMany(b => b.BasketItems)
                .HasForeignKey(a => a.BasketId);

            modelBuilder.Entity<BasketItem>()
                .HasOne(a => a.Product)
                .WithMany(b => b.BasketItems)
                .HasForeignKey(a => a.ProductId);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Neighborhood)
                .WithMany(b => b.Addresses)
                .HasForeignKey(a => a.NeighborhoodId);

            modelBuilder.Entity<Neighborhood>()
                .HasOne(a => a.County)
                .WithMany(b => b.Neighborhoods)
                .HasForeignKey(a => a.CountyId);

            modelBuilder.Entity<County>()
                .HasOne(a => a.City)
                .WithMany(b => b.Counties)
                .HasForeignKey(a => a.CityId);


            Seed(modelBuilder);

        }


        public virtual DbSet<Category> Category => Set<Category>();
        public virtual DbSet<ParentCategory> ParentCategory => Set<ParentCategory>();
        public virtual DbSet<Address> Address => Set<Address>();
        public virtual DbSet<City> City => Set<City>();
        public virtual DbSet<County> County => Set<County>();
        public virtual DbSet<Neighborhood> Neighborhood => Set<Neighborhood>();
        public virtual DbSet<Order> Order => Set<Order>();
        public virtual DbSet<OrderDetail> OrderDetail => Set<OrderDetail>();
        public virtual DbSet<Product> Product => Set<Product>();
        public virtual DbSet<ProductPhoto> ProductPhoto => Set<ProductPhoto>();
        public virtual DbSet<Favorite> Favorite => Set<Favorite>();
        public virtual DbSet<Slider> Slider => Set<Slider>();
        public virtual DbSet<Basket> Basket => Set<Basket>();
        public virtual DbSet<BasketItem> BasketItem => Set<BasketItem>();


        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParentCategory>().HasData(
                new ParentCategory
                {
                    Id = 1,
                    Name = "Abajur",
                    Slug = "abajur",
                    PhotoUrl = "1.jpg",
                    Order = 1,
                    IsActive = true,
                    IsDeleted = false,
                },
                new ParentCategory
                {
                    Id = 2,
                    Name = "Lambader",
                    Slug = "lambader",
                    PhotoUrl = "2.jpg",
                    Order = 2,
                    IsActive = true,
                    IsDeleted = false,
                },
                new ParentCategory
                {
                    Id = 3,
                    Name = "Şamdan & Mumluk",
                    Slug = "dekorasyon",
                    PhotoUrl = "3.jpg",
                    Order = 3,
                    IsActive = true,
                    IsDeleted = false,
                },
                new ParentCategory
                {
                    Id = 4,
                    Name = "Ampül & Led",
                    Slug = "dekorasyon",
                    PhotoUrl = "4.jpg",
                    Order = 4,
                    IsActive = true,
                    IsDeleted = false,
                }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    ParentCategoryId = 1,
                    Name = "Blue Blanc Serisi",
                    Slug = "blue-blanc-serisi",
                    PhotoUrl = "1.jpg",
                    Order = 1,
                    IsActive = true,
                    IsDeleted = false,
                },
                new Category
                {
                    Id = 2,
                    ParentCategoryId = 1,
                    Name = "Ahşap Serisi",
                    Slug = "ahsap-serisi",
                    PhotoUrl = "2.jpg",
                    Order = 2,
                    IsActive = true,
                    IsDeleted = false,
                },
                new Category
                {
                    Id = 3,
                    ParentCategoryId = 1,
                    Name = "Porselen Serisi",
                    Slug = "porselen-serisi",
                    PhotoUrl = "3.jpg",
                    Order = 3,
                    IsActive = true,
                    IsDeleted = false,
                },
                new Category
                {
                    Id = 4,
                    ParentCategoryId = 1,
                    Name = "Cam Serisi",
                    Slug = "cam-serisi",
                    PhotoUrl = "4.jpg",
                    Order = 4,
                    IsActive = true,
                    IsDeleted = false,
                },
                new Category
                {
                    Id = 5,
                    ParentCategoryId = 1,
                    Name = "Metal Serisi",
                    Slug = "metal-serisi",
                    PhotoUrl = "5.jpg",
                    Order = 5,
                    IsActive = true,
                    IsDeleted = false,
                },
                new Category
                {
                    Id = 6,
                    ParentCategoryId = 2,
                    Name = "Ahsap Serisi",
                    Slug = "ahsap-serisi",
                    PhotoUrl = "6.jpg",
                    Order = 1,
                    IsActive = true,
                    IsDeleted = false,
                },
                new Category
                {
                    Id = 7,
                    ParentCategoryId = 2,
                    Name = "Metal Serisi",
                    Slug = "metal-serisi",
                    PhotoUrl = "7.jpg",
                    Order = 2,
                    IsActive = true,
                    IsDeleted = false,
                },
                new Category
                {
                    Id = 8,
                    ParentCategoryId = 3,
                    Name = "Şamdan",
                    Slug = "samdan",
                    PhotoUrl = "8.jpg",
                    Order = 1,
                    IsActive = true,
                    IsDeleted = false,
                },
                new Category
                {
                    Id = 9,
                    ParentCategoryId = 3,
                    Name = "Mumluk",
                    Slug = "mumluk",
                    PhotoUrl = "9.jpg",
                    Order = 2,
                    IsActive = true,
                    IsDeleted = false,
                },
                new Category
                {
                    Id = 10,
                    ParentCategoryId = 4,
                    Name = "Rustik Ampül",
                    Slug = "rustik-ampul",
                    PhotoUrl = "10.jpg",
                    Order = 1,
                    IsActive = true,
                    IsDeleted = false,
                },
                new Category
                {
                    Id = 11,
                    ParentCategoryId = 4,
                    Name = "Led",
                    Slug = "led",
                    PhotoUrl = "11.jpg",
                    Order = 2,
                    IsActive = true,
                    IsDeleted = false,
                }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Code = "8622f51e",
                    CategoryId = 1,
                    Name = "Product-1",
                    Slug = "product-1",
                    Description = "modern ve şık",
                    Stock = 3,
                    Price = 2700,
                    PriceWithoutDiscount = 3000,
                    Discount = 100 - (2700 * 100 / 3000),
                    IsDiscounted = true,
                    IsMostSelled = true,
                    IsFeatured = true,
                    IsNew = true,
                    IsSpecialOffer = true,
                    SpecialOfferEndDate = DateTime.Now.AddHours(22),
                    IsActive = true,
                    IsDeleted = false,
                },
                new Product
                {
                    Id = 2,
                    Code = "9dae0207",
                    CategoryId = 2,
                    Name = "Product-2",
                    Slug = "product-2",
                    Description = "modern ve şık",
                    Stock = 4,
                    Price = 3300,
                    PriceWithoutDiscount = 3600,
                    Discount = 100 - (3300 * 100 / 3600),
                    IsDiscounted = true,
                    IsMostSelled = true,
                    IsFeatured = true,
                    IsNew = true,
                    IsSpecialOffer = true,
                    SpecialOfferEndDate = DateTime.Now.AddHours(22),
                    IsActive = true,
                    IsDeleted = false,
                },
                new Product
                {
                    Id = 3,
                    Code = "27ae0101",
                    CategoryId = 2,
                    Name = "Product-3",
                    Slug = "product-3",
                    Description = "modern ve şık",
                    Stock = 0,
                    Price = 1750,
                    PriceWithoutDiscount = 2250,
                    Discount = 100 - (1750 * 100 / 2250),
                    IsDiscounted = true,
                    IsMostSelled = true,
                    IsFeatured = true,
                    IsNew = true,
                    IsSpecialOffer = true,
                    SpecialOfferEndDate = DateTime.Now.AddHours(22),
                    IsActive = true,
                    IsDeleted = false,
                }
             );

            modelBuilder.Entity<ProductPhoto>().HasData(
                new ProductPhoto
                {
                    Id = 1,
                    ProductId = 1,
                    Url = "6e9694b3-f6ea-46ce-8637-fb933352781e.jpg",
                    Order = 1,
                    IsActive = true,
                    IsDeleted = false,
                },
                new ProductPhoto
                {
                    Id = 2,
                    ProductId = 2,
                    Url = "cdf13471-2761-4fab-aa98-ba1bf26933a4.jpg",
                    Order = 1,
                    IsActive = true,
                    IsDeleted = false,
                },
                new ProductPhoto
                {
                    Id = 3,
                    ProductId = 3,
                    Url = "a985a819-7a2c-49d3-8fb0-07deea42c239.jpg",
                    Order = 1,
                    IsActive = true,
                    IsDeleted = false,
                }
             );

            modelBuilder.Entity<Slider>().HasData(
                new Slider
                {
                    Id = 1,
                    Title = "Yeni Soft Koleksiyon",
                    Description = "modern ve şık",
                    Link = "identity/account/login",
                    PhotoUrl = "de4bd898-88b0-4cba-b8c1-c59d15f2d190.jpg",
                    Price = 2750,
                    IsActive = true,
                    IsDeleted = false,
                    Order = 1,
                },
                new Slider
                {
                    Id = 2,
                    Title = "Sezon Sonu İndirimleri",
                    Description = "sınırlı stoklarla",
                    Link = "identity/account/login",
                    PhotoUrl = "98a44b7e-91bd-4291-93a6-5482cb678cb2.jpg",
                    Price = 1950,
                    IsActive = true,
                    IsDeleted = false,
                    Order = 2,
                },
                new Slider
                {
                    Id = 3,
                    Title = "Fırsat Ürünleri",
                    Description = "porselen kalitesiyle",
                    Link = "identity/account/login",
                    PhotoUrl = "8f8fbaa963f1e51d5ba74ac4bda36287.jpg",
                    Price = 3250,
                    IsActive = true,
                    IsDeleted = false,
                    Order = 3,
                }
            );
            modelBuilder.Entity<City>().HasData(
                new City
                {
                    Id = 1,
                    Name ="Ankara",
                    IsActive = true,
                    IsDeleted = false,
                }
             );
            modelBuilder.Entity<City>().HasData(
                new City
                {
                    Id = 2,
                    Name = "Adana",
                    IsActive = true,
                    IsDeleted = false,
                }
             );
            modelBuilder.Entity<County>().HasData(
                new County
                {
                    Id = 1,
                    CityId = 1,
                    Name = "Yenimahalle",
                    IsActive = true,
                    IsDeleted = false,
                },
                 new County
                 {
                     Id = 2,
                     CityId = 1,
                     Name = "Gölbaşı",
                     IsActive = true,
                     IsDeleted = false,
                 },
                 new County
                 {
                     Id = 3,
                     CityId = 2,
                     Name = "Yüreğir",
                     IsActive = true,
                     IsDeleted = false,
                 }
             );
            modelBuilder.Entity<Neighborhood>().HasData(
                new Neighborhood
                {
                    Id = 1,
                    CountyId = 1,
                    Name = "Çamlıca Mahallesi",
                    IsActive = true,
                    IsDeleted = false,
                },
                new Neighborhood
                {
                    Id = 2,
                    CountyId = 2,
                    Name = "İncek Mahallesi",
                    IsActive = true,
                    IsDeleted = false,
                }
             );
            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    Id = 1,
                    GId = "66016ad3-baa8-4be9-bdf0-38a53ca57ec8",
                    NeighborhoodId = 1,
                    Title = "Ev",
                    FirstName="Ersel",
                    LastName ="Saygı",
                    Phone ="5539288584",
                    UserId = "66016ad3-baa8-4be9-bdf0-38a53ca57ec9",
                    IsCorporate = false,
                    CorporateName = null,
                    TaxAdministration = null,
                    TaxIdentificationNumber = null,
                    AddressDetail = "162 Cad. 14/B Kat:1 No:6",
                    IsActive = true,
                    IsDeleted = false,
                },
                new Address
                {
                    Id = 2,
                    GId = "66016ad3-baa8-4be9-bdf0-38a53ca57ec9",
                    NeighborhoodId = 2,
                    Title = "İş",
                    FirstName = "Ersel",
                    LastName = "Saygı",
                    Phone = "5539288584",
                    UserId = "66016ad3-baa8-4be9-bdf0-38a53ca57ec9",
                    IsCorporate = false,
                    CorporateName = null,
                    TaxAdministration = null,
                    TaxIdentificationNumber = null,
                    AddressDetail = "30648 Cadde T2-0 Blok Belediye No:0/0",
                    IsActive = true,
                    IsDeleted = false,
                }


             );
        }

    }
}
