using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class actionlogremoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionLogs",
                schema: "RosaFiesta");

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
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c21f58de-236c-4eb6-a37f-ad8f434ddbf3", new DateTimeOffset(new DateTime(2023, 6, 9, 16, 8, 41, 654, DateTimeKind.Unspecified).AddTicks(8762), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEFd3gEICva58LcGG1XmqCZfHHOcgMNT+EL3BDN0lR27sleg5s2XQ39D4E8FbxaUYVA==", "0f1e558c-bdb6-451e-8c9b-d67e5b0ef0b8" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47b25bbd-1fba-46ce-87f2-6a19b4bc9f30", new DateTimeOffset(new DateTime(2023, 6, 9, 16, 8, 41, 654, DateTimeKind.Unspecified).AddTicks(8779), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEJrpkSJU0Az/KqSI6EgOX/eQPszRA0ormCmNtwYBCPWmKudvAsqCmRRBBIXsEONLIA==", "a4370643-36fb-407c-88b2-76223a5dfcf0" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b5cfa85-3732-4e66-9fb9-cf08bf70d8b0", new DateTimeOffset(new DateTime(2023, 6, 9, 16, 8, 41, 654, DateTimeKind.Unspecified).AddTicks(8806), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEPPsPst8dINnjhuxnI7+d1h7etPjnLxA4II5q+tbq4zWV7diJ3PnEpIRsUXyfaUVKw==", "37302607-a97d-4c7f-8aa9-bc33592e639f" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "93adf123-0fa3-4a4a-afad-f6cb04e89713", new DateTimeOffset(new DateTime(2023, 6, 9, 16, 8, 41, 654, DateTimeKind.Unspecified).AddTicks(8748), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEMOP4JhAbOZYjxklTj08rJrUMuZu6nG987g4iTDuvxFUpc0mcHW7umvMcTxiBZ+nBw==", "9ca44b23-527f-471a-85e7-97655d9fe7c5" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8cf417b5-86b4-40fe-ba11-39223cffdecc", new DateTimeOffset(new DateTime(2023, 6, 9, 16, 8, 41, 654, DateTimeKind.Unspecified).AddTicks(8708), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEMK2rtkbWzZKDmdG2WQBbS7QUlaapZaCjN3/xT8hCF4wdPxjiE1azizY6iOl8AXq2Q==", "d2df41ee-5880-4b16-b221-439bbf32a928" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionLogs",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<int>(type: "integer", nullable: false),
                    ActivityId = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    ActivityType = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    Timestamp = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionLogs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 7, 9, 10, 31, 245, DateTimeKind.Unspecified).AddTicks(6017), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 7, 9, 10, 31, 245, DateTimeKind.Unspecified).AddTicks(6048), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 6, 7, 9, 10, 31, 245, DateTimeKind.Unspecified).AddTicks(6049), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb7cf576-d7f7-4aee-9566-ef862430f39f", new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 263, DateTimeKind.Unspecified).AddTicks(8963), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEAIL2fmR+GlwAuArZ6+q8H0mH0sLYboyxnmbMPGsTm6w96bvHTda3nKn8IW7i9v59w==", "26095aa7-c859-41af-bb67-c6a89927c412" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d965eb48-f7df-4251-a551-2353ecc18bf6", new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 263, DateTimeKind.Unspecified).AddTicks(8977), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAECeoLebvMpHjkAqCVRUDejH9oVMqiBgaVV0XfvkrfcmGEsJ2yWMQizSVhVRjn4FkXA==", "1c583128-10af-440c-9535-ae7b4ef640ee" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2cc1481f-43be-4964-8d7b-52f389a8911a", new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 263, DateTimeKind.Unspecified).AddTicks(8990), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEEQlRUn2hQdRF71hfF+uFeLQpe1I/RFusdOMiFud0l9ebwzydUu8V5hwfxOn+tmM2w==", "e9392aba-5cd1-4b1b-a04a-8d43df1600cf" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c0a6023c-4b20-4aea-8b31-06ab6d39146c", new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 263, DateTimeKind.Unspecified).AddTicks(8952), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEEDuKjnEf7tDU2/Km0XBIKMA0QTFlt/4ZBSBDw6/EaSPsFrqazSBtAKUy0aAUlDeNQ==", "eec9a5a8-da70-4e1c-afe9-a692f863439e" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ceb3809-7b4f-4dd3-8f4e-c606fbf47150", new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 263, DateTimeKind.Unspecified).AddTicks(8910), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEKweDuzBsUvS06fY+SLqTBpIHZv20yth5ccA1sf50u9wkOwia9kia/dR6+jvSxflNQ==", "89538251-add9-480d-bdeb-f0703823e043" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 247, DateTimeKind.Unspecified).AddTicks(3102), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "ROSA",
                columns: new[] { "CreatedAt", "Start" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 248, DateTimeKind.Unspecified).AddTicks(5207), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 248, DateTimeKind.Unspecified).AddTicks(5200), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "WELCOME",
                columns: new[] { "CreatedAt", "Start" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 248, DateTimeKind.Unspecified).AddTicks(5210), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 248, DateTimeKind.Unspecified).AddTicks(5209), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 249, DateTimeKind.Unspecified).AddTicks(5298), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 249, DateTimeKind.Unspecified).AddTicks(5308), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 249, DateTimeKind.Unspecified).AddTicks(5311), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PayMethodEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 7, 9, 10, 31, 250, DateTimeKind.Unspecified).AddTicks(5288), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA01",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 252, DateTimeKind.Unspecified).AddTicks(1962), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA02",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 252, DateTimeKind.Unspecified).AddTicks(1983), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 253, DateTimeKind.Unspecified).AddTicks(3398), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 253, DateTimeKind.Unspecified).AddTicks(3401), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 7, 9, 10, 31, 254, DateTimeKind.Unspecified).AddTicks(5603), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 7, 9, 10, 31, 254, DateTimeKind.Unspecified).AddTicks(5624), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 7, 9, 10, 31, 254, DateTimeKind.Unspecified).AddTicks(5650), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 7, 9, 10, 31, 255, DateTimeKind.Unspecified).AddTicks(3524), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f8"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 7, 9, 10, 31, 255, DateTimeKind.Unspecified).AddTicks(3509), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 257, DateTimeKind.Unspecified).AddTicks(5100), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SupplierEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 258, DateTimeKind.Unspecified).AddTicks(4286), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Warranties",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 7, 13, 10, 31, 570, DateTimeKind.Unspecified).AddTicks(447), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
