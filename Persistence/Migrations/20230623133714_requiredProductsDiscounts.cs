using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class requiredProductsDiscounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AppliedDate", "CreatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 23, 9, 37, 12, 964, DateTimeKind.Unspecified).AddTicks(4646), new TimeSpan(0, -4, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 23, 9, 37, 12, 964, DateTimeKind.Unspecified).AddTicks(4590), new TimeSpan(0, -4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AppliedDate", "CreatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 23, 9, 37, 12, 964, DateTimeKind.Unspecified).AddTicks(4652), new TimeSpan(0, -4, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 23, 9, 37, 12, 964, DateTimeKind.Unspecified).AddTicks(4650), new TimeSpan(0, -4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AppliedDate", "CreatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 23, 9, 37, 12, 964, DateTimeKind.Unspecified).AddTicks(4655), new TimeSpan(0, -4, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 23, 9, 37, 12, 964, DateTimeKind.Unspecified).AddTicks(4653), new TimeSpan(0, -4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00978f60-4c4b-4f23-b76b-b3eed7ecd141", new DateTimeOffset(new DateTime(2023, 6, 23, 13, 37, 12, 997, DateTimeKind.Unspecified).AddTicks(8340), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEGYcQjL8wY4iSwOyA2ou9fwci8//d8DLcqxG3jQzhyizoeziH9pcRhc7jg+H5tfweg==", "86da46e0-c5f6-4271-a3b3-1d8fd69812ae" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e26f9be7-6948-46f2-8206-a93ef4309963", new DateTimeOffset(new DateTime(2023, 6, 23, 13, 37, 12, 997, DateTimeKind.Unspecified).AddTicks(8355), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEOP2+u+PZ4VhwNtlTm349g20VsjEUBMno11hZndMYAh+RzaKrAXr4bKDx97niSbpgA==", "e3995d34-f726-4635-9f42-1b6b61a1a873" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ffa1e25-dc81-4b8a-b788-5b9ca421bc6c", new DateTimeOffset(new DateTime(2023, 6, 23, 13, 37, 12, 997, DateTimeKind.Unspecified).AddTicks(8396), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEITrvkKQI8AXAbY7OqBzuZxPa8ZZVSXNuEt+kj78Cw0Eoq3qJ4NmAM+ngfB0LsDAqw==", "26697739-11da-4efe-b018-a75b91f3b5ca" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e3877a3-68be-466b-b6a3-9b59ebcfd453", new DateTimeOffset(new DateTime(2023, 6, 23, 13, 37, 12, 997, DateTimeKind.Unspecified).AddTicks(8243), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAENqWeeo7XWgoCFw8cov++JQ+xVnjfQZVFJLnQHoYzBO/IdATqcW+Owkm8Kf/s4H7ow==", "a0861103-5484-47f0-91ae-bf5abde05e72" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d7d43c9-3649-40d6-9afb-1b5022aebf24", new DateTimeOffset(new DateTime(2023, 6, 23, 13, 37, 12, 997, DateTimeKind.Unspecified).AddTicks(8200), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEGuA+OYmQmLrKzSJ1WW6HFrZ8Evsgm6D0ldAWgY2TUAEWRgxTwq4Zak7RwqlPUkx3Q==", "959d69f3-2761-4a68-a820-805626b70b3a" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 13, 37, 12, 967, DateTimeKind.Unspecified).AddTicks(8299), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "ROSA",
                columns: new[] { "CreatedAt", "Start", "Type" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 23, 13, 37, 12, 972, DateTimeKind.Unspecified).AddTicks(6761), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 23, 13, 37, 12, 972, DateTimeKind.Unspecified).AddTicks(6721), new TimeSpan(0, 0, 0, 0, 0)), 2 });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "WELCOME",
                columns: new[] { "CreatedAt", "Start", "Type" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 23, 13, 37, 12, 972, DateTimeKind.Unspecified).AddTicks(6791), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 23, 13, 37, 12, 972, DateTimeKind.Unspecified).AddTicks(6789), new TimeSpan(0, 0, 0, 0, 0)), 1 });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 13, 37, 12, 975, DateTimeKind.Unspecified).AddTicks(6672), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 13, 37, 12, 975, DateTimeKind.Unspecified).AddTicks(6702), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 13, 37, 12, 975, DateTimeKind.Unspecified).AddTicks(6709), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PayMethodEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 37, 12, 978, DateTimeKind.Unspecified).AddTicks(880), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA01",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 37, 12, 980, DateTimeKind.Unspecified).AddTicks(9407), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA02",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 37, 12, 980, DateTimeKind.Unspecified).AddTicks(9485), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 37, 12, 981, DateTimeKind.Unspecified).AddTicks(4395), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f5"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 37, 12, 981, DateTimeKind.Unspecified).AddTicks(4423), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 37, 12, 981, DateTimeKind.Unspecified).AddTicks(4426), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 37, 12, 982, DateTimeKind.Unspecified).AddTicks(4012), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 37, 12, 982, DateTimeKind.Unspecified).AddTicks(4032), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 37, 12, 983, DateTimeKind.Unspecified).AddTicks(9966), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 37, 12, 983, DateTimeKind.Unspecified).AddTicks(9982), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 37, 12, 983, DateTimeKind.Unspecified).AddTicks(9984), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 37, 12, 985, DateTimeKind.Unspecified).AddTicks(2091), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f8"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 37, 12, 985, DateTimeKind.Unspecified).AddTicks(2066), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 13, 37, 12, 986, DateTimeKind.Unspecified).AddTicks(9027), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SupplierEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 13, 37, 12, 987, DateTimeKind.Unspecified).AddTicks(5525), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Warranties",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 13, 37, 13, 546, DateTimeKind.Unspecified).AddTicks(9274), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "CreatedAt", "Start", "Type" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 22, 20, 26, 41, 21, DateTimeKind.Unspecified).AddTicks(1846), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 22, 20, 26, 41, 21, DateTimeKind.Unspecified).AddTicks(1837), new TimeSpan(0, 0, 0, 0, 0)), 1 });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "WELCOME",
                columns: new[] { "CreatedAt", "Start", "Type" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 22, 20, 26, 41, 21, DateTimeKind.Unspecified).AddTicks(1850), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 22, 20, 26, 41, 21, DateTimeKind.Unspecified).AddTicks(1849), new TimeSpan(0, 0, 0, 0, 0)), 0 });

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
        }
    }
}
