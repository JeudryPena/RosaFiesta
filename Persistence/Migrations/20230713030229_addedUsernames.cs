using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedUsernames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "3db45765-809a-460e-bcc4-c33756e99cfc", new DateTimeOffset(new DateTime(2023, 7, 12, 23, 2, 29, 105, DateTimeKind.Unspecified).AddTicks(1073), new TimeSpan(0, -4, 0, 0, 0)), "ROSALBA2", "AQAAAAIAAYagAAAAENb7wB8zqm6W1DOHHu8X8EXOEUQOt3+WT7jhuzpniH03Ou2BmGstLwQo5dlpoARa2A==", "6b9b048a-49e4-4a67-a6df-8287aebc852f", "Rosalba2" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ab8e80bf-bea4-4de9-8d04-670130215e5c", new DateTimeOffset(new DateTime(2023, 7, 12, 23, 2, 29, 105, DateTimeKind.Unspecified).AddTicks(1092), new TimeSpan(0, -4, 0, 0, 0)), "JENDRY", "AQAAAAIAAYagAAAAEN4+OujqGqlG0jXyZrFCRdBXdxdhqYOr+hAKiFwmf5Es0L71OKUEcPzWgsWXa1x5HA==", "861a643d-0673-4d7d-8016-dd7c0ce647ce", "Jendry" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "48638b46-0659-4483-9fde-63534eef20cd", new DateTimeOffset(new DateTime(2023, 7, 12, 23, 2, 29, 105, DateTimeKind.Unspecified).AddTicks(1109), new TimeSpan(0, -4, 0, 0, 0)), "ROSMERY", "AQAAAAIAAYagAAAAEMViY28kNrGsvMSyqbFss+pjuLbqVYm0Kai3eKfqR5jfvzae7mszIUMNdxbhEAgOQA==", "8010705b-d8f4-4869-9d9f-f861cde79a2c", "Rosmery" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "4dd675f7-8245-4ae2-8356-e25f54988295", new DateTimeOffset(new DateTime(2023, 7, 12, 23, 2, 29, 105, DateTimeKind.Unspecified).AddTicks(1047), new TimeSpan(0, -4, 0, 0, 0)), "ROSANNY", "AQAAAAIAAYagAAAAELRddWTUDEVUnGx2YBSgMTGLzgjmMcH1cp1mZ5lWd0Jf0CkGYbLbJVgDNny6CWsgSA==", "341fb5d1-1569-4ae6-9736-4aaeaab12d0f", "Rosanny" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ed849eb2-ff03-4cd5-951a-65420cd6186f", new DateTimeOffset(new DateTime(2023, 7, 12, 23, 2, 29, 105, DateTimeKind.Unspecified).AddTicks(764), new TimeSpan(0, -4, 0, 0, 0)), "ROSALBA", "AQAAAAIAAYagAAAAELypTCZC5+crxdzjMrI7X7DJNOaGMht9P0EMjngwI4/iCjodSDbD593q9nt5JCIfyw==", "ae5c879b-5851-45c3-8856-d300517b8436", "Rosalba" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "231428fb-3367-4be0-9b5b-845f92a8d85b", new DateTimeOffset(new DateTime(2023, 7, 12, 21, 55, 15, 529, DateTimeKind.Unspecified).AddTicks(4609), new TimeSpan(0, -4, 0, 0, 0)), null, "AQAAAAIAAYagAAAAEHB6swKoRwrXmL06AyMY6vhyIGNB3S+wRydraXHAYLSzO/mdkcBgDE451L30mgjOyQ==", "ab022fd6-a8bc-4c61-9e4e-a05d6523b84f", null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "3f917f4a-a244-4efb-ac01-f0b64d7fc176", new DateTimeOffset(new DateTime(2023, 7, 12, 21, 55, 15, 529, DateTimeKind.Unspecified).AddTicks(4715), new TimeSpan(0, -4, 0, 0, 0)), null, "AQAAAAIAAYagAAAAEGV3ThyBE6AYTl2CAn6kotWKslfa1Vrbws16Pbl8mtDIsLNto7pbmFcf/SxLYMXmLA==", "dbf1e2b3-09c4-43ad-90e4-8787bf9961c6", null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "9ec28feb-1bd5-4905-8ab0-74cfb4b17baf", new DateTimeOffset(new DateTime(2023, 7, 12, 21, 55, 15, 529, DateTimeKind.Unspecified).AddTicks(4735), new TimeSpan(0, -4, 0, 0, 0)), null, "AQAAAAIAAYagAAAAEPTnfcQgV7hvkHHe7DPaoAqAPUTPif7v4fU85rAWHcRnVCawKhky4qIkMJhnPICalA==", "d2d4c6a7-6da4-41a8-bebe-719c8f17b75c", null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "416924a5-c1bb-4882-a594-4ab7aabed2ac", new DateTimeOffset(new DateTime(2023, 7, 12, 21, 55, 15, 529, DateTimeKind.Unspecified).AddTicks(4563), new TimeSpan(0, -4, 0, 0, 0)), null, "AQAAAAIAAYagAAAAENHwkZZgz8jCxu431eHsN2b3US4mBLVZyqRpJcb0Np1BpNK0Wp7l74vfztBxzTHJ8w==", "ddf122dd-6dc4-46a3-b615-ef5fcfc3b153", null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "4158ad03-db3d-410b-9845-99203cc33027", new DateTimeOffset(new DateTime(2023, 7, 12, 21, 55, 15, 529, DateTimeKind.Unspecified).AddTicks(4202), new TimeSpan(0, -4, 0, 0, 0)), null, "AQAAAAIAAYagAAAAEGCio3wz6FQm9CcpqLansHWT9nfy8zWiY+xPAbKg3kYRq8RLPGiQfJgbSxy8zKApeQ==", "325f6338-cede-4f49-a562-9bbc24c94477", null });
        }
    }
}
