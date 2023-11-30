﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.Data;

#nullable disable

namespace Store.Migrations
{
    [DbContext(typeof(DataDbContext))]
    partial class DataDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Store.Models.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFeatured")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("ParentCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            IsDeleted = false,
                            IsFeatured = false,
                            Name = "Blue Blanc Serisi",
                            Order = 1,
                            ParentCategoryId = 1,
                            PhotoUrl = "1.jpg",
                            Slug = "blue-blanc-serisi"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            IsDeleted = false,
                            IsFeatured = false,
                            Name = "Ahşap Serisi",
                            Order = 2,
                            ParentCategoryId = 1,
                            PhotoUrl = "1.jpg",
                            Slug = "ahsap-serisi"
                        });
                });

            modelBuilder.Entity("Store.Models.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Store.Models.Entities.County", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("County");
                });

            modelBuilder.Entity("Store.Models.Entities.Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Favorite");
                });

            modelBuilder.Entity("Store.Models.Entities.Neighborhood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountyId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("CountyId");

                    b.ToTable("Neighborhood");
                });

            modelBuilder.Entity("Store.Models.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Store.Models.Entities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("Store.Models.Entities.ParentCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("ParentCategory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Abajurlar",
                            Order = 1,
                            PhotoUrl = "1.jpg",
                            Slug = "abajurlar"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Lambaderler",
                            Order = 2,
                            PhotoUrl = "2.jpg",
                            Slug = "lambaderler"
                        });
                });

            modelBuilder.Entity("Store.Models.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDiscounted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFeatured")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMostSelled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNew")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSpecialOffer")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("PriceWithoutDiscount")
                        .HasColumnType("float");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime?>("SpecialOfferEndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Code = "8622f51e",
                            Description = "modern ve şık",
                            Discount = 10,
                            IsActive = true,
                            IsDeleted = false,
                            IsDiscounted = true,
                            IsFeatured = true,
                            IsMostSelled = true,
                            IsNew = true,
                            IsSpecialOffer = true,
                            Name = "Product-1",
                            Price = 2700.0,
                            PriceWithoutDiscount = 3000.0,
                            Slug = "product-1",
                            SpecialOfferEndDate = new DateTime(2023, 12, 1, 11, 5, 15, 662, DateTimeKind.Local).AddTicks(3656),
                            Stock = 3
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Code = "9dae0207",
                            Description = "modern ve şık",
                            Discount = 9,
                            IsActive = true,
                            IsDeleted = false,
                            IsDiscounted = true,
                            IsFeatured = true,
                            IsMostSelled = true,
                            IsNew = true,
                            IsSpecialOffer = true,
                            Name = "Product-2",
                            Price = 3300.0,
                            PriceWithoutDiscount = 3600.0,
                            Slug = "product-2",
                            SpecialOfferEndDate = new DateTime(2023, 12, 1, 11, 5, 15, 662, DateTimeKind.Local).AddTicks(3691),
                            Stock = 4
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Code = "27ae0101",
                            Description = "modern ve şık",
                            Discount = 23,
                            IsActive = true,
                            IsDeleted = false,
                            IsDiscounted = true,
                            IsFeatured = true,
                            IsMostSelled = true,
                            IsNew = true,
                            IsSpecialOffer = true,
                            Name = "Product-3",
                            Price = 1750.0,
                            PriceWithoutDiscount = 2250.0,
                            Slug = "product-3",
                            SpecialOfferEndDate = new DateTime(2023, 12, 1, 11, 5, 15, 662, DateTimeKind.Local).AddTicks(3694),
                            Stock = 0
                        });
                });

            modelBuilder.Entity("Store.Models.Entities.ProductPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPhoto");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            IsDeleted = false,
                            Order = 1,
                            ProductId = 1,
                            Url = "6e9694b3-f6ea-46ce-8637-fb933352781e.jpg"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            IsDeleted = false,
                            Order = 1,
                            ProductId = 2,
                            Url = "cdf13471-2761-4fab-aa98-ba1bf26933a4.jpg"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            IsDeleted = false,
                            Order = 1,
                            ProductId = 3,
                            Url = "a985a819-7a2c-49d3-8fb0-07deea42c239.jpg"
                        });
                });

            modelBuilder.Entity("Store.Models.Entities.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("Id");

                    b.ToTable("Slider");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "modern ve şık",
                            IsActive = true,
                            IsDeleted = false,
                            Link = "identity/account/login",
                            Order = 1,
                            PhotoUrl = "de4bd898-88b0-4cba-b8c1-c59d15f2d190.jpg",
                            Price = 2750.0,
                            Title = "Yeni Soft Koleksiyon"
                        },
                        new
                        {
                            Id = 2,
                            Description = "sınırlı stoklarla",
                            IsActive = true,
                            IsDeleted = false,
                            Link = "identity/account/login",
                            Order = 2,
                            PhotoUrl = "98a44b7e-91bd-4291-93a6-5482cb678cb2.jpg",
                            Price = 1950.0,
                            Title = "Sezon Sonu İndirimleri"
                        },
                        new
                        {
                            Id = 3,
                            Description = "porselen kalitesiyle",
                            IsActive = true,
                            IsDeleted = false,
                            Link = "identity/account/login",
                            Order = 3,
                            PhotoUrl = "8f8fbaa963f1e51d5ba74ac4bda36287.jpg",
                            Price = 3250.0,
                            Title = "Fırsat Ürünleri"
                        });
                });

            modelBuilder.Entity("Store.Models.Entities.Category", b =>
                {
                    b.HasOne("Store.Models.Entities.ParentCategory", "ParentCategory")
                        .WithMany("Categories")
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Store.Models.Entities.County", b =>
                {
                    b.HasOne("Store.Models.Entities.City", "City")
                        .WithMany("Counties")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Store.Models.Entities.Neighborhood", b =>
                {
                    b.HasOne("Store.Models.Entities.County", "County")
                        .WithMany("Neighborhoods")
                        .HasForeignKey("CountyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("County");
                });

            modelBuilder.Entity("Store.Models.Entities.OrderDetail", b =>
                {
                    b.HasOne("Store.Models.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Store.Models.Entities.Product", b =>
                {
                    b.HasOne("Store.Models.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Store.Models.Entities.ProductPhoto", b =>
                {
                    b.HasOne("Store.Models.Entities.Product", "Product")
                        .WithMany("ProductPhotos")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Store.Models.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Store.Models.Entities.City", b =>
                {
                    b.Navigation("Counties");
                });

            modelBuilder.Entity("Store.Models.Entities.County", b =>
                {
                    b.Navigation("Neighborhoods");
                });

            modelBuilder.Entity("Store.Models.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Store.Models.Entities.ParentCategory", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Store.Models.Entities.Product", b =>
                {
                    b.Navigation("ProductPhotos");
                });
#pragma warning restore 612, 618
        }
    }
}
