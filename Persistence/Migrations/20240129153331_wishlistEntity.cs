using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class wishlistEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d828152f-01c0-46e9-a72f-a4e6de723bc7", new DateTimeOffset(new DateTime(2024, 1, 23, 14, 53, 13, 996, DateTimeKind.Unspecified).AddTicks(4667), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEL+4EYjXoTP10uT4UEjGWODCVmZ+Z4xCiCSPj5g/aRLsj1+ldXwelpsqcVw9fw5EOg==", "f263cbe1-e4bc-455e-9390-87804c25cb59" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4de394a6-1d76-4eaa-b49d-c3b3bd034267", new DateTimeOffset(new DateTime(2024, 1, 23, 14, 53, 13, 996, DateTimeKind.Unspecified).AddTicks(4692), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEFdxffEeFNgrgzM9itEkNMX7BOyfPPoQQ7vINgWZ6xOyQ4KT85I8KlqcKTRnkISHrw==", "f646c3c5-358e-4d9f-a147-a7c36602e0ba" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b22aa36-ebd9-4f66-8d69-46bdd87b7f72", new DateTimeOffset(new DateTime(2024, 1, 23, 14, 53, 13, 996, DateTimeKind.Unspecified).AddTicks(4716), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEGAakEjHr0b3IYsBR+G5gnQi5+IMF04ol0J5QmhsJjDqdX+kFZeSlkqwM5npicPNRA==", "7527f5e8-2855-450e-b530-25073204d120" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b3d8788-9375-4508-9b68-d4fe4c83fde1", new DateTimeOffset(new DateTime(2024, 1, 23, 14, 53, 13, 996, DateTimeKind.Unspecified).AddTicks(4621), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEKmQOGjL5B/jcYNoaEELBy58XXGfzlGF7g1Meg+AQrbo4OB0KM9O21GLm/P28keTBg==", "05cff717-275e-4eb7-b283-927e30d65075" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "245d209e-f807-4e4d-a04c-f83d3c82f44e", new DateTimeOffset(new DateTime(2024, 1, 23, 14, 53, 13, 996, DateTimeKind.Unspecified).AddTicks(4200), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAELXUBi9a6Bws6/+gMmJDNN2xXvpspWP6Lpm1VftAxsYfEfzOCzryyAsrWwslKkoI1Q==", "36cbcb93-446d-49d7-80e0-7bf6277975be" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 14, 53, 14, 673, DateTimeKind.Unspecified).AddTicks(7920), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 14, 53, 14, 673, DateTimeKind.Unspecified).AddTicks(7924), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 14, 53, 14, 673, DateTimeKind.Unspecified).AddTicks(7927), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 14, 53, 14, 673, DateTimeKind.Unspecified).AddTicks(7915), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 14, 53, 14, 673, DateTimeKind.Unspecified).AddTicks(7816), new TimeSpan(0, -4, 0, 0, 0)));
        }
    }
}
