using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class fixedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsDiscounts_Products_ProductEntityId",
                schema: "RosaFiesta",
                table: "ProductsDiscounts");

            migrationBuilder.DropIndex(
                name: "IX_ProductsDiscounts_ProductEntityId",
                schema: "RosaFiesta",
                table: "ProductsDiscounts");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "RosaFiesta",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                schema: "RosaFiesta",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProductEntityId",
                schema: "RosaFiesta",
                table: "ProductsDiscounts");

            migrationBuilder.DropColumn(
                name: "EndedAt",
                schema: "RosaFiesta",
                table: "Options");

            migrationBuilder.RenameColumn(
                name: "DetailId",
                schema: "RosaFiesta",
                table: "PurchaseDetails",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CartId",
                schema: "RosaFiesta",
                table: "Carts",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "RosaFiesta",
                table: "Quotes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(36)",
                oldMaxLength: 36,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExtraInfo",
                schema: "RosaFiesta",
                table: "Quotes",
                type: "character varying(5000)",
                maxLength: 5000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(4)",
                oldMaxLength: 4,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "RosaFiesta",
                table: "Quotes",
                type: "character varying(320)",
                maxLength: 320,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(7)",
                oldMaxLength: 7,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                schema: "RosaFiesta",
                table: "Options",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "RosaFiesta",
                table: "Addresses",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(36)",
                oldMaxLength: 36);

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c2f8286-5034-4e5d-9739-1a95a7babc79", new DateTimeOffset(new DateTime(2023, 7, 20, 12, 3, 16, 213, DateTimeKind.Unspecified).AddTicks(6160), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEBbSDD15HyL/AMWoV9AJCDj8FPaJrqqngkxCxVUiUTtXuHGQVZ7rIOksjbNCxLnvCA==", "17be6de5-7683-4ae3-a4eb-4d49c06775c7" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0dbedc2a-829e-41a1-a4ed-3b46d40e355c", new DateTimeOffset(new DateTime(2023, 7, 20, 12, 3, 16, 213, DateTimeKind.Unspecified).AddTicks(6170), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAECTY9aNvAgC38XdLVkrIOCGaa5RJNyme8RjGqgC/tFsOTmSZEI0zUr1m8Tj+BwUWCw==", "98165d45-54b2-472c-ba1b-dfc20cc1fb58" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c933618-3ccd-4cdf-85c6-e01cde3338b6", new DateTimeOffset(new DateTime(2023, 7, 20, 12, 3, 16, 213, DateTimeKind.Unspecified).AddTicks(6181), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAELRyrtZmRqMFSiRJ+U8rxXZICkBZLQeT/F+dcWHKb0cjC/o/NqM1DL9xosHLCDIhkQ==", "5fdcdac3-90a4-4ace-9f8d-f95b7fb2766a" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e970dc3f-4908-4200-ab0c-04258e9e84e0", new DateTimeOffset(new DateTime(2023, 7, 20, 12, 3, 16, 213, DateTimeKind.Unspecified).AddTicks(6134), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEDcKLOmvbdgwFstJ/IAwBQCmwDf0xcAOqrZSRXkfdLq3SfiwSTpySCTsNc8N7J0Lhg==", "be968566-e831-43b0-b6c0-39e91774fea8" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60b7438a-3653-4e6d-ac77-8a910f863e27", new DateTimeOffset(new DateTime(2023, 7, 20, 12, 3, 16, 213, DateTimeKind.Unspecified).AddTicks(5955), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEKLNcTehR4KGwgBOoacVIcuKcCUjxsJ8jFuUaXas3pZrdu4ECsjSQDHeZloE3UzItQ==", "08851049-29c4-48e3-a27b-b9109f0a94e0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                schema: "RosaFiesta",
                table: "Options");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "RosaFiesta",
                table: "PurchaseDetails",
                newName: "DetailId");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "RosaFiesta",
                table: "Carts",
                newName: "CartId");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "RosaFiesta",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                schema: "RosaFiesta",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "RosaFiesta",
                table: "Quotes",
                type: "character varying(36)",
                maxLength: 36,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExtraInfo",
                schema: "RosaFiesta",
                table: "Quotes",
                type: "character varying(4)",
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(5000)",
                oldMaxLength: 5000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "RosaFiesta",
                table: "Quotes",
                type: "character varying(7)",
                maxLength: 7,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(320)",
                oldMaxLength: 320,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductEntityId",
                schema: "RosaFiesta",
                table: "ProductsDiscounts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EndedAt",
                schema: "RosaFiesta",
                table: "Options",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "RosaFiesta",
                table: "Addresses",
                type: "character varying(36)",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "393a3056-9676-47ce-a44a-41611d0a3ed0", new DateTimeOffset(new DateTime(2023, 7, 17, 12, 51, 44, 144, DateTimeKind.Unspecified).AddTicks(1106), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEDw8IN4anoo+RbmhQdqdagHtmGw/bCxXysFceKaqihnB9FlDHa29nsa7sr7CvymQgw==", "18497505946", true, "003f602d-8977-4d6d-b133-afa50cb6a929" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "edc30f8b-2a19-4545-a14e-eb8d0c3fbb55", new DateTimeOffset(new DateTime(2023, 7, 17, 12, 51, 44, 144, DateTimeKind.Unspecified).AddTicks(1128), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEOhHmvqg9aBkSqQku034CT5n91pxh27rynK6ffbWjT2G/ciEkByk2PtkMEuVVK688g==", "18497505947", true, "4f9d5c28-101c-449c-ada3-febbe28e03b2" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "edf47029-1ffd-4138-99ce-c0aa426daa3a", new DateTimeOffset(new DateTime(2023, 7, 17, 12, 51, 44, 144, DateTimeKind.Unspecified).AddTicks(1137), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAELCJuSWaA4coSyDqqFG/hBCgTuRFijlkGy8hVENGzoCuykz2SIeSpqv94AsHqVGqGg==", "18497505948", true, "89516410-f20f-4e2c-8f56-72db2040609d" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "c345d409-a072-4a3a-a1c8-017ef45c1b9d", new DateTimeOffset(new DateTime(2023, 7, 17, 12, 51, 44, 144, DateTimeKind.Unspecified).AddTicks(1069), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEFolABg9UVxdDOaMpQhCQWUs2+2WPNZ/Fq+tQfypxcy8aPnwm3E/I5FrY1CRhFTicA==", "18497505945", true, "8134588c-c2b3-45ec-9a10-1ab064c619e4" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "27a50021-3d13-4576-994f-6baa8193beba", new DateTimeOffset(new DateTime(2023, 7, 17, 12, 51, 44, 144, DateTimeKind.Unspecified).AddTicks(878), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEI1NfjihrFYSvMRxphlS0jTwJUlgWPtWXrOmLW3b1cKDwfwe78IdkGNvLfGz0N1hYQ==", "18497505944", true, "742aad4a-0bbe-41b2-a395-fa1db3b98583" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsDiscounts_ProductEntityId",
                schema: "RosaFiesta",
                table: "ProductsDiscounts",
                column: "ProductEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsDiscounts_Products_ProductEntityId",
                schema: "RosaFiesta",
                table: "ProductsDiscounts",
                column: "ProductEntityId",
                principalSchema: "RosaFiesta",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
