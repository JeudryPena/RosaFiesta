using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FieldsDateAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                schema: "RosaFiesta",
                table: "AddressEntity",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "RosaFiesta",
                table: "AddressEntity",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                schema: "RosaFiesta",
                table: "AddressEntity",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c40af015-a157-444c-9c7b-68f224f42b90", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 4, 59, 136, DateTimeKind.Unspecified).AddTicks(7871), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEBUheOwixPdftLSLMCrsSqaMTpRr4FCn8IK78JPeJ+lhT40b36UqZWZIGq9PiPliug==", "b2326774-8b9e-4fee-b827-ed1b0a7ec0ce" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "087fd3d5-4d57-4e41-b1e5-3ebf2ec52934", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 4, 59, 136, DateTimeKind.Unspecified).AddTicks(7885), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEHxk7zKrQIODllPVCTCIHOetBOHwnaoFm0TrSaZzfIeMrSObkigsmOs8DufEJA4qZw==", "5002da16-71fc-4179-8b4d-b9aacb8fe221" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bebdfbde-0c94-4d81-9e62-9a214a8f3ed3", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 4, 59, 136, DateTimeKind.Unspecified).AddTicks(7933), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEL2JLoT2xZLoyYIt4uSlmKLelycqyXFUQ7+LaiXNevI7EyP+pbcLlHXO4m9QDTSeMA==", "ac71219c-3523-49dd-9472-8af6f381bfde" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba0dabd1-4dae-406c-9755-7b3cb3b3fbe2", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 4, 59, 136, DateTimeKind.Unspecified).AddTicks(7856), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEJYuDi0RhrYtKdQCPoABE516bYFqpg2uWxUYx83jnNPgtYTMja+dUPF25WVFi8DDWg==", "5c61eed8-ccca-4933-8c02-69466f2f83e6" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a1f5451-8d7c-4483-bb6a-5783cdb9ab94", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 4, 59, 136, DateTimeKind.Unspecified).AddTicks(7552), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEEkM77dEKjadac7xY6pP12dPPe3fINkkQiY+0V+ltwtIzB/5mSPy5pGlKm8uxpEQVw==", "f2eb0b31-46c9-421e-8d18-8fac08616b94" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 4, 59, 422, DateTimeKind.Unspecified).AddTicks(6989), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 4, 59, 422, DateTimeKind.Unspecified).AddTicks(6992), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 4, 59, 422, DateTimeKind.Unspecified).AddTicks(6994), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 4, 59, 422, DateTimeKind.Unspecified).AddTicks(6985), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 4, 59, 422, DateTimeKind.Unspecified).AddTicks(6905), new TimeSpan(0, -4, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "RosaFiesta",
                table: "AddressEntity");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "RosaFiesta",
                table: "AddressEntity");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "RosaFiesta",
                table: "AddressEntity");

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
    }
}
