using System;
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
                name: "CategoryEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ScopeType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 50, nullable: true),
                    Period = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Conditions = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                name: "SubCategoryEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                name: "ProductEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
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
                name: "Options",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    EndedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Thumbnail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    QuantityAvaliable = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Size = table.Column<float>(type: "real", nullable: true),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    GenderFor = table.Column<int>(type: "int", nullable: true),
                    Material = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_ProductEntity_ProductCode",
                        column: x => x.ProductCode,
                        principalSchema: "RosaFiesta",
                        principalTable: "ProductEntity",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsDiscountsEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscountCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OptionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsDiscountsEntity", x => new { x.Id, x.DiscountCode });
                    table.ForeignKey(
                        name: "FK_ProductsDiscountsEntity_DiscountEntity_DiscountCode",
                        column: x => x.DiscountCode,
                        principalSchema: "RosaFiesta",
                        principalTable: "DiscountEntity",
                        principalColumn: "DiscountCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsDiscountsEntity_Options_OptionId",
                        column: x => x.OptionId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Options",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductsDiscountsEntity_ProductEntity_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "RosaFiesta",
                        principalTable: "ProductEntity",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tittle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
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
                    AppliedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppliedDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppliedDiscounts_DiscountEntity_DiscountCode",
                        column: x => x.DiscountCode,
                        principalSchema: "RosaFiesta",
                        principalTable: "DiscountEntity",
                        principalColumn: "DiscountCode",
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
                    RefreshToken = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    PromotionalMails = table.Column<bool>(type: "bit", nullable: false),
                    RefreshTokenExpiryTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DefaultAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DefaultPayMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Addresses_DefaultAddressId",
                        column: x => x.DefaultAddressId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                name: "PayMethodEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PayMethodType = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayMethodEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayMethodEntity_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "RosaFiesta",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewDescription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ReviewRating = table.Column<float>(type: "real", nullable: false),
                    ReviewDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ReviewUpdateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ReviewTittle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserReviewerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_ReviewEntity_Options_OptionId",
                        column: x => x.OptionId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Options",
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
                name: "OrderEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    SKU = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PayMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShippingCost = table.Column<double>(type: "float", nullable: false),
                    TaxesCost = table.Column<double>(type: "float", nullable: false),
                    VoucherType = table.Column<int>(type: "int", nullable: false),
                    VoucherNumber = table.Column<int>(type: "int", nullable: false),
                    VoucherSeries = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEntity", x => x.SKU);
                    table.ForeignKey(
                        name: "FK_OrderEntity_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "WishListProductsEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    WishListId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishListProductsEntity", x => new { x.WishListId, x.OptionId });
                    table.ForeignKey(
                        name: "FK_WishListProductsEntity_Options_OptionId",
                        column: x => x.OptionId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishListProductsEntity_WishesList_WishListId",
                        column: x => x.WishListId,
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
                    CartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetailEntity", x => x.PurchaseNumber);
                    table.ForeignKey(
                        name: "FK_PurchaseDetailEntity_CartEntity_CartId",
                        column: x => x.CartId,
                        principalSchema: "RosaFiesta",
                        principalTable: "CartEntity",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "PurchaseDetailOptions",
                schema: "RosaFiesta",
                columns: table => new
                {
                    PurchaseNumber = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    AppliedId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetailOptions", x => new { x.PurchaseNumber, x.OptionId });
                    table.ForeignKey(
                        name: "FK_PurchaseDetailOptions_AppliedDiscounts_AppliedId",
                        column: x => x.AppliedId,
                        principalSchema: "RosaFiesta",
                        principalTable: "AppliedDiscounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseDetailOptions_Options_OptionId",
                        column: x => x.OptionId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseDetailOptions_PurchaseDetailEntity_PurchaseNumber",
                        column: x => x.PurchaseNumber,
                        principalSchema: "RosaFiesta",
                        principalTable: "PurchaseDetailEntity",
                        principalColumn: "PurchaseNumber",
                        onDelete: ReferentialAction.Restrict);
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
                columns: new[] { "Id", "AccessFailedCount", "Age", "Avatar", "BirthDate", "CivilStatus", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "DefaultAddressId", "DefaultPayMethodId", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PromotionalMails", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[] { "b22698b8-42a2-4115-9631-1c2d1e2ac5f7", 0, 45, "https://i.imgur.com/1Q1Z1Zm.jpg", new DateTimeOffset(new DateTime(1996, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)), 1, "c477c9ea-683c-4258-94c4-e8a3fc9e0614", new DateTimeOffset(new DateTime(2023, 4, 7, 16, 10, 49, 761, DateTimeKind.Unspecified).AddTicks(3907), new TimeSpan(0, 0, 0, 0, 0)), "System", null, null, "user@example.com", true, "Rosalba Pena", false, null, "USER@EXAMPLE.COM", "ROSALBA", "AQAAAAIAAYagAAAAEDD2Z6EeOyqnXivkxiV48PdonpLDq2blf4yLldl2Jj8aKFfd1rolsK9OTVEXeeeaLQ==", "18497505944", true, false, null, null, "4682ebe6-fae1-40ac-8924-f5421b0a6038", false, null, null, "Rosalba" });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "CategoryEntity",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Icon", "Image", "IsActive", "Name", "Slug", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2023, 4, 7, 16, 10, 49, 743, DateTimeKind.Unspecified).AddTicks(2152), new TimeSpan(0, 0, 0, 0, 0)), "System", "Peluches de todos los tipos", "https://i.imgur.com/0jQYs1R.png", "https://i.imgur.com/0jQYs1R.png", true, "Peluches", "peluches", new DateTimeOffset(new DateTime(2023, 4, 7, 16, 10, 49, 743, DateTimeKind.Unspecified).AddTicks(2154), new TimeSpan(0, 0, 0, 0, 0)), "System" });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                columns: new[] { "DiscountCode", "CreatedAt", "CreatedBy", "DiscountDescription", "DiscountEndDate", "DiscountImage", "DiscountName", "DiscountStartDate", "DiscountType", "DiscountValue", "MaxTimesApply", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "ROSA", new DateTimeOffset(new DateTime(2023, 4, 7, 16, 10, 49, 745, DateTimeKind.Unspecified).AddTicks(6671), new TimeSpan(0, 0, 0, 0, 0)), "System", "10% de descuento en todos los productos", new DateTimeOffset(new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "https://i.imgur.com/1ZQZ1Zm.png", "Descuento Inicial", new DateTimeOffset(new DateTime(2023, 4, 7, 16, 10, 49, 745, DateTimeKind.Unspecified).AddTicks(6675), new TimeSpan(0, 0, 0, 0, 0)), 1, 200.0, 5, null, null },
                    { "WELCOME", new DateTimeOffset(new DateTime(2023, 4, 7, 16, 10, 49, 745, DateTimeKind.Unspecified).AddTicks(6687), new TimeSpan(0, 0, 0, 0, 0)), "System", "100$ de descuento en todos los productos", new DateTimeOffset(new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "https://i.imgur.com/1ZQZ1Zm.png", "Descuento de Bienvenida", new DateTimeOffset(new DateTime(2023, 4, 7, 16, 10, 49, 745, DateTimeKind.Unspecified).AddTicks(6688), new TimeSpan(0, 0, 0, 0, 0)), 0, 10.0, 1, null, null }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "SupplierEntity",
                columns: new[] { "Id", "Address", "CreatedAt", "CreatedBy", "Description", "Email", "IsActive", "Name", "Phone", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"), "La Capital", new DateTimeOffset(new DateTime(2023, 4, 7, 16, 10, 49, 754, DateTimeKind.Unspecified).AddTicks(2087), new TimeSpan(0, 0, 0, 0, 0)), "System", null, "suplidor@hotmail.com", true, "Supplier 1", "8095395539", new DateTimeOffset(new DateTime(2023, 4, 7, 16, 10, 49, 754, DateTimeKind.Unspecified).AddTicks(2089), new TimeSpan(0, 0, 0, 0, 0)), "System" });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "Warranties",
                columns: new[] { "Id", "Conditions", "CreatedAt", "CreatedBy", "Description", "Name", "Period", "ScopeType", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"), "Warranty 1", new DateTimeOffset(new DateTime(2023, 4, 7, 16, 10, 49, 839, DateTimeKind.Unspecified).AddTicks(7202), new TimeSpan(0, 0, 0, 0, 0)), "System", "Warranty 1", "Warranty 1", "1 year", 2, 1, 3, null, null });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                columns: new[] { "Id", "AppliedDate", "DiscountCode", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2023, 4, 7, 12, 10, 49, 741, DateTimeKind.Unspecified).AddTicks(4451), new TimeSpan(0, -4, 0, 0, 0)), "ROSA", "b22698b8-42a2-4115-9631-1c2d1e2ac5f7" },
                    { 2, new DateTimeOffset(new DateTime(2023, 4, 7, 12, 10, 49, 741, DateTimeKind.Unspecified).AddTicks(4483), new TimeSpan(0, -4, 0, 0, 0)), "WELCOME", "b22698b8-42a2-4115-9631-1c2d1e2ac5f7" },
                    { 3, new DateTimeOffset(new DateTime(2023, 4, 7, 12, 10, 49, 741, DateTimeKind.Unspecified).AddTicks(4485), new TimeSpan(0, -4, 0, 0, 0)), "WELCOME", "b22698b8-42a2-4115-9631-1c2d1e2ac5f7" }
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
                table: "PayMethodEntity",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "PayMethodType", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"), new DateTimeOffset(new DateTime(2023, 4, 7, 12, 10, 49, 748, DateTimeKind.Unspecified).AddTicks(3623), new TimeSpan(0, -4, 0, 0, 0)), "Cash payment", "Cash", 2, null, "b22698b8-42a2-4115-9631-1c2d1e2ac5f7" });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                columns: new[] { "Code", "Brand", "CategoryId", "CreatedAt", "CreatedBy", "SupplierId", "Title", "Type", "UpdatedAt", "UpdatedBy", "WarrantyId" },
                values: new object[,]
                {
                    { "SDA01", "Champion", 1, new DateTimeOffset(new DateTime(2023, 4, 7, 16, 10, 49, 750, DateTimeKind.Unspecified).AddTicks(4373), new TimeSpan(0, 0, 0, 0, 0)), "System", new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"), "Polo", 1, null, null, new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6") },
                    { "SDA02", "Flores", 1, new DateTimeOffset(new DateTime(2023, 4, 7, 16, 10, 49, 750, DateTimeKind.Unspecified).AddTicks(4379), new TimeSpan(0, 0, 0, 0, 0)), "System", new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"), "Flores", 1, null, null, new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6") }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedBy", "Description", "Icon", "Image", "IsActive", "Name", "Slug", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, 1, new DateTimeOffset(new DateTime(2023, 4, 7, 16, 10, 49, 753, DateTimeKind.Unspecified).AddTicks(9646), new TimeSpan(0, 0, 0, 0, 0)), "System", "Electronics", "https://i.imgur.com/0jQYs1R.png", "https://i.imgur.com/0jQYs1R.png", true, "Electronics", "electronics", new DateTimeOffset(new DateTime(2023, 4, 7, 16, 10, 49, 753, DateTimeKind.Unspecified).AddTicks(9648), new TimeSpan(0, 0, 0, 0, 0)), "System" });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "Options",
                columns: new[] { "Id", "Color", "Condition", "Description", "EndedAt", "GenderFor", "Image", "Material", "Price", "ProductCode", "QuantityAvaliable", "Size", "Thumbnail", "Weight" },
                values: new object[,]
                {
                    { 1, "Gold", 1, "Polo de manga larga", null, 3, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.amazon.com%2FChampion-Reverse-Weave-Polo-White%2Fdp%2FB07G1J7Q2Q&psig=AOvVaw2D5N7VQ2v0uL7zS9O4yJ7l&ust=162812", 6, 1200.0, "SDA01", 8, 1.7f, null, 0.7f },
                    { 2, "White", 1, "Polo de manga corta", null, 3, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.amazon.com%2FChampion-Reverse-Weave-Polo-White%2Fdp%2FB07G1J7Q2Q&psig=AOvVaw2D5N7VQ2v0uL7zS9O4yJ7l&ust=1628125928634000&source=images&cd=vfe&ved=0CAsQjRxqFwoTCOjGqfCg1_ICFQAAAAAdAAAAABAD", 6, 800.0, "SDA01", 10, 1.5f, null, 0.5f },
                    { 3, "Green", 2, "Polo XL", null, 3, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.amazon.com%2FChampion-Reverse-Weave-Polo-White%2Fdp%2FB07G1J7Q2Q&psig=AOvVaw2D5N7VQ2v0uL7zS9O4yJ7l&ust=1628125928634000&source=images&cd=vfe&ved=0CAsQjRxqFwoTCOjGqfCg1_ICFQAAAAAdAAAAABAD", 6, 1400.0, "SDA02", 10, 2f, null, 1f }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                columns: new[] { "PurchaseNumber", "CartId", "OrderSku", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, null, "SDA01" },
                    { 2, 1, null, "SDA02" }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                columns: new[] { "DiscountCode", "Id", "OptionId", "ProductId" },
                values: new object[,]
                {
                    { "ROSA", new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"), 1, "SDA01" },
                    { "WELCOME", new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f5"), 2, "SDA01" },
                    { "WELCOME", new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"), 3, "SDA02" }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                columns: new[] { "OptionId", "PurchaseNumber", "AppliedId", "CreatedAt", "Quantity", "UnitPrice", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTimeOffset(new DateTime(2023, 4, 7, 12, 10, 49, 753, DateTimeKind.Unspecified).AddTicks(2978), new TimeSpan(0, -4, 0, 0, 0)), 3, 1200.0, null },
                    { 2, 1, 2, new DateTimeOffset(new DateTime(2023, 4, 7, 12, 10, 49, 753, DateTimeKind.Unspecified).AddTicks(3001), new TimeSpan(0, -4, 0, 0, 0)), 4, 800.0, null },
                    { 3, 2, 3, new DateTimeOffset(new DateTime(2023, 4, 7, 12, 10, 49, 753, DateTimeKind.Unspecified).AddTicks(3003), new TimeSpan(0, -4, 0, 0, 0)), 2, 800.0, null }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                columns: new[] { "Id", "OptionId", "ReviewDate", "ReviewDescription", "ReviewRating", "ReviewTittle", "ReviewUpdateDate", "UserReviewerId" },
                values: new object[,]
                {
                    { new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f2"), 1, new DateTimeOffset(new DateTime(2023, 4, 7, 16, 10, 49, 753, DateTimeKind.Unspecified).AddTicks(5425), new TimeSpan(0, 0, 0, 0, 0)), "So so i liked the expierience a bit", 3f, "Kinda love it", new DateTimeOffset(new DateTime(2023, 4, 7, 16, 10, 49, 753, DateTimeKind.Unspecified).AddTicks(5426), new TimeSpan(0, 0, 0, 0, 0)), "b22698b8-42a2-4115-9631-1c2d1e2ac5f7" },
                    { new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f8"), 1, new DateTimeOffset(new DateTime(2023, 4, 7, 16, 10, 49, 753, DateTimeKind.Unspecified).AddTicks(5417), new TimeSpan(0, 0, 0, 0, 0)), "Excellent", 5f, "Nice product", new DateTimeOffset(new DateTime(2023, 4, 7, 16, 10, 49, 753, DateTimeKind.Unspecified).AddTicks(5418), new TimeSpan(0, 0, 0, 0, 0)), "b22698b8-42a2-4115-9631-1c2d1e2ac5f7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                schema: "RosaFiesta",
                table: "Addresses",
                column: "UserId");

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
                name: "IX_AspNetUsers_DefaultAddressId",
                schema: "RosaFiesta",
                table: "AspNetUsers",
                column: "DefaultAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DefaultPayMethodId",
                schema: "RosaFiesta",
                table: "AspNetUsers",
                column: "DefaultPayMethodId",
                unique: true,
                filter: "[DefaultPayMethodId] IS NOT NULL");

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
                name: "IX_Options_ProductCode",
                schema: "RosaFiesta",
                table: "Options",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntity_AddressId",
                schema: "RosaFiesta",
                table: "OrderEntity",
                column: "AddressId");

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
                name: "IX_PayMethodEntity_UserId",
                schema: "RosaFiesta",
                table: "PayMethodEntity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntity_CategoryId",
                schema: "RosaFiesta",
                table: "ProductEntity",
                column: "CategoryId");

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
                name: "IX_ProductsDiscountsEntity_DiscountCode",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                column: "DiscountCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsDiscountsEntity_OptionId",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsDiscountsEntity_ProductId",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetailEntity_CartId",
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                column: "CartId");

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
                name: "IX_PurchaseDetailOptions_AppliedId",
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                column: "AppliedId",
                unique: true,
                filter: "[AppliedId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetailOptions_OptionId",
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewEntity_OptionId",
                schema: "RosaFiesta",
                table: "ReviewEntity",
                column: "OptionId");

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
                name: "IX_WishListProductsEntity_OptionId",
                schema: "RosaFiesta",
                table: "WishListProductsEntity",
                column: "OptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId",
                schema: "RosaFiesta",
                table: "Addresses",
                column: "UserId",
                principalSchema: "RosaFiesta",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppliedDiscounts_AspNetUsers_UserId",
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                column: "UserId",
                principalSchema: "RosaFiesta",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "RosaFiesta",
                table: "AspNetUserClaims",
                column: "UserId",
                principalSchema: "RosaFiesta",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "RosaFiesta",
                table: "AspNetUserLogins",
                column: "UserId",
                principalSchema: "RosaFiesta",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "RosaFiesta",
                table: "AspNetUserRoles",
                column: "UserId",
                principalSchema: "RosaFiesta",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PayMethodEntity_DefaultPayMethodId",
                schema: "RosaFiesta",
                table: "AspNetUsers",
                column: "DefaultPayMethodId",
                principalSchema: "RosaFiesta",
                principalTable: "PayMethodEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId",
                schema: "RosaFiesta",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_PayMethodEntity_AspNetUsers_UserId",
                schema: "RosaFiesta",
                table: "PayMethodEntity");

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
                name: "ProductsDiscountsEntity",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "PurchaseDetailOptions",
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
                name: "AppliedDiscounts",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "PurchaseDetailEntity",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "Options",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "WishesList",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "DiscountEntity",
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
                name: "CategoryEntity",
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

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "PayMethodEntity",
                schema: "RosaFiesta");
        }
    }
}
