﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RosaFiesta");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CivilStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    City = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    State = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    PromotionalMails = table.Column<bool>(type: "bit", nullable: false),
                    RefreshTokenExpiryTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                name: "CategoryEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    DiscountCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiscountName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiscountType = table.Column<int>(type: "int", nullable: false),
                    DiscountValue = table.Column<double>(type: "float", nullable: false),
                    MaxTimesApply = table.Column<int>(type: "int", nullable: false),
                    DiscountStartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DiscountEndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DiscountDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DiscountImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountCodeImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountEntity", x => x.DiscountCode);
                });

            migrationBuilder.CreateTable(
                name: "PayMethodEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PayMethodType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayMethodEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupplierEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warranties",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ScopeType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 50, nullable: true),
                    Period = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Conditions = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warranties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "RosaFiesta",
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
                        principalSchema: "RosaFiesta",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "RosaFiesta",
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
                        principalSchema: "RosaFiesta",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "RosaFiesta",
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
                        principalSchema: "RosaFiesta",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "RosaFiesta",
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
                        principalSchema: "RosaFiesta",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "RosaFiesta",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "RosaFiesta",
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
                        principalSchema: "RosaFiesta",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartEntity", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_CartEntity_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "RosaFiesta",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishesList",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishesList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishesList_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "RosaFiesta",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoryEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoryEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategoryEntity_CategoryEntity_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "RosaFiesta",
                        principalTable: "CategoryEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppliedDiscounts",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiscountCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TimesApplied = table.Column<int>(type: "int", nullable: false),
                    AppliedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppliedDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppliedDiscounts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "RosaFiesta",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppliedDiscounts_DiscountEntity_DiscountCode",
                        column: x => x.DiscountCode,
                        principalSchema: "RosaFiesta",
                        principalTable: "DiscountEntity",
                        principalColumn: "DiscountCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    SKU = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PayMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingCost = table.Column<double>(type: "float", nullable: false),
                    VoucherType = table.Column<int>(type: "int", nullable: false),
                    VoucherNumber = table.Column<int>(type: "int", nullable: false),
                    VoucherSeries = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEntity", x => x.SKU);
                    table.ForeignKey(
                        name: "FK_OrderEntity_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "RosaFiesta",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderEntity_PayMethodEntity_PayMethodId",
                        column: x => x.PayMethodId,
                        principalSchema: "RosaFiesta",
                        principalTable: "PayMethodEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    EndedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Thumbnail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    QuantityAvaliable = table.Column<int>(type: "int", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Size = table.Column<float>(type: "real", nullable: true),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    GenderFor = table.Column<int>(type: "int", nullable: true),
                    Material = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    DiscountAppliedId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WarrantyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEntity", x => x.Code);
                    table.ForeignKey(
                        name: "FK_ProductEntity_CategoryEntity_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "RosaFiesta",
                        principalTable: "CategoryEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductEntity_DiscountEntity_DiscountAppliedId",
                        column: x => x.DiscountAppliedId,
                        principalSchema: "RosaFiesta",
                        principalTable: "DiscountEntity",
                        principalColumn: "DiscountCode");
                    table.ForeignKey(
                        name: "FK_ProductEntity_SupplierEntity_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "RosaFiesta",
                        principalTable: "SupplierEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductEntity_Warranties_WarrantyId",
                        column: x => x.WarrantyId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Warranties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductEntityWishListEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    ProductsCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WishListProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEntityWishListEntity", x => new { x.ProductsCode, x.WishListProductsId });
                    table.ForeignKey(
                        name: "FK_ProductEntityWishListEntity_ProductEntity_ProductsCode",
                        column: x => x.ProductsCode,
                        principalSchema: "RosaFiesta",
                        principalTable: "ProductEntity",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductEntityWishListEntity_WishesList_WishListProductsId",
                        column: x => x.WishListProductsId,
                        principalSchema: "RosaFiesta",
                        principalTable: "WishesList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetailEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    PurchaseNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderSku = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    DiscountCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetailEntity", x => new { x.PurchaseNumber, x.ProductId });
                    table.ForeignKey(
                        name: "FK_PurchaseDetailEntity_CartEntity_CartId",
                        column: x => x.CartId,
                        principalSchema: "RosaFiesta",
                        principalTable: "CartEntity",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseDetailEntity_DiscountEntity_DiscountCode",
                        column: x => x.DiscountCode,
                        principalSchema: "RosaFiesta",
                        principalTable: "DiscountEntity",
                        principalColumn: "DiscountCode");
                    table.ForeignKey(
                        name: "FK_PurchaseDetailEntity_OrderEntity_OrderSku",
                        column: x => x.OrderSku,
                        principalSchema: "RosaFiesta",
                        principalTable: "OrderEntity",
                        principalColumn: "SKU");
                    table.ForeignKey(
                        name: "FK_PurchaseDetailEntity_ProductEntity_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "RosaFiesta",
                        principalTable: "ProductEntity",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReviewRating = table.Column<int>(type: "int", nullable: false),
                    ReviewDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ReviewUpdateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ReviewTittle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserReviewerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewEntity_AspNetUsers_UserReviewerId",
                        column: x => x.UserReviewerId,
                        principalSchema: "RosaFiesta",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewEntity_ProductEntity_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "RosaFiesta",
                        principalTable: "ProductEntity",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "WishListProductsEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    WishListId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishListProductsEntity", x => new { x.WishListId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_WishListProductsEntity_ProductEntity_ProductCode",
                        column: x => x.ProductCode,
                        principalSchema: "RosaFiesta",
                        principalTable: "ProductEntity",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishListProductsEntity_WishesList_WishListId",
                        column: x => x.WishListId,
                        principalSchema: "RosaFiesta",
                        principalTable: "WishesList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2301D884-221A-4E7D-B509-0113DCC043E1", null, "Admin", "ADMIN" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "Avatar", "BirthDate", "City", "CivilStatus", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PromotionalMails", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "State", "TwoFactorEnabled", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[] { "b22698b8-42a2-4115-9631-1c2d1e2ac5f7", 0, "Calle 1", 45, "https://i.imgur.com/1Q1Z1Zm.jpg", new DateTimeOffset(new DateTime(1996, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)), "Santo Domingo", 1, "4ff22384-ffc5-4be0-8522-09c1dab35027", new DateTimeOffset(new DateTime(2023, 3, 19, 22, 29, 37, 148, DateTimeKind.Unspecified).AddTicks(1778), new TimeSpan(0, 0, 0, 0, 0)), "System", "user@example.com", true, "Rosalba Pena", false, null, "USER@EXAMPLE.COM", "ROSALBA", "AQAAAAIAAYagAAAAEAGXsd3Hla2TLCvvqO4QEeYXbwcZUqhwXxYwDx+tmUMo4Fhocs95bXykdK8ca7h45Q==", "18497505944", true, false, null, null, "3dce577a-3722-4019-86bb-5c5de56cda83", "Distrito Nacional", false, null, null, "Rosalba" });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "CategoryEntity",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Icon", "Image", "IsActive", "Name", "Slug", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2023, 3, 19, 22, 29, 37, 139, DateTimeKind.Unspecified).AddTicks(9088), new TimeSpan(0, 0, 0, 0, 0)), "System", "Peluches de todos los tipos", "https://i.imgur.com/0jQYs1R.png", "https://i.imgur.com/0jQYs1R.png", true, "Peluches", "peluches", new DateTimeOffset(new DateTime(2023, 3, 19, 22, 29, 37, 139, DateTimeKind.Unspecified).AddTicks(9089), new TimeSpan(0, 0, 0, 0, 0)), "System" });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                columns: new[] { "DiscountCode", "CreatedAt", "CreatedBy", "DiscountCodeImage", "DiscountDescription", "DiscountEndDate", "DiscountImage", "DiscountName", "DiscountStartDate", "DiscountType", "DiscountValue", "MaxTimesApply", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "ROSA", new DateTimeOffset(new DateTime(2023, 3, 19, 22, 29, 37, 140, DateTimeKind.Unspecified).AddTicks(9020), new TimeSpan(0, 0, 0, 0, 0)), "System", "https://i.imgur.com/1ZQZ1Zm.png", "10% de descuento en todos los productos", new DateTimeOffset(new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "https://i.imgur.com/1ZQZ1Zm.png", "Descuento Inicial", new DateTimeOffset(new DateTime(2023, 3, 19, 22, 29, 37, 140, DateTimeKind.Unspecified).AddTicks(9024), new TimeSpan(0, 0, 0, 0, 0)), 1, 200.0, 5, null, null },
                    { "WELCOME", new DateTimeOffset(new DateTime(2023, 3, 19, 22, 29, 37, 140, DateTimeKind.Unspecified).AddTicks(9033), new TimeSpan(0, 0, 0, 0, 0)), "System", "https://i.imgur.com/1ZQZ1Zm.png", "100$ de descuento en todos los productos", new DateTimeOffset(new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "https://i.imgur.com/1ZQZ1Zm.png", "Descuento de Bienvenida", new DateTimeOffset(new DateTime(2023, 3, 19, 22, 29, 37, 140, DateTimeKind.Unspecified).AddTicks(9034), new TimeSpan(0, 0, 0, 0, 0)), 0, 10.0, 1, null, null }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "PayMethodEntity",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "PayMethodType", "UpdatedDate" },
                values: new object[] { new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"), new DateTimeOffset(new DateTime(2023, 3, 19, 18, 29, 37, 142, DateTimeKind.Unspecified).AddTicks(8493), new TimeSpan(0, -4, 0, 0, 0)), "Cash payment", "Cash", 2, null });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "SupplierEntity",
                columns: new[] { "Id", "Address", "CreatedAt", "CreatedBy", "Description", "Email", "IsActive", "Name", "Phone", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"), "La Capital", new DateTimeOffset(new DateTime(2023, 3, 19, 22, 29, 37, 147, DateTimeKind.Unspecified).AddTicks(1220), new TimeSpan(0, 0, 0, 0, 0)), "System", null, "suplidor@hotmail.com", true, "Supplier 1", "8095395539", new DateTimeOffset(new DateTime(2023, 3, 19, 22, 29, 37, 147, DateTimeKind.Unspecified).AddTicks(1221), new TimeSpan(0, 0, 0, 0, 0)), "System" });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "Warranties",
                columns: new[] { "Id", "Conditions", "CreatedAt", "CreatedBy", "Description", "Name", "Period", "ScopeType", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"), "Warranty 1", new DateTimeOffset(new DateTime(2023, 3, 19, 22, 29, 37, 221, DateTimeKind.Unspecified).AddTicks(7913), new TimeSpan(0, 0, 0, 0, 0)), "System", "Warranty 1", "Warranty 1", "1 year", 2, 1, 3, null, null });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                columns: new[] { "Id", "AppliedDate", "DiscountCode", "TimesApplied", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2023, 3, 19, 18, 29, 37, 138, DateTimeKind.Unspecified).AddTicks(9659), new TimeSpan(0, -4, 0, 0, 0)), "ROSA", 2, "b22698b8-42a2-4115-9631-1c2d1e2ac5f7" },
                    { 2, new DateTimeOffset(new DateTime(2023, 3, 19, 18, 29, 37, 138, DateTimeKind.Unspecified).AddTicks(9689), new TimeSpan(0, -4, 0, 0, 0)), "WELCOME", 1, "b22698b8-42a2-4115-9631-1c2d1e2ac5f7" }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2301D884-221A-4E7D-B509-0113DCC043E1", "b22698b8-42a2-4115-9631-1c2d1e2ac5f7" });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "CartEntity",
                columns: new[] { "CartId", "UserId" },
                values: new object[] { 1, "b22698b8-42a2-4115-9631-1c2d1e2ac5f7" });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                columns: new[] { "Code", "Brand", "CategoryId", "Color", "Condition", "CreatedAt", "CreatedBy", "Description", "DiscountAppliedId", "EndedAt", "GenderFor", "Image", "Material", "Name", "Price", "QuantityAvaliable", "Size", "Stock", "SupplierId", "Thumbnail", "Type", "UpdatedAt", "UpdatedBy", "WarrantyId", "Weight" },
                values: new object[,]
                {
                    { "SDA01", "Champion", 1, "White", 1, new DateTimeOffset(new DateTime(2023, 3, 19, 22, 29, 37, 145, DateTimeKind.Unspecified).AddTicks(4932), new TimeSpan(0, 0, 0, 0, 0)), "System", "Polo de manga corta", "ROSA", null, 3, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.amazon.com%2FChampion-Reverse-Weave-Polo-White%2Fdp%2FB07G1J7Q2Q&psig=AOvVaw2D5N7VQ2v0uL7zS9O4yJ7l&ust=1628125928634000&source=images&cd=vfe&ved=0CAsQjRxqFwoTCOjGqfCg1_ICFQAAAAAdAAAAABAD", 6, "Polo", 1000.0, 10, 1.5f, 1, new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"), null, 1, null, null, new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"), 0.5f },
                    { "SDA02", "Flores", 1, "Rosas", 1, new DateTimeOffset(new DateTime(2023, 3, 19, 22, 29, 37, 145, DateTimeKind.Unspecified).AddTicks(4945), new TimeSpan(0, 0, 0, 0, 0)), "System", "Flores de rosas", "WELCOME", null, 3, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.amazon.com%2FChampion-Reverse-Weave-Polo-White%2Fdp%2FB07G1J7Q2Q&psig=AOvVaw2D5N7VQ2v0uL7zS9O4yJ7l&ust=1628125928634000&source=images&cd=vfe&ved=0CAsQjRxqFwoTCOjGqfCg1_ICFQAAAAAdAAAAABAD", 7, "Flores", 500.0, 3, 1.5f, 1, new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"), null, 1, null, null, new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"), 0.5f }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedBy", "Description", "Icon", "Image", "IsActive", "Name", "Slug", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, 1, new DateTimeOffset(new DateTime(2023, 3, 19, 22, 29, 37, 146, DateTimeKind.Unspecified).AddTicks(9016), new TimeSpan(0, 0, 0, 0, 0)), "System", "Electronics", "https://i.imgur.com/0jQYs1R.png", "https://i.imgur.com/0jQYs1R.png", true, "Electronics", "electronics", new DateTimeOffset(new DateTime(2023, 3, 19, 22, 29, 37, 146, DateTimeKind.Unspecified).AddTicks(9018), new TimeSpan(0, 0, 0, 0, 0)), "System" });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                columns: new[] { "ProductId", "PurchaseNumber", "CartId", "CreatedAt", "DiscountCode", "OrderSku", "Quantity", "UnitPrice", "UpdatedAt" },
                values: new object[,]
                {
                    { "SDA01", 1, 1, new DateTimeOffset(new DateTime(2023, 3, 19, 22, 29, 37, 146, DateTimeKind.Unspecified).AddTicks(3260), new TimeSpan(0, 0, 0, 0, 0)), "ROSA", null, 2, 1000.0, null },
                    { "SDA02", 2, 1, new DateTimeOffset(new DateTime(2023, 3, 19, 22, 29, 37, 146, DateTimeKind.Unspecified).AddTicks(3262), new TimeSpan(0, 0, 0, 0, 0)), "WELCOME", null, 1, 500.0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppliedDiscounts_DiscountCode",
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                column: "DiscountCode");

            migrationBuilder.CreateIndex(
                name: "IX_AppliedDiscounts_UserId",
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "RosaFiesta",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "RosaFiesta",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "RosaFiesta",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "RosaFiesta",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "RosaFiesta",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "RosaFiesta",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "RosaFiesta",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartEntity_UserId",
                schema: "RosaFiesta",
                table: "CartEntity",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntity_PayMethodId",
                schema: "RosaFiesta",
                table: "OrderEntity",
                column: "PayMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntity_UserId",
                schema: "RosaFiesta",
                table: "OrderEntity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntity_CategoryId",
                schema: "RosaFiesta",
                table: "ProductEntity",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntity_DiscountAppliedId",
                schema: "RosaFiesta",
                table: "ProductEntity",
                column: "DiscountAppliedId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntity_SupplierId",
                schema: "RosaFiesta",
                table: "ProductEntity",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntity_WarrantyId",
                schema: "RosaFiesta",
                table: "ProductEntity",
                column: "WarrantyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntityWishListEntity_WishListProductsId",
                schema: "RosaFiesta",
                table: "ProductEntityWishListEntity",
                column: "WishListProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetailEntity_CartId",
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetailEntity_DiscountCode",
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                column: "DiscountCode");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetailEntity_OrderSku",
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                column: "OrderSku");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetailEntity_ProductId",
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewEntity_ProductId",
                schema: "RosaFiesta",
                table: "ReviewEntity",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewEntity_UserReviewerId",
                schema: "RosaFiesta",
                table: "ReviewEntity",
                column: "UserReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryEntity_CategoryId",
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WishesList_UserId",
                schema: "RosaFiesta",
                table: "WishesList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WishListProductsEntity_ProductCode",
                schema: "RosaFiesta",
                table: "WishListProductsEntity",
                column: "ProductCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppliedDiscounts",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "ProductEntityWishListEntity",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "PurchaseDetailEntity",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "ReviewEntity",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "SubCategoryEntity",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "WishListProductsEntity",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "CartEntity",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "OrderEntity",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "ProductEntity",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "WishesList",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "PayMethodEntity",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "CategoryEntity",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "DiscountEntity",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "SupplierEntity",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "Warranties",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "RosaFiesta");
        }
    }
}
