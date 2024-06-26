﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.Data;

#nullable disable

namespace Store.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20231210123046_InitialDB")]
    partial class InitialDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Store.Models.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressDetail")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("CorporateName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCorporate")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("NeighborhoodId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("TaxAdministration")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("TaxIdentificationNumber")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("NeighborhoodId");

                    b.ToTable("Address");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressDetail = "162 Cad. 14/B Kat:1 No:6",
                            FirstName = "Ersel",
                            IsActive = true,
                            IsCorporate = false,
                            IsDeleted = false,
                            LastName = "Saygı",
                            NeighborhoodId = 1,
                            Phone = "5539288584",
                            Title = "Ev",
                            UserId = "66016ad3-baa8-4be9-bdf0-38a53ca57ec9"
                        },
                        new
                        {
                            Id = 2,
                            AddressDetail = "30648 Cadde T2-0 Blok Belediye No:0/0",
                            FirstName = "Ersel",
                            IsActive = true,
                            IsCorporate = false,
                            IsDeleted = false,
                            LastName = "Saygı",
                            NeighborhoodId = 2,
                            Phone = "5539288584",
                            Title = "İş",
                            UserId = "66016ad3-baa8-4be9-bdf0-38a53ca57ec9"
                        });
                });

            modelBuilder.Entity("Store.Models.Entities.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Basket");
                });

            modelBuilder.Entity("Store.Models.Entities.BasketItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BasketId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.HasIndex("ProductId");

                    b.ToTable("BasketItem");
                });

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
                            PhotoUrl = "2.jpg",
                            Slug = "ahsap-serisi"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            IsDeleted = false,
                            IsFeatured = false,
                            Name = "Porselen Serisi",
                            Order = 3,
                            ParentCategoryId = 1,
                            PhotoUrl = "3.jpg",
                            Slug = "porselen-serisi"
                        },
                        new
                        {
                            Id = 4,
                            IsActive = true,
                            IsDeleted = false,
                            IsFeatured = false,
                            Name = "Cam Serisi",
                            Order = 4,
                            ParentCategoryId = 1,
                            PhotoUrl = "4.jpg",
                            Slug = "cam-serisi"
                        },
                        new
                        {
                            Id = 5,
                            IsActive = true,
                            IsDeleted = false,
                            IsFeatured = false,
                            Name = "Metal Serisi",
                            Order = 5,
                            ParentCategoryId = 1,
                            PhotoUrl = "5.jpg",
                            Slug = "metal-serisi"
                        },
                        new
                        {
                            Id = 6,
                            IsActive = true,
                            IsDeleted = false,
                            IsFeatured = false,
                            Name = "Ahsap Serisi",
                            Order = 1,
                            ParentCategoryId = 2,
                            PhotoUrl = "6.jpg",
                            Slug = "ahsap-serisi"
                        },
                        new
                        {
                            Id = 7,
                            IsActive = true,
                            IsDeleted = false,
                            IsFeatured = false,
                            Name = "Metal Serisi",
                            Order = 2,
                            ParentCategoryId = 2,
                            PhotoUrl = "7.jpg",
                            Slug = "metal-serisi"
                        },
                        new
                        {
                            Id = 8,
                            IsActive = true,
                            IsDeleted = false,
                            IsFeatured = false,
                            Name = "Şamdan",
                            Order = 1,
                            ParentCategoryId = 3,
                            PhotoUrl = "8.jpg",
                            Slug = "samdan"
                        },
                        new
                        {
                            Id = 9,
                            IsActive = true,
                            IsDeleted = false,
                            IsFeatured = false,
                            Name = "Mumluk",
                            Order = 2,
                            ParentCategoryId = 3,
                            PhotoUrl = "9.jpg",
                            Slug = "mumluk"
                        },
                        new
                        {
                            Id = 10,
                            IsActive = true,
                            IsDeleted = false,
                            IsFeatured = false,
                            Name = "Rustik Ampül",
                            Order = 1,
                            ParentCategoryId = 4,
                            PhotoUrl = "10.jpg",
                            Slug = "rustik-ampul"
                        },
                        new
                        {
                            Id = 11,
                            IsActive = true,
                            IsDeleted = false,
                            IsFeatured = false,
                            Name = "Led",
                            Order = 2,
                            ParentCategoryId = 4,
                            PhotoUrl = "11.jpg",
                            Slug = "led"
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Ankara"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Yenimahalle"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Gölbaşı"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountyId = 1,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Çamlıca Mahallesi"
                        },
                        new
                        {
                            Id = 2,
                            CountyId = 2,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "İncek Mahallesi"
                        });
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
                            Name = "Abajur",
                            Order = 1,
                            PhotoUrl = "1.jpg",
                            Slug = "abajur"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Lambader",
                            Order = 2,
                            PhotoUrl = "2.jpg",
                            Slug = "lambader"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Şamdan & Mumluk",
                            Order = 3,
                            PhotoUrl = "3.jpg",
                            Slug = "dekorasyon"
                        },
                        new
                        {
                            Id = 4,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Ampül & Led",
                            Order = 4,
                            PhotoUrl = "4.jpg",
                            Slug = "dekorasyon"
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
                            SpecialOfferEndDate = new DateTime(2023, 12, 11, 13, 30, 45, 774, DateTimeKind.Local).AddTicks(732),
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
                            SpecialOfferEndDate = new DateTime(2023, 12, 11, 13, 30, 45, 774, DateTimeKind.Local).AddTicks(756),
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
                            SpecialOfferEndDate = new DateTime(2023, 12, 11, 13, 30, 45, 774, DateTimeKind.Local).AddTicks(759),
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

            modelBuilder.Entity("Store.Models.Entities.Address", b =>
                {
                    b.HasOne("Store.Models.Entities.Neighborhood", "Neighborhood")
                        .WithMany("Addresses")
                        .HasForeignKey("NeighborhoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Neighborhood");
                });

            modelBuilder.Entity("Store.Models.Entities.BasketItem", b =>
                {
                    b.HasOne("Store.Models.Entities.Basket", "Basket")
                        .WithMany("BasketItems")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.Models.Entities.Product", "Product")
                        .WithMany("BasketItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("Product");
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

            modelBuilder.Entity("Store.Models.Entities.Basket", b =>
                {
                    b.Navigation("BasketItems");
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

            modelBuilder.Entity("Store.Models.Entities.Neighborhood", b =>
                {
                    b.Navigation("Addresses");
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
                    b.Navigation("BasketItems");

                    b.Navigation("ProductPhotos");
                });
#pragma warning restore 612, 618
        }
    }
}
