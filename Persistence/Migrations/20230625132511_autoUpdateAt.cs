using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class autoUpdateAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                schema: "RosaFiesta",
                table: "CategoryEntity",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 13, 25, 10, 389, DateTimeKind.Unspecified).AddTicks(3255), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 23, 23, 9, 43, 491, DateTimeKind.Unspecified).AddTicks(42), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "804c2a9d-8081-4135-8dc1-be2770a632f6", new DateTimeOffset(new DateTime(2023, 6, 25, 9, 25, 10, 422, DateTimeKind.Unspecified).AddTicks(8401), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEBw9Pvr/z0B8DJ4B6bx+evMvsDamTBuCRMoaZP9pU8fFj5ysNBV7HlGyBGO062wx4w==", "be097474-d7c3-40e6-b9e5-04993b717bf9" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82262bf2-c73a-4096-93f2-075b11c749c3", new DateTimeOffset(new DateTime(2023, 6, 25, 9, 25, 10, 422, DateTimeKind.Unspecified).AddTicks(8420), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEJI88UvXpPUWBtiPAZTkWePeK5B5Y5UepeMY3CN5h4j2kH46+mlZ6VKvSaUWfde3Ig==", "51b3a6b0-261f-482b-90b1-115ff9beefa0" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f7d6a02-594f-4f6e-914d-8faa8d0ac8cb", new DateTimeOffset(new DateTime(2023, 6, 25, 9, 25, 10, 422, DateTimeKind.Unspecified).AddTicks(8434), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEASbDtblO9jJIcVPAKEv3PMUJ1vHdloMQsxgA40btPVxbZnzgMtZ22Mc1Ef8/MXFiA==", "673a53ed-1130-487e-9d1c-af35397e75e5" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc1657bd-e879-422a-964f-31779b4e5c8e", new DateTimeOffset(new DateTime(2023, 6, 25, 9, 25, 10, 422, DateTimeKind.Unspecified).AddTicks(8384), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAELZhyUNINXsXpjFdo3TrS8yi327DFohRR7jr2rEAf9IjneTqGU8YvLpCqZbhNAhX9A==", "8702b2a1-bda4-4330-844d-0a533c6af8b2" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4096bd34-ae9d-46ee-8416-76c29765c093", new DateTimeOffset(new DateTime(2023, 6, 25, 9, 25, 10, 422, DateTimeKind.Unspecified).AddTicks(8080), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEAXJVPO0l9EnyEJLGkdpnA1z0t54tbH6n/ypvkSGxcpBpuTrhuU33tm01pGzCNk+Fw==", "d2125914-c238-4c83-a75d-10062d998eec" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                schema: "RosaFiesta",
                table: "CategoryEntity",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 23, 23, 9, 43, 491, DateTimeKind.Unspecified).AddTicks(42), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 13, 25, 10, 389, DateTimeKind.Unspecified).AddTicks(3255), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a01d32a-4359-40e6-bb07-ee71e13cece9", new DateTimeOffset(new DateTime(2023, 6, 23, 19, 9, 43, 512, DateTimeKind.Unspecified).AddTicks(4753), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEBDF5q8chEJBdt/LhoaOkuRcZXnygkIzsovyf3ED+2aFJNI+NqqkbLp32QEKRVNgMg==", "e0a769af-5f31-4b38-a5db-0f00fe3a1082" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80c4359e-4243-4275-90ec-040c26ba2387", new DateTimeOffset(new DateTime(2023, 6, 23, 19, 9, 43, 512, DateTimeKind.Unspecified).AddTicks(4774), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEOvzD8RZTZN4BguPOfXPx0iKYn85w06G7txtVv2dsVI3fFiNuF68O7Se1GBH886K7w==", "e82b4b7d-47b2-4d0b-bb1c-355cbc327b62" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32a90b79-e662-49de-bc79-707d76a71b98", new DateTimeOffset(new DateTime(2023, 6, 23, 19, 9, 43, 512, DateTimeKind.Unspecified).AddTicks(4786), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAENeZc97FDUiZeMbBxkEcEjK1nU0CjtPXgJzzUFkit7IwfAjIXh0u0IVe2ebmZn3keA==", "c38dd714-265f-4de0-80ad-058ad2adaabb" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fce124bd-479c-48dd-88e9-99ccf2a527ed", new DateTimeOffset(new DateTime(2023, 6, 23, 19, 9, 43, 512, DateTimeKind.Unspecified).AddTicks(4712), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEOhqaXDQ4Xp7dZ3M8pZGAuv3Vqe2gXkv3sspsKjdY5UqbeJLbdn9C5KB7cx3V3vOgg==", "b8ab5e9c-69b1-4b9f-96c4-1bcb0ab662bb" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24de3769-2910-45b0-a21a-a9919ec76b14", new DateTimeOffset(new DateTime(2023, 6, 23, 19, 9, 43, 512, DateTimeKind.Unspecified).AddTicks(4482), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEFaXJ8xQAOqxz1NxgU3maJo5tpwrCrzQJUFjrgF9N8O6FoNCT4I9clTZ8k+Ty+GLkQ==", "94479c0d-9fa3-4e17-ad50-7682b5df8c8c" });
        }
    }
}
