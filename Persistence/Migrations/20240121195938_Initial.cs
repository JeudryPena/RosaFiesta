using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                name: "AddressEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CountryCode = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    CustomerName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: true),
                    Description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressEntity", x => x.Id);
                });

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
                name: "Users",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    PromotionalMails = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    WishListId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                name: "Carts",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
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
                    ImageId = table.Column<Guid>(type: "uuid", nullable: true),
                    QuantityAvailable = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: true),
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
                    Views = table.Column<int>(type: "integer", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
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
                name: "Orders",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    TransactionId = table.Column<string>(type: "text", nullable: true),
                    CurrencyCode = table.Column<string>(type: "text", nullable: true),
                    PayerId = table.Column<string>(type: "text", nullable: true),
                    Shipping = table.Column<double>(type: "double precision", nullable: true),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: true),
                    QuoteId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AddressEntity_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "RosaFiesta",
                        principalTable: "AddressEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetails",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    WarrantyId = table.Column<Guid>(type: "uuid", nullable: true),
                    CartId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseDetails_Carts_CartId",
                        column: x => x.CartId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Carts",
                        principalColumn: "Id");
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
                        name: "FK_PurchaseDetails_Warranties_WarrantyId",
                        column: x => x.WarrantyId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Warranties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EventDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotes_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quotes_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Users",
                        principalColumn: "Id");
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
                    Taxes = table.Column<double>(type: "double precision", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PromotionalMails", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UpdatedBy", "UserName", "WishListId" },
                values: new object[,]
                {
                    { "2301d884-221a-4e7d-b509-0113dcc043e1", 0, new DateOnly(1999, 1, 3), "14995b56-9f74-4ded-8c87-93939ad39357", new DateTimeOffset(new DateTime(2024, 1, 21, 15, 59, 38, 276, DateTimeKind.Unspecified).AddTicks(4865), new TimeSpan(0, -4, 0, 0, 0)), null, "rosalbapp@gmail.com", true, false, false, null, "ROSALBAPP@GMAIL.COM", "ROSALBA2", "AQAAAAIAAYagAAAAEB4Ydy+04fEVceoulvM7EI3mgTzHtqma1XLnC1DO9qG4banYg7ayHZ/OV0k8w+gwUQ==", false, null, null, "a4894dbb-5fee-40de-8b79-0126c5f71397", false, null, null, "Rosalba2", null },
                    { "2301d884-221a-4e7d-b509-0113dcc043e2", 0, new DateOnly(1999, 1, 4), "1f9b6f25-d46c-4652-91e2-d8a2d2a70ef0", new DateTimeOffset(new DateTime(2024, 1, 21, 15, 59, 38, 276, DateTimeKind.Unspecified).AddTicks(4882), new TimeSpan(0, -4, 0, 0, 0)), null, "jendrypp@gmail.com", true, false, false, null, "JENDRYPP@GMAIL.COM", "JENDRY", "AQAAAAIAAYagAAAAEKtyqKoz6k5nH/XS5kohQSezItF0V0612vljWf/DhJqL9srijjVngx4xey9rCiorTw==", false, null, null, "d8ee78ed-9fc3-4a96-9c15-c9723e903ded", false, null, null, "Jendry", null },
                    { "2301d884-221a-4e7d-b509-0113dcc043e3", 0, new DateOnly(1999, 1, 5), "0ec59284-e38e-400f-831b-0979fe598d72", new DateTimeOffset(new DateTime(2024, 1, 21, 15, 59, 38, 276, DateTimeKind.Unspecified).AddTicks(4892), new TimeSpan(0, -4, 0, 0, 0)), null, "rosmerypp@gmail.com", true, false, false, null, "ROSMERYPP@GMAIL.COM", "ROSMERY", "AQAAAAIAAYagAAAAELF+XvoA496LCZxOehpkkGOre7uBEm87HsanvuQjoZHRF6GbaOgsalXaBKPC6l96Ww==", false, null, null, "d2d2fe1d-a174-4595-8af0-e4984078acb1", false, null, null, "Rosmery", null },
                    { "7d9b7113-a8f8-4035-99a7-a20dd400f6a3", 0, new DateOnly(1999, 1, 2), "cc149675-38cd-4b85-8d09-31df8f50edfb", new DateTimeOffset(new DateTime(2024, 1, 21, 15, 59, 38, 276, DateTimeKind.Unspecified).AddTicks(4852), new TimeSpan(0, -4, 0, 0, 0)), null, "rosanny@gmail.com", true, false, false, null, "ROSANNY@GMAIL.COM", "ROSANNY", "AQAAAAIAAYagAAAAEOohnL4QxPb7vXcPhS2hyCwCahLqLU3/DY/KyZS3TFHGCFNyRiQ/crcs3K90xcQuLQ==", false, null, null, "8dfd8808-8583-4080-90a1-8969b2ec7c3b", false, null, null, "Rosanny", null },
                    { "b22698b8-42a2-4115-9631-1c2d1e2ac5f7", 0, new DateOnly(1999, 1, 1), "98c67c8b-679d-4234-99f5-980cba4827b7", new DateTimeOffset(new DateTime(2024, 1, 21, 15, 59, 38, 276, DateTimeKind.Unspecified).AddTicks(4623), new TimeSpan(0, -4, 0, 0, 0)), null, "user@example.com", true, false, false, null, "USER@EXAMPLE.COM", "ROSALBA", "AQAAAAIAAYagAAAAEEP8WRqs899X8ba501aJMptJtUoeHx3jrGZF1KeDyAe+MY7WF2xdzlCyAerUei9lTQ==", false, null, null, "53156e0d-a94e-488f-ae8b-1458ad33559e", false, null, null, "Rosalba", null }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "Carts",
                columns: new[] { "Id", "IsDeleted", "UserId" },
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

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "WishesList",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"), new DateTimeOffset(new DateTime(2024, 1, 21, 15, 59, 38, 601, DateTimeKind.Unspecified).AddTicks(9635), new TimeSpan(0, -4, 0, 0, 0)), false, null, "2301d884-221a-4e7d-b509-0113dcc043e1" },
                    { new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"), new DateTimeOffset(new DateTime(2024, 1, 21, 15, 59, 38, 601, DateTimeKind.Unspecified).AddTicks(9643), new TimeSpan(0, -4, 0, 0, 0)), false, null, "2301d884-221a-4e7d-b509-0113dcc043e2" },
                    { new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"), new DateTimeOffset(new DateTime(2024, 1, 21, 15, 59, 38, 601, DateTimeKind.Unspecified).AddTicks(9647), new TimeSpan(0, -4, 0, 0, 0)), false, null, "2301d884-221a-4e7d-b509-0113dcc043e3" },
                    { new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"), new DateTimeOffset(new DateTime(2024, 1, 21, 15, 59, 38, 601, DateTimeKind.Unspecified).AddTicks(9630), new TimeSpan(0, -4, 0, 0, 0)), false, null, "7d9b7113-a8f8-4035-99a7-a20dd400f6a3" },
                    { new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"), new DateTimeOffset(new DateTime(2024, 1, 21, 15, 59, 38, 601, DateTimeKind.Unspecified).AddTicks(9539), new TimeSpan(0, -4, 0, 0, 0)), false, null, "b22698b8-42a2-4115-9631-1c2d1e2ac5f7" }
                });

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
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_QuoteId",
                schema: "RosaFiesta",
                table: "Orders",
                column: "QuoteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                schema: "RosaFiesta",
                table: "Orders",
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
                name: "IX_PurchaseDetails_WarrantyId",
                schema: "RosaFiesta",
                table: "PurchaseDetails",
                column: "WarrantyId");

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
                name: "IX_Quotes_OrderId",
                schema: "RosaFiesta",
                table: "Quotes",
                column: "OrderId");

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
                name: "FK_Orders_Quotes_QuoteId",
                schema: "RosaFiesta",
                table: "Orders",
                column: "QuoteId",
                principalSchema: "RosaFiesta",
                principalTable: "Quotes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                schema: "RosaFiesta",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Users_UserId",
                schema: "RosaFiesta",
                table: "Quotes");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionImages_Options_OptionId",
                schema: "RosaFiesta",
                table: "OptionImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Options_OptionId",
                schema: "RosaFiesta",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AddressEntity_AddressId",
                schema: "RosaFiesta",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Quotes_QuoteId",
                schema: "RosaFiesta",
                table: "Orders");

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
                name: "Users",
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

            migrationBuilder.DropTable(
                name: "AddressEntity",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "Quotes",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "RosaFiesta");
        }
    }
}
