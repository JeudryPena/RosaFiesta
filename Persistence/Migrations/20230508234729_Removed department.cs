using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Removeddepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_Department",
                schema: "RosaFiesta",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "RosaFiesta");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Department",
                schema: "RosaFiesta",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "Department",
                schema: "RosaFiesta",
                table: "Employees",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Department",
                schema: "RosaFiesta",
                table: "Employees",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Floor = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 5, 3, 15, 45, 32, 524, DateTimeKind.Unspecified).AddTicks(1743), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 5, 3, 15, 45, 32, 524, DateTimeKind.Unspecified).AddTicks(1781), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 5, 3, 15, 45, 32, 524, DateTimeKind.Unspecified).AddTicks(1783), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e073bc6b-fdef-4d1b-9613-7836b1ef8a2e", new DateTimeOffset(new DateTime(2023, 5, 3, 19, 45, 32, 547, DateTimeKind.Unspecified).AddTicks(1897), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEFviD6LGngaBJQxqKzBjgZg+G7G45XMngKTU0u+4O7lh4+DrAFnSbWAnIL45Tz+oxA==", "71bfec22-ea39-4ea3-8740-85e7cb265d1d" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 3, 19, 45, 32, 525, DateTimeKind.Unspecified).AddTicks(9712), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 3, 19, 45, 32, 525, DateTimeKind.Unspecified).AddTicks(9714), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "DiscountCode",
                keyValue: "ROSA",
                columns: new[] { "CreatedAt", "DiscountStartDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 3, 19, 45, 32, 528, DateTimeKind.Unspecified).AddTicks(2182), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 3, 19, 45, 32, 528, DateTimeKind.Unspecified).AddTicks(2187), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "DiscountCode",
                keyValue: "WELCOME",
                columns: new[] { "CreatedAt", "DiscountStartDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 3, 19, 45, 32, 528, DateTimeKind.Unspecified).AddTicks(2196), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 3, 19, 45, 32, 528, DateTimeKind.Unspecified).AddTicks(2197), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PayMethodEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 5, 3, 15, 45, 32, 530, DateTimeKind.Unspecified).AddTicks(9895), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA01",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 3, 19, 45, 32, 534, DateTimeKind.Unspecified).AddTicks(943), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA02",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 3, 19, 45, 32, 534, DateTimeKind.Unspecified).AddTicks(949), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 3, 15, 45, 32, 537, DateTimeKind.Unspecified).AddTicks(4304), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 3, 15, 45, 32, 537, DateTimeKind.Unspecified).AddTicks(4352), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 3, 15, 45, 32, 537, DateTimeKind.Unspecified).AddTicks(4355), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f2"),
                columns: new[] { "ReviewDate", "ReviewUpdateDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 3, 19, 45, 32, 538, DateTimeKind.Unspecified).AddTicks(8244), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 3, 19, 45, 32, 538, DateTimeKind.Unspecified).AddTicks(8245), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f8"),
                columns: new[] { "ReviewDate", "ReviewUpdateDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 3, 19, 45, 32, 538, DateTimeKind.Unspecified).AddTicks(8234), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 3, 19, 45, 32, 538, DateTimeKind.Unspecified).AddTicks(8237), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 3, 19, 45, 32, 539, DateTimeKind.Unspecified).AddTicks(7796), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 3, 19, 45, 32, 539, DateTimeKind.Unspecified).AddTicks(7798), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SupplierEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 3, 19, 45, 32, 540, DateTimeKind.Unspecified).AddTicks(1456), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 3, 19, 45, 32, 540, DateTimeKind.Unspecified).AddTicks(1459), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Warranties",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 3, 19, 45, 32, 629, DateTimeKind.Unspecified).AddTicks(6859), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Department",
                schema: "RosaFiesta",
                table: "Employees",
                column: "Department");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name",
                schema: "RosaFiesta",
                table: "Departments",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_Department",
                schema: "RosaFiesta",
                table: "Employees",
                column: "Department",
                principalSchema: "RosaFiesta",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
