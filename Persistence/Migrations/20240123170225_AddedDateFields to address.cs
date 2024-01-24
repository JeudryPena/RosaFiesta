using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedDateFieldstoaddress : Migration
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
                values: new object[] { "5e011d80-0d68-441d-a8e2-a4e4bde9373e", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 2, 25, 45, DateTimeKind.Unspecified).AddTicks(201), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEBl/65c/mVfRmVker+Tl4T2psET+BIIFqkFymhqq9TwNz1lzWrhwBzbJJyqwSoqjUA==", "f12f88a9-bdbd-4a89-adc8-f5d45f3acdd2" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a680f7ce-640d-4b5c-a887-4ad44d500d2d", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 2, 25, 45, DateTimeKind.Unspecified).AddTicks(210), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEKb4kTWjQWdgM87VzNHimvMFVtUIivJGo2OXaf6SdgJr+C8xTOs8OpJ5Zg5FgII7Ow==", "1f809d37-e172-44ab-bd51-227a7b1fc5a1" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5968befd-05e4-4ade-bbc1-237ee649f9ea", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 2, 25, 45, DateTimeKind.Unspecified).AddTicks(247), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEGmqT267JjqsFDeiw7J4v26o97INqX+Y1M8rb+4yYmFSjaDruPT20jjp2KYffHtdtw==", "658cd575-d027-45f6-8502-09c2cb353300" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c446e8b-3baf-4658-ae33-6bf49a8171ce", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 2, 25, 45, DateTimeKind.Unspecified).AddTicks(181), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAECxh6JchnOzswEqEcO9YKORJbEtsvmDkxX4YAcRtpoQ5NyuER87pQN77cJ6BrskNAg==", "9f4c2eb4-f461-4437-b535-20e5e9089a69" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76810a90-74be-469a-93e6-78fcbfbc52a1", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 2, 25, 44, DateTimeKind.Unspecified).AddTicks(9944), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEPvWNZmgiVYUvWe1ajj8UAcIV2w/ixtYn4bFtwEXGGb494vi8jH3qB2sNa/2XHf5mQ==", "1a2eb74a-98b1-4c94-a661-4fa70e487351" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 2, 25, 344, DateTimeKind.Unspecified).AddTicks(5374), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 2, 25, 344, DateTimeKind.Unspecified).AddTicks(5377), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 2, 25, 344, DateTimeKind.Unspecified).AddTicks(5379), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 2, 25, 344, DateTimeKind.Unspecified).AddTicks(5371), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 2, 25, 344, DateTimeKind.Unspecified).AddTicks(5239), new TimeSpan(0, -4, 0, 0, 0)));
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
                values: new object[] { "a86fa797-6e51-41e4-b289-00d9659c24b9", new DateTimeOffset(new DateTime(2024, 1, 23, 12, 57, 25, 279, DateTimeKind.Unspecified).AddTicks(1522), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEGxTYZgZe97Y0R8mVDnj4Q7vERUILk2voH13IQ90y0fjQ3coeF+bTo4eXfmnUDARuQ==", "d37ebfe9-c58b-42c3-a8af-07894a202ea9" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c254f01-4ced-4665-a235-449ceec10e91", new DateTimeOffset(new DateTime(2024, 1, 23, 12, 57, 25, 279, DateTimeKind.Unspecified).AddTicks(1535), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEIRuAhFBAwtxzWDbvCMZVVRsevduFuCHYIijlnfaU+HX9iLjyA1+UGzakXH0f0FY5Q==", "8f2c512f-f214-431a-999c-30f839712aae" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91956863-8356-426d-a4f6-dd0ce0d4eef7", new DateTimeOffset(new DateTime(2024, 1, 23, 12, 57, 25, 279, DateTimeKind.Unspecified).AddTicks(1581), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEAy9pJEnP6vA+EdAHYCT9EdBnNyNWlOZUmQ1bMdqUSStAOz1AccAkZyhV9St0xuq1g==", "adb89c67-a6fe-4dbc-a06e-f8efd30ef288" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5df526bf-1551-41d0-a6f3-b6acd4638020", new DateTimeOffset(new DateTime(2024, 1, 23, 12, 57, 25, 279, DateTimeKind.Unspecified).AddTicks(1486), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAENzmgY2be7JdOTt6Xuti5YBDE7LFk9XT4O6rMwN+YVemquOvGG0UP0CqP4LiQVLXow==", "acd92d94-bd95-4dd3-b5e2-fdff992540a5" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1eb54f3-c9e8-4a11-8a07-471a2e9e09ab", new DateTimeOffset(new DateTime(2024, 1, 23, 12, 57, 25, 279, DateTimeKind.Unspecified).AddTicks(1221), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEIuaHOE08s2vJfu2EVRAC9Aqo8Mfgh2yXYSorPuWgbDsB7kkgT0kNGaoMavygau+xQ==", "b4d46d06-58a0-4e7b-b2f9-fc5c089135a4" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 12, 57, 25, 797, DateTimeKind.Unspecified).AddTicks(5371), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 12, 57, 25, 797, DateTimeKind.Unspecified).AddTicks(5374), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 12, 57, 25, 797, DateTimeKind.Unspecified).AddTicks(5381), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 12, 57, 25, 797, DateTimeKind.Unspecified).AddTicks(5367), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 12, 57, 25, 797, DateTimeKind.Unspecified).AddTicks(5275), new TimeSpan(0, -4, 0, 0, 0)));
        }
    }
}
