using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class userFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "231428fb-3367-4be0-9b5b-845f92a8d85b", new DateTimeOffset(new DateTime(2023, 7, 12, 21, 55, 15, 529, DateTimeKind.Unspecified).AddTicks(4609), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEHB6swKoRwrXmL06AyMY6vhyIGNB3S+wRydraXHAYLSzO/mdkcBgDE451L30mgjOyQ==", "ab022fd6-a8bc-4c61-9e4e-a05d6523b84f" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f917f4a-a244-4efb-ac01-f0b64d7fc176", new DateTimeOffset(new DateTime(2023, 7, 12, 21, 55, 15, 529, DateTimeKind.Unspecified).AddTicks(4715), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEGV3ThyBE6AYTl2CAn6kotWKslfa1Vrbws16Pbl8mtDIsLNto7pbmFcf/SxLYMXmLA==", "dbf1e2b3-09c4-43ad-90e4-8787bf9961c6" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ec28feb-1bd5-4905-8ab0-74cfb4b17baf", new DateTimeOffset(new DateTime(2023, 7, 12, 21, 55, 15, 529, DateTimeKind.Unspecified).AddTicks(4735), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEPTnfcQgV7hvkHHe7DPaoAqAPUTPif7v4fU85rAWHcRnVCawKhky4qIkMJhnPICalA==", "d2d4c6a7-6da4-41a8-bebe-719c8f17b75c" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "416924a5-c1bb-4882-a594-4ab7aabed2ac", new DateTimeOffset(new DateTime(2023, 7, 12, 21, 55, 15, 529, DateTimeKind.Unspecified).AddTicks(4563), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAENHwkZZgz8jCxu431eHsN2b3US4mBLVZyqRpJcb0Np1BpNK0Wp7l74vfztBxzTHJ8w==", "ddf122dd-6dc4-46a3-b615-ef5fcfc3b153" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4158ad03-db3d-410b-9845-99203cc33027", new DateTimeOffset(new DateTime(2023, 7, 12, 21, 55, 15, 529, DateTimeKind.Unspecified).AddTicks(4202), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEGCio3wz6FQm9CcpqLansHWT9nfy8zWiY+xPAbKg3kYRq8RLPGiQfJgbSxy8zKApeQ==", "325f6338-cede-4f49-a562-9bbc24c94477" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92d3c31a-3aac-4406-ba33-3220a7bdfd65", new DateTimeOffset(new DateTime(2023, 7, 12, 21, 52, 38, 573, DateTimeKind.Unspecified).AddTicks(8523), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEMChcNb0X/R/V4ZbzeSeT2TDqP3dGA+tRKyDjeM+ru5nah+3lxcR02EvL3/bvXD6vQ==", "72a5b5a7-d314-4bea-9275-95471b2c47f1" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29bfdf2e-055e-44de-b975-51de06058e37", new DateTimeOffset(new DateTime(2023, 7, 12, 21, 52, 38, 573, DateTimeKind.Unspecified).AddTicks(8541), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEL60PTsPkuBQeBgvibVpeO0UoJwqtp8MHfb61+PEA6QtmA7lONkTABYR2SMkEIBaew==", "082bead4-8b20-4ccd-9890-3cdacf1973fc" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa3b55af-6636-4615-8335-e87c1e24011c", new DateTimeOffset(new DateTime(2023, 7, 12, 21, 52, 38, 573, DateTimeKind.Unspecified).AddTicks(8557), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEDpe2SgG1qLRjzTbDSEsyPaFwyGtm/nVOYQU03ySZUABsuadRJdcvXibaqO3uV8pfQ==", "51c35d66-33b1-42b0-9a9f-e731bbccea65" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "614d9af6-b17e-4a86-97c8-71588ad0bf0b", new DateTimeOffset(new DateTime(2023, 7, 12, 21, 52, 38, 573, DateTimeKind.Unspecified).AddTicks(8474), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAELUzinPxdPbY/YOHfZa9GRNVBax8dtgFU3fwOMpZ0CX/eMA66OsZM9r77K85dto2mQ==", "a14776b4-8917-459e-a2e3-40544bfefe07" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce4d07ff-37bd-46ef-ab87-9def40cacf76", new DateTimeOffset(new DateTime(2023, 7, 12, 21, 52, 38, 573, DateTimeKind.Unspecified).AddTicks(7829), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAED3Rwkvq2VEwYaMplEWrztfTSTbBPV2bU89HXEU4msentksvAgMhpMm/2xZz5JCisw==", "67bf55c2-cdc5-4004-aa40-35d51b14894a" });
        }
    }
}
