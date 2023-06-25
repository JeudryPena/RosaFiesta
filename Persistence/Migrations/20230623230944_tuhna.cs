using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class tuhna : Migration
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
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 23, 23, 9, 43, 491, DateTimeKind.Unspecified).AddTicks(42), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                schema: "RosaFiesta",
                table: "CategoryEntity",
                type: "timestamp with time zone",
                nullable: true,
                defaultValueSql: "GETDATE()",
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
                values: new object[] { "6351b638-269b-453d-8a96-7216dca13299", new DateTimeOffset(new DateTime(2023, 6, 23, 19, 4, 47, 92, DateTimeKind.Unspecified).AddTicks(6875), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEKz6hcPaJNBeyHbRAhR83Y9GD1VPrtTFxaNtZFXXFjARG9AF7JzEm/GtM6tWftgrwQ==", "d6c8802c-d070-44f0-a5ac-5bb72f690680" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e37a3ae6-17e4-4c20-8ee3-6e2a16e0cdc1", new DateTimeOffset(new DateTime(2023, 6, 23, 19, 4, 47, 92, DateTimeKind.Unspecified).AddTicks(6901), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEF9ucOzocRCmLV6yjZYSOQpHDiE865FGikIWnEA5oRsIgz1fSfhvtwNcBygMho42Ng==", "5335f601-c4c6-4c68-b49d-aab804d3c813" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b52b58bf-6249-4daa-ac1c-b429b838064a", new DateTimeOffset(new DateTime(2023, 6, 23, 19, 4, 47, 92, DateTimeKind.Unspecified).AddTicks(6914), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEEHGL4pTQBnXxDrnec3fALQoPJ80LfAgP7OYJbdVa8A7vD7IoJmHgyKu9G+DDl41Ow==", "02671eb1-1b50-4e49-8d6c-23ded778d858" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3685052a-ec72-4040-b444-bc1b60085814", new DateTimeOffset(new DateTime(2023, 6, 23, 19, 4, 47, 92, DateTimeKind.Unspecified).AddTicks(6859), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEHUiDJNEU5M92/K0dWj2ViaoD37JUdry/hFdI/HuNLtIW+a+RBZo/McVbcHm9PfRGw==", "2179e5c7-7809-4103-b12b-4e6b188bd45a" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a127faf0-d566-4aff-a6f6-ae7c86d3941b", new DateTimeOffset(new DateTime(2023, 6, 23, 19, 4, 47, 92, DateTimeKind.Unspecified).AddTicks(6583), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEAYk60x1tvlz21UkL9cwbS3XqCPCbGPAoS6xxkDY782u0L7+r+CBXlMEL6T5MT2XNw==", "76acbe36-8ea2-4af5-b0cb-8af77264ce08" });
        }
    }
}
