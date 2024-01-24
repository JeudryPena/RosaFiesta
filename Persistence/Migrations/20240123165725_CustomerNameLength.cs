using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CustomerNameLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CustomerName",
                schema: "RosaFiesta",
                table: "AddressEntity",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CustomerName",
                schema: "RosaFiesta",
                table: "AddressEntity",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

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
    }
}
