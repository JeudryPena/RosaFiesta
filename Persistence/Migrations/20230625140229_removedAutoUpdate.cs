using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removedAutoUpdate : Migration
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
                values: new object[] { "55c91f19-d48a-46fa-bf74-8c360c0c139f", new DateTimeOffset(new DateTime(2023, 6, 25, 10, 2, 29, 290, DateTimeKind.Unspecified).AddTicks(1113), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAELI7v8MgP2jdMdxS9qAUooBMUFmE5/77xBocwWko63+z/9kmzOMRMFeIRGHf1i85rA==", "e3748700-f40b-42b7-a140-ffaa0b438306" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d8f8578-79c5-4c66-a258-d190a7884f2b", new DateTimeOffset(new DateTime(2023, 6, 25, 10, 2, 29, 290, DateTimeKind.Unspecified).AddTicks(1130), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEEqzZ16K3cdb0GH/LhD3FxF4sxTQPu5EHEQd6/h/IsPT2SCHDL7bbkKeeDGiUyUOwQ==", "e9b95cd3-ddbc-4407-8ab4-3fbaba44bf4c" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91f45ea1-8aaa-4cf7-b34a-b447b86f0103", new DateTimeOffset(new DateTime(2023, 6, 25, 10, 2, 29, 290, DateTimeKind.Unspecified).AddTicks(1151), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAECaq08T1SVD0JF2KWjPQQq6zGkioMEWwsaS5jArg9rwWQlQ0qZ0TmWjO1JS4V8Q9rg==", "6a6ad4ac-aafb-4d08-9e79-d7583a778e9a" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61f0180d-ee4b-49d8-a433-d8387317044f", new DateTimeOffset(new DateTime(2023, 6, 25, 10, 2, 29, 290, DateTimeKind.Unspecified).AddTicks(1091), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEAZgwkeYpj9ACpu1DapdocvJg5zWTODKA8DNTxmuP7FzsKjumnnH3utyUNIo+/cNkw==", "e61a3774-587b-422f-beb1-51813ef9382a" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04b38b33-5be1-4c16-8942-adc7a5397b9c", new DateTimeOffset(new DateTime(2023, 6, 25, 10, 2, 29, 290, DateTimeKind.Unspecified).AddTicks(790), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAECBsNo63LHGLds0S+6JMcYL876Olc54C/XZNlErQUbJgd6baXcluWxwc9ndQzc4+zg==", "dbfbf831-0921-4c94-bc22-7dfda9579356" });
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
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 13, 25, 10, 389, DateTimeKind.Unspecified).AddTicks(3255), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

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
    }
}
