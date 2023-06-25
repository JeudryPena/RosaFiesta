using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class refactorizedConfigs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppliedDiscounts_DiscountEntity_Code",
                schema: "RosaFiesta",
                table: "AppliedDiscounts");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PayMethodEntity_DefaultPayMethodId",
                schema: "RosaFiesta",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CartEntity_AspNetUsers_UserId",
                schema: "RosaFiesta",
                table: "CartEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_ProductEntity_ProductCode",
                schema: "RosaFiesta",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderEntity_Addresses_AddressId",
                schema: "RosaFiesta",
                table: "OrderEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderEntity_AspNetUsers_UserId",
                schema: "RosaFiesta",
                table: "OrderEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderEntity_PayMethodEntity_PayMethodId",
                schema: "RosaFiesta",
                table: "OrderEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PayMethodEntity_AspNetUsers_UserId",
                schema: "RosaFiesta",
                table: "PayMethodEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductEntity_CategoryEntity_CategoryId",
                schema: "RosaFiesta",
                table: "ProductEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductEntity_SubCategoryEntity_SubCategoryId",
                schema: "RosaFiesta",
                table: "ProductEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductEntity_SupplierEntity_SupplierId",
                schema: "RosaFiesta",
                table: "ProductEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductEntity_Warranties_WarrantyId",
                schema: "RosaFiesta",
                table: "ProductEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsDiscountsEntity_DiscountEntity_Code",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsDiscountsEntity_Options_OptionId",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsDiscountsEntity_ProductEntity_ProductEntityCode",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetailEntity_CartEntity_CartId",
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetailEntity_OrderEntity_OrderId",
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetailEntity_ProductEntity_ProductId",
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetailOptions_AppliedDiscounts_AppliedId",
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetailOptions_Options_OptionId",
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetailOptions_PurchaseDetailEntity_PurchaseNumber",
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteItemEntity_Quotes_QuoteId",
                schema: "RosaFiesta",
                table: "QuoteItemEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteItemEntity_Services_ServiceId",
                schema: "RosaFiesta",
                table: "QuoteItemEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewEntity_AspNetUsers_UserId",
                schema: "RosaFiesta",
                table: "ReviewEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewEntity_Options_OptionId",
                schema: "RosaFiesta",
                table: "ReviewEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryEntity_CategoryEntity_CategoryId",
                schema: "RosaFiesta",
                table: "SubCategoryEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_WishListProductsEntity_Options_OptionId",
                schema: "RosaFiesta",
                table: "WishListProductsEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_WishListProductsEntity_WishesList_WishListId",
                schema: "RosaFiesta",
                table: "WishListProductsEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishListProductsEntity",
                schema: "RosaFiesta",
                table: "WishListProductsEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierEntity",
                schema: "RosaFiesta",
                table: "SupplierEntity");

            migrationBuilder.DropIndex(
                name: "IX_SupplierEntity_Email",
                schema: "RosaFiesta",
                table: "SupplierEntity");

            migrationBuilder.DropIndex(
                name: "IX_SupplierEntity_Phone",
                schema: "RosaFiesta",
                table: "SupplierEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategoryEntity",
                schema: "RosaFiesta",
                table: "SubCategoryEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReviewEntity",
                schema: "RosaFiesta",
                table: "ReviewEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuoteItemEntity",
                schema: "RosaFiesta",
                table: "QuoteItemEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseDetailOptions",
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseDetailEntity",
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsDiscountsEntity",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductEntity",
                schema: "RosaFiesta",
                table: "ProductEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PayMethodEntity",
                schema: "RosaFiesta",
                table: "PayMethodEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderEntity",
                schema: "RosaFiesta",
                table: "OrderEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiscountEntity",
                schema: "RosaFiesta",
                table: "DiscountEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryEntity",
                schema: "RosaFiesta",
                table: "CategoryEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartEntity",
                schema: "RosaFiesta",
                table: "CartEntity");

            migrationBuilder.DropColumn(
                name: "Age",
                schema: "RosaFiesta",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "WishListProductsEntity",
                schema: "RosaFiesta",
                newName: "WishesListProducts",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "SupplierEntity",
                schema: "RosaFiesta",
                newName: "Suppliers",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "SubCategoryEntity",
                schema: "RosaFiesta",
                newName: "SubCategories",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "ReviewEntity",
                schema: "RosaFiesta",
                newName: "Reviews",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "QuoteItemEntity",
                schema: "RosaFiesta",
                newName: "QuoteItems",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "PurchaseDetailOptions",
                schema: "RosaFiesta",
                newName: "PurchaseDetailsOptions",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "PurchaseDetailEntity",
                schema: "RosaFiesta",
                newName: "PurchaseDetails",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "ProductsDiscountsEntity",
                schema: "RosaFiesta",
                newName: "ProductsDiscounts",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "ProductEntity",
                schema: "RosaFiesta",
                newName: "Products",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "PayMethodEntity",
                schema: "RosaFiesta",
                newName: "PayMethods",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "OrderEntity",
                schema: "RosaFiesta",
                newName: "Orders",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "DiscountEntity",
                schema: "RosaFiesta",
                newName: "Discounts",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "CategoryEntity",
                schema: "RosaFiesta",
                newName: "Categories",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "CartEntity",
                schema: "RosaFiesta",
                newName: "Carts",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameIndex(
                name: "IX_WishListProductsEntity_OptionId",
                schema: "RosaFiesta",
                table: "WishesListProducts",
                newName: "IX_WishesListProducts_OptionId");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierEntity_Name",
                schema: "RosaFiesta",
                table: "Suppliers",
                newName: "IX_Suppliers_Name");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategoryEntity_Name",
                schema: "RosaFiesta",
                table: "SubCategories",
                newName: "IX_SubCategories_Name");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategoryEntity_CategoryId",
                schema: "RosaFiesta",
                table: "SubCategories",
                newName: "IX_SubCategories_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewEntity_UserId",
                schema: "RosaFiesta",
                table: "Reviews",
                newName: "IX_Reviews_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewEntity_OptionId",
                schema: "RosaFiesta",
                table: "Reviews",
                newName: "IX_Reviews_OptionId");

            migrationBuilder.RenameIndex(
                name: "IX_QuoteItemEntity_ServiceId",
                schema: "RosaFiesta",
                table: "QuoteItems",
                newName: "IX_QuoteItems_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_QuoteItemEntity_QuoteId",
                schema: "RosaFiesta",
                table: "QuoteItems",
                newName: "IX_QuoteItems_QuoteId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseDetailOptions_OptionId",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions",
                newName: "IX_PurchaseDetailsOptions_OptionId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseDetailOptions_AppliedId",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions",
                newName: "IX_PurchaseDetailsOptions_AppliedId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseDetailEntity_ProductId",
                schema: "RosaFiesta",
                table: "PurchaseDetails",
                newName: "IX_PurchaseDetails_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseDetailEntity_OrderId",
                schema: "RosaFiesta",
                table: "PurchaseDetails",
                newName: "IX_PurchaseDetails_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseDetailEntity_CartId",
                schema: "RosaFiesta",
                table: "PurchaseDetails",
                newName: "IX_PurchaseDetails_CartId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsDiscountsEntity_ProductEntityCode",
                schema: "RosaFiesta",
                table: "ProductsDiscounts",
                newName: "IX_ProductsDiscounts_ProductEntityCode");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsDiscountsEntity_OptionId",
                schema: "RosaFiesta",
                table: "ProductsDiscounts",
                newName: "IX_ProductsDiscounts_OptionId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsDiscountsEntity_Code",
                schema: "RosaFiesta",
                table: "ProductsDiscounts",
                newName: "IX_ProductsDiscounts_Code");

            migrationBuilder.RenameIndex(
                name: "IX_ProductEntity_WarrantyId",
                schema: "RosaFiesta",
                table: "Products",
                newName: "IX_Products_WarrantyId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductEntity_SupplierId",
                schema: "RosaFiesta",
                table: "Products",
                newName: "IX_Products_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductEntity_SubCategoryId",
                schema: "RosaFiesta",
                table: "Products",
                newName: "IX_Products_SubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductEntity_CategoryId",
                schema: "RosaFiesta",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_PayMethodEntity_UserId",
                schema: "RosaFiesta",
                table: "PayMethods",
                newName: "IX_PayMethods_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderEntity_UserId",
                schema: "RosaFiesta",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderEntity_PayMethodId",
                schema: "RosaFiesta",
                table: "Orders",
                newName: "IX_Orders_PayMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderEntity_AddressId",
                schema: "RosaFiesta",
                table: "Orders",
                newName: "IX_Orders_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryEntity_Name",
                schema: "RosaFiesta",
                table: "Categories",
                newName: "IX_Categories_Name");

            migrationBuilder.RenameIndex(
                name: "IX_CartEntity_UserId",
                schema: "RosaFiesta",
                table: "Carts",
                newName: "IX_Carts_UserId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "RosaFiesta",
                table: "PurchaseDetails",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                schema: "RosaFiesta",
                table: "PurchaseDetails",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishesListProducts",
                schema: "RosaFiesta",
                table: "WishesListProducts",
                columns: new[] { "WishListId", "OptionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                schema: "RosaFiesta",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategories",
                schema: "RosaFiesta",
                table: "SubCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                schema: "RosaFiesta",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuoteItems",
                schema: "RosaFiesta",
                table: "QuoteItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseDetailsOptions",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions",
                columns: new[] { "PurchaseNumber", "OptionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseDetails",
                schema: "RosaFiesta",
                table: "PurchaseDetails",
                column: "PurchaseNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsDiscounts",
                schema: "RosaFiesta",
                table: "ProductsDiscounts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                schema: "RosaFiesta",
                table: "Products",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PayMethods",
                schema: "RosaFiesta",
                table: "PayMethods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                schema: "RosaFiesta",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discounts",
                schema: "RosaFiesta",
                table: "Discounts",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                schema: "RosaFiesta",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                schema: "RosaFiesta",
                table: "Carts",
                column: "CartId");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "d4ce7172-9634-4fec-89d9-8ec42a1b7c11", new DateTimeOffset(new DateTime(2023, 6, 25, 15, 27, 36, 587, DateTimeKind.Unspecified).AddTicks(2403), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAENHlfewpOUp9Gcnx5VwnEpaV3iUzUDQRI/MZJBQ40X8s2Xn3cLZTDxDpHnhVM73+aw==", "374b01de-c547-47ab-b11d-b67a73eacebf", null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "455f5277-3df5-4805-baad-58248f120a66", new DateTimeOffset(new DateTime(2023, 6, 25, 15, 27, 36, 587, DateTimeKind.Unspecified).AddTicks(2427), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAELH8yQi4scZ+sBzBgfU8ViI4BzfpV0+25O8x2LMgx6QXXwwluYWTIe7HnOy7oJ7DzA==", "c2b8778c-b065-4490-93ad-b929d1e1c4c1", null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "f776bb9c-93e8-42f3-b6ec-7bd2d86bd1ef", new DateTimeOffset(new DateTime(2023, 6, 25, 15, 27, 36, 587, DateTimeKind.Unspecified).AddTicks(2453), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEB999u1eHQ3h4Hv7dUtwZUboB6lMEB3+sKjcoyp+6YJFLK6O9LsIbQZOQZJwQbvn+w==", "4a085808-c326-430f-92df-251d483a901c", null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "841d2f2d-72a2-4179-b935-130ff770dbef", new DateTimeOffset(new DateTime(2023, 6, 25, 15, 27, 36, 587, DateTimeKind.Unspecified).AddTicks(2358), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEM68zjaR96eoFGYBbQcmlN3ux+IyaGa+psFXkIgR7drWLuvAM5E9qq1+v9SzmXQQQA==", "dee7be38-5d9a-4602-af60-3c55482d7a32", null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "3ee63201-c7aa-4d9f-b1a5-bfc9d52b2949", new DateTimeOffset(new DateTime(2023, 6, 25, 15, 27, 36, 587, DateTimeKind.Unspecified).AddTicks(2074), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAENsu9V0H4KMo2zyItRxm5XD/xmmS2LByjptfzj7fN9KbROAN7bsBs+l3UkLSpuEG0A==", "95c4faa2-9c26-4129-9fd0-c98f434dc240", null });

            migrationBuilder.AddForeignKey(
                name: "FK_AppliedDiscounts_Discounts_Code",
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                column: "Code",
                principalSchema: "RosaFiesta",
                principalTable: "Discounts",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PayMethods_DefaultPayMethodId",
                schema: "RosaFiesta",
                table: "AspNetUsers",
                column: "DefaultPayMethodId",
                principalSchema: "RosaFiesta",
                principalTable: "PayMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                schema: "RosaFiesta",
                table: "Carts",
                column: "UserId",
                principalSchema: "RosaFiesta",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Products_ProductCode",
                schema: "RosaFiesta",
                table: "Options",
                column: "ProductCode",
                principalSchema: "RosaFiesta",
                principalTable: "Products",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                schema: "RosaFiesta",
                table: "Orders",
                column: "AddressId",
                principalSchema: "RosaFiesta",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                schema: "RosaFiesta",
                table: "Orders",
                column: "UserId",
                principalSchema: "RosaFiesta",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

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
                name: "FK_PayMethods_AspNetUsers_UserId",
                schema: "RosaFiesta",
                table: "PayMethods",
                column: "UserId",
                principalSchema: "RosaFiesta",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                schema: "RosaFiesta",
                table: "Products",
                column: "CategoryId",
                principalSchema: "RosaFiesta",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubCategories_SubCategoryId",
                schema: "RosaFiesta",
                table: "Products",
                column: "SubCategoryId",
                principalSchema: "RosaFiesta",
                principalTable: "SubCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_SupplierId",
                schema: "RosaFiesta",
                table: "Products",
                column: "SupplierId",
                principalSchema: "RosaFiesta",
                principalTable: "Suppliers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Warranties_WarrantyId",
                schema: "RosaFiesta",
                table: "Products",
                column: "WarrantyId",
                principalSchema: "RosaFiesta",
                principalTable: "Warranties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsDiscounts_Discounts_Code",
                schema: "RosaFiesta",
                table: "ProductsDiscounts",
                column: "Code",
                principalSchema: "RosaFiesta",
                principalTable: "Discounts",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsDiscounts_Options_OptionId",
                schema: "RosaFiesta",
                table: "ProductsDiscounts",
                column: "OptionId",
                principalSchema: "RosaFiesta",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsDiscounts_Products_ProductEntityCode",
                schema: "RosaFiesta",
                table: "ProductsDiscounts",
                column: "ProductEntityCode",
                principalSchema: "RosaFiesta",
                principalTable: "Products",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_Carts_CartId",
                schema: "RosaFiesta",
                table: "PurchaseDetails",
                column: "CartId",
                principalSchema: "RosaFiesta",
                principalTable: "Carts",
                principalColumn: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_Orders_OrderId",
                schema: "RosaFiesta",
                table: "PurchaseDetails",
                column: "OrderId",
                principalSchema: "RosaFiesta",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_Products_ProductId",
                schema: "RosaFiesta",
                table: "PurchaseDetails",
                column: "ProductId",
                principalSchema: "RosaFiesta",
                principalTable: "Products",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetailsOptions_AppliedDiscounts_AppliedId",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions",
                column: "AppliedId",
                principalSchema: "RosaFiesta",
                principalTable: "AppliedDiscounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetailsOptions_Options_OptionId",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions",
                column: "OptionId",
                principalSchema: "RosaFiesta",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetailsOptions_PurchaseDetails_PurchaseNumber",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions",
                column: "PurchaseNumber",
                principalSchema: "RosaFiesta",
                principalTable: "PurchaseDetails",
                principalColumn: "PurchaseNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteItems_Quotes_QuoteId",
                schema: "RosaFiesta",
                table: "QuoteItems",
                column: "QuoteId",
                principalSchema: "RosaFiesta",
                principalTable: "Quotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteItems_Services_ServiceId",
                schema: "RosaFiesta",
                table: "QuoteItems",
                column: "ServiceId",
                principalSchema: "RosaFiesta",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                schema: "RosaFiesta",
                table: "Reviews",
                column: "UserId",
                principalSchema: "RosaFiesta",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Options_OptionId",
                schema: "RosaFiesta",
                table: "Reviews",
                column: "OptionId",
                principalSchema: "RosaFiesta",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                schema: "RosaFiesta",
                table: "SubCategories",
                column: "CategoryId",
                principalSchema: "RosaFiesta",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishesListProducts_Options_OptionId",
                schema: "RosaFiesta",
                table: "WishesListProducts",
                column: "OptionId",
                principalSchema: "RosaFiesta",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishesListProducts_WishesList_WishListId",
                schema: "RosaFiesta",
                table: "WishesListProducts",
                column: "WishListId",
                principalSchema: "RosaFiesta",
                principalTable: "WishesList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppliedDiscounts_Discounts_Code",
                schema: "RosaFiesta",
                table: "AppliedDiscounts");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PayMethods_DefaultPayMethodId",
                schema: "RosaFiesta",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                schema: "RosaFiesta",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_Products_ProductCode",
                schema: "RosaFiesta",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                schema: "RosaFiesta",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                schema: "RosaFiesta",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PayMethods_PayMethodId",
                schema: "RosaFiesta",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_PayMethods_AspNetUsers_UserId",
                schema: "RosaFiesta",
                table: "PayMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                schema: "RosaFiesta",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubCategories_SubCategoryId",
                schema: "RosaFiesta",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_SupplierId",
                schema: "RosaFiesta",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Warranties_WarrantyId",
                schema: "RosaFiesta",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsDiscounts_Discounts_Code",
                schema: "RosaFiesta",
                table: "ProductsDiscounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsDiscounts_Options_OptionId",
                schema: "RosaFiesta",
                table: "ProductsDiscounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsDiscounts_Products_ProductEntityCode",
                schema: "RosaFiesta",
                table: "ProductsDiscounts");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_Carts_CartId",
                schema: "RosaFiesta",
                table: "PurchaseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_Orders_OrderId",
                schema: "RosaFiesta",
                table: "PurchaseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_Products_ProductId",
                schema: "RosaFiesta",
                table: "PurchaseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetailsOptions_AppliedDiscounts_AppliedId",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetailsOptions_Options_OptionId",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetailsOptions_PurchaseDetails_PurchaseNumber",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteItems_Quotes_QuoteId",
                schema: "RosaFiesta",
                table: "QuoteItems");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteItems_Services_ServiceId",
                schema: "RosaFiesta",
                table: "QuoteItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                schema: "RosaFiesta",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Options_OptionId",
                schema: "RosaFiesta",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                schema: "RosaFiesta",
                table: "SubCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_WishesListProducts_Options_OptionId",
                schema: "RosaFiesta",
                table: "WishesListProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_WishesListProducts_WishesList_WishListId",
                schema: "RosaFiesta",
                table: "WishesListProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishesListProducts",
                schema: "RosaFiesta",
                table: "WishesListProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                schema: "RosaFiesta",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategories",
                schema: "RosaFiesta",
                table: "SubCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                schema: "RosaFiesta",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuoteItems",
                schema: "RosaFiesta",
                table: "QuoteItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseDetailsOptions",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseDetails",
                schema: "RosaFiesta",
                table: "PurchaseDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsDiscounts",
                schema: "RosaFiesta",
                table: "ProductsDiscounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                schema: "RosaFiesta",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PayMethods",
                schema: "RosaFiesta",
                table: "PayMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                schema: "RosaFiesta",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discounts",
                schema: "RosaFiesta",
                table: "Discounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                schema: "RosaFiesta",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                schema: "RosaFiesta",
                table: "Carts");

            migrationBuilder.RenameTable(
                name: "WishesListProducts",
                schema: "RosaFiesta",
                newName: "WishListProductsEntity",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                schema: "RosaFiesta",
                newName: "SupplierEntity",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "SubCategories",
                schema: "RosaFiesta",
                newName: "SubCategoryEntity",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "Reviews",
                schema: "RosaFiesta",
                newName: "ReviewEntity",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "QuoteItems",
                schema: "RosaFiesta",
                newName: "QuoteItemEntity",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "PurchaseDetailsOptions",
                schema: "RosaFiesta",
                newName: "PurchaseDetailOptions",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "PurchaseDetails",
                schema: "RosaFiesta",
                newName: "PurchaseDetailEntity",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "ProductsDiscounts",
                schema: "RosaFiesta",
                newName: "ProductsDiscountsEntity",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "RosaFiesta",
                newName: "ProductEntity",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "PayMethods",
                schema: "RosaFiesta",
                newName: "PayMethodEntity",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "RosaFiesta",
                newName: "OrderEntity",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "Discounts",
                schema: "RosaFiesta",
                newName: "DiscountEntity",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "RosaFiesta",
                newName: "CategoryEntity",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameTable(
                name: "Carts",
                schema: "RosaFiesta",
                newName: "CartEntity",
                newSchema: "RosaFiesta");

            migrationBuilder.RenameIndex(
                name: "IX_WishesListProducts_OptionId",
                schema: "RosaFiesta",
                table: "WishListProductsEntity",
                newName: "IX_WishListProductsEntity_OptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Suppliers_Name",
                schema: "RosaFiesta",
                table: "SupplierEntity",
                newName: "IX_SupplierEntity_Name");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategories_Name",
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                newName: "IX_SubCategoryEntity_Name");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategories_CategoryId",
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                newName: "IX_SubCategoryEntity_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UserId",
                schema: "RosaFiesta",
                table: "ReviewEntity",
                newName: "IX_ReviewEntity_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_OptionId",
                schema: "RosaFiesta",
                table: "ReviewEntity",
                newName: "IX_ReviewEntity_OptionId");

            migrationBuilder.RenameIndex(
                name: "IX_QuoteItems_ServiceId",
                schema: "RosaFiesta",
                table: "QuoteItemEntity",
                newName: "IX_QuoteItemEntity_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_QuoteItems_QuoteId",
                schema: "RosaFiesta",
                table: "QuoteItemEntity",
                newName: "IX_QuoteItemEntity_QuoteId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseDetailsOptions_OptionId",
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                newName: "IX_PurchaseDetailOptions_OptionId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseDetailsOptions_AppliedId",
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                newName: "IX_PurchaseDetailOptions_AppliedId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseDetails_ProductId",
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                newName: "IX_PurchaseDetailEntity_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseDetails_OrderId",
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                newName: "IX_PurchaseDetailEntity_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseDetails_CartId",
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                newName: "IX_PurchaseDetailEntity_CartId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsDiscounts_ProductEntityCode",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                newName: "IX_ProductsDiscountsEntity_ProductEntityCode");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsDiscounts_OptionId",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                newName: "IX_ProductsDiscountsEntity_OptionId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsDiscounts_Code",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                newName: "IX_ProductsDiscountsEntity_Code");

            migrationBuilder.RenameIndex(
                name: "IX_Products_WarrantyId",
                schema: "RosaFiesta",
                table: "ProductEntity",
                newName: "IX_ProductEntity_WarrantyId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SupplierId",
                schema: "RosaFiesta",
                table: "ProductEntity",
                newName: "IX_ProductEntity_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SubCategoryId",
                schema: "RosaFiesta",
                table: "ProductEntity",
                newName: "IX_ProductEntity_SubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                schema: "RosaFiesta",
                table: "ProductEntity",
                newName: "IX_ProductEntity_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_PayMethods_UserId",
                schema: "RosaFiesta",
                table: "PayMethodEntity",
                newName: "IX_PayMethodEntity_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                schema: "RosaFiesta",
                table: "OrderEntity",
                newName: "IX_OrderEntity_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_PayMethodId",
                schema: "RosaFiesta",
                table: "OrderEntity",
                newName: "IX_OrderEntity_PayMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_AddressId",
                schema: "RosaFiesta",
                table: "OrderEntity",
                newName: "IX_OrderEntity_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_Name",
                schema: "RosaFiesta",
                table: "CategoryEntity",
                newName: "IX_CategoryEntity_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_UserId",
                schema: "RosaFiesta",
                table: "CartEntity",
                newName: "IX_CartEntity_UserId");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                schema: "RosaFiesta",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishListProductsEntity",
                schema: "RosaFiesta",
                table: "WishListProductsEntity",
                columns: new[] { "WishListId", "OptionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierEntity",
                schema: "RosaFiesta",
                table: "SupplierEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategoryEntity",
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReviewEntity",
                schema: "RosaFiesta",
                table: "ReviewEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuoteItemEntity",
                schema: "RosaFiesta",
                table: "QuoteItemEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseDetailOptions",
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                columns: new[] { "PurchaseNumber", "OptionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseDetailEntity",
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                column: "PurchaseNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsDiscountsEntity",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductEntity",
                schema: "RosaFiesta",
                table: "ProductEntity",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PayMethodEntity",
                schema: "RosaFiesta",
                table: "PayMethodEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderEntity",
                schema: "RosaFiesta",
                table: "OrderEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiscountEntity",
                schema: "RosaFiesta",
                table: "DiscountEntity",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryEntity",
                schema: "RosaFiesta",
                table: "CategoryEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartEntity",
                schema: "RosaFiesta",
                table: "CartEntity",
                column: "CartId");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "Age", "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { 15, "37339a29-ea4e-4c5f-9741-c7f784a5d642", new DateTimeOffset(new DateTime(2023, 6, 25, 12, 34, 59, 252, DateTimeKind.Unspecified).AddTicks(6729), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEK5VLGhvsmPCyNCImUmaxwYV1WZ2ZksbCxvzTYVuavqpGiLU7juDbyn4rusbIcq+Rw==", "27af544a-f7c9-4939-92fa-96546cd7a564" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "Age", "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { 15, "24a03d23-83d5-46ec-95cd-e97133d3f49b", new DateTimeOffset(new DateTime(2023, 6, 25, 12, 34, 59, 252, DateTimeKind.Unspecified).AddTicks(6739), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEFMRaq6OV28QGCLGL/ccfvoJlV5Y14mCe6wOcM8QLTEEfvnlRWTIYUXNU27CmpG25w==", "d910c400-a45a-43cf-97ee-e6f11cfa76d8" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "Age", "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { 15, "4356958b-e234-4fcf-a704-fce1a1a68d25", new DateTimeOffset(new DateTime(2023, 6, 25, 12, 34, 59, 252, DateTimeKind.Unspecified).AddTicks(6784), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEIYqECmmIUbmacT9mJDONcqNX+e4xIkU1T73KjFponTBDLrRi7aNUQ/ZfKK7xaOeNw==", "e51b21ec-b0be-4410-987b-a1575eadbfe3" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "Age", "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { 15, "729f145b-bd0b-4a7a-9173-e131ffd4bc67", new DateTimeOffset(new DateTime(2023, 6, 25, 12, 34, 59, 252, DateTimeKind.Unspecified).AddTicks(6715), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEB5vlA0x5bHS+p8E6/tsUNKrN+xyfY+gpItzbtlEYoMauBNzJ1aXlSko8JOMIO4ngQ==", "6872fa88-edae-4159-8a87-d2cf9f191f29" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "Age", "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { 45, "f7baa828-fb76-4e9f-9038-3a5976089e5f", new DateTimeOffset(new DateTime(2023, 6, 25, 12, 34, 59, 252, DateTimeKind.Unspecified).AddTicks(6468), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAECpxjs7xhd5O4f/uyCKO+dcTYoYiCH1yoAHZiHfh+5aVZF0+2lKkv8Jt8YHbyH8Dfw==", "6c3b5d5f-66ca-416b-b31a-e3afb9cc1674" });

            migrationBuilder.CreateIndex(
                name: "IX_SupplierEntity_Email",
                schema: "RosaFiesta",
                table: "SupplierEntity",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupplierEntity_Phone",
                schema: "RosaFiesta",
                table: "SupplierEntity",
                column: "Phone",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppliedDiscounts_DiscountEntity_Code",
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                column: "Code",
                principalSchema: "RosaFiesta",
                principalTable: "DiscountEntity",
                principalColumn: "Code",
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

            migrationBuilder.AddForeignKey(
                name: "FK_CartEntity_AspNetUsers_UserId",
                schema: "RosaFiesta",
                table: "CartEntity",
                column: "UserId",
                principalSchema: "RosaFiesta",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_ProductEntity_ProductCode",
                schema: "RosaFiesta",
                table: "Options",
                column: "ProductCode",
                principalSchema: "RosaFiesta",
                principalTable: "ProductEntity",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEntity_Addresses_AddressId",
                schema: "RosaFiesta",
                table: "OrderEntity",
                column: "AddressId",
                principalSchema: "RosaFiesta",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEntity_AspNetUsers_UserId",
                schema: "RosaFiesta",
                table: "OrderEntity",
                column: "UserId",
                principalSchema: "RosaFiesta",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEntity_PayMethodEntity_PayMethodId",
                schema: "RosaFiesta",
                table: "OrderEntity",
                column: "PayMethodId",
                principalSchema: "RosaFiesta",
                principalTable: "PayMethodEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PayMethodEntity_AspNetUsers_UserId",
                schema: "RosaFiesta",
                table: "PayMethodEntity",
                column: "UserId",
                principalSchema: "RosaFiesta",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductEntity_CategoryEntity_CategoryId",
                schema: "RosaFiesta",
                table: "ProductEntity",
                column: "CategoryId",
                principalSchema: "RosaFiesta",
                principalTable: "CategoryEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductEntity_SubCategoryEntity_SubCategoryId",
                schema: "RosaFiesta",
                table: "ProductEntity",
                column: "SubCategoryId",
                principalSchema: "RosaFiesta",
                principalTable: "SubCategoryEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductEntity_SupplierEntity_SupplierId",
                schema: "RosaFiesta",
                table: "ProductEntity",
                column: "SupplierId",
                principalSchema: "RosaFiesta",
                principalTable: "SupplierEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductEntity_Warranties_WarrantyId",
                schema: "RosaFiesta",
                table: "ProductEntity",
                column: "WarrantyId",
                principalSchema: "RosaFiesta",
                principalTable: "Warranties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsDiscountsEntity_DiscountEntity_Code",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                column: "Code",
                principalSchema: "RosaFiesta",
                principalTable: "DiscountEntity",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsDiscountsEntity_Options_OptionId",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                column: "OptionId",
                principalSchema: "RosaFiesta",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsDiscountsEntity_ProductEntity_ProductEntityCode",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                column: "ProductEntityCode",
                principalSchema: "RosaFiesta",
                principalTable: "ProductEntity",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetailEntity_CartEntity_CartId",
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                column: "CartId",
                principalSchema: "RosaFiesta",
                principalTable: "CartEntity",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetailEntity_OrderEntity_OrderId",
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                column: "OrderId",
                principalSchema: "RosaFiesta",
                principalTable: "OrderEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetailEntity_ProductEntity_ProductId",
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                column: "ProductId",
                principalSchema: "RosaFiesta",
                principalTable: "ProductEntity",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetailOptions_AppliedDiscounts_AppliedId",
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                column: "AppliedId",
                principalSchema: "RosaFiesta",
                principalTable: "AppliedDiscounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetailOptions_Options_OptionId",
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                column: "OptionId",
                principalSchema: "RosaFiesta",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetailOptions_PurchaseDetailEntity_PurchaseNumber",
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                column: "PurchaseNumber",
                principalSchema: "RosaFiesta",
                principalTable: "PurchaseDetailEntity",
                principalColumn: "PurchaseNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteItemEntity_Quotes_QuoteId",
                schema: "RosaFiesta",
                table: "QuoteItemEntity",
                column: "QuoteId",
                principalSchema: "RosaFiesta",
                principalTable: "Quotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteItemEntity_Services_ServiceId",
                schema: "RosaFiesta",
                table: "QuoteItemEntity",
                column: "ServiceId",
                principalSchema: "RosaFiesta",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewEntity_AspNetUsers_UserId",
                schema: "RosaFiesta",
                table: "ReviewEntity",
                column: "UserId",
                principalSchema: "RosaFiesta",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewEntity_Options_OptionId",
                schema: "RosaFiesta",
                table: "ReviewEntity",
                column: "OptionId",
                principalSchema: "RosaFiesta",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryEntity_CategoryEntity_CategoryId",
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                column: "CategoryId",
                principalSchema: "RosaFiesta",
                principalTable: "CategoryEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishListProductsEntity_Options_OptionId",
                schema: "RosaFiesta",
                table: "WishListProductsEntity",
                column: "OptionId",
                principalSchema: "RosaFiesta",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishListProductsEntity_WishesList_WishListId",
                schema: "RosaFiesta",
                table: "WishListProductsEntity",
                column: "WishListId",
                principalSchema: "RosaFiesta",
                principalTable: "WishesList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
