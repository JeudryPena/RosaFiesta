using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class productSubcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductEntity_CategoryEntity_CategoryId",
                schema: "RosaFiesta",
                table: "ProductEntity");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                schema: "RosaFiesta",
                table: "ProductEntity",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                schema: "RosaFiesta",
                table: "ProductEntity",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 20, 20, 16, 750, DateTimeKind.Unspecified).AddTicks(8498), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 20, 20, 16, 750, DateTimeKind.Unspecified).AddTicks(8538), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 20, 20, 16, 750, DateTimeKind.Unspecified).AddTicks(8539), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4242a4a-24db-485d-8408-beec865239d6", new DateTimeOffset(new DateTime(2023, 6, 12, 0, 20, 16, 790, DateTimeKind.Unspecified).AddTicks(5621), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEF27i8u7eIvsC+oTzkxGxtIGQRlt53opjSiBRLTbIg1ZFaC60ehOqAs3AJgLStTG5g==", "2a3da2a7-2bac-4bc3-9d7c-a1bcba1806ef" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd83184e-a6d5-4833-8d99-1fd489dbc61e", new DateTimeOffset(new DateTime(2023, 6, 12, 0, 20, 16, 790, DateTimeKind.Unspecified).AddTicks(5643), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEI23E+tUf9uvZCSFf6hGNN5IgQWiW3CqCmtkmRXd0cOUIxtDlDItUlLWj+MwpHzvCg==", "95ac2588-3b07-46f0-9b55-232bafae096c" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6c60832-1216-4f36-901c-e48886ebfed2", new DateTimeOffset(new DateTime(2023, 6, 12, 0, 20, 16, 790, DateTimeKind.Unspecified).AddTicks(5679), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEJOrwtUx+6fzLcxVyapmZ8DGAcAnmpR2q+wKb6Rh1QC5eOPC1njzTpEmUQmCxtwE5g==", "c85ec0d9-6092-4c18-a6d5-dcfda709d3be" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ef9e89c-4959-4bd5-a584-fe5ea1628632", new DateTimeOffset(new DateTime(2023, 6, 12, 0, 20, 16, 790, DateTimeKind.Unspecified).AddTicks(5236), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEPkNKNsxWNecL3QvzRUW60VhWyO9QPkRKK/HlZMl1dvRd/ToTC/ItQVMjMiAkYYJzg==", "e90e9082-8543-4506-bb39-3f57f8b778e9" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dab49278-aca7-483d-acd2-91460f951169", new DateTimeOffset(new DateTime(2023, 6, 12, 0, 20, 16, 790, DateTimeKind.Unspecified).AddTicks(4719), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEI8CYiA48PVIOpX51BKqc3AQboI9xljdCP1bmbSd5SG+f/czQTgmji+BzNT4x8+Tsw==", "df3050af-9483-4269-8143-d8bc1057c1e1" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 12, 0, 20, 16, 753, DateTimeKind.Unspecified).AddTicks(1488), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "ROSA",
                columns: new[] { "CreatedAt", "Start" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 12, 0, 20, 16, 756, DateTimeKind.Unspecified).AddTicks(8717), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 12, 0, 20, 16, 756, DateTimeKind.Unspecified).AddTicks(8712), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "WELCOME",
                columns: new[] { "CreatedAt", "Start" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 12, 0, 20, 16, 756, DateTimeKind.Unspecified).AddTicks(8721), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 12, 0, 20, 16, 756, DateTimeKind.Unspecified).AddTicks(8720), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 12, 0, 20, 16, 759, DateTimeKind.Unspecified).AddTicks(1696), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 12, 0, 20, 16, 759, DateTimeKind.Unspecified).AddTicks(1701), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 12, 0, 20, 16, 759, DateTimeKind.Unspecified).AddTicks(1705), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PayMethodEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 20, 20, 16, 760, DateTimeKind.Unspecified).AddTicks(5773), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA01",
                columns: new[] { "CreatedAt", "SubCategoryId" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 11, 20, 20, 16, 763, DateTimeKind.Unspecified).AddTicks(7585), new TimeSpan(0, -4, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA02",
                columns: new[] { "CreatedAt", "SubCategoryId" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 11, 20, 20, 16, 763, DateTimeKind.Unspecified).AddTicks(7609), new TimeSpan(0, -4, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 20, 20, 16, 767, DateTimeKind.Unspecified).AddTicks(4446), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 20, 20, 16, 767, DateTimeKind.Unspecified).AddTicks(4463), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 20, 20, 16, 769, DateTimeKind.Unspecified).AddTicks(9853), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 20, 20, 16, 769, DateTimeKind.Unspecified).AddTicks(9868), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 20, 20, 16, 769, DateTimeKind.Unspecified).AddTicks(9869), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 20, 20, 16, 771, DateTimeKind.Unspecified).AddTicks(1902), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f8"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 20, 20, 16, 771, DateTimeKind.Unspecified).AddTicks(1897), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 12, 0, 20, 16, 773, DateTimeKind.Unspecified).AddTicks(1609), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SupplierEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 12, 0, 20, 16, 780, DateTimeKind.Unspecified).AddTicks(9855), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Warranties",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 12, 0, 20, 17, 114, DateTimeKind.Unspecified).AddTicks(4388), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntity_SubCategoryId",
                schema: "RosaFiesta",
                table: "ProductEntity",
                column: "SubCategoryId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductEntity_CategoryEntity_CategoryId",
                schema: "RosaFiesta",
                table: "ProductEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductEntity_SubCategoryEntity_SubCategoryId",
                schema: "RosaFiesta",
                table: "ProductEntity");

            migrationBuilder.DropIndex(
                name: "IX_ProductEntity_SubCategoryId",
                schema: "RosaFiesta",
                table: "ProductEntity");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                schema: "RosaFiesta",
                table: "ProductEntity");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                schema: "RosaFiesta",
                table: "ProductEntity",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 18, 22, 55, 235, DateTimeKind.Unspecified).AddTicks(7850), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 18, 22, 55, 235, DateTimeKind.Unspecified).AddTicks(7878), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 18, 22, 55, 235, DateTimeKind.Unspecified).AddTicks(7879), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a01b3774-60b0-4c7c-86aa-b6be9b3a2668", new DateTimeOffset(new DateTime(2023, 6, 11, 22, 22, 55, 251, DateTimeKind.Unspecified).AddTicks(1927), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEN0SmvQVwhrDTnqRc93yBbYjFB7hxs9RSosjAulNj6aGGlHsulg0vVCKkXiikzbKsg==", "b8a7a272-4764-4e78-839d-2cd52b5d1a7c" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5662cd30-c499-4725-9ee8-6b5c926d10aa", new DateTimeOffset(new DateTime(2023, 6, 11, 22, 22, 55, 251, DateTimeKind.Unspecified).AddTicks(1938), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEC7YhDA7bsMlatkvO2QEvtTm9Y1NZ7avlRNl2Vkk4XdrOcLZna7KUqzgQg0AySFTJw==", "cbcc3caa-8794-4e0f-8faa-77cbf88b3fc6" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a631d1cf-1cc6-437f-bae4-3933fe692121", new DateTimeOffset(new DateTime(2023, 6, 11, 22, 22, 55, 251, DateTimeKind.Unspecified).AddTicks(1948), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEEUDmrVe5P0p2a8f26gBSjeg1iTOEVYJRXb/2aC0rr61ERwHONyD7WlKLaJioKaz6g==", "6d794544-de52-4196-98cb-346712cd4695" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68468f4b-1e7d-430b-9e06-e9372320e2f8", new DateTimeOffset(new DateTime(2023, 6, 11, 22, 22, 55, 251, DateTimeKind.Unspecified).AddTicks(1917), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEFH56AFRu/WOsF62n7M2sFNrtKlhttP4rXjU6lES01TahyrNvEhNWMlfqUc8sSxbxQ==", "d64401de-05da-42d2-aa00-9878bbf9c9ad" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2754ece-7967-4f39-987b-42c59059f50e", new DateTimeOffset(new DateTime(2023, 6, 11, 22, 22, 55, 251, DateTimeKind.Unspecified).AddTicks(1899), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEJdrjXYrrkxT/yb78ioTgoNhQmS2vvnBvc5wzlx7j1QOU4Xf9paPnZFFNM6o3NqyeQ==", "5ba7a191-f696-49ce-9506-f98943dcb3e9" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 22, 22, 55, 237, DateTimeKind.Unspecified).AddTicks(5517), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "ROSA",
                columns: new[] { "CreatedAt", "Start" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 11, 22, 22, 55, 238, DateTimeKind.Unspecified).AddTicks(8789), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 11, 22, 22, 55, 238, DateTimeKind.Unspecified).AddTicks(8785), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "WELCOME",
                columns: new[] { "CreatedAt", "Start" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 11, 22, 22, 55, 238, DateTimeKind.Unspecified).AddTicks(8792), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 11, 22, 22, 55, 238, DateTimeKind.Unspecified).AddTicks(8791), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 22, 22, 55, 239, DateTimeKind.Unspecified).AddTicks(7766), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 22, 22, 55, 239, DateTimeKind.Unspecified).AddTicks(7770), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 22, 22, 55, 239, DateTimeKind.Unspecified).AddTicks(7773), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PayMethodEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 18, 22, 55, 240, DateTimeKind.Unspecified).AddTicks(8931), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA01",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 18, 22, 55, 242, DateTimeKind.Unspecified).AddTicks(5175), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA02",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 18, 22, 55, 242, DateTimeKind.Unspecified).AddTicks(5203), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 18, 22, 55, 243, DateTimeKind.Unspecified).AddTicks(5321), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 18, 22, 55, 243, DateTimeKind.Unspecified).AddTicks(5330), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 18, 22, 55, 244, DateTimeKind.Unspecified).AddTicks(7568), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 18, 22, 55, 244, DateTimeKind.Unspecified).AddTicks(7578), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 18, 22, 55, 244, DateTimeKind.Unspecified).AddTicks(7580), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 18, 22, 55, 245, DateTimeKind.Unspecified).AddTicks(4980), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f8"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 18, 22, 55, 245, DateTimeKind.Unspecified).AddTicks(4976), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 22, 22, 55, 246, DateTimeKind.Unspecified).AddTicks(1507), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SupplierEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 22, 22, 55, 246, DateTimeKind.Unspecified).AddTicks(3332), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Warranties",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 22, 22, 55, 540, DateTimeKind.Unspecified).AddTicks(9237), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_ProductEntity_CategoryEntity_CategoryId",
                schema: "RosaFiesta",
                table: "ProductEntity",
                column: "CategoryId",
                principalSchema: "RosaFiesta",
                principalTable: "CategoryEntity",
                principalColumn: "Id");
        }
    }
}
