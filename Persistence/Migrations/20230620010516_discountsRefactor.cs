using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class discountsRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScopeType",
                schema: "RosaFiesta",
                table: "Warranties");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "RosaFiesta",
                table: "DiscountEntity",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "RosaFiesta",
                table: "DiscountEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AppliedDate", "CreatedAt", "IsDeleted", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 19, 21, 5, 15, 660, DateTimeKind.Unspecified).AddTicks(8826), new TimeSpan(0, -4, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 19, 21, 5, 15, 660, DateTimeKind.Unspecified).AddTicks(8785), new TimeSpan(0, -4, 0, 0, 0)), false, null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AppliedDate", "CreatedAt", "IsDeleted", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 19, 21, 5, 15, 660, DateTimeKind.Unspecified).AddTicks(8829), new TimeSpan(0, -4, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 19, 21, 5, 15, 660, DateTimeKind.Unspecified).AddTicks(8828), new TimeSpan(0, -4, 0, 0, 0)), false, null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AppliedDate", "CreatedAt", "IsDeleted", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 19, 21, 5, 15, 660, DateTimeKind.Unspecified).AddTicks(8831), new TimeSpan(0, -4, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 19, 21, 5, 15, 660, DateTimeKind.Unspecified).AddTicks(8830), new TimeSpan(0, -4, 0, 0, 0)), false, null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57a886e6-06c1-4244-a683-e2d8d77bab76", new DateTimeOffset(new DateTime(2023, 6, 20, 1, 5, 15, 690, DateTimeKind.Unspecified).AddTicks(6009), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEJ0zF24ECsNRsE9KBvSubL9cZM8JhJNpDb/b4pIrd0LGbgZ9U0e0DKST/3wbSJK4AQ==", "80f7e56b-5f8c-4832-9f54-5f93200d7acd" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac65a3e9-a5ae-4758-917d-07bc9c772e14", new DateTimeOffset(new DateTime(2023, 6, 20, 1, 5, 15, 690, DateTimeKind.Unspecified).AddTicks(6023), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAED3vJ0DzZR5e+uwKDyXI2AakaZopPxpJgwtY/oDIgNO8JtKHR6cjqZ9E2kQZNDYPlw==", "f4f1ca1f-b144-4951-87bc-c44cec0beb1c" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19e72fff-4075-4ddb-8e6b-5ea13e5d396b", new DateTimeOffset(new DateTime(2023, 6, 20, 1, 5, 15, 690, DateTimeKind.Unspecified).AddTicks(6055), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEBvcmaLo2d1o/zREr/WW07AgWPbO+HNkFLExH26SCqjYGSDNUYfvMW+XIQmCxT1GNQ==", "44b312e0-66eb-40cf-94c1-6273c6db46f9" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2620f30-bc75-4a11-b179-de01a4ba9cf5", new DateTimeOffset(new DateTime(2023, 6, 20, 1, 5, 15, 690, DateTimeKind.Unspecified).AddTicks(5994), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEIZsv50UJAZwNPO330ZBeyZZE+HL1Q8Wq3wVj1zR7ptbie1gYhOVZQLuCpgIFuMGAw==", "89f08d57-d548-4565-8ce1-d5fc7621d1cc" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f382792f-9285-4322-af17-1ee933feeb75", new DateTimeOffset(new DateTime(2023, 6, 20, 1, 5, 15, 690, DateTimeKind.Unspecified).AddTicks(5957), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEIj7ZfRzEQKYeSxmwSaHTFoF1HyTKeWUwbFqnbhyahKGpnbqit3HZDT6jf8kUK7yRg==", "b869d4e9-1903-4cf4-90af-429435bca5bb" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 20, 1, 5, 15, 663, DateTimeKind.Unspecified).AddTicks(5514), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "ROSA",
                columns: new[] { "CreatedAt", "CreatedBy", "Start", "UpdatedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 20, 1, 5, 15, 665, DateTimeKind.Unspecified).AddTicks(2513), new TimeSpan(0, 0, 0, 0, 0)), "System", new DateTimeOffset(new DateTime(2023, 6, 20, 1, 5, 15, 665, DateTimeKind.Unspecified).AddTicks(2503), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "WELCOME",
                columns: new[] { "CreatedAt", "CreatedBy", "Start", "UpdatedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 20, 1, 5, 15, 665, DateTimeKind.Unspecified).AddTicks(2516), new TimeSpan(0, 0, 0, 0, 0)), "System", new DateTimeOffset(new DateTime(2023, 6, 20, 1, 5, 15, 665, DateTimeKind.Unspecified).AddTicks(2515), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 20, 1, 5, 15, 666, DateTimeKind.Unspecified).AddTicks(7298), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 20, 1, 5, 15, 666, DateTimeKind.Unspecified).AddTicks(7307), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 20, 1, 5, 15, 666, DateTimeKind.Unspecified).AddTicks(7312), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PayMethodEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 19, 21, 5, 15, 668, DateTimeKind.Unspecified).AddTicks(4284), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA01",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 19, 21, 5, 15, 672, DateTimeKind.Unspecified).AddTicks(4293), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA02",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 19, 21, 5, 15, 672, DateTimeKind.Unspecified).AddTicks(4357), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                keyColumns: new[] { "Code", "Id" },
                keyValues: new object[] { "ROSA", new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4") },
                columns: new[] { "CreatedAt", "IsDeleted", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 19, 21, 5, 15, 673, DateTimeKind.Unspecified).AddTicks(3554), new TimeSpan(0, -4, 0, 0, 0)), false, null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                keyColumns: new[] { "Code", "Id" },
                keyValues: new object[] { "WELCOME", new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f5") },
                columns: new[] { "CreatedAt", "IsDeleted", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 19, 21, 5, 15, 673, DateTimeKind.Unspecified).AddTicks(3586), new TimeSpan(0, -4, 0, 0, 0)), false, null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                keyColumns: new[] { "Code", "Id" },
                keyValues: new object[] { "WELCOME", new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6") },
                columns: new[] { "CreatedAt", "IsDeleted", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 19, 21, 5, 15, 673, DateTimeKind.Unspecified).AddTicks(3589), new TimeSpan(0, -4, 0, 0, 0)), false, null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 19, 21, 5, 15, 674, DateTimeKind.Unspecified).AddTicks(9709), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 19, 21, 5, 15, 674, DateTimeKind.Unspecified).AddTicks(9729), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 19, 21, 5, 15, 677, DateTimeKind.Unspecified).AddTicks(8964), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 19, 21, 5, 15, 677, DateTimeKind.Unspecified).AddTicks(8996), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 19, 21, 5, 15, 677, DateTimeKind.Unspecified).AddTicks(8999), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 19, 21, 5, 15, 679, DateTimeKind.Unspecified).AddTicks(4357), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f8"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 19, 21, 5, 15, 679, DateTimeKind.Unspecified).AddTicks(4345), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 20, 1, 5, 15, 681, DateTimeKind.Unspecified).AddTicks(3421), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SupplierEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 20, 1, 5, 15, 681, DateTimeKind.Unspecified).AddTicks(7281), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Warranties",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 20, 1, 5, 16, 13, DateTimeKind.Unspecified).AddTicks(8826), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "RosaFiesta",
                table: "DiscountEntity");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "RosaFiesta",
                table: "DiscountEntity");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "RosaFiesta",
                table: "AppliedDiscounts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "RosaFiesta",
                table: "AppliedDiscounts");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "RosaFiesta",
                table: "AppliedDiscounts");

            migrationBuilder.AddColumn<int>(
                name: "ScopeType",
                schema: "RosaFiesta",
                table: "Warranties",
                type: "integer",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

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
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 16, 23, 1, 22, 854, DateTimeKind.Unspecified).AddTicks(4342), new TimeSpan(0, 0, 0, 0, 0)));

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
                columns: new[] { "CreatedAt", "ScopeType" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 16, 23, 1, 23, 252, DateTimeKind.Unspecified).AddTicks(3813), new TimeSpan(0, 0, 0, 0, 0)), 2 });
        }
    }
}
