using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removedDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsDiscountsEntity_ProductEntity_ProductCode",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "RosaFiesta",
                table: "SubCategoryEntity");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "RosaFiesta",
                table: "SubCategoryEntity");

            migrationBuilder.RenameColumn(
                name: "ProductCode",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                newName: "ProductEntityCode");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsDiscountsEntity_ProductCode",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                newName: "IX_ProductsDiscountsEntity_ProductEntityCode");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AppliedDate", "CreatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 23, 12, 47, 30, 457, DateTimeKind.Unspecified).AddTicks(4690), new TimeSpan(0, -4, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 23, 12, 47, 30, 457, DateTimeKind.Unspecified).AddTicks(4646), new TimeSpan(0, -4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AppliedDate", "CreatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 23, 12, 47, 30, 457, DateTimeKind.Unspecified).AddTicks(4694), new TimeSpan(0, -4, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 23, 12, 47, 30, 457, DateTimeKind.Unspecified).AddTicks(4693), new TimeSpan(0, -4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AppliedDate", "CreatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 23, 12, 47, 30, 457, DateTimeKind.Unspecified).AddTicks(4697), new TimeSpan(0, -4, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 23, 12, 47, 30, 457, DateTimeKind.Unspecified).AddTicks(4695), new TimeSpan(0, -4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fbaa50c-dbbd-4dd9-bad2-c23103d87dbc", new DateTimeOffset(new DateTime(2023, 6, 23, 16, 47, 30, 497, DateTimeKind.Unspecified).AddTicks(3866), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEDw+G3okDf3d/7M1NMR+whhNyTLRcH//QQMWwnfqjur7hxCFx8Dklr7Wfj2xyohB7A==", "d2c7648b-192c-4f1c-becc-982b0a1fb88b" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4613d7a1-3611-42ee-b233-bce0256d0d65", new DateTimeOffset(new DateTime(2023, 6, 23, 16, 47, 30, 497, DateTimeKind.Unspecified).AddTicks(3882), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEA5ybebEUuZ9PE1yoLLqXzXTPPqkHVPAvRHYBu1o+OcIy2ysxWIUm8tYZIS7RqhF+w==", "43fa4609-723b-4f3e-8f36-9174222cc111" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d40d434b-861d-4675-9a38-0f15215c5870", new DateTimeOffset(new DateTime(2023, 6, 23, 16, 47, 30, 497, DateTimeKind.Unspecified).AddTicks(3927), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEMOR1bOaLLUH+boPFln72bYcBHvA+DS2W8eYKXjmBTMlBitPdanvgqx2rvV49z4UVA==", "37841fd6-eb2f-4e6c-abed-79ebf280e745" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71dfa2b0-48c9-4f6f-8652-ae96c0e2a472", new DateTimeOffset(new DateTime(2023, 6, 23, 16, 47, 30, 497, DateTimeKind.Unspecified).AddTicks(3813), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEA8eo/XOrimWdwelum2xsot+PWR3ETAvWTMlz+sO92qWt+UaPIHukoKEjSNAoLH+Fg==", "1d54a9e5-1a4b-4ab6-847a-a8bceadd91af" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "746181d4-4324-42d7-95f0-7dc8578d5083", new DateTimeOffset(new DateTime(2023, 6, 23, 16, 47, 30, 497, DateTimeKind.Unspecified).AddTicks(3768), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEPLUzx8/PaejswIek5+6RQ/Za0B2Aqp9B8p30M06hybJM/HzGk6LQ8wtVYF997wbOQ==", "75d61464-3e7c-4704-a436-77292f31b945" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 16, 47, 30, 460, DateTimeKind.Unspecified).AddTicks(1555), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "ROSA",
                columns: new[] { "CreatedAt", "Start" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 23, 16, 47, 30, 464, DateTimeKind.Unspecified).AddTicks(42), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 23, 16, 47, 30, 464, DateTimeKind.Unspecified).AddTicks(27), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "Code",
                keyValue: "WELCOME",
                columns: new[] { "CreatedAt", "Start" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 23, 16, 47, 30, 464, DateTimeKind.Unspecified).AddTicks(65), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 23, 16, 47, 30, 464, DateTimeKind.Unspecified).AddTicks(64), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 16, 47, 30, 466, DateTimeKind.Unspecified).AddTicks(3843), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 16, 47, 30, 466, DateTimeKind.Unspecified).AddTicks(3853), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 16, 47, 30, 466, DateTimeKind.Unspecified).AddTicks(3857), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PayMethodEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 12, 47, 30, 468, DateTimeKind.Unspecified).AddTicks(3035), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA01",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 12, 47, 30, 471, DateTimeKind.Unspecified).AddTicks(2110), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA02",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 12, 47, 30, 471, DateTimeKind.Unspecified).AddTicks(2156), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"),
                columns: new[] { "CreatedAt", "ProductEntityCode" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 23, 12, 47, 30, 471, DateTimeKind.Unspecified).AddTicks(6505), new TimeSpan(0, -4, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f5"),
                columns: new[] { "CreatedAt", "ProductEntityCode" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 23, 12, 47, 30, 471, DateTimeKind.Unspecified).AddTicks(6542), new TimeSpan(0, -4, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"),
                columns: new[] { "CreatedAt", "ProductEntityCode" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 23, 12, 47, 30, 471, DateTimeKind.Unspecified).AddTicks(6545), new TimeSpan(0, -4, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 12, 47, 30, 472, DateTimeKind.Unspecified).AddTicks(8077), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailEntity",
                keyColumn: "PurchaseNumber",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 12, 47, 30, 472, DateTimeKind.Unspecified).AddTicks(8102), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 12, 47, 30, 476, DateTimeKind.Unspecified).AddTicks(4334), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 12, 47, 30, 476, DateTimeKind.Unspecified).AddTicks(4371), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 12, 47, 30, 476, DateTimeKind.Unspecified).AddTicks(4374), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 12, 47, 30, 478, DateTimeKind.Unspecified).AddTicks(6811), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f8"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 12, 47, 30, 478, DateTimeKind.Unspecified).AddTicks(6709), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SupplierEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 16, 47, 30, 482, DateTimeKind.Unspecified).AddTicks(7207), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Warranties",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 6, 23, 16, 47, 31, 18, DateTimeKind.Unspecified).AddTicks(7949), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsDiscountsEntity_ProductEntity_ProductEntityCode",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                column: "ProductEntityCode",
                principalSchema: "RosaFiesta",
                principalTable: "ProductEntity",
                principalColumn: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsDiscountsEntity_ProductEntity_ProductEntityCode",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity");

            migrationBuilder.RenameColumn(
                name: "ProductEntityCode",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                newName: "ProductCode");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsDiscountsEntity_ProductEntityCode",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                newName: "IX_ProductsDiscountsEntity_ProductCode");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                type: "timestamp with time zone",
                nullable: true);

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
                columns: new[] { "CreatedAt", "ProductCode" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 23, 9, 43, 58, 841, DateTimeKind.Unspecified).AddTicks(8506), new TimeSpan(0, -4, 0, 0, 0)), "SDA01" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f5"),
                columns: new[] { "CreatedAt", "ProductCode" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 23, 9, 43, 58, 841, DateTimeKind.Unspecified).AddTicks(8542), new TimeSpan(0, -4, 0, 0, 0)), "SDA01" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"),
                columns: new[] { "CreatedAt", "ProductCode" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 23, 9, 43, 58, 841, DateTimeKind.Unspecified).AddTicks(8544), new TimeSpan(0, -4, 0, 0, 0)), "SDA02" });

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 6, 23, 13, 43, 58, 846, DateTimeKind.Unspecified).AddTicks(8705), new TimeSpan(0, 0, 0, 0, 0)), null });

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsDiscountsEntity_ProductEntity_ProductCode",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                column: "ProductCode",
                principalSchema: "RosaFiesta",
                principalTable: "ProductEntity",
                principalColumn: "Code");
        }
    }
}
