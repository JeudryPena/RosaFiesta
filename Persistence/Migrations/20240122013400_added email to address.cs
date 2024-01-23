using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedemailtoaddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "RosaFiesta",
                table: "AddressEntity",
                type: "text",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "RosaFiesta",
                table: "AddressEntity");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "404ccf45-ce82-4f2b-9a62-ecab1df6a059", new DateTimeOffset(new DateTime(2024, 1, 21, 20, 51, 55, 254, DateTimeKind.Unspecified).AddTicks(3063), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEMiunNBfCrF0u81kHpV6doW7LhnniJTwVX0Jbz7zVAXYsPWwkKhx6qH58bgB3BQPWA==", "50866459-b3f5-47d8-baec-96f879750068" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bde67bbb-20f2-4b7c-9714-d4b6261a1abe", new DateTimeOffset(new DateTime(2024, 1, 21, 20, 51, 55, 254, DateTimeKind.Unspecified).AddTicks(3123), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEMjBqG/ucGo6hletOixAPzrVxQIlnxaWqNsI98l7vzo8H2q341Ixde0lGXVtF7xzuQ==", "9ad5cae9-e9a0-4306-83db-3f91925bfe50" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2c306fe-8401-44a1-b549-dd0cc849f236", new DateTimeOffset(new DateTime(2024, 1, 21, 20, 51, 55, 254, DateTimeKind.Unspecified).AddTicks(3134), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEBq6aFtZsQn/tsqIoTF/hgyfAEXdP/dJiSk+JjyLu4Sxano4U+GyxxCevzqBtl0+ww==", "58c8d64a-652a-4c4e-8b3f-ae73ea371d00" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9de601ca-b025-41a5-89f2-9c0125641cf2", new DateTimeOffset(new DateTime(2024, 1, 21, 20, 51, 55, 254, DateTimeKind.Unspecified).AddTicks(3040), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAENu+AtkIHlbdS3vjz2AST2hDGcnVxHt6V7bZEdpu+6Kh1lngVvmqFBJU1Re9f1WpNQ==", "49efae5c-5594-45c6-bd71-aecac2be1fad" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "785ec22c-0cbb-48d4-a13d-73a2744027a3", new DateTimeOffset(new DateTime(2024, 1, 21, 20, 51, 55, 254, DateTimeKind.Unspecified).AddTicks(2817), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAECFqpe7uS9X+M292taMWtHP/931r+cHlgqtSasq3Z9zC4phTP0vu/OkrN8hmWIDxtg==", "17a5ad21-80d2-4eab-b2c9-23d14c68d944" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 20, 51, 55, 665, DateTimeKind.Unspecified).AddTicks(6392), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 20, 51, 55, 665, DateTimeKind.Unspecified).AddTicks(6396), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 20, 51, 55, 665, DateTimeKind.Unspecified).AddTicks(6401), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 20, 51, 55, 665, DateTimeKind.Unspecified).AddTicks(6379), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 20, 51, 55, 665, DateTimeKind.Unspecified).AddTicks(6275), new TimeSpan(0, -4, 0, 0, 0)));
        }
    }
}
