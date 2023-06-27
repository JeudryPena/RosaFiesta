using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class productCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "RosaFiesta",
                table: "Products",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae698297-ac17-49fa-93f5-e1e16b25adec", new DateTimeOffset(new DateTime(2023, 6, 26, 20, 11, 38, 973, DateTimeKind.Unspecified).AddTicks(9612), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEFwIubQ9+j2hehFVbWkBOjrDXBmxaLl022Em2sU+zadZM/BNlNx3PVoi1137tl1ygg==", "6884ac18-b450-43f6-a878-8a94d7bf044a" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ef4a581-bc77-4333-a040-2a3ca85e615b", new DateTimeOffset(new DateTime(2023, 6, 26, 20, 11, 38, 973, DateTimeKind.Unspecified).AddTicks(9804), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEHYoweKr99/lNGofX0HmplGAXv8w6OoPmwAj7FQ1xrGHdZ1Di9dhZvZEbVnfEkz5Tw==", "6c33021d-aa8c-4427-a829-d84d0e72d744" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e68c54b-4a4e-4603-8688-7f4d6411444a", new DateTimeOffset(new DateTime(2023, 6, 26, 20, 11, 38, 973, DateTimeKind.Unspecified).AddTicks(9846), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEF4AFq2f+H1Fd4njTLzX0I3BC/GHV0OOwxOWhAUFd2rGiwRWE9I8oA3/pOBMwK3WkQ==", "421364eb-eecf-4b5d-ba8b-1255d8677ac5" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9fe276c9-4705-44fb-aeac-4f60cce59d8e", new DateTimeOffset(new DateTime(2023, 6, 26, 20, 11, 38, 973, DateTimeKind.Unspecified).AddTicks(9563), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAELfCuMV1DvA2+t1DuUUXm2gqbtpIT7JYY+DFlTMtKmcXxiZ4g+OZ2d8IwBgBB/8mfQ==", "f449825b-9e67-41ac-a072-00c210973b46" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad870611-cd0c-4440-84e1-a50ec7aac6e9", new DateTimeOffset(new DateTime(2023, 6, 26, 20, 11, 38, 973, DateTimeKind.Unspecified).AddTicks(6626), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEK8V7ca17+Hn7UEsb8jJ95EAMsWzgsWd/126dN820UbFFVJeW05+p3JvG6mKU5uw2Q==", "d4475a56-ed77-442a-8965-4afdb435160a" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Code",
                schema: "RosaFiesta",
                table: "Products",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Code",
                schema: "RosaFiesta",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "RosaFiesta",
                table: "Products");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9cc558d-1bf9-419f-acc9-b0180650dd59", new DateTimeOffset(new DateTime(2023, 6, 26, 19, 56, 15, 951, DateTimeKind.Unspecified).AddTicks(1697), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEP/p5cqK3mnufHWEEa3hT70z0c0tWe07f9bZZyUuGKqn4VkxFGOYBY0rQO4GtxDYbg==", "5db02b44-83e3-4958-9b91-3f0128f364bd" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8b9123c-ea86-4010-899e-46fdd04c9209", new DateTimeOffset(new DateTime(2023, 6, 26, 19, 56, 15, 951, DateTimeKind.Unspecified).AddTicks(1723), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEJPC+raWbhN131unmjCNjEVI/FPiGgI8ZuBaS/4APk0KZ8UoKxKXUReFOmkPMII6JQ==", "6271fe20-eca1-4835-af9a-7d3c3e318622" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5511348-b108-42b6-918c-feac7121d7c4", new DateTimeOffset(new DateTime(2023, 6, 26, 19, 56, 15, 951, DateTimeKind.Unspecified).AddTicks(1738), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEMAuNRSM1I2lgJdOAqA8yx/Lzlvr9HvObzYnNJtvlvV/tmGKT5FOe+d9bxSNWJtFqg==", "086d0430-9c9b-4631-9ec7-268409639ae2" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5ba4d4b-ad07-4252-afe0-b856690b2659", new DateTimeOffset(new DateTime(2023, 6, 26, 19, 56, 15, 951, DateTimeKind.Unspecified).AddTicks(1678), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEDpAosuJNpfwsv3dOKi9uQ5EkE5zV9/hiidwrtrzKI8hwdmo/VHUUS9haAbc40VpkQ==", "87084d27-2643-4ef3-982e-c1414f3932c1" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d492c10b-65b7-4cba-a948-0343ecb34ed7", new DateTimeOffset(new DateTime(2023, 6, 26, 19, 56, 15, 951, DateTimeKind.Unspecified).AddTicks(1376), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEBOya8obtumP/Awy68nuoE0k2HT/9AOqohHgidE5+SVTRgZUytr98qWSskPSdJbXtg==", "e53c9eb6-ddfc-4eb3-a575-4ee495e89306" });
        }
    }
}
