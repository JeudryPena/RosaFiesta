using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class QuotePropertiesChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EventName",
                schema: "RosaFiesta",
                table: "Quotes",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "EventDate",
                schema: "RosaFiesta",
                table: "Quotes",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Province",
                schema: "RosaFiesta",
                table: "AddressEntity",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<int>(
                name: "PostalCode",
                schema: "RosaFiesta",
                table: "AddressEntity",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                schema: "RosaFiesta",
                table: "AddressEntity",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "RosaFiesta",
                table: "AddressEntity",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                schema: "RosaFiesta",
                table: "AddressEntity",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EventName",
                schema: "RosaFiesta",
                table: "Quotes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "EventDate",
                schema: "RosaFiesta",
                table: "Quotes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Province",
                schema: "RosaFiesta",
                table: "AddressEntity",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PostalCode",
                schema: "RosaFiesta",
                table: "AddressEntity",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                schema: "RosaFiesta",
                table: "AddressEntity",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "RosaFiesta",
                table: "AddressEntity",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                schema: "RosaFiesta",
                table: "AddressEntity",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81b73251-0a63-4c88-b8d0-cd676bab0f70", new DateTimeOffset(new DateTime(2024, 1, 22, 16, 56, 16, 39, DateTimeKind.Unspecified).AddTicks(1236), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEGGx9b6iEswNhb8o0rf4qYKwLoKOFFOy/PD2MWf3fDt8xsv5MQ1ZexUVpp0zu7JXfg==", "025c06ce-7580-4664-b08e-0d135322d3db" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f902428a-39ee-4833-8da6-5a6c275f021f", new DateTimeOffset(new DateTime(2024, 1, 22, 16, 56, 16, 39, DateTimeKind.Unspecified).AddTicks(1251), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEGnWpSN1AoHek0EoUWJdRXt6qYGU8ca5Gfc28N9u3W2OJMXsZx09UMsgGUfSsWsX2w==", "a0a2fa29-bbca-424d-93b6-fcefb6790207" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53829cc8-a183-4e39-806b-99449fcd347e", new DateTimeOffset(new DateTime(2024, 1, 22, 16, 56, 16, 39, DateTimeKind.Unspecified).AddTicks(1267), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEP6liraMeNtbkxxpso9RgMZYMbuaQLGRoEkM+shEEpjCPvtB83wkgmNjGry/ZTT+dg==", "4875f63c-d32d-4840-b5cd-e483f1d47846" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a25d470-b08d-47b4-a117-9ab1da8367f8", new DateTimeOffset(new DateTime(2024, 1, 22, 16, 56, 16, 39, DateTimeKind.Unspecified).AddTicks(1143), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEHfK9Y+auMNQwWMXVZ3pvKJouxzEvuRAkIXk6C+HsoR/mGH7blWBwrhuTxSWY3FKEw==", "1db3cccc-4a69-4752-871d-404d539a501d" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46c38154-8bfb-4516-ae5d-22bca432afb6", new DateTimeOffset(new DateTime(2024, 1, 22, 16, 56, 16, 39, DateTimeKind.Unspecified).AddTicks(899), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEFywTuiqXvKVKb6Nxo8p4U+fJ3dIWDp2Mnczn9HXrANj3gHrYjiKY+EVuxLdqhjJAA==", "361e28e8-b95e-4820-af79-6f9ed3ba4622" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 22, 16, 56, 16, 498, DateTimeKind.Unspecified).AddTicks(5068), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 22, 16, 56, 16, 498, DateTimeKind.Unspecified).AddTicks(5148), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 22, 16, 56, 16, 498, DateTimeKind.Unspecified).AddTicks(5154), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 22, 16, 56, 16, 498, DateTimeKind.Unspecified).AddTicks(5057), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 22, 16, 56, 16, 498, DateTimeKind.Unspecified).AddTicks(4926), new TimeSpan(0, -4, 0, 0, 0)));
        }
    }
}
