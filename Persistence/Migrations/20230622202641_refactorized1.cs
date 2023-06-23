using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class refactorized1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsDiscountsEntity_ProductEntity_ProductId",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                newName: "ProductCode");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsDiscountsEntity_ProductId",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                newName: "IX_ProductsDiscountsEntity_ProductCode");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AppliedDate", "CreatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 22, 16, 26, 41, 15, DateTimeKind.Unspecified).AddTicks(4853), new TimeSpan(0, -4, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 22, 16, 26, 41, 15, DateTimeKind.Unspecified).AddTicks(4514), new TimeSpan(0, -4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AppliedDate", "CreatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 22, 16, 26, 41, 15, DateTimeKind.Unspecified).AddTicks(4856), new TimeSpan(0, -4, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 22, 16, 26, 41, 15, DateTimeKind.Unspecified).AddTicks(4855), new TimeSpan(0, -4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AppliedDate", "CreatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 22, 16, 26, 41, 15, DateTimeKind.Unspecified).AddTicks(4859), new TimeSpan(0, -4, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 22, 16, 26, 41, 15, DateTimeKind.Unspecified).AddTicks(4857), new TimeSpan(0, -4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ae2e1a6-b7e7-4f00-b782-1ee11102115b", new DateTimeOffset(new DateTime(2023, 6, 22, 20, 26, 41, 43, DateTimeKind.Unspecified).AddTicks(3506), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEP0aEc1DLsEhPC7OqzT/SKd4FGEExlnUL2ZkafK179uU5BSf2yo0gMDgQnpXmvd0+Q==", "d6d6745a-83df-4825-bb91-e96c01e8dc01" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "198894ea-4254-40ee-afe5-a05c556c7748", new DateTimeOffset(new DateTime(2023, 6, 22, 20, 26, 41, 43, DateTimeKind.Unspecified).AddTicks(3563), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEBx3nDF16oh/NrAwxd/D0ta0RyanPTn0oQLxmfWHsj4gBF8URzBy/IUZu+bXc4CgHw==", "b8adb814-c373-4512-b7b2-8785b66cdd6a" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3e1fd1b-c231-4fe0-be9a-b0af6e574aaf", new DateTimeOffset(new DateTime(2023, 6, 22, 20, 26, 41, 43, DateTimeKind.Unspecified).AddTicks(3591), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEBy+F3WhCWHBNPwSW2ISYxzgr5Kw7QI64xCVE5GhHl20y0IkRr5knCznLKNA+G4njg==", "468746b9-2deb-4c9f-a6cd-1cc17ae81130" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75ec262e-3396-4069-9d02-0b8f85f19642", new DateTimeOffset(new DateTime(2023, 6, 22, 20, 26, 41, 43, DateTimeKind.Unspecified).AddTicks(3493), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAECZzJMmhMwiKPrPGUbX5TuVFuAFSeCWKz2UOTPy+4aVOOW2c7QssdxRRsTGYtTnIxQ==", "d67d723f-ee84-4323-9810-ba6f5b22e74b" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da300112-13c5-4e24-b4cb-a67a022cc22b", new DateTimeOffset(new DateTime(2023, 6, 22, 20, 26, 41, 43, DateTimeKind.Unspecified).AddTicks(3471), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEJi/sl2pPUj2LFU2tlgP508rzKSjKYzUeEmvO1DYP3Dp4cSBRsml02YV5IyPaW1FWA==", "ffc261ec-ca3f-481e-a730-a23be2ff12ec" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 20, 26, 41, 18, DateTimeKind.Unspecified).AddTicks(7528), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "ROSA",
                columns: new[] { "CreatedAt", "Start" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 22, 20, 26, 41, 21, DateTimeKind.Unspecified).AddTicks(1846), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 22, 20, 26, 41, 21, DateTimeKind.Unspecified).AddTicks(1837), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "WELCOME",
                columns: new[] { "CreatedAt", "Start" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 22, 20, 26, 41, 21, DateTimeKind.Unspecified).AddTicks(1850), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 22, 20, 26, 41, 21, DateTimeKind.Unspecified).AddTicks(1849), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 20, 26, 41, 22, DateTimeKind.Unspecified).AddTicks(6734), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 20, 26, 41, 22, DateTimeKind.Unspecified).AddTicks(6741), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 20, 26, 41, 22, DateTimeKind.Unspecified).AddTicks(6745), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PayMethodEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 26, 41, 24, DateTimeKind.Unspecified).AddTicks(1606), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA01",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 26, 41, 27, DateTimeKind.Unspecified).AddTicks(4193), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA02",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 26, 41, 27, DateTimeKind.Unspecified).AddTicks(4391), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 26, 41, 27, DateTimeKind.Unspecified).AddTicks(9428), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f5"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 26, 41, 27, DateTimeKind.Unspecified).AddTicks(9453), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 26, 41, 27, DateTimeKind.Unspecified).AddTicks(9455), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 26, 41, 29, DateTimeKind.Unspecified).AddTicks(3032), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 26, 41, 29, DateTimeKind.Unspecified).AddTicks(3048), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 26, 41, 31, DateTimeKind.Unspecified).AddTicks(5618), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 26, 41, 31, DateTimeKind.Unspecified).AddTicks(5634), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 26, 41, 31, DateTimeKind.Unspecified).AddTicks(5636), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 26, 41, 32, DateTimeKind.Unspecified).AddTicks(7215), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f8"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 26, 41, 32, DateTimeKind.Unspecified).AddTicks(7194), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 20, 26, 41, 34, DateTimeKind.Unspecified).AddTicks(2134), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SupplierEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 20, 26, 41, 34, DateTimeKind.Unspecified).AddTicks(5376), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Warranties",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 20, 26, 41, 390, DateTimeKind.Unspecified).AddTicks(1703), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsDiscountsEntity_ProductEntity_ProductCode",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                column: "ProductCode",
                principalSchema: "RosaFiesta",
                principalTable: "ProductEntity",
                principalColumn: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsDiscountsEntity_ProductEntity_ProductCode",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity");

            migrationBuilder.RenameColumn(
                name: "ProductCode",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsDiscountsEntity_ProductCode",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                newName: "IX_ProductsDiscountsEntity_ProductId");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AppliedDate", "CreatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 22, 16, 14, 39, 107, DateTimeKind.Unspecified).AddTicks(3664), new TimeSpan(0, -4, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 22, 16, 14, 39, 107, DateTimeKind.Unspecified).AddTicks(3624), new TimeSpan(0, -4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AppliedDate", "CreatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 22, 16, 14, 39, 107, DateTimeKind.Unspecified).AddTicks(3666), new TimeSpan(0, -4, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 22, 16, 14, 39, 107, DateTimeKind.Unspecified).AddTicks(3665), new TimeSpan(0, -4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AppliedDate", "CreatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 22, 16, 14, 39, 107, DateTimeKind.Unspecified).AddTicks(3669), new TimeSpan(0, -4, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 22, 16, 14, 39, 107, DateTimeKind.Unspecified).AddTicks(3668), new TimeSpan(0, -4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b25bc3c8-391d-4107-b014-67e78ee049e5", new DateTimeOffset(new DateTime(2023, 6, 22, 20, 14, 39, 126, DateTimeKind.Unspecified).AddTicks(2090), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAENtV6JTCVXfMIAiQVynV2XX7vVOmrYVkQa1m7vh+MzZVWJHO4V07rgRI8af/ybu+1A==", "566b9200-62a2-4c4d-b402-458143e2e056" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4052c20-6475-439d-a978-a5ac085f6975", new DateTimeOffset(new DateTime(2023, 6, 22, 20, 14, 39, 126, DateTimeKind.Unspecified).AddTicks(2100), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEPTCe6CVGK+JxookzkgRQRFqtmO15nFhd4AXoSav01u96WvoPGanmv9tdozj5WwUPQ==", "2634b749-c7b6-46b5-9772-6b8004a518b7" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d966c8d-c306-4ad6-8579-5eeb5455b732", new DateTimeOffset(new DateTime(2023, 6, 22, 20, 14, 39, 126, DateTimeKind.Unspecified).AddTicks(2111), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAELozt9NA1P1GLg2C/uoeuQkvJIFZQss/zIsJ6quX1iDu6Q10ywnkNuuhCtX+AET4dw==", "d3d04fe6-025a-4977-848f-66e8c3fc1fed" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b5fa9b9-6f8c-4671-b748-716617f9bca6", new DateTimeOffset(new DateTime(2023, 6, 22, 20, 14, 39, 126, DateTimeKind.Unspecified).AddTicks(2079), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEHkDKFCpX29AOk0blUT/O+OTlr7GSpepbdzzlbV67/5WqveMhhqcaYGBvXQ4vwRiyw==", "0ed0db97-893a-4f6a-9ba4-05b06608e356" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f998e8e-e52c-4977-8c1f-bef7804eb38a", new DateTimeOffset(new DateTime(2023, 6, 22, 20, 14, 39, 126, DateTimeKind.Unspecified).AddTicks(2047), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEJJMKNcfeWBhdIw7YTfBFlGKckKwPgyMfK6xsFLC8j39NiPIB/vDIyxvmWsoWd7yjg==", "ff83678d-24e0-48b0-a10e-0da779e3dab4" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 20, 14, 39, 109, DateTimeKind.Unspecified).AddTicks(4875), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "ROSA",
                columns: new[] { "CreatedAt", "Start" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 22, 20, 14, 39, 111, DateTimeKind.Unspecified).AddTicks(4227), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 22, 20, 14, 39, 111, DateTimeKind.Unspecified).AddTicks(4220), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "WELCOME",
                columns: new[] { "CreatedAt", "Start" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 22, 20, 14, 39, 111, DateTimeKind.Unspecified).AddTicks(4231), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 22, 20, 14, 39, 111, DateTimeKind.Unspecified).AddTicks(4230), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 20, 14, 39, 112, DateTimeKind.Unspecified).AddTicks(9335), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 20, 14, 39, 112, DateTimeKind.Unspecified).AddTicks(9343), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 20, 14, 39, 112, DateTimeKind.Unspecified).AddTicks(9347), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PayMethodEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 14, 39, 114, DateTimeKind.Unspecified).AddTicks(4085), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA01",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 14, 39, 116, DateTimeKind.Unspecified).AddTicks(4739), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA02",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 14, 39, 116, DateTimeKind.Unspecified).AddTicks(4768), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 14, 39, 116, DateTimeKind.Unspecified).AddTicks(7957), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f5"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 14, 39, 116, DateTimeKind.Unspecified).AddTicks(7978), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 14, 39, 116, DateTimeKind.Unspecified).AddTicks(7980), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 14, 39, 117, DateTimeKind.Unspecified).AddTicks(5904), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 14, 39, 117, DateTimeKind.Unspecified).AddTicks(5915), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 14, 39, 119, DateTimeKind.Unspecified).AddTicks(1342), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 14, 39, 119, DateTimeKind.Unspecified).AddTicks(1356), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 14, 39, 119, DateTimeKind.Unspecified).AddTicks(1360), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 14, 39, 120, DateTimeKind.Unspecified).AddTicks(828), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f8"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 16, 14, 39, 120, DateTimeKind.Unspecified).AddTicks(822), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 20, 14, 39, 121, DateTimeKind.Unspecified).AddTicks(953), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SupplierEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 20, 14, 39, 121, DateTimeKind.Unspecified).AddTicks(3036), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Warranties",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 22, 20, 14, 39, 498, DateTimeKind.Unspecified).AddTicks(6348), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsDiscountsEntity_ProductEntity_ProductId",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                column: "ProductId",
                principalSchema: "RosaFiesta",
                principalTable: "ProductEntity",
                principalColumn: "Code");
        }
    }
}
