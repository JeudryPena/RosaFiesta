using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class upgradedNavigateProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMale",
                schema: "RosaFiesta",
                table: "Options");

            migrationBuilder.AddColumn<Guid>(
                name: "OptionId",
                schema: "RosaFiesta",
                table: "Products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "GenderFor",
                schema: "RosaFiesta",
                table: "Options",
                type: "integer",
                maxLength: 20,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                schema: "RosaFiesta",
                table: "Options",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Products_OptionId",
                schema: "RosaFiesta",
                table: "Products",
                column: "OptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Options_ImageId",
                schema: "RosaFiesta",
                table: "Options",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_OptionImages_ImageId",
                schema: "RosaFiesta",
                table: "Options",
                column: "ImageId",
                principalSchema: "RosaFiesta",
                principalTable: "OptionImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_OptionImages_ImageId",
                schema: "RosaFiesta",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Options_OptionId",
                schema: "RosaFiesta",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OptionId",
                schema: "RosaFiesta",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Options_ImageId",
                schema: "RosaFiesta",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "OptionId",
                schema: "RosaFiesta",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GenderFor",
                schema: "RosaFiesta",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "ImageId",
                schema: "RosaFiesta",
                table: "Options");

            migrationBuilder.AddColumn<bool>(
                name: "IsMale",
                schema: "RosaFiesta",
                table: "Options",
                type: "boolean",
                maxLength: 20,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3db45765-809a-460e-bcc4-c33756e99cfc", new DateTimeOffset(new DateTime(2023, 7, 12, 23, 2, 29, 105, DateTimeKind.Unspecified).AddTicks(1073), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAENb7wB8zqm6W1DOHHu8X8EXOEUQOt3+WT7jhuzpniH03Ou2BmGstLwQo5dlpoARa2A==", "6b9b048a-49e4-4a67-a6df-8287aebc852f" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab8e80bf-bea4-4de9-8d04-670130215e5c", new DateTimeOffset(new DateTime(2023, 7, 12, 23, 2, 29, 105, DateTimeKind.Unspecified).AddTicks(1092), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEN4+OujqGqlG0jXyZrFCRdBXdxdhqYOr+hAKiFwmf5Es0L71OKUEcPzWgsWXa1x5HA==", "861a643d-0673-4d7d-8016-dd7c0ce647ce" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48638b46-0659-4483-9fde-63534eef20cd", new DateTimeOffset(new DateTime(2023, 7, 12, 23, 2, 29, 105, DateTimeKind.Unspecified).AddTicks(1109), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEMViY28kNrGsvMSyqbFss+pjuLbqVYm0Kai3eKfqR5jfvzae7mszIUMNdxbhEAgOQA==", "8010705b-d8f4-4869-9d9f-f861cde79a2c" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4dd675f7-8245-4ae2-8356-e25f54988295", new DateTimeOffset(new DateTime(2023, 7, 12, 23, 2, 29, 105, DateTimeKind.Unspecified).AddTicks(1047), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAELRddWTUDEVUnGx2YBSgMTGLzgjmMcH1cp1mZ5lWd0Jf0CkGYbLbJVgDNny6CWsgSA==", "341fb5d1-1569-4ae6-9736-4aaeaab12d0f" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed849eb2-ff03-4cd5-951a-65420cd6186f", new DateTimeOffset(new DateTime(2023, 7, 12, 23, 2, 29, 105, DateTimeKind.Unspecified).AddTicks(764), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAELypTCZC5+crxdzjMrI7X7DJNOaGMht9P0EMjngwI4/iCjodSDbD593q9nt5JCIfyw==", "ae5c879b-5851-45c3-8856-d300517b8436" });
        }
    }
}
