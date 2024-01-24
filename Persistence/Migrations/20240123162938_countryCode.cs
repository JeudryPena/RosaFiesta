using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class countryCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                schema: "RosaFiesta",
                table: "AddressEntity",
                type: "character varying(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2580e8d-fbd8-4c86-9a6a-c0399475cfda", new DateTimeOffset(new DateTime(2024, 1, 23, 12, 29, 37, 589, DateTimeKind.Unspecified).AddTicks(2925), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEEMWtfi/xQjLqQiyqa5LwMeO3DW+uxwAfssxwlVdmPhC7+WRDMX8n4vNx7kzDXttBw==", "b0ac87f1-58d1-4231-91aa-027c44416cb8" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8492666a-d811-493d-b453-bee27410ba28", new DateTimeOffset(new DateTime(2024, 1, 23, 12, 29, 37, 589, DateTimeKind.Unspecified).AddTicks(3002), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEBUIBPr1EYxV50rKIhvVa6M8/W7pZsU2uOfNykjgC3kBlF4OqGIobSyKvDzIIlMAZQ==", "b239ca32-1c16-44ce-87f6-24b5a7a559ba" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd983594-1392-4e59-8c83-a292228b44c4", new DateTimeOffset(new DateTime(2024, 1, 23, 12, 29, 37, 589, DateTimeKind.Unspecified).AddTicks(3017), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEMy9b2J5HkED1JEA/XMW3FOZMwinosvzyI4t93SU1M3xP0uXwkvbhKnenHbuz8pnvg==", "236b6fd8-b29d-4cc2-9fda-5787529fcaa9" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7212a6ba-75ac-43b8-875a-395b89a1e987", new DateTimeOffset(new DateTime(2024, 1, 23, 12, 29, 37, 589, DateTimeKind.Unspecified).AddTicks(2883), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEGopXr4RjMo3DAL9TfhjFDvUyIWYlmshmPhtJCzGswg8QET1s1k/8QbYMh48ydvBaQ==", "15c5d4e5-71a7-4824-b6d0-40a81315fec7" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59febc1f-4798-4679-ac74-c33c03c43d02", new DateTimeOffset(new DateTime(2024, 1, 23, 12, 29, 37, 589, DateTimeKind.Unspecified).AddTicks(2622), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEEwKG2TWmOa3NXOLTMKEhI20RtEWmt5HdoC+xQtHCfDh6PeZABjVBo9SPrB4JaAvLg==", "8fc11fd6-0faa-47d2-8c0f-64b00b26f421" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 12, 29, 38, 75, DateTimeKind.Unspecified).AddTicks(3050), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 12, 29, 38, 75, DateTimeKind.Unspecified).AddTicks(3053), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 12, 29, 38, 75, DateTimeKind.Unspecified).AddTicks(3056), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 12, 29, 38, 75, DateTimeKind.Unspecified).AddTicks(3046), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 12, 29, 38, 75, DateTimeKind.Unspecified).AddTicks(2959), new TimeSpan(0, -4, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                schema: "RosaFiesta",
                table: "AddressEntity",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d609301-0eb0-42af-8e28-ad7375c31f2f", new DateTimeOffset(new DateTime(2024, 1, 23, 12, 24, 41, 418, DateTimeKind.Unspecified).AddTicks(4099), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEJK5fjC1LRLTfOkE6YUoK7l1OrDrkqvfwxTNfuVs9FdIqRGtfyTnViBfVp3wK7FQNQ==", "fef7506f-3536-472a-8d15-d65119057ddf" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d66f749a-1423-42b4-9080-ef95efd781b5", new DateTimeOffset(new DateTime(2024, 1, 23, 12, 24, 41, 418, DateTimeKind.Unspecified).AddTicks(4111), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEOauJgchXpDkiBsZ59Ejxow83WOkvGR9YafMKF7OvSvkcy+T6P6Keyhm2PMBaTgg8w==", "da306f73-a07d-4e84-9195-e83a31fa674c" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e83543e4-6e5a-4c07-974c-1e6c1132a61a", new DateTimeOffset(new DateTime(2024, 1, 23, 12, 24, 41, 418, DateTimeKind.Unspecified).AddTicks(4123), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAELpJMsQfVfNyhDWeP0226zPft4KoSdvZ247nUJul6I++mX8n5nA9N/m/177Fastmmw==", "d1c32388-a0a2-48c6-abab-882bfe1d4eec" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4cc610a9-b4bf-4f9f-82fb-b17ca3508687", new DateTimeOffset(new DateTime(2024, 1, 23, 12, 24, 41, 418, DateTimeKind.Unspecified).AddTicks(4067), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEFR2ErY67pGPDkRD4Zr6t0YEL+JZHO2U0gJnoK04vUfdN5eNZOXVVXtQ7aGG+1/fNQ==", "e1eee43e-71c3-4fcd-8977-e92c052e1d27" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4309eff0-1502-4393-9a84-3cde345c53d7", new DateTimeOffset(new DateTime(2024, 1, 23, 12, 24, 41, 418, DateTimeKind.Unspecified).AddTicks(3834), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEMX7Dx/HS8MOFE1mZWxWijggZqnMqcvO4Y3AJ641giZV3wo86Lfmr5CbUeAMcSGxMA==", "c51cd0f8-f04b-4c34-95b9-c9bb0aed3306" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 12, 24, 41, 758, DateTimeKind.Unspecified).AddTicks(5881), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 12, 24, 41, 758, DateTimeKind.Unspecified).AddTicks(5884), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 12, 24, 41, 758, DateTimeKind.Unspecified).AddTicks(5886), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 12, 24, 41, 758, DateTimeKind.Unspecified).AddTicks(5877), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 12, 24, 41, 758, DateTimeKind.Unspecified).AddTicks(5798), new TimeSpan(0, -4, 0, 0, 0)));
        }
    }
}
