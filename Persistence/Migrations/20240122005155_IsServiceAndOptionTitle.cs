using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IsServiceAndOptionTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsService",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "404ccf45-ce82-4f2b-9a62-ecab1df6a059", new DateTimeOffset(new DateTime(2024, 1, 21, 20, 51, 55, 254, DateTimeKind.Unspecified).AddTicks(3063), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEMiunNBfCrF0u81kHpV6doW7LhnniJTwVX0Jbz7zVAXYsPWwkKhx6qH58bgB3BQPWA==", "50866459-b3f5-47d8-baec-96f879750068" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bde67bbb-20f2-4b7c-9714-d4b6261a1abe", new DateTimeOffset(new DateTime(2024, 1, 21, 20, 51, 55, 254, DateTimeKind.Unspecified).AddTicks(3123), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEMjBqG/ucGo6hletOixAPzrVxQIlnxaWqNsI98l7vzo8H2q341Ixde0lGXVtF7xzuQ==", "9ad5cae9-e9a0-4306-83db-3f91925bfe50" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2c306fe-8401-44a1-b549-dd0cc849f236", new DateTimeOffset(new DateTime(2024, 1, 21, 20, 51, 55, 254, DateTimeKind.Unspecified).AddTicks(3134), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEBq6aFtZsQn/tsqIoTF/hgyfAEXdP/dJiSk+JjyLu4Sxano4U+GyxxCevzqBtl0+ww==", "58c8d64a-652a-4c4e-8b3f-ae73ea371d00" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9de601ca-b025-41a5-89f2-9c0125641cf2", new DateTimeOffset(new DateTime(2024, 1, 21, 20, 51, 55, 254, DateTimeKind.Unspecified).AddTicks(3040), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAENu+AtkIHlbdS3vjz2AST2hDGcnVxHt6V7bZEdpu+6Kh1lngVvmqFBJU1Re9f1WpNQ==", "49efae5c-5594-45c6-bd71-aecac2be1fad" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "785ec22c-0cbb-48d4-a13d-73a2744027a3", new DateTimeOffset(new DateTime(2024, 1, 21, 20, 51, 55, 254, DateTimeKind.Unspecified).AddTicks(2817), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAECFqpe7uS9X+M292taMWtHP/931r+cHlgqtSasq3Z9zC4phTP0vu/OkrN8hmWIDxtg==", "17a5ad21-80d2-4eab-b2c9-23d14c68d944" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 20, 51, 55, 665, DateTimeKind.Unspecified).AddTicks(6392), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 20, 51, 55, 665, DateTimeKind.Unspecified).AddTicks(6396), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 20, 51, 55, 665, DateTimeKind.Unspecified).AddTicks(6401), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 20, 51, 55, 665, DateTimeKind.Unspecified).AddTicks(6379), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 20, 51, 55, 665, DateTimeKind.Unspecified).AddTicks(6275), new TimeSpan(0, -4, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsService",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2bed474d-2cff-409b-984f-f9db931c1f33", new DateTimeOffset(new DateTime(2024, 1, 21, 17, 51, 2, 850, DateTimeKind.Unspecified).AddTicks(4986), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEHSarz15Ldbpb+zgRKJU2HfARiojU1lrp65T+ZSMCJJqLP9ffDkzfWxXeT46NoTneA==", "fb1c6802-d661-4f96-93fa-e2aae0ffedca" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6633391e-658a-4c48-84a3-d07ed9540934", new DateTimeOffset(new DateTime(2024, 1, 21, 17, 51, 2, 850, DateTimeKind.Unspecified).AddTicks(5001), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEAmOPX0bJ0QwxtOpPpw4J4Uuo1cJIueXiujdsIXKgHo5uOp4eFOrEeOs1q0y1ru45g==", "fae6b85a-88be-4406-ab6c-62748cc969e8" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "45e9c580-c2c5-4a14-b683-a7a1c9d064f9", new DateTimeOffset(new DateTime(2024, 1, 21, 17, 51, 2, 850, DateTimeKind.Unspecified).AddTicks(5019), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEDXAawVqdxL3z1GhzzY7kjkaxjKlxAN6rTLOmvdGEu2V8ZWIJYO1uxPUfqO9AQjwRQ==", "a2a203f4-d237-46fb-8ba2-0563bf867977" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c04b2b22-4e74-4210-9398-caaa324df5df", new DateTimeOffset(new DateTime(2024, 1, 21, 17, 51, 2, 850, DateTimeKind.Unspecified).AddTicks(4956), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEMIVqYk9kcC1M6COrL93nAW/u6AHfT4oUQmM50OAhpzwtqtqdDdfKlippBtNEW9a7Q==", "ad3b4974-3e32-40ec-855c-e16966aee568" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9dcb85e-d918-4124-99d4-330de90f2965", new DateTimeOffset(new DateTime(2024, 1, 21, 17, 51, 2, 850, DateTimeKind.Unspecified).AddTicks(4680), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEBHwM0b1v0eq/5LwjTxtxRlh3d6cl4RpIbzL5PCFwXMVEjCfaH9F6wMFDNTD3K9JbA==", "98ca0a3f-b7c5-46ae-b4a8-a198abfb3c9f" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 17, 51, 3, 409, DateTimeKind.Unspecified).AddTicks(6017), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 17, 51, 3, 409, DateTimeKind.Unspecified).AddTicks(6021), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 17, 51, 3, 409, DateTimeKind.Unspecified).AddTicks(6024), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 17, 51, 3, 409, DateTimeKind.Unspecified).AddTicks(6012), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 17, 51, 3, 409, DateTimeKind.Unspecified).AddTicks(5916), new TimeSpan(0, -4, 0, 0, 0)));
        }
    }
}
