using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EventName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventName",
                schema: "RosaFiesta",
                table: "Quotes",
                type: "text",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventName",
                schema: "RosaFiesta",
                table: "Quotes");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d092fa7-3fed-48c9-85d8-48063d9273a6", new DateTimeOffset(new DateTime(2024, 1, 21, 21, 33, 59, 383, DateTimeKind.Unspecified).AddTicks(1808), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEEu+gvLsDqmkBow/xLuF532iWkz+dEyS0n7fL0P33/LZPspVU/lPIUU5Lw5LiNmquw==", "b30df90d-c5a3-454b-8c57-b3f6e8f223d0" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c5b4e40-4242-4e78-868a-d110b4fd29fb", new DateTimeOffset(new DateTime(2024, 1, 21, 21, 33, 59, 383, DateTimeKind.Unspecified).AddTicks(1824), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEC0l+Ni9YZkF9hl9vXCEg/RKXXpADpd1yK/SEeXqxZJBl8wc6OTxZtXrNkk9tExMbg==", "ee734a09-8e1b-4bbd-96a4-eaf141fc5321" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6dabb3c-88af-4fae-ab13-7f7eecae98c3", new DateTimeOffset(new DateTime(2024, 1, 21, 21, 33, 59, 383, DateTimeKind.Unspecified).AddTicks(1836), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEPxPPTJWODNNmOWRVppyEgJ0nOCvClivNkxOTzPIX0YHEuqvHEzbwHrPhDpBvynYbA==", "fd9d91ab-c82e-4a4a-b2b6-c216f02a72a1" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5f32942-6cd0-410a-b327-a92029e82062", new DateTimeOffset(new DateTime(2024, 1, 21, 21, 33, 59, 383, DateTimeKind.Unspecified).AddTicks(1757), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEOz7tDJiKh6Fhxgz05nLGpBbeB+ydtJCDwOdvKbhRZaN/Z2Diyv7m4OblWz6DkUqaQ==", "2702c62f-d6c8-40cf-8ca7-85313b0e98d4" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6689f6f8-8b63-46e8-afc3-df987f17bab3", new DateTimeOffset(new DateTime(2024, 1, 21, 21, 33, 59, 383, DateTimeKind.Unspecified).AddTicks(1521), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAENowrFeYn7GQ8YjZmeBDD0U85kT4axObuFK0t19LZQqVWAJn3K5+fhBTKanSEqESvw==", "8b8e0f19-1e55-45db-bdea-6b68eb842e2f" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 21, 33, 59, 833, DateTimeKind.Unspecified).AddTicks(8534), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 21, 33, 59, 833, DateTimeKind.Unspecified).AddTicks(8569), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 21, 33, 59, 833, DateTimeKind.Unspecified).AddTicks(8572), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 21, 33, 59, 833, DateTimeKind.Unspecified).AddTicks(8530), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 21, 33, 59, 833, DateTimeKind.Unspecified).AddTicks(8441), new TimeSpan(0, -4, 0, 0, 0)));
        }
    }
}
