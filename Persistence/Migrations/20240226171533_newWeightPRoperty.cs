using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class newWeightPRoperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                schema: "RosaFiesta",
                table: "Options");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "836aef0a-3a68-4bff-b0d4-76e5ff90df0f", new DateTimeOffset(new DateTime(2024, 1, 29, 11, 33, 31, 330, DateTimeKind.Unspecified).AddTicks(557), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEFuw1jp5Ww5QSbtE33HJQKnKuXhguAm/SS09nmB85D9D+omQ+xxJ3xhztiWXVd1YZg==", "4de53e01-7228-4a89-b9f3-ad54e6fe3736" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04d1146b-b7d1-44d5-b03c-b96d8140433c", new DateTimeOffset(new DateTime(2024, 1, 29, 11, 33, 31, 330, DateTimeKind.Unspecified).AddTicks(585), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEARpfdGgurASZUpYxKx1Hsp3SdASAoDClZJaiE8EkW7A7IZp2Zr3N7Df7mMT/xQk3w==", "0fbe4193-53f6-488c-a126-e5dd66c35dfc" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3503d4e-5b38-479e-9ca4-c42d8d529db6", new DateTimeOffset(new DateTime(2024, 1, 29, 11, 33, 31, 330, DateTimeKind.Unspecified).AddTicks(597), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEA80sJqsBB7ivQRcVZn3qT83MG3812BmuJT/ZPsyhXTff5M7cnG5HbK5//J/Y1K+9Q==", "8bae7c42-476d-43f3-adc3-c0bb61767348" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad0a9a7f-8980-4ac0-a019-e0f7d9e04c1e", new DateTimeOffset(new DateTime(2024, 1, 29, 11, 33, 31, 330, DateTimeKind.Unspecified).AddTicks(534), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEL/uKLk1PhpcXTUsECoQlpcuLmxBc71w5CLGdx7t2y1q5LHfXSW4cCi7ixbB0bwm+A==", "d36d5347-40ba-4613-9d80-ddc03d6a50a5" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d28d7634-af46-42bc-a121-96d5ee1a3028", new DateTimeOffset(new DateTime(2024, 1, 29, 11, 33, 31, 330, DateTimeKind.Unspecified).AddTicks(291), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEJ7Z3FTMKg2nyqD6xbI0jc46HWEEaFzbfbDEVNSjfdrKWkJJOjaqAiqOnT2XHAVt4Q==", "eaf007c5-4522-469b-9106-4ab26baa64c3" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 29, 11, 33, 31, 745, DateTimeKind.Unspecified).AddTicks(9560), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 29, 11, 33, 31, 745, DateTimeKind.Unspecified).AddTicks(9563), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 29, 11, 33, 31, 745, DateTimeKind.Unspecified).AddTicks(9565), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 29, 11, 33, 31, 745, DateTimeKind.Unspecified).AddTicks(9556), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 29, 11, 33, 31, 745, DateTimeKind.Unspecified).AddTicks(9481), new TimeSpan(0, -4, 0, 0, 0)));
        }
    }
}
