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
                name: "AspNetUsers",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CivilStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
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
                    Discount = table.Column<double>(type: "float", nullable: false),
                    DiscountStartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DiscountEndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DiscountDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DiscountImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountCodeImage = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
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
                        principalColumn: "CartId",
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
                        principalColumn: "CartId",
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
                        principalColumn: "CartId",
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
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "RosaFiesta",
                        principalTable: "AspNetUsers",
                        principalColumn: "CartId",
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
                        principalColumn: "CartId",
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
                        principalColumn: "CartId",
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
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    NumFactura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PayMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    AmmountPaid = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillEntity", x => x.NumFactura);
                    table.ForeignKey(
                        name: "FK_BillEntity_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "RosaFiesta",
                        principalTable: "AspNetUsers",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillEntity_PayMethodEntity_PayMethodId",
                        column: x => x.PayMethodId,
                        principalSchema: "RosaFiesta",
                        principalTable: "PayMethodEntity",
                        principalColumn: "CartId",
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
                    Price = table.Column<int>(type: "int", nullable: false),
                    EndedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    QuantityAvaliable = table.Column<int>(type: "int", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Size = table.Column<float>(type: "real", nullable: true),
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
                        principalColumn: "CartId");
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
                        principalColumn: "CartId");
                    table.ForeignKey(
                        name: "FK_ProductEntity_Warranties_WarrantyId",
                        column: x => x.WarrantyId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Warranties",
                        principalColumn: "CartId");
                });

            migrationBuilder.CreateTable(
                name: "CartEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartEntity_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "RosaFiesta",
                        principalTable: "AspNetUsers",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartEntity_ProductEntity_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "RosaFiesta",
                        principalTable: "ProductEntity",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductWishList",
                schema: "RosaFiesta",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WishListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWishList", x => new { x.ProductId, x.WishListId });
                    table.ForeignKey(
                        name: "FK_ProductWishList_ProductEntity_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "RosaFiesta",
                        principalTable: "ProductEntity",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductWishList_WishesList_WishListId",
                        column: x => x.WishListId,
                        principalSchema: "RosaFiesta",
                        principalTable: "WishesList",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetailEntity",
                schema: "RosaFiesta",
                columns: table => new
                {
                    PurchaseNumber = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillNumFactura = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    PurchaseStatus = table.Column<int>(type: "int", nullable: false),
                    DiscountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetailEntity", x => new { x.PurchaseNumber, x.BillId });
                    table.ForeignKey(
                        name: "FK_PurchaseDetailEntity_BillEntity_BillNumFactura",
                        column: x => x.BillNumFactura,
                        principalSchema: "RosaFiesta",
                        principalTable: "OrderEntity",
                        principalColumn: "SKU",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseDetailEntity_DiscountEntity_DiscountId",
                        column: x => x.DiscountId,
                        principalSchema: "RosaFiesta",
                        principalTable: "DiscountEntity",
                        principalColumn: "DiscountCode");
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
                    ConfirmedAdquisition = table.Column<bool>(type: "bit", nullable: false),
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
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewEntity_ProductEntity_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "RosaFiesta",
                        principalTable: "ProductEntity",
                        principalColumn: "Code");
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "AspNetRoles",
                columns: new[] { "CartId", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2301D884-221A-4E7D-B509-0113DCC043E1", null, "Admin", "ADMIN" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                columns: new[] { "CartId", "AccessFailedCount", "Address", "Age", "Avatar", "BirthDate", "City", "CivilStatus", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PromotionalMails", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "State", "TwoFactorEnabled", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[] { "B22698B8-42A2-4115-9631-1C2D1E2AC5F7", 0, "Calle 1", 45, "https://i.imgur.com/1Q1Z1Zm.jpg", new DateTimeOffset(new DateTime(1996, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)), "Santo Domingo", 1, "297c30f2-4351-4d43-85b9-650f84e27ef9", new DateTimeOffset(new DateTime(2023, 3, 12, 17, 53, 12, 813, DateTimeKind.Unspecified).AddTicks(1140), new TimeSpan(0, 0, 0, 0, 0)), "user@example.com", true, "Rosalba Pena", false, null, "USER@EXAMPLE.COM", "ROSALBA", "AQAAAAIAAYagAAAAEB0oTM/iskpfblyV+rGXTGYZyrETrEIoUyH8q4tFjum8HzFXPNGcMmp+iIl409hlUQ==", "18497505944", true, false, null, null, "1132ab9c-f09e-4ca3-9bc6-d9d888152bb0", "Distrito Nacional", false, null, null, "Rosalba" });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "CategoryEntity",
                columns: new[] { "CartId", "CreatedAt", "CreatedBy", "Description", "Icon", "Image", "IsActive", "Name", "Slug", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2023, 3, 12, 17, 53, 12, 806, DateTimeKind.Unspecified).AddTicks(4539), new TimeSpan(0, 0, 0, 0, 0)), "System", "Electronics", "https://i.imgur.com/0jQYs1R.png", "https://i.imgur.com/0jQYs1R.png", true, "Electronics", "electronics", new DateTimeOffset(new DateTime(2023, 3, 12, 17, 53, 12, 806, DateTimeKind.Unspecified).AddTicks(4542), new TimeSpan(0, 0, 0, 0, 0)), "System" });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "SupplierEntity",
                columns: new[] { "CartId", "Address", "CreatedAt", "CreatedBy", "Description", "Email", "IsActive", "Name", "Phone", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"), "La Capital", new DateTimeOffset(new DateTime(2023, 3, 12, 17, 53, 12, 812, DateTimeKind.Unspecified).AddTicks(3024), new TimeSpan(0, 0, 0, 0, 0)), "System", null, "suplidor@hotmail.com", true, "Supplier 1", "8095395539", new DateTimeOffset(new DateTime(2023, 3, 12, 17, 53, 12, 812, DateTimeKind.Unspecified).AddTicks(3025), new TimeSpan(0, 0, 0, 0, 0)), "System" });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "Warranties",
                columns: new[] { "CartId", "Conditions", "CreatedAt", "CreatedBy", "Description", "Name", "Period", "ScopeType", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"), "Warranty 1", new DateTimeOffset(new DateTime(2023, 3, 12, 17, 53, 12, 869, DateTimeKind.Unspecified).AddTicks(5250), new TimeSpan(0, 0, 0, 0, 0)), "System", "Warranty 1", "Warranty 1", "1 year", 2, 1, 3, null, null });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2301D884-221A-4E7D-B509-0113DCC043E1", "B22698B8-42A2-4115-9631-1C2D1E2AC5F7" });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                columns: new[] { "Code", "Brand", "CategoryId", "Color", "Condition", "CreatedAt", "CreatedBy", "Description", "DiscountAppliedId", "EndedAt", "GenderFor", "Image", "Material", "Name", "Price", "QuantityAvaliable", "Size", "Stock", "SupplierId", "Type", "UpdatedAt", "UpdatedBy", "WarrantyId" },
                values: new object[] { "SDA01", "Champion", 1, "White", 1, new DateTimeOffset(new DateTime(2023, 3, 12, 17, 53, 12, 811, DateTimeKind.Unspecified).AddTicks(6461), new TimeSpan(0, 0, 0, 0, 0)), "Admin", "Polo de manga corta", null, null, 3, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.amazon.com%2FChampion-Reverse-Weave-Polo-White%2Fdp%2FB07G1J7Q2Q&psig=AOvVaw2D5N7VQ2v0uL7zS9O4yJ7l&ust=1628125928634000&source=images&cd=vfe&ved=0CAsQjRxqFwoTCOjGqfCg1_ICFQAAAAAdAAAAABAD", 6, "Polo", 1000, 1, 1.5f, 1, new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"), 1, null, null, new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6") });

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                columns: new[] { "CartId", "CategoryId", "CreatedAt", "CreatedBy", "Description", "Icon", "Image", "IsActive", "Name", "Slug", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, 1, new DateTimeOffset(new DateTime(2023, 3, 12, 17, 53, 12, 812, DateTimeKind.Unspecified).AddTicks(1280), new TimeSpan(0, 0, 0, 0, 0)), "System", "Electronics", "https://i.imgur.com/0jQYs1R.png", "https://i.imgur.com/0jQYs1R.png", true, "Electronics", "electronics", new DateTimeOffset(new DateTime(2023, 3, 12, 17, 53, 12, 812, DateTimeKind.Unspecified).AddTicks(1281), new TimeSpan(0, 0, 0, 0, 0)), "System" });

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
                name: "IX_BillEntity_PayMethodId",
                schema: "RosaFiesta",
                table: "OrderEntity",
                column: "PayMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_BillEntity_UserId",
                schema: "RosaFiesta",
                table: "OrderEntity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartEntity_ProductId",
                schema: "RosaFiesta",
                table: "CartEntity",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartEntity_UserId",
                schema: "RosaFiesta",
                table: "CartEntity",
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
                name: "IX_ProductWishList_WishListId",
                schema: "RosaFiesta",
                table: "ProductWishList",
                column: "WishListId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetailEntity_BillNumFactura",
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                column: "BillNumFactura");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetailEntity_DiscountId",
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                column: "DiscountId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "CartEntity",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "ProductWishList",
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
                name: "AspNetRoles",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "WishesList",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "OrderEntity",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "ProductEntity",
                schema: "RosaFiesta");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
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
        }
    }
}
