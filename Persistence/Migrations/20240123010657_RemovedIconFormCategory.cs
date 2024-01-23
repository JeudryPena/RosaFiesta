using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemovedIconFormCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                schema: "RosaFiesta",
                table: "Categories");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b066dfa7-195c-4160-ab10-59014d82bf96", new DateTimeOffset(new DateTime(2024, 1, 22, 21, 6, 56, 378, DateTimeKind.Unspecified).AddTicks(7577), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAECKrlCkNOu5/oJAjDKgHtUJfhJVYy7aoi8Nwx1ohYOyb7DwYzAt0nWhS+tOUl/Ohsg==", "b1bed865-7a32-4640-9926-14a1539d3092" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a5526aa-fc35-4fee-b003-b5ebbfa99830", new DateTimeOffset(new DateTime(2024, 1, 22, 21, 6, 56, 378, DateTimeKind.Unspecified).AddTicks(7649), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEJ8SUWyZ0cCFOxHZ5fezMFfpm656lBpqFbh2Fp5j83qvE2qRO2nANEXZ+2K7ne+Zgg==", "959e402e-a427-4215-9d31-de778d1125b4" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc5c3e96-2f83-44ae-ab43-34790d435b74", new DateTimeOffset(new DateTime(2024, 1, 22, 21, 6, 56, 378, DateTimeKind.Unspecified).AddTicks(7667), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEIVCgycrPdmJoOGNQpdWGMEwgEvS97PVpUxowaqqdce6sFBwYer4goKstouXGb9ZDQ==", "f05e05d6-0c0c-4c62-8c3b-3481281147e0" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65322174-ae26-4abb-af12-0170b8a872a9", new DateTimeOffset(new DateTime(2024, 1, 22, 21, 6, 56, 378, DateTimeKind.Unspecified).AddTicks(7547), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEBvmH2qJr+onqI651oh7m4+bSOXefwlVQ0SFZ9fSF3X4yD9IPCwKaOyRn3wZLAH33A==", "100c15ad-da26-4f30-b2dd-9d845a8c311e" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77c580cc-55c0-4641-898b-55d6dee2b99f", new DateTimeOffset(new DateTime(2024, 1, 22, 21, 6, 56, 378, DateTimeKind.Unspecified).AddTicks(7277), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEIJ+O1LZtTE4s81mKdMlcHrmVIiYoijxIvNyMAS86XCXOSARSOE6zNl61Ftnlr379g==", "92b92a11-a310-442a-b24b-ae9e384cf887" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 22, 21, 6, 56, 943, DateTimeKind.Unspecified).AddTicks(7003), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 22, 21, 6, 56, 943, DateTimeKind.Unspecified).AddTicks(7010), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 22, 21, 6, 56, 943, DateTimeKind.Unspecified).AddTicks(7016), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 22, 21, 6, 56, 943, DateTimeKind.Unspecified).AddTicks(6992), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 22, 21, 6, 56, 943, DateTimeKind.Unspecified).AddTicks(6876), new TimeSpan(0, -4, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                schema: "RosaFiesta",
                table: "Categories",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab4fe1df-31df-49c3-8584-8c9058829c2d", new DateTimeOffset(new DateTime(2024, 1, 22, 17, 57, 50, 105, DateTimeKind.Unspecified).AddTicks(1411), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEORQYoGEicX4gd46qB3N0CUJQAVfvwuAPtTj9gxRSDU14jm1zIF0PcrPlWgnK1kgSw==", "cf18a55f-36a3-4ca3-8563-c2b3008acd18" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b8ae117-115b-4ea5-ab7e-4ab7489bd5fd", new DateTimeOffset(new DateTime(2024, 1, 22, 17, 57, 50, 105, DateTimeKind.Unspecified).AddTicks(1439), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEFzOpNNR56BYdSOywYASHCvVdprH/UaWn9bnFtRtdT/IotRWT9QAKV0HovGp5O6L2A==", "67c14645-6d12-41a6-974e-a8d504e4f2fc" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aaf32f37-462c-4417-b923-b93dd8249454", new DateTimeOffset(new DateTime(2024, 1, 22, 17, 57, 50, 105, DateTimeKind.Unspecified).AddTicks(1494), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEAdbhD6OxZC5KLQqj0OXpDP1xsQiJO3AXx+aHfC+uZ2B2KhYq/mq4LGsSRRKhK4Hfw==", "913edb69-7aea-40c5-af6b-572e692525fe" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b2b69c7-3979-414e-8477-500f7811830c", new DateTimeOffset(new DateTime(2024, 1, 22, 17, 57, 50, 105, DateTimeKind.Unspecified).AddTicks(1380), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEO4Hh+kFZMpAGCRCGOTs7BzjgZ4RrKA5wrVu1/5+XFRcoBjzXtqBW5FP0JosY4dX2A==", "e1eacbed-7601-402b-bf14-d3fe1ea75fa1" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a15f0f7-e82a-4526-be6c-96900340bead", new DateTimeOffset(new DateTime(2024, 1, 22, 17, 57, 50, 105, DateTimeKind.Unspecified).AddTicks(1122), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEIyecY5p7GC+hM310dwuHTzks9MQTIVA6vBqPQTE/1gKu1AcI6doiJfF/3+X6pypqg==", "296cb5c2-e81a-4831-8ab9-496173f75f32" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 22, 17, 57, 50, 600, DateTimeKind.Unspecified).AddTicks(3757), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 22, 17, 57, 50, 600, DateTimeKind.Unspecified).AddTicks(3760), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 22, 17, 57, 50, 600, DateTimeKind.Unspecified).AddTicks(3763), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 22, 17, 57, 50, 600, DateTimeKind.Unspecified).AddTicks(3753), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 22, 17, 57, 50, 600, DateTimeKind.Unspecified).AddTicks(3664), new TimeSpan(0, -4, 0, 0, 0)));
        }
    }
}
