﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace MagicPOS.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20241215041122_cloudupload")]
    partial class cloudupload
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Identity.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "a2bd32c0-d75e-4966-8274-758e273da3fb",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d4ba05a9-03a9-446a-95ad-9dd96b1aa463",
                            Email = "admin@test.com",
                            EmailConfirmed = true,
                            FirstName = "John",
                            LastName = "Doe",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@TEST.COM",
                            NormalizedUserName = "ADMIN@TEST.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEBQwiPlcbxBGyI5RUHyjoF8aZKxE+kbIPpUEzGHgm5fQScXBoc1vJSVCLctfRUdOxw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "admin@test.com"
                        },
                        new
                        {
                            Id = "d7930984-3648-45c8-b33e-7b902e1166b4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e6617651-e824-4b97-8213-7696adfd7e14",
                            Email = "thayuran1998@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "S",
                            LastName = "T",
                            LockoutEnabled = false,
                            NormalizedEmail = "THAYURAN1998@GMAIL.COM",
                            NormalizedUserName = "THAYURAN1998@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAENox5yixH3YisKlUXI6Jg6uSKCqbHmYYhOd4rtR5/xX4Xti3cB1DJWnNUr4w5DvhvA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "thayuran1998@gmail.com"
                        });
                });

            modelBuilder.Entity("Entities.Identity.UserRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "cfa9978f-2afd-4786-9cf9-97b4493f4d34",
                            DateCreated = new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "6a670f0d-a08f-4bba-b1fd-9b6df6e42d70",
                            DateCreated = new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cashier",
                            NormalizedName = "CASHIER"
                        });
                });

            modelBuilder.Entity("Entities.Models.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"),
                            Name = "Apple"
                        },
                        new
                        {
                            Id = new Guid("302a431a-2f54-4768-8a34-b6414f3909df"),
                            Name = "Samsung"
                        },
                        new
                        {
                            Id = new Guid("14c1b3fb-57d0-48f5-aa4a-130a1ab629c0"),
                            Name = "Dell"
                        },
                        new
                        {
                            Id = new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"),
                            Name = "Lenovo"
                        },
                        new
                        {
                            Id = new Guid("ffb0451c-5f0b-457d-a513-e308e9b87326"),
                            Name = "HP"
                        });
                });

            modelBuilder.Entity("Entities.Models.Cartitem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid?>("SalesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.HasIndex("SalesId");

                    b.ToTable("CartItems", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"),
                            Name = "Laptops"
                        },
                        new
                        {
                            Id = new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"),
                            Name = "Desktops"
                        },
                        new
                        {
                            Id = new Guid("42a2b158-1964-47da-8c4e-31a249aa1b3a"),
                            Name = "Printers"
                        },
                        new
                        {
                            Id = new Guid("f8f32941-7bad-471e-9d15-07b0ed660516"),
                            Name = "Mobile Phone"
                        });
                });

            modelBuilder.Entity("Entities.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Entities.Models.Device", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("imageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Devices");

                    b.HasData(
                        new
                        {
                            Id = new Guid("23057b6d-3541-443d-a29f-c126a8b4d2ac"),
                            BrandId = new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"),
                            CategoryId = new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"),
                            IsAvailable = true,
                            Name = "Lenovo ThinkPad",
                            Price = 250000.0,
                            Quantity = 20,
                            SerialNumber = "SN123456",
                            Status = true,
                            SupplierId = new Guid("029e2d94-fd9d-41bd-9b4a-58b2f738c662"),
                            imageUrl = "https://res.cloudinary.com/dtm5fjebv/image/upload/v1733854815/images/c4w6df0r9nm4l3ftryto.jpg"
                        },
                        new
                        {
                            Id = new Guid("cc800764-1677-4af8-8c75-67c707d52dc2"),
                            BrandId = new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"),
                            CategoryId = new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"),
                            IsAvailable = true,
                            Name = "Dell Inspiron",
                            Price = 140000.0,
                            Quantity = 10,
                            SerialNumber = "SN789012",
                            Status = true,
                            SupplierId = new Guid("029e2d94-fd9d-41bd-9b4a-58b2f738c662"),
                            imageUrl = "https://res.cloudinary.com/dtm5fjebv/image/upload/v1734058042/scy7zp5v72vlhudufnzy.jpg"
                        },
                        new
                        {
                            Id = new Guid("577bbd55-5dcb-40fc-ad16-a869cbc40761"),
                            BrandId = new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"),
                            CategoryId = new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"),
                            IsAvailable = true,
                            Name = "Lenovo LOQ",
                            Price = 280000.0,
                            Quantity = 5,
                            SerialNumber = "SN345678",
                            Status = false,
                            SupplierId = new Guid("029e2d94-fd9d-41bd-9b4a-58b2f738c662"),
                            imageUrl = "https://res.cloudinary.com/dtm5fjebv/image/upload/v1733854812/images/rol33mjrwr9380xp4xnv.jpg"
                        },
                        new
                        {
                            Id = new Guid("16e8935b-7194-41bf-a2ff-574216455972"),
                            BrandId = new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"),
                            CategoryId = new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"),
                            IsAvailable = true,
                            Name = "I7 10th Gen",
                            Price = 120000.0,
                            Quantity = 2,
                            SerialNumber = "SN246810",
                            Status = false,
                            SupplierId = new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0"),
                            imageUrl = "https://res.cloudinary.com/dtm5fjebv/image/upload/v1733854818/images/y2ajycr8e3xbb1585gxg.png"
                        },
                        new
                        {
                            Id = new Guid("0b611685-169b-4273-bcea-a652dd6615eb"),
                            BrandId = new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"),
                            CategoryId = new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"),
                            IsAvailable = true,
                            Name = "I3 13th Gen",
                            Price = 110000.0,
                            Quantity = 3,
                            SerialNumber = "SN567890",
                            Status = false,
                            SupplierId = new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0"),
                            imageUrl = "https://res.cloudinary.com/dtm5fjebv/image/upload/v1734063664/images/nv8ozozlc95wbokb7xts.jpg"
                        },
                        new
                        {
                            Id = new Guid("c122ec89-a68f-442f-b5b0-961e7e741af9"),
                            BrandId = new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"),
                            CategoryId = new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"),
                            IsAvailable = true,
                            Name = "I5 12th Gen",
                            Price = 140000.0,
                            Quantity = 4,
                            SerialNumber = "SN112233",
                            Status = false,
                            SupplierId = new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0"),
                            imageUrl = "https://res.cloudinary.com/dtm5fjebv/image/upload/v1734063778/images/fif9q0fxmfdii59arhlv.jpg"
                        },
                        new
                        {
                            Id = new Guid("c242e7bb-af9f-459d-8ce6-d0f69f1ba5ff"),
                            BrandId = new Guid("ffb0451c-5f0b-457d-a513-e308e9b87326"),
                            CategoryId = new Guid("42a2b158-1964-47da-8c4e-31a249aa1b3a"),
                            IsAvailable = true,
                            Name = "Canon Inkjet",
                            Price = 50000.0,
                            Quantity = 6,
                            SerialNumber = "SN987654",
                            Status = false,
                            SupplierId = new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"),
                            imageUrl = "https://res.cloudinary.com/dtm5fjebv/image/upload/v1733854811/images/qmibmebvowduiziqsurw.jpg"
                        },
                        new
                        {
                            Id = new Guid("20c793e6-877c-4270-bd2f-df1a6d31a7f3"),
                            BrandId = new Guid("ffb0451c-5f0b-457d-a513-e308e9b87326"),
                            CategoryId = new Guid("42a2b158-1964-47da-8c4e-31a249aa1b3a"),
                            IsAvailable = true,
                            Name = "HP Smart Tank ",
                            Price = 60000.0,
                            Quantity = 8,
                            SerialNumber = "SN456789",
                            Status = false,
                            SupplierId = new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"),
                            imageUrl = "https://res.cloudinary.com/dtm5fjebv/image/upload/v1733854813/images/wp7jvyj4r2fa5zxbpsvy.jpg"
                        },
                        new
                        {
                            Id = new Guid("c0c410ef-8ec7-44f2-a176-a061cbe1f84e"),
                            BrandId = new Guid("ffb0451c-5f0b-457d-a513-e308e9b87326"),
                            CategoryId = new Guid("42a2b158-1964-47da-8c4e-31a249aa1b3a"),
                            IsAvailable = true,
                            Name = "HP DeskJet ink",
                            Price = 45000.0,
                            Quantity = 2,
                            SerialNumber = "SN135790",
                            Status = false,
                            SupplierId = new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"),
                            imageUrl = "https://res.cloudinary.com/dtm5fjebv/image/upload/v1734063998/images/kko6rsjsh8t2tzhpnjbf.jpg"
                        },
                        new
                        {
                            Id = new Guid("4e35b1c8-a42c-4264-8dcd-7b003a42c255"),
                            BrandId = new Guid("302a431a-2f54-4768-8a34-b6414f3909df"),
                            CategoryId = new Guid("f8f32941-7bad-471e-9d15-07b0ed660516"),
                            IsAvailable = true,
                            Name = "Iphone 15 pro",
                            Price = 250000.0,
                            Quantity = 3,
                            SerialNumber = "SN789012",
                            Status = true,
                            SupplierId = new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"),
                            imageUrl = "https://res.cloudinary.com/dtm5fjebv/image/upload/v1733854972/images/rwpvbxtu1xuclw94vi6f.png"
                        },
                        new
                        {
                            Id = new Guid("9b49833e-f19a-4b4a-8bd7-b11565f4d004"),
                            BrandId = new Guid("302a431a-2f54-4768-8a34-b6414f3909df"),
                            CategoryId = new Guid("f8f32941-7bad-471e-9d15-07b0ed660516"),
                            IsAvailable = true,
                            Name = "Iphone 11",
                            Price = 150000.0,
                            Quantity = 5,
                            SerialNumber = "SN456789",
                            Status = true,
                            SupplierId = new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"),
                            imageUrl = "https://res.cloudinary.com/dtm5fjebv/image/upload/v1734063996/images/vgsjribmbko82wpih351.jpg"
                        },
                        new
                        {
                            Id = new Guid("8d954ebd-6462-4626-bd13-283c0db01360"),
                            BrandId = new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"),
                            CategoryId = new Guid("f8f32941-7bad-471e-9d15-07b0ed660516"),
                            IsAvailable = true,
                            Name = "Samsung Galaxy A06",
                            Price = 64000.0,
                            Quantity = 4,
                            SerialNumber = "SN135790",
                            Status = true,
                            SupplierId = new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"),
                            imageUrl = "https://res.cloudinary.com/dtm5fjebv/image/upload/v1733854971/images/yiyrnaiw7zoubg4q1l9c.png"
                        });
                });

            modelBuilder.Entity("Entities.Models.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GeneratedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Entities.Models.Sales", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<Guid>("CustomerId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("isPaid")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId1");

                    b.ToTable("Sales", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"),
                            ContactInfo = "Adiyapatham Road,Kokuvil",
                            Name = "Mr Cherry Computer"
                        },
                        new
                        {
                            Id = new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0"),
                            ContactInfo = "Parameswara junction,Thirunelvely",
                            Name = "NALIN IT"
                        },
                        new
                        {
                            Id = new Guid("029e2d94-fd9d-41bd-9b4a-58b2f738c662"),
                            ContactInfo = "Nelliady",
                            Name = "Aura PC Factory"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "a2bd32c0-d75e-4966-8274-758e273da3fb",
                            RoleId = "cfa9978f-2afd-4786-9cf9-97b4493f4d34"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Cartitem", b =>
                {
                    b.HasOne("Entities.Models.Device", "Product")
                        .WithOne()
                        .HasForeignKey("Entities.Models.Cartitem", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Sales", null)
                        .WithMany("CartItems")
                        .HasForeignKey("SalesId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Entities.Models.Device", b =>
                {
                    b.HasOne("Entities.Models.Brand", "Brand")
                        .WithMany("Devices")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Category", "Category")
                        .WithMany("Devices")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Supplier", "Supplier")
                        .WithMany("Devices")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Entities.Models.Sales", b =>
                {
                    b.HasOne("Entities.Models.Customer", "Customer")
                        .WithMany("Sales")
                        .HasForeignKey("CustomerId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Entities.Identity.UserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Entities.Identity.UserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Brand", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("Entities.Models.Customer", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Entities.Models.Sales", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("Entities.Models.Supplier", b =>
                {
                    b.Navigation("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}
