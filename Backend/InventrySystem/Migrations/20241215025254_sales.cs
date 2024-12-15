﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicPOS.Migrations
{
    /// <inheritdoc />
    public partial class sales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneratedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isPaid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Customers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Devices_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Devices_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Devices_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DateCreated", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6a670f0d-a08f-4bba-b1fd-9b6df6e42d70", null, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cashier", "CASHIER" },
                    { "cfa9978f-2afd-4786-9cf9-97b4493f4d34", null, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a2bd32c0-d75e-4966-8274-758e273da3fb", 0, "a9b1146e-1ece-4f17-b30a-273532dd70dc", "admin@test.com", true, "John", "Doe", false, null, "ADMIN@TEST.COM", "ADMIN@TEST.COM", "AQAAAAIAAYagAAAAEJJJSVw+VYFvLufcGS0dMy3VWhVBNOt/7t82kQmZSW2q4FCBjrvH9tUrWZtrrOcKEQ==", null, false, "", false, "admin@test.com" },
                    { "d7930984-3648-45c8-b33e-7b902e1166b4", 0, "5ffe4750-8e4a-4707-8293-4c7c881d98bb", "thayuran1998@gmail.com", true, "S", "T", false, null, "THAYURAN1998@GMAIL.COM", "THAYURAN1998@GMAIL.COM", "AQAAAAIAAYagAAAAEBp4VSQU9cpJYt8tWHdGvUL4TyvD66N4+6xcwb58HJsvZD0NyR6R7fAOx0WtH1tamA==", null, false, "", false, "thayuran1998@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("14c1b3fb-57d0-48f5-aa4a-130a1ab629c0"), "Dell" },
                    { new Guid("302a431a-2f54-4768-8a34-b6414f3909df"), "Samsung" },
                    { new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"), "Lenovo" },
                    { new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"), "Apple" },
                    { new Guid("ffb0451c-5f0b-457d-a513-e308e9b87326"), "HP" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("42a2b158-1964-47da-8c4e-31a249aa1b3a"), "Printers" },
                    { new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"), "Laptops" },
                    { new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"), "Desktops" },
                    { new Guid("f8f32941-7bad-471e-9d15-07b0ed660516"), "Mobile Phone" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "ContactInfo", "Name" },
                values: new object[,]
                {
                    { new Guid("029e2d94-fd9d-41bd-9b4a-58b2f738c662"), "Nelliady", "Aura PC Factory" },
                    { new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"), "Adiyapatham Road,Kokuvil", "Mr Cherry Computer" },
                    { new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0"), "Parameswara junction,Thirunelvely", "NALIN IT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cfa9978f-2afd-4786-9cf9-97b4493f4d34", "a2bd32c0-d75e-4966-8274-758e273da3fb" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "BrandId", "CategoryId", "IsAvailable", "Name", "Price", "Quantity", "SerialNumber", "Status", "SupplierId", "imageUrl" },
                values: new object[,]
                {
                    { new Guid("02e96f30-e7d8-4342-adc7-9a35de39913a"), new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"), new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"), true, "I3 13th Gen", 110000.0, 3, "SN567890", false, new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0"), "https://res.cloudinary.com/dtm5fjebv/image/upload/v1734063664/images/nv8ozozlc95wbokb7xts.jpg" },
                    { new Guid("06c4e3f5-89ac-4f1f-8ad5-09185ad34b09"), new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"), new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"), true, "I7 10th Gen", 120000.0, 2, "SN246810", false, new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0"), "https://res.cloudinary.com/dtm5fjebv/image/upload/v1733854818/images/y2ajycr8e3xbb1585gxg.png" },
                    { new Guid("2c848b1a-9527-41bb-a54e-32ebfe745f14"), new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"), new Guid("f8f32941-7bad-471e-9d15-07b0ed660516"), true, "Samsung Galaxy A06", 64000.0, 4, "SN135790", true, new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"), "https://res.cloudinary.com/dtm5fjebv/image/upload/v1733854971/images/yiyrnaiw7zoubg4q1l9c.png" },
                    { new Guid("3ef67796-b563-482c-886c-d9c2316ba817"), new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"), new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"), true, "I5 12th Gen", 140000.0, 4, "SN112233", false, new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0"), "https://res.cloudinary.com/dtm5fjebv/image/upload/v1734063778/images/fif9q0fxmfdii59arhlv.jpg" },
                    { new Guid("3fd15e6f-fe14-41ac-aa00-829779e4255b"), new Guid("302a431a-2f54-4768-8a34-b6414f3909df"), new Guid("f8f32941-7bad-471e-9d15-07b0ed660516"), true, "Iphone 15 pro", 250000.0, 3, "SN789012", true, new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"), "https://res.cloudinary.com/dtm5fjebv/image/upload/v1733854972/images/rwpvbxtu1xuclw94vi6f.png" },
                    { new Guid("45125592-3dca-47ad-b2f5-3a03438ae070"), new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"), new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"), true, "Lenovo ThinkPad", 250000.0, 20, "SN123456", true, new Guid("029e2d94-fd9d-41bd-9b4a-58b2f738c662"), "https://res.cloudinary.com/dtm5fjebv/image/upload/v1733854815/images/c4w6df0r9nm4l3ftryto.jpg" },
                    { new Guid("53668ede-fd01-4881-9869-80d17a7afb63"), new Guid("ffb0451c-5f0b-457d-a513-e308e9b87326"), new Guid("42a2b158-1964-47da-8c4e-31a249aa1b3a"), true, "HP Smart Tank ", 60000.0, 8, "SN456789", false, new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"), "https://res.cloudinary.com/dtm5fjebv/image/upload/v1733854813/images/wp7jvyj4r2fa5zxbpsvy.jpg" },
                    { new Guid("552b4189-3198-4606-965c-a893e5428100"), new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"), new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"), true, "Lenovo LOQ", 280000.0, 5, "SN345678", false, new Guid("029e2d94-fd9d-41bd-9b4a-58b2f738c662"), "https://res.cloudinary.com/dtm5fjebv/image/upload/v1733854812/images/rol33mjrwr9380xp4xnv.jpg" },
                    { new Guid("65d349b4-de62-45c9-8672-bc617fcdd7a2"), new Guid("ffb0451c-5f0b-457d-a513-e308e9b87326"), new Guid("42a2b158-1964-47da-8c4e-31a249aa1b3a"), true, "Canon Inkjet", 50000.0, 6, "SN987654", false, new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"), "https://res.cloudinary.com/dtm5fjebv/image/upload/v1733854811/images/qmibmebvowduiziqsurw.jpg" },
                    { new Guid("a818d1d5-e05e-4b4f-a8fc-a21f85d5d5e1"), new Guid("ffb0451c-5f0b-457d-a513-e308e9b87326"), new Guid("42a2b158-1964-47da-8c4e-31a249aa1b3a"), true, "HP DeskJet ink", 45000.0, 2, "SN135790", false, new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"), "https://res.cloudinary.com/dtm5fjebv/image/upload/v1734063998/images/kko6rsjsh8t2tzhpnjbf.jpg" },
                    { new Guid("aa1d386e-457f-4509-ae4a-0d23846a33fd"), new Guid("302a431a-2f54-4768-8a34-b6414f3909df"), new Guid("f8f32941-7bad-471e-9d15-07b0ed660516"), true, "Iphone 11", 150000.0, 5, "SN456789", true, new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"), "https://res.cloudinary.com/dtm5fjebv/image/upload/v1734063996/images/vgsjribmbko82wpih351.jpg" },
                    { new Guid("e223cde1-d721-4a7c-8ba6-4985813d7faf"), new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"), new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"), true, "Dell Inspiron", 140000.0, 10, "SN789012", true, new Guid("029e2d94-fd9d-41bd-9b4a-58b2f738c662"), "https://res.cloudinary.com/dtm5fjebv/image/upload/v1734058042/scy7zp5v72vlhudufnzy.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_SalesId",
                table: "CartItems",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_BrandId",
                table: "Devices",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_CategoryId",
                table: "Devices",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_SupplierId",
                table: "Devices",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId1",
                table: "Sales",
                column: "CustomerId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
