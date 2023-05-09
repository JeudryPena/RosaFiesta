using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemovedEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees",
                schema: "RosaFiesta");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 5, 8, 20, 9, 12, 421, DateTimeKind.Unspecified).AddTicks(4432), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 5, 8, 20, 9, 12, 421, DateTimeKind.Unspecified).AddTicks(4469), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 5, 8, 20, 9, 12, 421, DateTimeKind.Unspecified).AddTicks(4471), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a52c1588-535d-43c0-a86e-492aeff941e1", new DateTimeOffset(new DateTime(2023, 5, 9, 0, 9, 12, 442, DateTimeKind.Unspecified).AddTicks(7682), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEBnsQ927Hgy4F1cxyDXux0JLoqb/XD7LynPChkD+vrhBhUu/bYyymn5uey1HsV06Ww==", "d18c3ace-ec6d-4479-88ce-d73fecd982db" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 9, 0, 9, 12, 423, DateTimeKind.Unspecified).AddTicks(1682), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 9, 0, 9, 12, 423, DateTimeKind.Unspecified).AddTicks(1685), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "DiscountCode",
                keyValue: "ROSA",
                columns: new[] { "CreatedAt", "DiscountStartDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 9, 0, 9, 12, 424, DateTimeKind.Unspecified).AddTicks(6578), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 9, 0, 9, 12, 424, DateTimeKind.Unspecified).AddTicks(6583), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "DiscountCode",
                keyValue: "WELCOME",
                columns: new[] { "CreatedAt", "DiscountStartDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 9, 0, 9, 12, 424, DateTimeKind.Unspecified).AddTicks(6625), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 9, 0, 9, 12, 424, DateTimeKind.Unspecified).AddTicks(6626), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PayMethodEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 5, 8, 20, 9, 12, 427, DateTimeKind.Unspecified).AddTicks(247), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA01",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 0, 9, 12, 429, DateTimeKind.Unspecified).AddTicks(2731), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA02",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 0, 9, 12, 429, DateTimeKind.Unspecified).AddTicks(2738), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 8, 20, 9, 12, 432, DateTimeKind.Unspecified).AddTicks(1394), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 8, 20, 9, 12, 432, DateTimeKind.Unspecified).AddTicks(1422), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 8, 20, 9, 12, 432, DateTimeKind.Unspecified).AddTicks(1424), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f2"),
                columns: new[] { "ReviewDate", "ReviewUpdateDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 9, 0, 9, 12, 433, DateTimeKind.Unspecified).AddTicks(5214), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 9, 0, 9, 12, 433, DateTimeKind.Unspecified).AddTicks(5215), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f8"),
                columns: new[] { "ReviewDate", "ReviewUpdateDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 9, 0, 9, 12, 433, DateTimeKind.Unspecified).AddTicks(5205), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 9, 0, 9, 12, 433, DateTimeKind.Unspecified).AddTicks(5207), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 9, 0, 9, 12, 434, DateTimeKind.Unspecified).AddTicks(6125), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 9, 0, 9, 12, 434, DateTimeKind.Unspecified).AddTicks(6128), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SupplierEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 9, 0, 9, 12, 434, DateTimeKind.Unspecified).AddTicks(9393), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 9, 0, 9, 12, 434, DateTimeKind.Unspecified).AddTicks(9396), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Warranties",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 0, 9, 12, 530, DateTimeKind.Unspecified).AddTicks(16), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Address = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Department = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    FullName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IdentityCard = table.Column<string>(type: "text", nullable: false),
                    JobTitle = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: false),
                    Resume = table.Column<string>(type: "text", nullable: true),
                    Salary = table.Column<decimal>(type: "numeric", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    WorkingDays = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    WorkingHours = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 5, 8, 19, 47, 28, 764, DateTimeKind.Unspecified).AddTicks(8349), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 5, 8, 19, 47, 28, 764, DateTimeKind.Unspecified).AddTicks(8385), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 5, 8, 19, 47, 28, 764, DateTimeKind.Unspecified).AddTicks(8387), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fca2b24d-d29b-4cff-8540-5cd7701c8eb4", new DateTimeOffset(new DateTime(2023, 5, 8, 23, 47, 28, 783, DateTimeKind.Unspecified).AddTicks(9932), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEGWY1TprMxy1TF+q42+zN9qeehZtcJ3Ywo4DifZNR5jZuYpBgVB6y1bPmxqzesJPZw==", "e93f40b8-c761-43d4-ba36-620fb79ed5b0" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 8, 23, 47, 28, 766, DateTimeKind.Unspecified).AddTicks(5822), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 8, 23, 47, 28, 766, DateTimeKind.Unspecified).AddTicks(5824), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "DiscountCode",
                keyValue: "ROSA",
                columns: new[] { "CreatedAt", "DiscountStartDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 8, 23, 47, 28, 768, DateTimeKind.Unspecified).AddTicks(1562), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 8, 23, 47, 28, 768, DateTimeKind.Unspecified).AddTicks(1567), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "DiscountCode",
                keyValue: "WELCOME",
                columns: new[] { "CreatedAt", "DiscountStartDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 8, 23, 47, 28, 768, DateTimeKind.Unspecified).AddTicks(1576), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 8, 23, 47, 28, 768, DateTimeKind.Unspecified).AddTicks(1577), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PayMethodEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 5, 8, 19, 47, 28, 771, DateTimeKind.Unspecified).AddTicks(4366), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA01",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 8, 23, 47, 28, 773, DateTimeKind.Unspecified).AddTicks(2055), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA02",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 8, 23, 47, 28, 773, DateTimeKind.Unspecified).AddTicks(2061), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 8, 19, 47, 28, 775, DateTimeKind.Unspecified).AddTicks(9695), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 8, 19, 47, 28, 775, DateTimeKind.Unspecified).AddTicks(9722), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 8, 19, 47, 28, 775, DateTimeKind.Unspecified).AddTicks(9724), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f2"),
                columns: new[] { "ReviewDate", "ReviewUpdateDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 8, 23, 47, 28, 776, DateTimeKind.Unspecified).AddTicks(7747), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 8, 23, 47, 28, 776, DateTimeKind.Unspecified).AddTicks(7748), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f8"),
                columns: new[] { "ReviewDate", "ReviewUpdateDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 8, 23, 47, 28, 776, DateTimeKind.Unspecified).AddTicks(7739), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 8, 23, 47, 28, 776, DateTimeKind.Unspecified).AddTicks(7741), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 8, 23, 47, 28, 777, DateTimeKind.Unspecified).AddTicks(5601), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 8, 23, 47, 28, 777, DateTimeKind.Unspecified).AddTicks(5604), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SupplierEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 8, 23, 47, 28, 777, DateTimeKind.Unspecified).AddTicks(8103), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 8, 23, 47, 28, 777, DateTimeKind.Unspecified).AddTicks(8105), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Warranties",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 8, 23, 47, 28, 851, DateTimeKind.Unspecified).AddTicks(6767), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                schema: "RosaFiesta",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdentityCard",
                schema: "RosaFiesta",
                table: "Employees",
                column: "IdentityCard",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Phone",
                schema: "RosaFiesta",
                table: "Employees",
                column: "Phone",
                unique: true);
        }
    }
}
