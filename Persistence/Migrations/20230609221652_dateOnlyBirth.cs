using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class dateOnlyBirth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "BirthDate",
                schema: "RosaFiesta",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 18, 16, 51, 846, DateTimeKind.Unspecified).AddTicks(3237), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 18, 16, 51, 846, DateTimeKind.Unspecified).AddTicks(3284), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 18, 16, 51, 846, DateTimeKind.Unspecified).AddTicks(3286), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateOnly(1996, 10, 10), "7c7d26d1-ffdf-42a5-85ff-02c052b78f91", new DateTimeOffset(new DateTime(2023, 6, 9, 22, 16, 51, 873, DateTimeKind.Unspecified).AddTicks(6698), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEM6cc0afjbS1QKPoYOa9208Ka5q/UShnf26weIj9ObAqQ+82fzQjj+oLwLznH+Kd3Q==", "02c985e9-e40d-49d8-a0b2-c4f416c3feec" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateOnly(1996, 10, 10), "9835cf78-3839-450f-869f-dd0053526766", new DateTimeOffset(new DateTime(2023, 6, 9, 22, 16, 51, 873, DateTimeKind.Unspecified).AddTicks(6714), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAENL5ukguf/jR9+A4Rq3NiDPtePzzkUnUoS/RXXSqO7FLHbfiPDBoiiTdC/HH/cQg5A==", "060f7444-1894-421b-b756-59967b35e757" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateOnly(1996, 10, 10), "bcee9067-6aaa-4fa3-970c-56a9ec37d3b0", new DateTimeOffset(new DateTime(2023, 6, 9, 22, 16, 51, 873, DateTimeKind.Unspecified).AddTicks(6754), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEOcBAvksWc4LFdAbE15SAAxIFtcwUhd9KcDo5Pkh0f9vWYhgfrleOMpFDlECP+fuww==", "350e1e71-c930-47ab-9932-b42a802677a4" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateOnly(1996, 10, 10), "0d8ecef4-6f65-4bfe-86c9-f92d923d7757", new DateTimeOffset(new DateTime(2023, 6, 9, 22, 16, 51, 873, DateTimeKind.Unspecified).AddTicks(6681), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEKuiJttkEXCirTemQcROPrH0BcLusUY3XaA2kG85qFwohzHfxpaAb3g7aBjtY8Orhg==", "4bdfb278-a684-48a1-9b4c-ada2555be2b9" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateOnly(1996, 10, 10), "0cba0fd4-65d9-404c-b300-a3e810445847", new DateTimeOffset(new DateTime(2023, 6, 9, 22, 16, 51, 873, DateTimeKind.Unspecified).AddTicks(6654), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAELXBI1V140JJOhczV5LVjt3K/W76GL/eiJM7xONQG5IeCxpIkHhb0l+D5X5B6C0zww==", "a97d7039-ddbb-4f76-a55f-4d6fc085dc46" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 22, 16, 51, 849, DateTimeKind.Unspecified).AddTicks(1864), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "ROSA",
                columns: new[] { "CreatedAt", "Start" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 9, 22, 16, 51, 851, DateTimeKind.Unspecified).AddTicks(1565), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 9, 22, 16, 51, 851, DateTimeKind.Unspecified).AddTicks(1561), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "WELCOME",
                columns: new[] { "CreatedAt", "Start" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 9, 22, 16, 51, 851, DateTimeKind.Unspecified).AddTicks(1568), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 9, 22, 16, 51, 851, DateTimeKind.Unspecified).AddTicks(1567), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 22, 16, 51, 852, DateTimeKind.Unspecified).AddTicks(6978), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 22, 16, 51, 852, DateTimeKind.Unspecified).AddTicks(6983), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 22, 16, 51, 852, DateTimeKind.Unspecified).AddTicks(6987), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PayMethodEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 18, 16, 51, 854, DateTimeKind.Unspecified).AddTicks(2221), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA01",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 18, 16, 51, 856, DateTimeKind.Unspecified).AddTicks(4449), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA02",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 18, 16, 51, 856, DateTimeKind.Unspecified).AddTicks(4488), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 18, 16, 51, 858, DateTimeKind.Unspecified).AddTicks(3493), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 18, 16, 51, 858, DateTimeKind.Unspecified).AddTicks(3517), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 18, 16, 51, 861, DateTimeKind.Unspecified).AddTicks(3642), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 18, 16, 51, 861, DateTimeKind.Unspecified).AddTicks(3678), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 18, 16, 51, 861, DateTimeKind.Unspecified).AddTicks(3682), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 18, 16, 51, 863, DateTimeKind.Unspecified).AddTicks(2504), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f8"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 18, 16, 51, 863, DateTimeKind.Unspecified).AddTicks(2496), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 22, 16, 51, 864, DateTimeKind.Unspecified).AddTicks(7247), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SupplierEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 22, 16, 51, 865, DateTimeKind.Unspecified).AddTicks(750), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Warranties",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 22, 16, 52, 201, DateTimeKind.Unspecified).AddTicks(8044), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "BirthDate",
                schema: "RosaFiesta",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 12, 8, 41, 628, DateTimeKind.Unspecified).AddTicks(8391), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 12, 8, 41, 628, DateTimeKind.Unspecified).AddTicks(8428), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 12, 8, 41, 628, DateTimeKind.Unspecified).AddTicks(8430), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTimeOffset(new DateTime(1996, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)), "c21f58de-236c-4eb6-a37f-ad8f434ddbf3", new DateTimeOffset(new DateTime(2023, 6, 9, 16, 8, 41, 654, DateTimeKind.Unspecified).AddTicks(8762), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEFd3gEICva58LcGG1XmqCZfHHOcgMNT+EL3BDN0lR27sleg5s2XQ39D4E8FbxaUYVA==", "0f1e558c-bdb6-451e-8c9b-d67e5b0ef0b8" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTimeOffset(new DateTime(1996, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)), "47b25bbd-1fba-46ce-87f2-6a19b4bc9f30", new DateTimeOffset(new DateTime(2023, 6, 9, 16, 8, 41, 654, DateTimeKind.Unspecified).AddTicks(8779), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEJrpkSJU0Az/KqSI6EgOX/eQPszRA0ormCmNtwYBCPWmKudvAsqCmRRBBIXsEONLIA==", "a4370643-36fb-407c-88b2-76223a5dfcf0" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTimeOffset(new DateTime(1996, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)), "3b5cfa85-3732-4e66-9fb9-cf08bf70d8b0", new DateTimeOffset(new DateTime(2023, 6, 9, 16, 8, 41, 654, DateTimeKind.Unspecified).AddTicks(8806), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEPPsPst8dINnjhuxnI7+d1h7etPjnLxA4II5q+tbq4zWV7diJ3PnEpIRsUXyfaUVKw==", "37302607-a97d-4c7f-8aa9-bc33592e639f" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTimeOffset(new DateTime(1996, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)), "93adf123-0fa3-4a4a-afad-f6cb04e89713", new DateTimeOffset(new DateTime(2023, 6, 9, 16, 8, 41, 654, DateTimeKind.Unspecified).AddTicks(8748), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEMOP4JhAbOZYjxklTj08rJrUMuZu6nG987g4iTDuvxFUpc0mcHW7umvMcTxiBZ+nBw==", "9ca44b23-527f-471a-85e7-97655d9fe7c5" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTimeOffset(new DateTime(1996, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)), "8cf417b5-86b4-40fe-ba11-39223cffdecc", new DateTimeOffset(new DateTime(2023, 6, 9, 16, 8, 41, 654, DateTimeKind.Unspecified).AddTicks(8708), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEMK2rtkbWzZKDmdG2WQBbS7QUlaapZaCjN3/xT8hCF4wdPxjiE1azizY6iOl8AXq2Q==", "d2df41ee-5880-4b16-b221-439bbf32a928" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 16, 8, 41, 630, DateTimeKind.Unspecified).AddTicks(8918), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "ROSA",
                columns: new[] { "CreatedAt", "Start" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 9, 16, 8, 41, 632, DateTimeKind.Unspecified).AddTicks(7941), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 9, 16, 8, 41, 632, DateTimeKind.Unspecified).AddTicks(7936), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "WELCOME",
                columns: new[] { "CreatedAt", "Start" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 9, 16, 8, 41, 632, DateTimeKind.Unspecified).AddTicks(7945), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 9, 16, 8, 41, 632, DateTimeKind.Unspecified).AddTicks(7943), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 16, 8, 41, 634, DateTimeKind.Unspecified).AddTicks(4001), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 16, 8, 41, 634, DateTimeKind.Unspecified).AddTicks(4006), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 16, 8, 41, 634, DateTimeKind.Unspecified).AddTicks(4010), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PayMethodEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 12, 8, 41, 636, DateTimeKind.Unspecified).AddTicks(2644), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA01",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 12, 8, 41, 639, DateTimeKind.Unspecified).AddTicks(182), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA02",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 12, 8, 41, 639, DateTimeKind.Unspecified).AddTicks(220), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 12, 8, 41, 640, DateTimeKind.Unspecified).AddTicks(7356), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 12, 8, 41, 640, DateTimeKind.Unspecified).AddTicks(7370), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 12, 8, 41, 642, DateTimeKind.Unspecified).AddTicks(7494), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 12, 8, 41, 642, DateTimeKind.Unspecified).AddTicks(7511), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 12, 8, 41, 642, DateTimeKind.Unspecified).AddTicks(7514), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 12, 8, 41, 643, DateTimeKind.Unspecified).AddTicks(8316), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f8"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 12, 8, 41, 643, DateTimeKind.Unspecified).AddTicks(8311), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 16, 8, 41, 644, DateTimeKind.Unspecified).AddTicks(9358), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SupplierEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 16, 8, 41, 645, DateTimeKind.Unspecified).AddTicks(2431), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Warranties",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 9, 16, 8, 42, 16, DateTimeKind.Unspecified).AddTicks(26), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
