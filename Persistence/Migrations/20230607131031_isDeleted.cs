using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class isDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RosaFiesta");

            migrationBuilder.CreateTable(
                name: "ActionLogs",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ActivityType = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    UserId = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    ActivityId = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    Action = table.Column<int>(type: "integer", nullable: false),
                    Timestamp = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                    Code = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Type = table.Column<int>(type: "integer", maxLength: 25, nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false),
                    MaxTimesApply = table.Column<int>(type: "integer", nullable: false),
                    Start = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountEntity", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(700)", maxLength: 700, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Image = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    QuantityAvaliable = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupplierEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Email = table.Column<string>(type: "character varying(320)", maxLength: 320, nullable: true),
                    Phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Address = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    ScopeType = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "integer", maxLength: 50, nullable: true),
                    Period = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Conditions = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                    Code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Brand = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Type = table.Column<int>(type: "integer", maxLength: 15, nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: true),
                    WarrantyId = table.Column<Guid>(type: "uuid", nullable: true),
                    SupplierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    EndedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    QuantityAvaliable = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Size = table.Column<float>(type: "real", nullable: true),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Condition = table.Column<int>(type: "integer", maxLength: 20, nullable: false),
                    GenderFor = table.Column<int>(type: "integer", maxLength: 20, nullable: true),
                    Material = table.Column<int>(type: "integer", maxLength: 20, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                name: "OptionImages",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Image = table.Column<string>(type: "text", nullable: false),
                    OptionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionImages_Options_OptionId",
                        column: x => x.OptionId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsDiscountsEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    ProductId = table.Column<string>(type: "character varying(100)", nullable: true),
                    OptionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsDiscountsEntity", x => new { x.Id, x.Code });
                    table.ForeignKey(
                        name: "FK_ProductsDiscountsEntity_DiscountEntity_Code",
                        column: x => x.Code,
                        principalSchema: "RosaFiesta",
                        principalTable: "DiscountEntity",
                        principalColumn: "Code",
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ZipCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Street = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    UserId = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    AppliedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppliedDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppliedDiscounts_DiscountEntity_Code",
                        column: x => x.Code,
                        principalSchema: "RosaFiesta",
                        principalTable: "DiscountEntity",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    Id = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    BirthDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    PromotionalMails = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DefaultAddressId = table.Column<Guid>(type: "uuid", nullable: true),
                    DefaultPayMethodId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                    CartId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    PayMethodType = table.Column<int>(type: "integer", maxLength: 10, nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                name: "Quotes",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ContactNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    ExtraInfo = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    Email = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: true),
                    EventName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    EventDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Location = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "RosaFiesta",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReviewEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    OptionId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewEntity_AspNetUsers_UserId",
                        column: x => x.UserId,
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                    SKU = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    PayMethodId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShippingCost = table.Column<double>(type: "double precision", nullable: false),
                    TaxesCost = table.Column<double>(type: "double precision", nullable: false),
                    VoucherType = table.Column<int>(type: "integer", maxLength: 35, nullable: false),
                    VoucherNumber = table.Column<int>(type: "integer", nullable: false),
                    VoucherSeries = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                name: "QuoteItemEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(type: "integer", maxLength: 250, nullable: false),
                    QuoteId = table.Column<int>(type: "integer", maxLength: 36, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteItemEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuoteItemEntity_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuoteItemEntity_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishListProductsEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    WishListId = table.Column<int>(type: "integer", nullable: false),
                    OptionId = table.Column<int>(type: "integer", nullable: false)
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
                    PurchaseNumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<string>(type: "character varying(100)", nullable: false),
                    OrderSku = table.Column<int>(type: "integer", nullable: true),
                    CartId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                    PurchaseNumber = table.Column<int>(type: "integer", nullable: false),
                    OptionId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<double>(type: "double precision", nullable: false),
                    AppliedId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    IsReturned = table.Column<bool>(type: "boolean", nullable: true)
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
                    { "2301D884-221A-4E7D-B509-0113DCC043E2", null, "ProductsManager", "PRODUCTSMANAGER" },
                    { "2301D884-221A-4E7D-B509-0113DCC043E3", null, "SalesManager", "SALESMANAGER" },
                    { "2301D884-221A-4E7D-B509-0113DCC043E4", null, "MarketingManager", "MARKETINGMANAGER" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", null, "CLIENT", "CLIENT" }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "BirthDate", "ConcurrencyStamp", "CreatedAt", "DefaultAddressId", "DefaultPayMethodId", "Email", "EmailConfirmed", "FullName", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PromotionalMails", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { "2301D884-221A-4E7D-B509-0113DCC043E1", 0, 15, new DateTimeOffset(new DateTime(1996, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)), "bb7cf576-d7f7-4aee-9566-ef862430f39f", new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 263, DateTimeKind.Unspecified).AddTicks(8963), new TimeSpan(0, 0, 0, 0, 0)), null, null, "rosalbapp@gmail.com", true, "Rosalba Pena", false, false, null, "ROSALBAPP@GMAIL.COM", "ROSMERY2", "AQAAAAIAAYagAAAAEAIL2fmR+GlwAuArZ6+q8H0mH0sLYboyxnmbMPGsTm6w96bvHTda3nKn8IW7i9v59w==", "18497505946", true, false, null, null, "26095aa7-c859-41af-bb67-c6a89927c412", false, null, "Rosalba2" },
                    { "2301D884-221A-4E7D-B509-0113DCC043E2", 0, 15, new DateTimeOffset(new DateTime(1996, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)), "d965eb48-f7df-4251-a551-2353ecc18bf6", new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 263, DateTimeKind.Unspecified).AddTicks(8977), new TimeSpan(0, 0, 0, 0, 0)), null, null, "jendrypp@gmail.com", true, "Jendry Pena", false, false, null, "JENDRYPP@GMAIL.COM", "JENDRY", "AQAAAAIAAYagAAAAECeoLebvMpHjkAqCVRUDejH9oVMqiBgaVV0XfvkrfcmGEsJ2yWMQizSVhVRjn4FkXA==", "18497505947", true, false, null, null, "1c583128-10af-440c-9535-ae7b4ef640ee", false, null, "jendry" },
                    { "2301D884-221A-4E7D-B509-0113DCC043E3", 0, 15, new DateTimeOffset(new DateTime(1996, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)), "2cc1481f-43be-4964-8d7b-52f389a8911a", new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 263, DateTimeKind.Unspecified).AddTicks(8990), new TimeSpan(0, 0, 0, 0, 0)), null, null, "rosmerypp@gmail.com", true, "Rosmery Pena", false, false, null, "ROSMERYPP@GMAIL.COM", "ROSMERY", "AQAAAAIAAYagAAAAEEQlRUn2hQdRF71hfF+uFeLQpe1I/RFusdOMiFud0l9ebwzydUu8V5hwfxOn+tmM2w==", "18497505948", true, false, null, null, "e9392aba-5cd1-4b1b-a04a-8d43df1600cf", false, null, "Rosmery" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", 0, 15, new DateTimeOffset(new DateTime(1996, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)), "c0a6023c-4b20-4aea-8b31-06ab6d39146c", new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 263, DateTimeKind.Unspecified).AddTicks(8952), new TimeSpan(0, 0, 0, 0, 0)), null, null, "rosanny@gmail.com", true, "Rosanny Pena", false, false, null, "ROSANNY@GMAIL.COM", "ROSANNY", "AQAAAAIAAYagAAAAEEDuKjnEf7tDU2/Km0XBIKMA0QTFlt/4ZBSBDw6/EaSPsFrqazSBtAKUy0aAUlDeNQ==", "18497505945", true, false, null, null, "eec9a5a8-da70-4e1c-afe9-a692f863439e", false, null, "Rosanny" },
                    { "b22698b8-42a2-4115-9631-1c2d1e2ac5f7", 0, 45, new DateTimeOffset(new DateTime(1996, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)), "4ceb3809-7b4f-4dd3-8f4e-c606fbf47150", new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 263, DateTimeKind.Unspecified).AddTicks(8910), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user@example.com", true, "Rosalba Pena", false, false, null, "USER@EXAMPLE.COM", "ROSALBA", "AQAAAAIAAYagAAAAEKweDuzBsUvS06fY+SLqTBpIHZv20yth5ccA1sf50u9wkOwia9kia/dR6+jvSxflNQ==", "18497505944", true, false, null, null, "89538251-add9-480d-bdeb-f0703823e043", false, null, "Rosalba" }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "CategoryEntity",
                columns: new[] { "Id", "CreatedAt", "Description", "Icon", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 247, DateTimeKind.Unspecified).AddTicks(3102), new TimeSpan(0, 0, 0, 0, 0)), "Peluches de todos los tipos", "https://i.imgur.com/0jQYs1R.png", false, "Peluches", null });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                columns: new[] { "Code", "CreatedAt", "Description", "End", "IsDeleted", "MaxTimesApply", "Name", "Start", "Type", "UpdatedAt", "Value" },
                values: new object[,]
                {
                    { "ROSA", new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 248, DateTimeKind.Unspecified).AddTicks(5207), new TimeSpan(0, 0, 0, 0, 0)), "10% de descuento en todos los productos", new DateTimeOffset(new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, 5, "Descuento Inicial", new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 248, DateTimeKind.Unspecified).AddTicks(5200), new TimeSpan(0, 0, 0, 0, 0)), 1, null, 200.0 },
                    { "WELCOME", new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 248, DateTimeKind.Unspecified).AddTicks(5210), new TimeSpan(0, 0, 0, 0, 0)), "100$ de descuento en todos los productos", new DateTimeOffset(new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, 1, "Descuento de Bienvenida", new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 248, DateTimeKind.Unspecified).AddTicks(5209), new TimeSpan(0, 0, 0, 0, 0)), 0, null, 10.0 }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "SupplierEntity",
                columns: new[] { "Id", "Address", "CreatedAt", "Description", "Email", "IsDeleted", "Name", "Phone", "UpdatedAt" },
                values: new object[] { new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"), "La Capital", new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 258, DateTimeKind.Unspecified).AddTicks(4286), new TimeSpan(0, 0, 0, 0, 0)), null, "suplidor@hotmail.com", false, "Supplier 1", "8095395539", null });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "Warranties",
                columns: new[] { "Id", "Conditions", "CreatedAt", "Description", "IsDeleted", "Name", "Period", "ScopeType", "Status", "Type", "UpdatedAt" },
                values: new object[] { new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"), "Warranty 1", new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 570, DateTimeKind.Unspecified).AddTicks(447), new TimeSpan(0, 0, 0, 0, 0)), "Warranty 1", false, "Warranty 1", "1 year", 2, 1, 3, null });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                columns: new[] { "Id", "AppliedDate", "Code", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2023, 6, 7, 9, 10, 31, 245, DateTimeKind.Unspecified).AddTicks(6017), new TimeSpan(0, -4, 0, 0, 0)), "ROSA", "b22698b8-42a2-4115-9631-1c2d1e2ac5f7" },
                    { 2, new DateTimeOffset(new DateTime(2023, 6, 7, 9, 10, 31, 245, DateTimeKind.Unspecified).AddTicks(6048), new TimeSpan(0, -4, 0, 0, 0)), "WELCOME", "b22698b8-42a2-4115-9631-1c2d1e2ac5f7" },
                    { 3, new DateTimeOffset(new DateTime(2023, 6, 7, 9, 10, 31, 245, DateTimeKind.Unspecified).AddTicks(6049), new TimeSpan(0, -4, 0, 0, 0)), "WELCOME", "b22698b8-42a2-4115-9631-1c2d1e2ac5f7" }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2301D884-221A-4E7D-B509-0113DCC043E2", "2301D884-221A-4E7D-B509-0113DCC043E1" },
                    { "2301D884-221A-4E7D-B509-0113DCC043E3", "2301D884-221A-4E7D-B509-0113DCC043E2" },
                    { "2301D884-221A-4E7D-B509-0113DCC043E4", "2301D884-221A-4E7D-B509-0113DCC043E3" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "7D9B7113-A8F8-4035-99A7-A20DD400F6A3" },
                    { "2301D884-221A-4E7D-B509-0113DCC043E1", "b22698b8-42a2-4115-9631-1c2d1e2ac5f7" }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "CartEntity",
                columns: new[] { "CartId", "UserId" },
                values: new object[,]
                {
                    { 1, "b22698b8-42a2-4115-9631-1c2d1e2ac5f7" },
                    { 2, "7D9B7113-A8F8-4035-99A7-A20DD400F6A3" },
                    { 3, "2301D884-221A-4E7D-B509-0113DCC043E1" },
                    { 4, "2301D884-221A-4E7D-B509-0113DCC043E2" },
                    { 5, "2301D884-221A-4E7D-B509-0113DCC043E3" }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "PayMethodEntity",
                columns: new[] { "Id", "CreatedAt", "Description", "IsDeleted", "Name", "PayMethodType", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"), new DateTimeOffset(new DateTime(2023, 6, 7, 9, 10, 31, 250, DateTimeKind.Unspecified).AddTicks(5288), new TimeSpan(0, -4, 0, 0, 0)), "Cash payment", false, "Cash", 2, null, "b22698b8-42a2-4115-9631-1c2d1e2ac5f7" });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                columns: new[] { "Code", "Brand", "CategoryId", "CreatedAt", "IsDeleted", "SupplierId", "Title", "Type", "UpdatedAt", "WarrantyId" },
                values: new object[,]
                {
                    { "SDA01", "Champion", 1, new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 252, DateTimeKind.Unspecified).AddTicks(1962), new TimeSpan(0, 0, 0, 0, 0)), false, new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"), "Polo", 1, null, new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6") },
                    { "SDA02", "Flores", 1, new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 252, DateTimeKind.Unspecified).AddTicks(1983), new TimeSpan(0, 0, 0, 0, 0)), false, new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"), "Flores", 1, null, new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6") }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Icon", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[] { 1, 1, new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 257, DateTimeKind.Unspecified).AddTicks(5100), new TimeSpan(0, 0, 0, 0, 0)), "Electronics", "https://i.imgur.com/0jQYs1R.png", false, "Electronics", null });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "Options",
                columns: new[] { "Id", "Color", "Condition", "CreatedAt", "Description", "EndedAt", "GenderFor", "IsDeleted", "Material", "Price", "ProductCode", "QuantityAvaliable", "Size", "UpdatedAt", "Weight" },
                values: new object[,]
                {
                    { 1, "Gold", 1, new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 249, DateTimeKind.Unspecified).AddTicks(5298), new TimeSpan(0, 0, 0, 0, 0)), "Polo de manga larga", null, 3, false, 6, 1200.0, "SDA01", 8, 1.7f, null, 0.7f },
                    { 2, "White", 1, new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 249, DateTimeKind.Unspecified).AddTicks(5308), new TimeSpan(0, 0, 0, 0, 0)), "Polo de manga corta", null, 3, false, 6, 800.0, "SDA01", 10, 1.5f, null, 0.5f },
                    { 3, "Green", 2, new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 249, DateTimeKind.Unspecified).AddTicks(5311), new TimeSpan(0, 0, 0, 0, 0)), "Polo XL", null, 3, false, 6, 1400.0, "SDA02", 10, 2f, null, 1f }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                columns: new[] { "PurchaseNumber", "CartId", "CreatedAt", "OrderSku", "ProductId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 253, DateTimeKind.Unspecified).AddTicks(3398), new TimeSpan(0, 0, 0, 0, 0)), null, "SDA01", null },
                    { 2, 1, new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 253, DateTimeKind.Unspecified).AddTicks(3401), new TimeSpan(0, 0, 0, 0, 0)), null, "SDA02", null }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                columns: new[] { "Code", "Id", "OptionId", "ProductId" },
                values: new object[,]
                {
                    { "ROSA", new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"), 1, "SDA01" },
                    { "WELCOME", new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f5"), 2, "SDA01" },
                    { "WELCOME", new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"), 3, "SDA02" }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                columns: new[] { "OptionId", "PurchaseNumber", "AppliedId", "CreatedAt", "IsReturned", "Quantity", "UnitPrice", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTimeOffset(new DateTime(2023, 6, 7, 9, 10, 31, 254, DateTimeKind.Unspecified).AddTicks(5603), new TimeSpan(0, -4, 0, 0, 0)), null, 3, 1200.0, null },
                    { 2, 1, 2, new DateTimeOffset(new DateTime(2023, 6, 7, 9, 10, 31, 254, DateTimeKind.Unspecified).AddTicks(5624), new TimeSpan(0, -4, 0, 0, 0)), null, 4, 800.0, null },
                    { 3, 2, 3, new DateTimeOffset(new DateTime(2023, 6, 7, 9, 10, 31, 254, DateTimeKind.Unspecified).AddTicks(5650), new TimeSpan(0, -4, 0, 0, 0)), null, 2, 800.0, null }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                columns: new[] { "Id", "CreatedAt", "Description", "IsDeleted", "OptionId", "Rating", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f2"), new DateTimeOffset(new DateTime(2023, 6, 7, 9, 10, 31, 255, DateTimeKind.Unspecified).AddTicks(3524), new TimeSpan(0, -4, 0, 0, 0)), "So so i liked the expierience a bit", false, 1, 3f, "Kinda love it", null, "b22698b8-42a2-4115-9631-1c2d1e2ac5f7" },
                    { new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f8"), new DateTimeOffset(new DateTime(2023, 6, 7, 9, 10, 31, 255, DateTimeKind.Unspecified).AddTicks(3509), new TimeSpan(0, -4, 0, 0, 0)), "Excellent", false, 1, 5f, "Nice product", null, "b22698b8-42a2-4115-9631-1c2d1e2ac5f7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                schema: "RosaFiesta",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppliedDiscounts_Code",
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                column: "Code");

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
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "RosaFiesta",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartEntity_UserId",
                schema: "RosaFiesta",
                table: "CartEntity",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryEntity_Name",
                schema: "RosaFiesta",
                table: "CategoryEntity",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OptionImages_OptionId",
                schema: "RosaFiesta",
                table: "OptionImages",
                column: "OptionId");

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
                name: "IX_ProductsDiscountsEntity_Code",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                column: "Code");

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetailOptions_OptionId",
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteItemEntity_QuoteId",
                schema: "RosaFiesta",
                table: "QuoteItemEntity",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteItemEntity_ServiceId",
                schema: "RosaFiesta",
                table: "QuoteItemEntity",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_UserId",
                schema: "RosaFiesta",
                table: "Quotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewEntity_OptionId",
                schema: "RosaFiesta",
                table: "ReviewEntity",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewEntity_UserId",
                schema: "RosaFiesta",
                table: "ReviewEntity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_Name",
                schema: "RosaFiesta",
                table: "Services",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryEntity_CategoryId",
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryEntity_Name",
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupplierEntity_Email",
                schema: "RosaFiesta",
                table: "SupplierEntity",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupplierEntity_Name",
                schema: "RosaFiesta",
                table: "SupplierEntity",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warranties_Name",
                schema: "RosaFiesta",
                table: "Warranties",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_WishesList_Title",
                schema: "RosaFiesta",
                table: "WishesList",
                column: "Title",
                unique: true);

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
                name: "ActionLogs",
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
                name: "OptionImages",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "ProductsDiscountsEntity",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "PurchaseDetailOptions",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "QuoteItemEntity",
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
                name: "Quotes",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "Services",
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
