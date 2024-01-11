using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removedpaymethodsaves : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PayMethods_PayMethodId",
                schema: "RosaFiesta",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_PayMethods_DefaultPayMethodId",
                schema: "RosaFiesta",
                table: "Users");

            migrationBuilder.DropTable(
                name: "PayMethods",
                schema: "RosaFiesta");

            migrationBuilder.DropIndex(
                name: "IX_Users_DefaultPayMethodId",
                schema: "RosaFiesta",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PayMethodId",
                schema: "RosaFiesta",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DefaultPayMethodId",
                schema: "RosaFiesta",
                table: "Users");

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

            migrationBuilder.InsertData(
                schema: "RosaFiesta",
                table: "WishesList",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"), new DateTimeOffset(new DateTime(2024, 1, 10, 21, 19, 35, 990, DateTimeKind.Unspecified).AddTicks(6640), new TimeSpan(0, -4, 0, 0, 0)), false, null, "2301d884-221a-4e7d-b509-0113dcc043e1" },
                    { new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"), new DateTimeOffset(new DateTime(2024, 1, 10, 21, 19, 35, 990, DateTimeKind.Unspecified).AddTicks(6647), new TimeSpan(0, -4, 0, 0, 0)), false, null, "2301d884-221a-4e7d-b509-0113dcc043e2" },
                    { new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"), new DateTimeOffset(new DateTime(2024, 1, 10, 21, 19, 35, 990, DateTimeKind.Unspecified).AddTicks(6654), new TimeSpan(0, -4, 0, 0, 0)), false, null, "2301d884-221a-4e7d-b509-0113dcc043e3" },
                    { new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"), new DateTimeOffset(new DateTime(2024, 1, 10, 21, 19, 35, 990, DateTimeKind.Unspecified).AddTicks(6629), new TimeSpan(0, -4, 0, 0, 0)), false, null, "7d9b7113-a8f8-4035-99a7-a20dd400f6a3" },
                    { new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"), new DateTimeOffset(new DateTime(2024, 1, 10, 21, 19, 35, 990, DateTimeKind.Unspecified).AddTicks(6489), new TimeSpan(0, -4, 0, 0, 0)), false, null, "b22698b8-42a2-4115-9631-1c2d1e2ac5f7" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"));

            migrationBuilder.DeleteData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"));

            migrationBuilder.DeleteData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"));

            migrationBuilder.DeleteData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"));

            migrationBuilder.DeleteData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"));

            migrationBuilder.AddColumn<Guid>(
                name: "DefaultPayMethodId",
                schema: "RosaFiesta",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PayMethods",
                schema: "RosaFiesta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CardNumber = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Cvv = table.Column<string>(type: "text", nullable: false),
                    ExpirationDate = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    OwnerName = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayMethods_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "RosaFiesta",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "DefaultPayMethodId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c696e428-4bc8-4be2-bbf4-94812e9d043c", new DateTimeOffset(new DateTime(2024, 1, 10, 15, 34, 55, 996, DateTimeKind.Unspecified).AddTicks(5556), new TimeSpan(0, -4, 0, 0, 0)), null, "AQAAAAIAAYagAAAAEPRmtNYJJlhH5p4kgaXdR+P3cj2b59ielbzX00FRlq5zhJrb2mUxjnUkHR+3JBiSQQ==", "a5767903-116f-4d00-ab90-0b7eb3423085" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "DefaultPayMethodId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9944059-e657-4ed3-a5af-dc0437df1bd4", new DateTimeOffset(new DateTime(2024, 1, 10, 15, 34, 55, 996, DateTimeKind.Unspecified).AddTicks(5572), new TimeSpan(0, -4, 0, 0, 0)), null, "AQAAAAIAAYagAAAAEG6IoZV/iHv8meKeuqNGnWJfHJx3kdsT/j+jZe28LlH9BMQMas0aznX5nP6ljbMeCQ==", "b7a787b0-5487-46f1-81b3-642f1bfc112b" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "DefaultPayMethodId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c310ca3-1e03-4901-b461-a0b5149d5369", new DateTimeOffset(new DateTime(2024, 1, 10, 15, 34, 55, 996, DateTimeKind.Unspecified).AddTicks(5588), new TimeSpan(0, -4, 0, 0, 0)), null, "AQAAAAIAAYagAAAAENK1JmBXxvFknzXyyfSsojeqKUT8hwk/3Xxt3U6LBDeCz4P27k8yuVCDAEwKMzMYIQ==", "c6828521-4392-4975-844f-bc7a3346bee2" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "DefaultPayMethodId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e7164e7-2503-4362-bcac-fa6ba95b4f7e", new DateTimeOffset(new DateTime(2024, 1, 10, 15, 34, 55, 996, DateTimeKind.Unspecified).AddTicks(5512), new TimeSpan(0, -4, 0, 0, 0)), null, "AQAAAAIAAYagAAAAEOC+3Q7eE2CaL9ntZd634zjw3X2wyp/HePwmgWoEpKRaqumFcyXfEK/AybgqbUMeVg==", "e5e48797-171a-43f9-bfae-7daf33bf5669" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "DefaultPayMethodId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e216517b-5d65-44c3-a851-3ee2ef2ebb3b", new DateTimeOffset(new DateTime(2024, 1, 10, 15, 34, 55, 996, DateTimeKind.Unspecified).AddTicks(5251), new TimeSpan(0, -4, 0, 0, 0)), null, "AQAAAAIAAYagAAAAEFJ40EGBpOP4nujMKa/d5Aat47+x4KyBBFf2rlw+HGhg0vuLMgj9i6SAp6gUBlKojQ==", "ccf26d32-82dd-45e4-b9aa-57980bc37eeb" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_DefaultPayMethodId",
                schema: "RosaFiesta",
                table: "Users",
                column: "DefaultPayMethodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PayMethodId",
                schema: "RosaFiesta",
                table: "Orders",
                column: "PayMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PayMethods_UserId",
                schema: "RosaFiesta",
                table: "PayMethods",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PayMethods_PayMethodId",
                schema: "RosaFiesta",
                table: "Orders",
                column: "PayMethodId",
                principalSchema: "RosaFiesta",
                principalTable: "PayMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_PayMethods_DefaultPayMethodId",
                schema: "RosaFiesta",
                table: "Users",
                column: "DefaultPayMethodId",
                principalSchema: "RosaFiesta",
                principalTable: "PayMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
