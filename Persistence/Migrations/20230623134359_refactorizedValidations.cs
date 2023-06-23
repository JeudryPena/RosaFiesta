using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class refactorizedValidations : Migration
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
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 23, 9, 43, 58, 829, DateTimeKind.Unspecified).AddTicks(5673), new TimeSpan(0, -4, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 23, 9, 43, 58, 829, DateTimeKind.Unspecified).AddTicks(5640), new TimeSpan(0, -4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AppliedDate", "CreatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 23, 9, 43, 58, 829, DateTimeKind.Unspecified).AddTicks(5675), new TimeSpan(0, -4, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 23, 9, 43, 58, 829, DateTimeKind.Unspecified).AddTicks(5674), new TimeSpan(0, -4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AppliedDate", "CreatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 23, 9, 43, 58, 829, DateTimeKind.Unspecified).AddTicks(5677), new TimeSpan(0, -4, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 23, 9, 43, 58, 829, DateTimeKind.Unspecified).AddTicks(5676), new TimeSpan(0, -4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7181303-05e9-4252-8a8f-5afa34556640", new DateTimeOffset(new DateTime(2023, 6, 23, 13, 43, 58, 854, DateTimeKind.Unspecified).AddTicks(8841), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEHEKpYNDaH2PUernGlTUscGIZ7gyCI5Zi/v/8wKb7NOREDRo0gVpL7KqQNMFCkJpAQ==", "81717c8d-5a2f-4400-b9c9-25d925523926" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aab97a0b-cbfa-4cd0-86b7-64fd238db667", new DateTimeOffset(new DateTime(2023, 6, 23, 13, 43, 58, 854, DateTimeKind.Unspecified).AddTicks(8855), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEL5zSvS4vi3BWO8fQM3BUvWOO+eiX0puw+BTjekgiNDcVBSqRrZm2B6NNSZHf8v6Bg==", "3670efb4-02bd-474e-ab23-e8c649f81ca7" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d27c446c-5df6-476e-a73c-a559654225ac", new DateTimeOffset(new DateTime(2023, 6, 23, 13, 43, 58, 854, DateTimeKind.Unspecified).AddTicks(8890), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEEMjaeAgLSteiIc4PPsFcJNrTGMeK8R+S9uKcZ49y4y+vBVHB2nhCI34qbxvZwU0lQ==", "f05c5459-01ea-4f2d-be1e-d079bb0337fb" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddc5cacb-14d1-4a15-ba7a-e17ceea33ac7", new DateTimeOffset(new DateTime(2023, 6, 23, 13, 43, 58, 854, DateTimeKind.Unspecified).AddTicks(8830), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEGOSuzt63JbXGs3F2KV60g2VCke0RspviJMxl5raibtDGfhD1D7hxcvcqVH9v5ZLlQ==", "40b8b3b4-d6f1-4375-a8bc-114908ca3162" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06453d66-f078-474c-bf60-9b22425f64b7", new DateTimeOffset(new DateTime(2023, 6, 23, 13, 43, 58, 854, DateTimeKind.Unspecified).AddTicks(8807), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEAJJLfoXhK2QZ5Dyg0cr6+NHaLJ2HV75ptxGHbG7jakczlRXydBNglx+pCxGybaxqQ==", "b3d1a23e-0db7-4788-8810-caa766ace99e" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 13, 43, 58, 831, DateTimeKind.Unspecified).AddTicks(8986), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "ROSA",
                columns: new[] { "CreatedAt", "Start" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 23, 13, 43, 58, 833, DateTimeKind.Unspecified).AddTicks(9434), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 23, 13, 43, 58, 833, DateTimeKind.Unspecified).AddTicks(9428), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "WELCOME",
                columns: new[] { "CreatedAt", "Start" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 23, 13, 43, 58, 833, DateTimeKind.Unspecified).AddTicks(9439), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 23, 13, 43, 58, 833, DateTimeKind.Unspecified).AddTicks(9437), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 13, 43, 58, 835, DateTimeKind.Unspecified).AddTicks(2131), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 13, 43, 58, 835, DateTimeKind.Unspecified).AddTicks(2141), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 13, 43, 58, 835, DateTimeKind.Unspecified).AddTicks(2145), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PayMethodEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 43, 58, 836, DateTimeKind.Unspecified).AddTicks(9080), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA01",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 43, 58, 841, DateTimeKind.Unspecified).AddTicks(4248), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA02",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 43, 58, 841, DateTimeKind.Unspecified).AddTicks(4306), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 43, 58, 841, DateTimeKind.Unspecified).AddTicks(8506), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f5"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 43, 58, 841, DateTimeKind.Unspecified).AddTicks(8542), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 43, 58, 841, DateTimeKind.Unspecified).AddTicks(8544), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 43, 58, 842, DateTimeKind.Unspecified).AddTicks(8286), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 43, 58, 842, DateTimeKind.Unspecified).AddTicks(8303), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 43, 58, 844, DateTimeKind.Unspecified).AddTicks(6313), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 43, 58, 844, DateTimeKind.Unspecified).AddTicks(6327), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 43, 58, 844, DateTimeKind.Unspecified).AddTicks(6329), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 43, 58, 845, DateTimeKind.Unspecified).AddTicks(6172), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f8"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 9, 43, 58, 845, DateTimeKind.Unspecified).AddTicks(6154), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 13, 43, 58, 846, DateTimeKind.Unspecified).AddTicks(8705), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SupplierEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 13, 43, 58, 847, DateTimeKind.Unspecified).AddTicks(1510), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Warranties",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 13, 43, 59, 208, DateTimeKind.Unspecified).AddTicks(1459), new TimeSpan(0, 0, 0, 0, 0)));
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
                columns: new[] { "CreatedAt", "Start" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 23, 13, 37, 12, 972, DateTimeKind.Unspecified).AddTicks(6761), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 23, 13, 37, 12, 972, DateTimeKind.Unspecified).AddTicks(6721), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "WELCOME",
                columns: new[] { "CreatedAt", "Start" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 23, 13, 37, 12, 972, DateTimeKind.Unspecified).AddTicks(6791), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 23, 13, 37, 12, 972, DateTimeKind.Unspecified).AddTicks(6789), new TimeSpan(0, 0, 0, 0, 0)) });

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
    }
}
