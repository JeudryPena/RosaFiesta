using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DiscountedValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Discounted",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discounted",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5e8c92f-fdb5-4535-b988-1137b615bb34", new DateTimeOffset(new DateTime(2024, 1, 21, 17, 30, 43, 535, DateTimeKind.Unspecified).AddTicks(2195), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEMQvJjLCCEdP42jQU7Lcbp+ASAQgpJxz+hZhh6aI90DI2ZeMZRvLuzN5bHnC3cpEHQ==", "d656b12b-7018-4b28-bc6c-ea806fe473dc" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a813f07-b02e-45b6-8e8e-7fb429e6cdc2", new DateTimeOffset(new DateTime(2024, 1, 21, 17, 30, 43, 535, DateTimeKind.Unspecified).AddTicks(2209), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEHhJUrQ6IOcAZ2RRJbRe/8PO/hZq6SDvg6H74IdESyOJxr6DtDOJCjnuBAnOY/wkYA==", "9ab7e426-40aa-484b-aaaf-810d24c3120e" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef9b44eb-caf6-4037-bd32-452bebcbb132", new DateTimeOffset(new DateTime(2024, 1, 21, 17, 30, 43, 535, DateTimeKind.Unspecified).AddTicks(2261), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEHwLXAGoG4PPeeL454hjgeQCWFa+d8PoLAgnz86tEBem42YSONNfXQ8tOU37kUrPGw==", "44f3f327-0622-4210-aad3-18939380a8b2" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08ecbbe1-38ac-43b5-8d6a-bd4d61069a12", new DateTimeOffset(new DateTime(2024, 1, 21, 17, 30, 43, 535, DateTimeKind.Unspecified).AddTicks(2166), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEGvjSrO9cZF2vDCDQ7vXoLbNRdZ/No0pipqRl9PJRiHpMcQRgbzzECHz8IHZlJe2SA==", "07b40527-9dd1-46c0-88a4-bb3ea9be332a" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0eb6a908-be2a-42d5-b0d7-836a2295cb10", new DateTimeOffset(new DateTime(2024, 1, 21, 17, 30, 43, 535, DateTimeKind.Unspecified).AddTicks(1908), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAELNNhYyIF11fIuel/8KkMdLrZt32q5a+vtHmVcejYvd+B9/MwO41esXbjxekUGs9Mg==", "bf4776dc-9100-4434-9d4c-aa2fa1b9cc09" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 17, 30, 44, 3, DateTimeKind.Unspecified).AddTicks(46), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 17, 30, 44, 3, DateTimeKind.Unspecified).AddTicks(49), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 17, 30, 44, 3, DateTimeKind.Unspecified).AddTicks(53), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 17, 30, 44, 3, DateTimeKind.Unspecified).AddTicks(40), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 17, 30, 44, 2, DateTimeKind.Unspecified).AddTicks(9941), new TimeSpan(0, -4, 0, 0, 0)));
        }
    }
}
