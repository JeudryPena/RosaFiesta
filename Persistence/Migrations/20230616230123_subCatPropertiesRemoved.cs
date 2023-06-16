using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class subCatPropertiesRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "RosaFiesta",
                table: "SubCategoryEntity");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "RosaFiesta",
                table: "SubCategoryEntity");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 19, 1, 22, 852, DateTimeKind.Unspecified).AddTicks(3769), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 19, 1, 22, 852, DateTimeKind.Unspecified).AddTicks(3813), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 19, 1, 22, 852, DateTimeKind.Unspecified).AddTicks(3814), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e73ee07-2fe2-4075-b0d7-c91489b8b7ab", new DateTimeOffset(new DateTime(2023, 6, 16, 23, 1, 22, 880, DateTimeKind.Unspecified).AddTicks(1055), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEAA8DKpQ+FeYoxLfEm36HtQ0dllzcjElwZlI1/H+uP8N8aB+nF7jA0+ZUtXYdVFi8g==", "ffa965d8-4844-4802-ae90-1ee2282d4bbb" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2505bcc8-de66-4a92-bb00-7d6313af0b5c", new DateTimeOffset(new DateTime(2023, 6, 16, 23, 1, 22, 880, DateTimeKind.Unspecified).AddTicks(1078), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEE1EiNw5FqOFb5vZM1NtWw3uXFIYLfxZ8RJ4jbaNCzOBk3udxlY4CRztp2wtYxFvNA==", "eb30f77e-3df5-4fea-b745-f6c040bf0dd8" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25f0aa4a-bcc5-4ac0-a07b-c2b26cf65026", new DateTimeOffset(new DateTime(2023, 6, 16, 23, 1, 22, 880, DateTimeKind.Unspecified).AddTicks(1124), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEGgf5MbY+t5p+RDv6Xv9HzFvbaAcOAzzhZPSgyMQV93iLUL3Inr/pUBl6WdbkYgz5Q==", "5d0b7f27-6b4b-4734-8a05-502f8b7fce8c" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5f170e5-f2fe-461c-96ec-d5850bb8c55c", new DateTimeOffset(new DateTime(2023, 6, 16, 23, 1, 22, 880, DateTimeKind.Unspecified).AddTicks(1031), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAECEUsBDXwpw7+9eundgT+Ei2yInz0thLLNvTVzd32cLZofOY68JgESsPbf5FCCj3dA==", "e227113c-9294-4454-9230-a177cc985234" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f42f87f-0c7a-4db5-a64b-22d31365c825", new DateTimeOffset(new DateTime(2023, 6, 16, 23, 1, 22, 880, DateTimeKind.Unspecified).AddTicks(996), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAECEF7cNpVMxYTtiAWvI99Sx7B++8X4XNM6XnUlXvhiYOjVwIN4WtZ3YBCfgljLPqwA==", "7b99e44c-505a-491c-8f97-d216dbdd3426" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 16, 23, 1, 22, 854, DateTimeKind.Unspecified).AddTicks(4342), new TimeSpan(0, 0, 0, 0, 0)), "b22698b8-42a2-4115-9631-1c2d1e2ac5f7" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "ROSA",
                columns: new[] { "CreatedAt", "Start" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 16, 23, 1, 22, 856, DateTimeKind.Unspecified).AddTicks(3155), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 16, 23, 1, 22, 856, DateTimeKind.Unspecified).AddTicks(3150), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "WELCOME",
                columns: new[] { "CreatedAt", "Start" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 16, 23, 1, 22, 856, DateTimeKind.Unspecified).AddTicks(3159), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 16, 23, 1, 22, 856, DateTimeKind.Unspecified).AddTicks(3157), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 23, 1, 22, 857, DateTimeKind.Unspecified).AddTicks(7259), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 23, 1, 22, 857, DateTimeKind.Unspecified).AddTicks(7265), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 23, 1, 22, 857, DateTimeKind.Unspecified).AddTicks(7269), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PayMethodEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 19, 1, 22, 859, DateTimeKind.Unspecified).AddTicks(2605), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA01",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 19, 1, 22, 862, DateTimeKind.Unspecified).AddTicks(198), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA02",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 19, 1, 22, 862, DateTimeKind.Unspecified).AddTicks(299), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 19, 1, 22, 863, DateTimeKind.Unspecified).AddTicks(6733), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 19, 1, 22, 863, DateTimeKind.Unspecified).AddTicks(6747), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 19, 1, 22, 865, DateTimeKind.Unspecified).AddTicks(5159), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 19, 1, 22, 865, DateTimeKind.Unspecified).AddTicks(5178), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 19, 1, 22, 865, DateTimeKind.Unspecified).AddTicks(5180), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 19, 1, 22, 866, DateTimeKind.Unspecified).AddTicks(5467), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f8"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 19, 1, 22, 866, DateTimeKind.Unspecified).AddTicks(5462), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 23, 1, 22, 868, DateTimeKind.Unspecified).AddTicks(4003), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SupplierEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 23, 1, 22, 868, DateTimeKind.Unspecified).AddTicks(9467), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Warranties",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 23, 1, 23, 252, DateTimeKind.Unspecified).AddTicks(3813), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 16, 22, 23, 13, 342, DateTimeKind.Unspecified).AddTicks(9721), new TimeSpan(0, 0, 0, 0, 0)), "System" });

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
    }
}
