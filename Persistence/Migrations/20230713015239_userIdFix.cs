using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class userIdFix : Migration
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f790da78-860e-4431-b59e-e05a2507c963", new DateTimeOffset(new DateTime(2023, 7, 12, 20, 18, 4, 168, DateTimeKind.Unspecified).AddTicks(5968), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEGs+LthkLw70S5hNxckq+RSa1bZQBiKs3ByuMVcCK6yuksh2T4CGnItVMHiUUzjrWw==", "65757c69-26b0-4836-a358-53e395c5d08d" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "282a6def-9a20-46e9-b9b3-9f2276806f92", new DateTimeOffset(new DateTime(2023, 7, 12, 20, 18, 4, 168, DateTimeKind.Unspecified).AddTicks(6879), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEPymBJ1HPBgMqtvOH5UGTNyJ0UiztxZBNtf6JeBdGdXM0Z0LG3jLJ5FUXJVX5Lk/IA==", "f4a44f38-3348-4275-bf0a-5f016bdb322d" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8cb988e7-ef5c-4388-a089-36510b35e225", new DateTimeOffset(new DateTime(2023, 7, 12, 20, 18, 4, 168, DateTimeKind.Unspecified).AddTicks(6902), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEBoEwaCmUWlHtE4XZVzP1jmCE/0kwMzxNlyndNk23/FEpQxveO+BLI9+aCCj1Voa/Q==", "661e24a0-33e8-4c1b-bfc4-40ab6f0b2569" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fd9a6b0-c50c-4d42-a12d-4408706f491e", new DateTimeOffset(new DateTime(2023, 7, 12, 20, 18, 4, 168, DateTimeKind.Unspecified).AddTicks(5943), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEN7MtChicLFkzBtdFzeEWgLzvxgER9yXrf0dLhF3eaW5EoDjK0RmnCv/IVuJ0azBXQ==", "bfecf4b9-d73b-4587-8bd6-ca124a2294f6" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c27e0c1-6a88-44ac-aa27-e6bbae6e7dc0", new DateTimeOffset(new DateTime(2023, 7, 12, 20, 18, 4, 168, DateTimeKind.Unspecified).AddTicks(5554), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEJ/6usYs+/ijoH/IWU2r93P7cnu+6eFHM/zLLwkDYZC8yhw7ooYFDpmuoR4sdTBQqw==", "b326ee9b-3546-4f38-9213-ca55a6262a67" });
        }
    }
}
