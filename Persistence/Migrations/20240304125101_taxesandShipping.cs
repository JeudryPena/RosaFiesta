using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class taxesandShipping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                schema: "RosaFiesta",
                table: "Options");

            migrationBuilder.AddColumn<double>(
                name: "ShippingDiscount",
                schema: "RosaFiesta",
                table: "Orders",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Taxes",
                schema: "RosaFiesta",
                table: "Orders",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1485c9ca-b02c-4cf0-9f36-9693f163a7e4", new DateTimeOffset(new DateTime(2024, 3, 4, 8, 51, 0, 660, DateTimeKind.Unspecified).AddTicks(6190), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAECAF0FuNO5izW7ZCgMpraL+gfTAogsJl/uWJFxAp6GXo6Xbq2qQZUCnZurmr+6oonQ==", "5ce4cb35-798c-4e5e-85e3-7ffe28f36db6" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4eee41fd-e077-4738-abfa-309d71c1232b", new DateTimeOffset(new DateTime(2024, 3, 4, 8, 51, 0, 660, DateTimeKind.Unspecified).AddTicks(6205), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAENoy/uZ8pyt93SgziR9Q18ZIS9ZeSPMpeXXUcmuiHJBDm0QjIjtMFMR1UX97a5E4rw==", "8e1f6ae4-f7e3-4fa4-8c7a-24f075c40298" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fcae23c7-3a73-4b57-93cd-5b1f9aa9720e", new DateTimeOffset(new DateTime(2024, 3, 4, 8, 51, 0, 660, DateTimeKind.Unspecified).AddTicks(6221), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEM9qMZe7kXKlckO8IZDVIe6jiaLuOdl92x9XMWStGupZtv4aUtcVbl7U81mx/yOesw==", "e2bce8c2-1a2b-4b8d-b957-cffff44ad373" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bde1e666-a9ed-4974-9fb5-baecb1c6f2ef", new DateTimeOffset(new DateTime(2024, 3, 4, 8, 51, 0, 660, DateTimeKind.Unspecified).AddTicks(6167), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEJ8qqfrezuroRwl585wXxdUlvgpPuon8/iU/NiZXGbaEl5go4DmmedkE2/arXVDAeg==", "3240d75e-eb40-4f65-88a7-2f14e9c0449f" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1bd5c3a9-7b8c-461b-8511-b43f980dabf5", new DateTimeOffset(new DateTime(2024, 3, 4, 8, 51, 0, 660, DateTimeKind.Unspecified).AddTicks(5894), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEI5OtKc4XNqJjHbVfvOftzCy8lxUeYykIskXb8cmFF73T6tnwDVNgTeTRbi8+ZsXxA==", "d07aa709-85c8-47c9-9bcc-26fd9aba55bf" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 3, 4, 8, 51, 1, 273, DateTimeKind.Unspecified).AddTicks(8604), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 3, 4, 8, 51, 1, 273, DateTimeKind.Unspecified).AddTicks(8607), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 3, 4, 8, 51, 1, 273, DateTimeKind.Unspecified).AddTicks(8610), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 3, 4, 8, 51, 1, 273, DateTimeKind.Unspecified).AddTicks(8599), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 3, 4, 8, 51, 1, 273, DateTimeKind.Unspecified).AddTicks(8493), new TimeSpan(0, -4, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingDiscount",
                schema: "RosaFiesta",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Taxes",
                schema: "RosaFiesta",
                table: "Orders");

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                schema: "RosaFiesta",
                table: "Options",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86736a54-4f39-47eb-b510-313221c1939a", new DateTimeOffset(new DateTime(2024, 2, 26, 13, 15, 32, 259, DateTimeKind.Unspecified).AddTicks(704), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEGV6/8mfKzIjrr9LE0gNzMnp+dDNAYOWS0fmQa8qWeSasD8/U/EoXWB1ucVoAE07wA==", "18bf1ef7-1fc1-4ff9-88f0-89895f520723" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebb6b20b-91de-40f3-869a-9c7403ff8791", new DateTimeOffset(new DateTime(2024, 2, 26, 13, 15, 32, 259, DateTimeKind.Unspecified).AddTicks(736), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEFCW2lA/kBoIolEviE4YGfqyEUlsdMrJTUAjvb7TjzVyq1kkNnrUI8+aZBTiz28nXQ==", "7dab0a70-3618-40b4-bf18-435c11094c16" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f83896f-74ee-4384-b15c-0312fd262901", new DateTimeOffset(new DateTime(2024, 2, 26, 13, 15, 32, 259, DateTimeKind.Unspecified).AddTicks(750), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEDLe9RNVHdvvR2eTn3Xx2a2mPKaE6GAYCNNZRYCi49lAUjgbW+olEUHFALpbG239JQ==", "6374b151-640d-45ce-bda6-22e3f7973c3c" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd37da49-bee1-4505-85e3-7407ac9d36f8", new DateTimeOffset(new DateTime(2024, 2, 26, 13, 15, 32, 259, DateTimeKind.Unspecified).AddTicks(634), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEAFmQnuJcHWuSSkNSxucTUNuXVOOxOJiaCRnXahcyTEKdNjA/7egCFxrCmZNhIs6QA==", "4330a51e-c0f5-4894-902f-2d6e2538ebf0" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c75ffdd8-d22e-42fd-9dfc-7389ed52b049", new DateTimeOffset(new DateTime(2024, 2, 26, 13, 15, 32, 259, DateTimeKind.Unspecified).AddTicks(214), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEIL/hfiBE/9mqZTtalcT6H5/LRYgKVWGyDWSTy1JKRIIMlh1yDOw0F4zutP9KElRtA==", "1dc5f00a-4ec9-43da-8420-f06d9c10edab" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 2, 26, 13, 15, 32, 800, DateTimeKind.Unspecified).AddTicks(5862), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 2, 26, 13, 15, 32, 800, DateTimeKind.Unspecified).AddTicks(5866), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 2, 26, 13, 15, 32, 800, DateTimeKind.Unspecified).AddTicks(5869), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 2, 26, 13, 15, 32, 800, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 2, 26, 13, 15, 32, 800, DateTimeKind.Unspecified).AddTicks(5709), new TimeSpan(0, -4, 0, 0, 0)));
        }
    }
}
