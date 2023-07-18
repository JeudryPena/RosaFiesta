using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RosaFiesta");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Icon = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false),
                    Start = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Email = table.Column<string>(type: "character varying(320)", maxLength: 320, nullable: true),
                    Phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Address = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warranties",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Period = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warranties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
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
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExtraDetails = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Title = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
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
                name: "Carts",
                schema: "RosaFiesta",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "OptionImages",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    OptionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    EndedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: true),
                    QuantityAvailable = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Condition = table.Column<int>(type: "integer", maxLength: 20, nullable: false),
                    GenderFor = table.Column<int>(type: "integer", maxLength: 20, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_OptionImages_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "RosaFiesta",
                        principalTable: "OptionImages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsService = table.Column<bool>(type: "boolean", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    WarrantyId = table.Column<Guid>(type: "uuid", nullable: true),
                    SupplierId = table.Column<Guid>(type: "uuid", nullable: true),
                    OptionId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Options_OptionId",
                        column: x => x.OptionId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Options",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Warranties_WarrantyId",
                        column: x => x.WarrantyId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Warranties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductsDiscounts",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DiscountId = table.Column<Guid>(type: "uuid", nullable: false),
                    OptionId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ProductEntityId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsDiscounts_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsDiscounts_Options_OptionId",
                        column: x => x.OptionId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsDiscounts_Products_ProductEntityId",
                        column: x => x.ProductEntityId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    PayMethodId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayMethods",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    UserId = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    PromotionalMails = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    WishListId = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Addresses_DefaultAddressId",
                        column: x => x.DefaultAddressId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Users_PayMethods_DefaultPayMethodId",
                        column: x => x.DefaultPayMethodId,
                        principalSchema: "RosaFiesta",
                        principalTable: "PayMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
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
                        name: "FK_Quotes_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    OptionId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Options_OptionId",
                        column: x => x.OptionId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
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
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
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
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "RosaFiesta",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
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
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishesList",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishesList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishesList_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetails",
                schema: "RosaFiesta",
                columns: table => new
                {
                    DetailId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    CartId = table.Column<Guid>(type: "uuid", nullable: true),
                    QuoteId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetails", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_PurchaseDetails_Carts_CartId",
                        column: x => x.CartId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Carts",
                        principalColumn: "CartId");
                    table.ForeignKey(
                        name: "FK_PurchaseDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseDetails_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Quotes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WishesListProducts",
                schema: "RosaFiesta",
                columns: table => new
                {
                    WishListId = table.Column<Guid>(type: "uuid", nullable: false),
                    OptionId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishesListProducts", x => new { x.WishListId, x.OptionId });
                    table.ForeignKey(
                        name: "FK_WishesListProducts_Options_OptionId",
                        column: x => x.OptionId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishesListProducts_WishesList_WishListId",
                        column: x => x.WishListId,
                        principalSchema: "RosaFiesta",
                        principalTable: "WishesList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetailsOptions",
                schema: "RosaFiesta",
                columns: table => new
                {
                    DetailId = table.Column<Guid>(type: "uuid", nullable: false),
                    OptionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<double>(type: "double precision", nullable: false),
                    AppliedId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsReturned = table.Column<bool>(type: "boolean", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetailsOptions", x => new { x.DetailId, x.OptionId });
                    table.ForeignKey(
                        name: "FK_PurchaseDetailsOptions_Discounts_AppliedId",
                        column: x => x.AppliedId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Discounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseDetailsOptions_Options_OptionId",
                        column: x => x.OptionId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseDetailsOptions_PurchaseDetails_DetailId",
                        column: x => x.DetailId,
                        principalSchema: "RosaFiesta",
                        principalTable: "PurchaseDetails",
                        principalColumn: "DetailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2301d884-221a-4e7d-b509-0113dcc043e1", null, false, "ProductsManager", "PRODUCTSMANAGER" },
                    { "2301d884-221a-4e7d-b509-0113dcc043e2", null, false, "SalesManager", "SALESMANAGER" },
                    { "2301d884-221a-4e7d-b509-0113dcc043e3", null, false, "MarketingManager", "MARKETINGMANAGER" },
                    { "7d9b7113-a8f8-4035-99a7-a20dd400f6a3", null, false, "Client", "CLIENT" },
                    { "b22698b8-42a2-4115-9631-1c2d1e2ac5f7", null, false, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "DefaultAddressId", "DefaultPayMethodId", "Email", "EmailConfirmed", "FullName", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PromotionalMails", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UpdatedBy", "UserName", "WishListId" },
                values: new object[,]
                {
                    { "2301d884-221a-4e7d-b509-0113dcc043e1", 0, new DateOnly(1999, 1, 3), "393a3056-9676-47ce-a44a-41611d0a3ed0", new DateTimeOffset(new DateTime(2023, 7, 17, 12, 51, 44, 144, DateTimeKind.Unspecified).AddTicks(1106), new TimeSpan(0, -4, 0, 0, 0)), null, null, null, "rosalbapp@gmail.com", true, "Rosalba Pena", false, false, null, "ROSALBAPP@GMAIL.COM", "ROSALBA2", "AQAAAAIAAYagAAAAEDw8IN4anoo+RbmhQdqdagHtmGw/bCxXysFceKaqihnB9FlDHa29nsa7sr7CvymQgw==", "18497505946", true, false, null, null, "003f602d-8977-4d6d-b133-afa50cb6a929", false, null, null, "Rosalba2", null },
                    { "2301d884-221a-4e7d-b509-0113dcc043e2", 0, new DateOnly(1999, 1, 4), "edc30f8b-2a19-4545-a14e-eb8d0c3fbb55", new DateTimeOffset(new DateTime(2023, 7, 17, 12, 51, 44, 144, DateTimeKind.Unspecified).AddTicks(1128), new TimeSpan(0, -4, 0, 0, 0)), null, null, null, "jendrypp@gmail.com", true, "Jendry Pena", false, false, null, "JENDRYPP@GMAIL.COM", "JENDRY", "AQAAAAIAAYagAAAAEOhHmvqg9aBkSqQku034CT5n91pxh27rynK6ffbWjT2G/ciEkByk2PtkMEuVVK688g==", "18497505947", true, false, null, null, "4f9d5c28-101c-449c-ada3-febbe28e03b2", false, null, null, "Jendry", null },
                    { "2301d884-221a-4e7d-b509-0113dcc043e3", 0, new DateOnly(1999, 1, 5), "edf47029-1ffd-4138-99ce-c0aa426daa3a", new DateTimeOffset(new DateTime(2023, 7, 17, 12, 51, 44, 144, DateTimeKind.Unspecified).AddTicks(1137), new TimeSpan(0, -4, 0, 0, 0)), null, null, null, "rosmerypp@gmail.com", true, "Rosmery Pena", false, false, null, "ROSMERYPP@GMAIL.COM", "ROSMERY", "AQAAAAIAAYagAAAAELCJuSWaA4coSyDqqFG/hBCgTuRFijlkGy8hVENGzoCuykz2SIeSpqv94AsHqVGqGg==", "18497505948", true, false, null, null, "89516410-f20f-4e2c-8f56-72db2040609d", false, null, null, "Rosmery", null },
                    { "7d9b7113-a8f8-4035-99a7-a20dd400f6a3", 0, new DateOnly(1999, 1, 2), "c345d409-a072-4a3a-a1c8-017ef45c1b9d", new DateTimeOffset(new DateTime(2023, 7, 17, 12, 51, 44, 144, DateTimeKind.Unspecified).AddTicks(1069), new TimeSpan(0, -4, 0, 0, 0)), null, null, null, "rosanny@gmail.com", true, "Rosanny Pena", false, false, null, "ROSANNY@GMAIL.COM", "ROSANNY", "AQAAAAIAAYagAAAAEFolABg9UVxdDOaMpQhCQWUs2+2WPNZ/Fq+tQfypxcy8aPnwm3E/I5FrY1CRhFTicA==", "18497505945", true, false, null, null, "8134588c-c2b3-45ec-9a10-1ab064c619e4", false, null, null, "Rosanny", null },
                    { "b22698b8-42a2-4115-9631-1c2d1e2ac5f7", 0, new DateOnly(1999, 1, 1), "27a50021-3d13-4576-994f-6baa8193beba", new DateTimeOffset(new DateTime(2023, 7, 17, 12, 51, 44, 144, DateTimeKind.Unspecified).AddTicks(878), new TimeSpan(0, -4, 0, 0, 0)), null, null, null, "user@example.com", true, "Rosalba Pena", false, false, null, "USER@EXAMPLE.COM", "ROSALBA", "AQAAAAIAAYagAAAAEI1NfjihrFYSvMRxphlS0jTwJUlgWPtWXrOmLW3b1cKDwfwe78IdkGNvLfGz0N1hYQ==", "18497505944", true, false, null, null, "742aad4a-0bbe-41b2-a395-fa1db3b98583", false, null, null, "Rosalba", null }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "Carts",
                columns: new[] { "CartId", "IsDeleted", "UserId" },
                values: new object[,]
                {
                    { new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"), false, "2301d884-221a-4e7d-b509-0113dcc043e1" },
                    { new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"), false, "2301d884-221a-4e7d-b509-0113dcc043e2" },
                    { new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"), false, "2301d884-221a-4e7d-b509-0113dcc043e3" },
                    { new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"), false, "7d9b7113-a8f8-4035-99a7-a20dd400f6a3" },
                    { new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"), false, "b22698b8-42a2-4115-9631-1c2d1e2ac5f7" }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "IsDeleted" },
                values: new object[,]
                {
                    { "2301d884-221a-4e7d-b509-0113dcc043e1", "2301d884-221a-4e7d-b509-0113dcc043e1", false },
                    { "2301d884-221a-4e7d-b509-0113dcc043e2", "2301d884-221a-4e7d-b509-0113dcc043e2", false },
                    { "2301d884-221a-4e7d-b509-0113dcc043e3", "2301d884-221a-4e7d-b509-0113dcc043e3", false },
                    { "7d9b7113-a8f8-4035-99a7-a20dd400f6a3", "7d9b7113-a8f8-4035-99a7-a20dd400f6a3", false },
                    { "b22698b8-42a2-4115-9631-1c2d1e2ac5f7", "b22698b8-42a2-4115-9631-1c2d1e2ac5f7", false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                schema: "RosaFiesta",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                schema: "RosaFiesta",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                schema: "RosaFiesta",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OptionImages_OptionId",
                schema: "RosaFiesta",
                table: "OptionImages",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_ImageId",
                schema: "RosaFiesta",
                table: "Options",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Options_ProductId",
                schema: "RosaFiesta",
                table: "Options",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                schema: "RosaFiesta",
                table: "Orders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PayMethodId",
                schema: "RosaFiesta",
                table: "Orders",
                column: "PayMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                schema: "RosaFiesta",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PayMethods_UserId",
                schema: "RosaFiesta",
                table: "PayMethods",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                schema: "RosaFiesta",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Code",
                schema: "RosaFiesta",
                table: "Products",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OptionId",
                schema: "RosaFiesta",
                table: "Products",
                column: "OptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                schema: "RosaFiesta",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_WarrantyId",
                schema: "RosaFiesta",
                table: "Products",
                column: "WarrantyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsDiscounts_DiscountId",
                schema: "RosaFiesta",
                table: "ProductsDiscounts",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsDiscounts_OptionId",
                schema: "RosaFiesta",
                table: "ProductsDiscounts",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsDiscounts_ProductEntityId",
                schema: "RosaFiesta",
                table: "ProductsDiscounts",
                column: "ProductEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_CartId",
                schema: "RosaFiesta",
                table: "PurchaseDetails",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_OrderId",
                schema: "RosaFiesta",
                table: "PurchaseDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_ProductId",
                schema: "RosaFiesta",
                table: "PurchaseDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_QuoteId",
                schema: "RosaFiesta",
                table: "PurchaseDetails",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetailsOptions_AppliedId",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions",
                column: "AppliedId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetailsOptions_OptionId",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_UserId",
                schema: "RosaFiesta",
                table: "Quotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_OptionId",
                schema: "RosaFiesta",
                table: "Reviews",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                schema: "RosaFiesta",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "RosaFiesta",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "RosaFiesta",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_Name",
                schema: "RosaFiesta",
                table: "Suppliers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "RosaFiesta",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "RosaFiesta",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "RosaFiesta",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "RosaFiesta",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DefaultAddressId",
                schema: "RosaFiesta",
                table: "Users",
                column: "DefaultAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DefaultPayMethodId",
                schema: "RosaFiesta",
                table: "Users",
                column: "DefaultPayMethodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "RosaFiesta",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warranties_Name",
                schema: "RosaFiesta",
                table: "Warranties",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_WishesList_UserId",
                schema: "RosaFiesta",
                table: "WishesList",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishesListProducts_OptionId",
                schema: "RosaFiesta",
                table: "WishesListProducts",
                column: "OptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_UserId",
                schema: "RosaFiesta",
                table: "Addresses",
                column: "UserId",
                principalSchema: "RosaFiesta",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_UserId",
                schema: "RosaFiesta",
                table: "Carts",
                column: "UserId",
                principalSchema: "RosaFiesta",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionImages_Options_OptionId",
                schema: "RosaFiesta",
                table: "OptionImages",
                column: "OptionId",
                principalSchema: "RosaFiesta",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Products_ProductId",
                schema: "RosaFiesta",
                table: "Options",
                column: "ProductId",
                principalSchema: "RosaFiesta",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PayMethods_PayMethodId",
                schema: "RosaFiesta",
                table: "Orders",
                column: "PayMethodId",
                principalSchema: "RosaFiesta",
                principalTable: "PayMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                schema: "RosaFiesta",
                table: "Orders",
                column: "UserId",
                principalSchema: "RosaFiesta",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PayMethods_Users_UserId",
                schema: "RosaFiesta",
                table: "PayMethods",
                column: "UserId",
                principalSchema: "RosaFiesta",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_UserId",
                schema: "RosaFiesta",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_PayMethods_Users_UserId",
                schema: "RosaFiesta",
                table: "PayMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionImages_Options_OptionId",
                schema: "RosaFiesta",
                table: "OptionImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Options_OptionId",
                schema: "RosaFiesta",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductsDiscounts",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "PurchaseDetailsOptions",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "Reviews",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "WishesListProducts",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "Discounts",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "PurchaseDetails",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "WishesList",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "Carts",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "Quotes",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "PayMethods",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "Options",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "OptionImages",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "Suppliers",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "Warranties",
                schema: "RosaFiesta");
        }
    }
}
