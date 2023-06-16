using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class categoryProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                schema: "RosaFiesta",
                table: "CategoryEntity",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "RosaFiesta",
                table: "CategoryEntity",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "RosaFiesta",
                table: "CategoryEntity",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 18, 23, 13, 340, DateTimeKind.Unspecified).AddTicks(5782), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 18, 23, 13, 340, DateTimeKind.Unspecified).AddTicks(5815), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 18, 23, 13, 340, DateTimeKind.Unspecified).AddTicks(5816), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6cfd7bd4-6f8a-4e34-a1cb-2ef4c21db5ee", new DateTimeOffset(new DateTime(2023, 6, 16, 22, 23, 13, 364, DateTimeKind.Unspecified).AddTicks(4573), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEO4aOhoZhnIQY/qD4X7djU4vwe67ZicnPKBcRmDgeb5NSqDagrGiSBMNnFR/4ZXnNQ==", "ef263852-4ad4-47d7-8576-5e8b129e487e" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d491be5-33cc-4373-93a0-16a5e7ce29d8", new DateTimeOffset(new DateTime(2023, 6, 16, 22, 23, 13, 364, DateTimeKind.Unspecified).AddTicks(4614), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEN8WkSmmx50RKpj9KtrwVD1lzbg+abFLDREZaMzH8RRkWMbe5lVLp3RMX2I2an9l6Q==", "9f62e25b-8eb6-4493-94b6-596aa225629c" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b51d0dea-50e2-49a8-822c-e5d133dead22", new DateTimeOffset(new DateTime(2023, 6, 16, 22, 23, 13, 364, DateTimeKind.Unspecified).AddTicks(4627), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEGqlCnr02K/WBi5DPfSRHmG5Gt5XBtpnXfkb7oYLtFwF1UdZB5Bmgm+xA2vig1cYoA==", "6b9564c5-68e5-4ad7-b74e-0d391ff800cf" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5be7781c-96b2-4dec-a3e6-3019866bc743", new DateTimeOffset(new DateTime(2023, 6, 16, 22, 23, 13, 364, DateTimeKind.Unspecified).AddTicks(4562), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEOxneGzlfpyFoNFEgW3ITSyffHeWaNdKf7cW2dCaaRSa5zH4tDQbqdjoIopaVuHOlg==", "21256e61-33d0-4e74-a8b9-fbe5e85f5537" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0df155fe-5dc7-4702-a564-0c16fdc0377f", new DateTimeOffset(new DateTime(2023, 6, 16, 22, 23, 13, 364, DateTimeKind.Unspecified).AddTicks(4531), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEP7uIPUjN9yqy3N98TeK4S0hADf+am0/2g+4w+uTpHIG1y4ya1KkjimiMPx1Rpgsfw==", "96193ed5-588b-4c9d-ba4e-05954cb56283" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy", "UpdatedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 16, 22, 23, 13, 342, DateTimeKind.Unspecified).AddTicks(9721), new TimeSpan(0, 0, 0, 0, 0)), "System", null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "ROSA",
                columns: new[] { "CreatedAt", "Start" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 16, 22, 23, 13, 345, DateTimeKind.Unspecified).AddTicks(6288), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 16, 22, 23, 13, 345, DateTimeKind.Unspecified).AddTicks(6280), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "WELCOME",
                columns: new[] { "CreatedAt", "Start" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 16, 22, 23, 13, 345, DateTimeKind.Unspecified).AddTicks(6294), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 16, 22, 23, 13, 345, DateTimeKind.Unspecified).AddTicks(6292), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 22, 23, 13, 347, DateTimeKind.Unspecified).AddTicks(4148), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 22, 23, 13, 347, DateTimeKind.Unspecified).AddTicks(4157), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 22, 23, 13, 347, DateTimeKind.Unspecified).AddTicks(4161), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PayMethodEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 18, 23, 13, 349, DateTimeKind.Unspecified).AddTicks(1013), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA01",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 18, 23, 13, 351, DateTimeKind.Unspecified).AddTicks(7510), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA02",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 18, 23, 13, 351, DateTimeKind.Unspecified).AddTicks(7548), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 18, 23, 13, 353, DateTimeKind.Unspecified).AddTicks(3707), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 18, 23, 13, 353, DateTimeKind.Unspecified).AddTicks(3722), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 18, 23, 13, 355, DateTimeKind.Unspecified).AddTicks(813), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 18, 23, 13, 355, DateTimeKind.Unspecified).AddTicks(826), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 18, 23, 13, 355, DateTimeKind.Unspecified).AddTicks(828), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 18, 23, 13, 356, DateTimeKind.Unspecified).AddTicks(2201), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f8"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 18, 23, 13, 356, DateTimeKind.Unspecified).AddTicks(2195), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy", "UpdatedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 16, 22, 23, 13, 357, DateTimeKind.Unspecified).AddTicks(4710), new TimeSpan(0, 0, 0, 0, 0)), "System", null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SupplierEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 22, 23, 13, 357, DateTimeKind.Unspecified).AddTicks(7844), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Warranties",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 22, 23, 13, 758, DateTimeKind.Unspecified).AddTicks(1154), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "RosaFiesta",
                table: "SubCategoryEntity");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "RosaFiesta",
                table: "SubCategoryEntity");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "RosaFiesta",
                table: "CategoryEntity");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "RosaFiesta",
                table: "CategoryEntity");

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                schema: "RosaFiesta",
                table: "CategoryEntity",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

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
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 20, 20, 16, 763, DateTimeKind.Unspecified).AddTicks(7585), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA02",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 11, 20, 20, 16, 763, DateTimeKind.Unspecified).AddTicks(7609), new TimeSpan(0, -4, 0, 0, 0)));

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
        }
    }
}
