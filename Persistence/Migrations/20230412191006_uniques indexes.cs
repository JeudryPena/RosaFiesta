using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class uniquesindexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "RosaFiesta",
                table: "Warranties",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityCard",
                schema: "RosaFiesta",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 4, 12, 15, 10, 6, 554, DateTimeKind.Unspecified).AddTicks(3818), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 4, 12, 15, 10, 6, 554, DateTimeKind.Unspecified).AddTicks(3846), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 4, 12, 15, 10, 6, 554, DateTimeKind.Unspecified).AddTicks(3848), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "003b76bb-abc8-495f-960c-03a3d711759a", new DateTimeOffset(new DateTime(2023, 4, 12, 19, 10, 6, 575, DateTimeKind.Unspecified).AddTicks(5541), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEBccnXpeh9Pa+7ywZLLE17Tbg4qHpwgvl+l3N5Gpq/tCywRfXZ0nYoSXxMxBsCCRcw==", "2ad5413e-16f2-4526-b6ec-25f958959429" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 4, 12, 19, 10, 6, 555, DateTimeKind.Unspecified).AddTicks(8474), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 4, 12, 19, 10, 6, 555, DateTimeKind.Unspecified).AddTicks(8476), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "DiscountCode",
                keyValue: "ROSA",
                columns: new[] { "CreatedAt", "DiscountStartDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 4, 12, 19, 10, 6, 557, DateTimeKind.Unspecified).AddTicks(6572), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 4, 12, 19, 10, 6, 557, DateTimeKind.Unspecified).AddTicks(6577), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "DiscountCode",
                keyValue: "WELCOME",
                columns: new[] { "CreatedAt", "DiscountStartDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 4, 12, 19, 10, 6, 557, DateTimeKind.Unspecified).AddTicks(6583), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 4, 12, 19, 10, 6, 557, DateTimeKind.Unspecified).AddTicks(6584), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PayMethodEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 4, 12, 15, 10, 6, 560, DateTimeKind.Unspecified).AddTicks(576), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA01",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 12, 19, 10, 6, 561, DateTimeKind.Unspecified).AddTicks(9836), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA02",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 12, 19, 10, 6, 561, DateTimeKind.Unspecified).AddTicks(9842), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 12, 15, 10, 6, 565, DateTimeKind.Unspecified).AddTicks(7003), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 12, 15, 10, 6, 565, DateTimeKind.Unspecified).AddTicks(7035), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 12, 15, 10, 6, 565, DateTimeKind.Unspecified).AddTicks(7037), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f2"),
                columns: new[] { "ReviewDate", "ReviewUpdateDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 4, 12, 19, 10, 6, 566, DateTimeKind.Unspecified).AddTicks(9843), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 4, 12, 19, 10, 6, 566, DateTimeKind.Unspecified).AddTicks(9844), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f8"),
                columns: new[] { "ReviewDate", "ReviewUpdateDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 4, 12, 19, 10, 6, 566, DateTimeKind.Unspecified).AddTicks(9834), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 4, 12, 19, 10, 6, 566, DateTimeKind.Unspecified).AddTicks(9836), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 4, 12, 19, 10, 6, 568, DateTimeKind.Unspecified).AddTicks(526), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 4, 12, 19, 10, 6, 568, DateTimeKind.Unspecified).AddTicks(530), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SupplierEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 4, 12, 19, 10, 6, 568, DateTimeKind.Unspecified).AddTicks(3350), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 4, 12, 19, 10, 6, 568, DateTimeKind.Unspecified).AddTicks(3352), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Warranties",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 12, 19, 10, 6, 644, DateTimeKind.Unspecified).AddTicks(8640), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_WishesList_Title",
                schema: "RosaFiesta",
                table: "WishesList",
                column: "Title",
                unique: true,
                filter: "[Title] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Warranties_Name",
                schema: "RosaFiesta",
                table: "Warranties",
                column: "Name");

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

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name",
                schema: "RosaFiesta",
                table: "Departments",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryEntity_Name",
                schema: "RosaFiesta",
                table: "CategoryEntity",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WishesList_Title",
                schema: "RosaFiesta",
                table: "WishesList");

            migrationBuilder.DropIndex(
                name: "IX_Warranties_Name",
                schema: "RosaFiesta",
                table: "Warranties");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Email",
                schema: "RosaFiesta",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_IdentityCard",
                schema: "RosaFiesta",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Phone",
                schema: "RosaFiesta",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Departments_Name",
                schema: "RosaFiesta",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_CategoryEntity_Name",
                schema: "RosaFiesta",
                table: "CategoryEntity");

            migrationBuilder.DropColumn(
                name: "IdentityCard",
                schema: "RosaFiesta",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "RosaFiesta",
                table: "Warranties",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 4, 12, 14, 33, 5, 667, DateTimeKind.Unspecified).AddTicks(5636), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 4, 12, 14, 33, 5, 667, DateTimeKind.Unspecified).AddTicks(5667), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AppliedDiscounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "AppliedDate",
                value: new DateTimeOffset(new DateTime(2023, 4, 12, 14, 33, 5, 667, DateTimeKind.Unspecified).AddTicks(5669), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6e1272f-9bb7-4561-b859-e66d8b06d5c9", new DateTimeOffset(new DateTime(2023, 4, 12, 18, 33, 5, 688, DateTimeKind.Unspecified).AddTicks(5502), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEK5N+AVIHaLVbL6C7m8ZIW++sCn4mZaFLh7V1lOjnK7YK8YhfLqTAtaauZQ8zWGiww==", "712f2ac6-d638-4839-93e7-43734b668a3e" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 4, 12, 18, 33, 5, 669, DateTimeKind.Unspecified).AddTicks(2771), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 4, 12, 18, 33, 5, 669, DateTimeKind.Unspecified).AddTicks(2773), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "DiscountCode",
                keyValue: "ROSA",
                columns: new[] { "CreatedAt", "DiscountStartDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 4, 12, 18, 33, 5, 671, DateTimeKind.Unspecified).AddTicks(2763), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 4, 12, 18, 33, 5, 671, DateTimeKind.Unspecified).AddTicks(2767), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "DiscountEntity",
                keyColumn: "DiscountCode",
                keyValue: "WELCOME",
                columns: new[] { "CreatedAt", "DiscountStartDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 4, 12, 18, 33, 5, 671, DateTimeKind.Unspecified).AddTicks(2775), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 4, 12, 18, 33, 5, 671, DateTimeKind.Unspecified).AddTicks(2776), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PayMethodEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f4"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 4, 12, 14, 33, 5, 674, DateTimeKind.Unspecified).AddTicks(2261), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA01",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 12, 18, 33, 5, 676, DateTimeKind.Unspecified).AddTicks(9352), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ProductEntity",
                keyColumn: "Code",
                keyValue: "SDA02",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 12, 18, 33, 5, 676, DateTimeKind.Unspecified).AddTicks(9359), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 12, 14, 33, 5, 680, DateTimeKind.Unspecified).AddTicks(29), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 12, 14, 33, 5, 680, DateTimeKind.Unspecified).AddTicks(67), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "PurchaseDetailOptions",
                keyColumns: new[] { "OptionId", "PurchaseNumber" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 12, 14, 33, 5, 680, DateTimeKind.Unspecified).AddTicks(70), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f2"),
                columns: new[] { "ReviewDate", "ReviewUpdateDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 4, 12, 18, 33, 5, 681, DateTimeKind.Unspecified).AddTicks(925), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 4, 12, 18, 33, 5, 681, DateTimeKind.Unspecified).AddTicks(926), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "ReviewEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f8"),
                columns: new[] { "ReviewDate", "ReviewUpdateDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 4, 12, 18, 33, 5, 681, DateTimeKind.Unspecified).AddTicks(916), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 4, 12, 18, 33, 5, 681, DateTimeKind.Unspecified).AddTicks(918), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SubCategoryEntity",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 4, 12, 18, 33, 5, 682, DateTimeKind.Unspecified).AddTicks(64), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 4, 12, 18, 33, 5, 682, DateTimeKind.Unspecified).AddTicks(65), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "SupplierEntity",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f9"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 4, 12, 18, 33, 5, 682, DateTimeKind.Unspecified).AddTicks(2460), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 4, 12, 18, 33, 5, 682, DateTimeKind.Unspecified).AddTicks(2462), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Warranties",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f6"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 12, 18, 33, 5, 772, DateTimeKind.Unspecified).AddTicks(7653), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
