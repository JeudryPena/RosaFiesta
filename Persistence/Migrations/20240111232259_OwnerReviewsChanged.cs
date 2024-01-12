using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OwnerReviewsChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayMethodId",
                schema: "RosaFiesta",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "UserEntityId",
                schema: "RosaFiesta",
                table: "Reviews",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "278e3ac7-02f6-4f7e-844f-dcdf8db81761", new DateTimeOffset(new DateTime(2024, 1, 11, 19, 22, 57, 474, DateTimeKind.Unspecified).AddTicks(1517), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEGiqd7ChpUtAiKF7I6XFxBHTZEP3CXFst12dExxmyzrMVK2BeAehIohwWsDmcVlQFA==", "495f29a0-c9ae-4435-b13f-5c97edeb069b" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad24c06e-5494-48fc-8a9f-91d3e52329c9", new DateTimeOffset(new DateTime(2024, 1, 11, 19, 22, 57, 474, DateTimeKind.Unspecified).AddTicks(1557), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEG7NOT+DewnuLef71WnrjCJw0hF+mEaBc+bmq8kmkmr9/TrM4v3q2x5bNiIS4L5Zyg==", "3e993eb6-a779-45f9-b7d6-b908f9cecad2" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7978b69e-a588-4b2e-86e1-a4f0defc213f", new DateTimeOffset(new DateTime(2024, 1, 11, 19, 22, 57, 474, DateTimeKind.Unspecified).AddTicks(1582), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEEMbJKpUyDxPQqUs6S26ejSobUwSj1riAG6upA52uvyYjgyQI2VOyxxMEUZEj3ggtQ==", "118eaed6-16bb-47e7-a08c-0a80bd87848c" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fcb496c8-b201-499d-96ee-11851992936c", new DateTimeOffset(new DateTime(2024, 1, 11, 19, 22, 57, 474, DateTimeKind.Unspecified).AddTicks(1474), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEIODxf206eSJ6K08io+TSSOkitig/o6sB2SDb6SlMYb+a25QO3ddH8pROMTPvBH3lA==", "5c574509-7ea4-4d55-8fc2-80ce9254c34a" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e63f065-0167-4ebb-abd2-9a07c52a826e", new DateTimeOffset(new DateTime(2024, 1, 11, 19, 22, 57, 474, DateTimeKind.Unspecified).AddTicks(1020), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEMX/t90gc03OsT0DKY8W85uDQZ7c7M3QHpChw+bPRzpBE02b6Eg52zFCU/aMVFi0bg==", "b848d8ba-9314-4fb2-8bd2-e51ae35d8a18" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 19, 22, 58, 680, DateTimeKind.Unspecified).AddTicks(5191), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 19, 22, 58, 680, DateTimeKind.Unspecified).AddTicks(5199), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 19, 22, 58, 680, DateTimeKind.Unspecified).AddTicks(5205), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 19, 22, 58, 680, DateTimeKind.Unspecified).AddTicks(5179), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 19, 22, 58, 680, DateTimeKind.Unspecified).AddTicks(5057), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserEntityId",
                schema: "RosaFiesta",
                table: "Reviews",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserEntityId",
                schema: "RosaFiesta",
                table: "Reviews",
                column: "UserEntityId",
                principalSchema: "RosaFiesta",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserEntityId",
                schema: "RosaFiesta",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_UserEntityId",
                schema: "RosaFiesta",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                schema: "RosaFiesta",
                table: "Reviews");

            migrationBuilder.AddColumn<Guid>(
                name: "PayMethodId",
                schema: "RosaFiesta",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50676a23-df89-4bf8-bdac-2f214d582112", new DateTimeOffset(new DateTime(2024, 1, 10, 21, 19, 35, 69, DateTimeKind.Unspecified).AddTicks(7282), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEAIoBeSIT7NP9Bumv2YbApY48cnDpIedrZk77hPdUnpDZdue19YHFsUx5qWdwo0spQ==", "473f444e-6622-424c-9ba0-3339267c650f" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c01eaa7-bc15-4e4a-b324-f85c1dcd90d8", new DateTimeOffset(new DateTime(2024, 1, 10, 21, 19, 35, 69, DateTimeKind.Unspecified).AddTicks(7298), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEAwjaXDlgs5qwy+7TdJU8ZJ1IENHC0r8qDcMjJ1cnapX6pjVQjasFqPPz/MucIvxgw==", "d4292ba0-8be6-495f-9429-0b2c0fad4bf2" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd44a211-3abe-4f85-ba9b-4e9f02d08a58", new DateTimeOffset(new DateTime(2024, 1, 10, 21, 19, 35, 69, DateTimeKind.Unspecified).AddTicks(7320), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEDMybTIHy5K2qTWtujiLov7mOPIJOys2MM7UMXk3wBRmYE4nZJU0rp8pYkxHRRQXXA==", "1824119e-6476-4e6d-ac17-3293fc848553" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a377c8cc-e535-4657-a029-f533be966986", new DateTimeOffset(new DateTime(2024, 1, 10, 21, 19, 35, 69, DateTimeKind.Unspecified).AddTicks(7252), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEHllPGkq4b8/GNphbxiv7njpxlkSgXIDWaFwP0QkYz20OWD1lz0uIF8ixGL05Wd/Pg==", "f585816f-fe50-439a-8954-1d310a20b252" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5de24927-eac9-4148-a2b3-597ea5d8148d", new DateTimeOffset(new DateTime(2024, 1, 10, 21, 19, 35, 69, DateTimeKind.Unspecified).AddTicks(6921), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEKKQASrcmWwPyBnjf5KIlVlliaVJqhl3GD2UrOV6oQ4V/7cGajZzgwlkDMV9/Ss+Yw==", "741935f5-1414-4527-aab2-6b7d4f1dbd03" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 21, 19, 35, 990, DateTimeKind.Unspecified).AddTicks(6640), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 21, 19, 35, 990, DateTimeKind.Unspecified).AddTicks(6647), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 21, 19, 35, 990, DateTimeKind.Unspecified).AddTicks(6654), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 21, 19, 35, 990, DateTimeKind.Unspecified).AddTicks(6629), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 10, 21, 19, 35, 990, DateTimeKind.Unspecified).AddTicks(6489), new TimeSpan(0, -4, 0, 0, 0)));
        }
    }
}
