using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class optionalOption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Options_OptionId",
                schema: "RosaFiesta",
                table: "Products");

            migrationBuilder.AlterColumn<Guid>(
                name: "OptionId",
                schema: "RosaFiesta",
                table: "Products",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8a28f2a-f51c-441f-b9af-83991a532b60", new DateTimeOffset(new DateTime(2023, 7, 16, 10, 38, 41, 720, DateTimeKind.Unspecified).AddTicks(1760), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEO2aUv74qEYkZRh0ztizEbYLBxvZNH4y1yF6cjqG7/EMTmA2M+W7wIyWJrHHay7ZtA==", "11a07127-fbd4-4e3a-a2d3-fa2d33d415ea" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e9b0c95-98f9-4c57-9326-de2d0ff8cf63", new DateTimeOffset(new DateTime(2023, 7, 16, 10, 38, 41, 720, DateTimeKind.Unspecified).AddTicks(1770), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEJHH7gDyUrfzeq3JFYwSboT79IzhykvGhQGfg/YNBOuMb/TcRCHUV9nxQuBMv6bQmg==", "6f36f502-d237-4f37-846b-5ba6e045547e" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "593ccabd-ab2f-4ab5-95f4-ba7db1ffe773", new DateTimeOffset(new DateTime(2023, 7, 16, 10, 38, 41, 720, DateTimeKind.Unspecified).AddTicks(1779), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAENdZGZBMFmdzXIc5xjhTRlCBj/wvNo2FWDoCl10tQJUDqPzNOHxbDf3RyPJFpu2XNA==", "acd668b6-9119-4747-98dc-f1ce74f0be0f" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "612c0251-c14f-4525-a85b-7f58dece4056", new DateTimeOffset(new DateTime(2023, 7, 16, 10, 38, 41, 720, DateTimeKind.Unspecified).AddTicks(1735), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEIsJy0NlwqIpzqkI6u5/7Yrr0aivS8LvRK+RLtSouryOio+twxjIWYdpExUJRkFNdg==", "d30daacc-aa5f-4539-815c-c2c263d36389" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d3a3f29-0400-413e-939a-2777fcf8d7de", new DateTimeOffset(new DateTime(2023, 7, 16, 10, 38, 41, 720, DateTimeKind.Unspecified).AddTicks(1527), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEJrxFwt47Iq0OlzveMt4iEbu5SZCL4N64sY5G8/3Zg1WdAieHmMXdvPYjHvgoFQhUg==", "0618dc22-9d58-4b7f-9ca8-fe4d7955f540" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Options_OptionId",
                schema: "RosaFiesta",
                table: "Products",
                column: "OptionId",
                principalSchema: "RosaFiesta",
                principalTable: "Options",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Options_OptionId",
                schema: "RosaFiesta",
                table: "Products");

            migrationBuilder.AlterColumn<Guid>(
                name: "OptionId",
                schema: "RosaFiesta",
                table: "Products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "746d1bf1-bc44-465a-b88e-b5830b3f4a68", new DateTimeOffset(new DateTime(2023, 7, 14, 18, 22, 14, 746, DateTimeKind.Unspecified).AddTicks(9713), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAECfNHimljsZUYdPhJzh+dgYE2yMRy2JvyAnPN0xOxE/n1BE+B2jLbWsiIEtrnbD83g==", "70ce0e12-1878-474d-8e1a-8c278a073d63" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09620baf-5e28-4bb7-8809-363af033dddf", new DateTimeOffset(new DateTime(2023, 7, 14, 18, 22, 14, 746, DateTimeKind.Unspecified).AddTicks(9751), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEK8yarjjiAAJ51aN/y3Adcf3uI4OF/mr0sRBBiI2H0RFYKjFQkn7HTbPUaZZfDgvLw==", "021c9f69-c446-4ebd-87e4-f349328515f3" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b89156f5-435c-4535-8480-b763e50f701c", new DateTimeOffset(new DateTime(2023, 7, 14, 18, 22, 14, 746, DateTimeKind.Unspecified).AddTicks(9767), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAELl5ulX+9AAJNILFeXzK+Z3W+IgdQR0muGAhOd+HnlFIzZzPGWYC38/Bylb3RJT/iw==", "ee4e47be-4136-4103-a96e-e6fc9b12d9c3" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d0aeee2-c219-44e6-871b-a7da3eaf750f", new DateTimeOffset(new DateTime(2023, 7, 14, 18, 22, 14, 746, DateTimeKind.Unspecified).AddTicks(9687), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEC1eRcVbzXr+aoGT/mfp846HtwEYamYPZy2f10Q8zqRXGgETDGWtiYFaK5A8OAgblA==", "4cd9e558-e6d4-4280-aa12-041553be2849" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ececd389-362a-4a37-8814-aaa965639854", new DateTimeOffset(new DateTime(2023, 7, 14, 18, 22, 14, 746, DateTimeKind.Unspecified).AddTicks(9388), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEHjCsFPeO+TlMDTnKKgFpS1PSKYmfmXt4B/59Uj3ay/nkUsP3DtOoLVrDcprmxqx8g==", "460955e6-779c-43dc-bfcd-b61137a8f863" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Options_OptionId",
                schema: "RosaFiesta",
                table: "Products",
                column: "OptionId",
                principalSchema: "RosaFiesta",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
