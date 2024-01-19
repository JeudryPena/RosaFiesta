using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedwarrantyIdtopurchaseDetailEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WarrantyId",
                schema: "RosaFiesta",
                table: "PurchaseDetails",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "RosaFiesta",
                table: "Addresses",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldMaxLength: 40);

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88719ba4-c701-46ad-abce-1cf00c21a820", new DateTimeOffset(new DateTime(2024, 1, 17, 18, 56, 30, 380, DateTimeKind.Unspecified).AddTicks(7170), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEGHbFCdLSCE8eIuyiWBlD1uc2gw15LvgF8j8Q3TYqKmVs8NKqcVfqyi09V/KxvHI5Q==", "1e920086-7862-4362-b173-219be6686757" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31599845-a143-49c9-a51a-08c9a0e556d4", new DateTimeOffset(new DateTime(2024, 1, 17, 18, 56, 30, 380, DateTimeKind.Unspecified).AddTicks(7185), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEMPzldc0xaoi+h/I4IxvZkqMJaYxF9pvjFt9m6mMICKYA9WSs1NnI2DiD0QmTlrs8g==", "6a89e702-42df-4669-afec-2d425b186b25" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48f1431d-50f4-41c4-9c88-85a42445f90c", new DateTimeOffset(new DateTime(2024, 1, 17, 18, 56, 30, 380, DateTimeKind.Unspecified).AddTicks(7202), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEISw1ArZNH/hi8fHyKBPQIVQDvbHXGwJrz4Qhc+OpddD+AL7MGR8yEZrDF6ROrfTfQ==", "3213c788-ad68-4130-8629-79e98c18d416" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da58fd4a-4395-4d40-ae72-fc2604592fdd", new DateTimeOffset(new DateTime(2024, 1, 17, 18, 56, 30, 380, DateTimeKind.Unspecified).AddTicks(7124), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEGKgYFG0gW5t0wPIfiF3yxbpUCl9YbQTWCyoroItIvleDAQTMPOpWX83QO1VSr7oXg==", "aac1b247-ed13-4651-adbd-abe9f51386f6" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9179bb2-8b05-416a-b0e2-219e22238f06", new DateTimeOffset(new DateTime(2024, 1, 17, 18, 56, 30, 380, DateTimeKind.Unspecified).AddTicks(6867), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEMiG/2LKFANzUQl9eFdPLKnZTiQJVNAOT3+FMwU0ZgTeeGZVpOGyaT+UgbdtuvmsxA==", "83528602-a529-4389-8604-e53a0cb79281" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 18, 56, 30, 971, DateTimeKind.Unspecified).AddTicks(8891), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 18, 56, 30, 971, DateTimeKind.Unspecified).AddTicks(8895), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 18, 56, 30, 971, DateTimeKind.Unspecified).AddTicks(8933), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 18, 56, 30, 971, DateTimeKind.Unspecified).AddTicks(8885), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 18, 56, 30, 971, DateTimeKind.Unspecified).AddTicks(8786), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_WarrantyId",
                schema: "RosaFiesta",
                table: "PurchaseDetails",
                column: "WarrantyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_Warranties_WarrantyId",
                schema: "RosaFiesta",
                table: "PurchaseDetails",
                column: "WarrantyId",
                principalSchema: "RosaFiesta",
                principalTable: "Warranties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_Warranties_WarrantyId",
                schema: "RosaFiesta",
                table: "PurchaseDetails");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseDetails_WarrantyId",
                schema: "RosaFiesta",
                table: "PurchaseDetails");

            migrationBuilder.DropColumn(
                name: "WarrantyId",
                schema: "RosaFiesta",
                table: "PurchaseDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "RosaFiesta",
                table: "Addresses",
                type: "character varying(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e3d8bd6-5b0f-4532-b040-ea02bb595cbd", new DateTimeOffset(new DateTime(2024, 1, 15, 16, 46, 22, 698, DateTimeKind.Unspecified).AddTicks(7245), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEHhC/xn0HZYLgBCP2UPKQlmsTL4HXV6V85XK07klgXTP7nh76IvJGxsuLLMbjw6bIQ==", "6f587037-bd70-4ecb-b5bd-0521dc07427a" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4ae48ea-d3d4-4aed-8416-25908d0cd504", new DateTimeOffset(new DateTime(2024, 1, 15, 16, 46, 22, 698, DateTimeKind.Unspecified).AddTicks(7263), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAELPerby6XJHsbhb1ixi/vWcZBQBc/2laJAbTDRA7QaIrCDSZm7g8YhgaRULhskPGqQ==", "d10c53cb-8898-4ddc-9e00-8e1cddba44ee" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60d6de44-ffba-41dc-a347-7ee0f1109ddf", new DateTimeOffset(new DateTime(2024, 1, 15, 16, 46, 22, 698, DateTimeKind.Unspecified).AddTicks(7279), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEHZByx/zaU1N41bZSbVrCHz8PX1cAVuPE2Gl+LMlRsCmsw+TGFIaABZaSMuZyWh5/Q==", "c1fa8419-a453-47a4-9d87-e551e4eb2b5a" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b3cf83f-0beb-4daa-9772-2a87f7b2898f", new DateTimeOffset(new DateTime(2024, 1, 15, 16, 46, 22, 698, DateTimeKind.Unspecified).AddTicks(7201), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEMVXGdE070yuKJYqrrovgDFv4TsD8NkOaDGUUtBvYLRi1aq9t/ikrHG2Ctg/cCNq9A==", "08b2c773-5530-4035-bae8-3ef1996c5f27" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2631ffac-1744-459b-b290-8780481a5ca1", new DateTimeOffset(new DateTime(2024, 1, 15, 16, 46, 22, 698, DateTimeKind.Unspecified).AddTicks(6912), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEPwXopi8W4s9745pg/mYGJA9k3PoORcdm7XikWB8bU3a9z+PAlRjW53julOwoHCAuQ==", "f02f2033-f464-4585-8675-431b5a010490" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 15, 16, 46, 23, 334, DateTimeKind.Unspecified).AddTicks(6150), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 15, 16, 46, 23, 334, DateTimeKind.Unspecified).AddTicks(6156), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 15, 16, 46, 23, 334, DateTimeKind.Unspecified).AddTicks(6162), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 15, 16, 46, 23, 334, DateTimeKind.Unspecified).AddTicks(6137), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 15, 16, 46, 23, 334, DateTimeKind.Unspecified).AddTicks(6005), new TimeSpan(0, -4, 0, 0, 0)));
        }
    }
}
