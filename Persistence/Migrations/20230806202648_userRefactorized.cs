using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class userRefactorized : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_Carts_CartId",
                schema: "RosaFiesta",
                table: "PurchaseDetails");

            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "RosaFiesta",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Street",
                schema: "RosaFiesta",
                table: "Addresses",
                newName: "State");

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                schema: "RosaFiesta",
                table: "PurchaseDetails",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "RosaFiesta",
                table: "Addresses",
                type: "character varying(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "RosaFiesta",
                table: "Addresses",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9fbe11c-e18d-44fe-81b3-6694ae967dde", new DateTimeOffset(new DateTime(2023, 8, 6, 16, 26, 48, 72, DateTimeKind.Unspecified).AddTicks(401), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEGJGFZTDKcISWH+XeKAVEHQ6i5RT/5eiR7hQR0FvjUnDW2sMPpic18HHyAFjOmHePQ==", "fdcc4039-a6f3-4d36-8db6-a6ca4537afb1" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5acaba24-92b2-4910-bf75-e1062d41838b", new DateTimeOffset(new DateTime(2023, 8, 6, 16, 26, 48, 72, DateTimeKind.Unspecified).AddTicks(435), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEGQvnyeV8fAgmzKYgzs/+rH/gT1mDfMoeadEmNb+/KvXxgoHzJiLyfCt9oUZwCTtVg==", "467702bd-8189-4b68-b152-690ee48e2987" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c85efa6-18a6-4859-b990-252b6f7ac70a", new DateTimeOffset(new DateTime(2023, 8, 6, 16, 26, 48, 72, DateTimeKind.Unspecified).AddTicks(447), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEJg0vKjoiGWnX1iCvPxV+mTLQohhlQF7G8WsOnRG3xRhQZpnkn85vXnz6VlPgL+ieg==", "c6e3907c-593c-4b27-8d9e-cda921520601" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f898b7b-780b-4334-b36f-44bcf3f5132d", new DateTimeOffset(new DateTime(2023, 8, 6, 16, 26, 48, 72, DateTimeKind.Unspecified).AddTicks(332), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEG5vh6JXL8dMVmPARdFefIy53f168oeUVRFXbyFYu0kl12vI/8KJKXLI+/v49D61mA==", "bcbce843-a1d1-45d5-a361-128d888260ec" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e52954dc-5c27-4c40-8e4e-2a53b63cb9a3", new DateTimeOffset(new DateTime(2023, 8, 6, 16, 26, 48, 72, DateTimeKind.Unspecified).AddTicks(116), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEKG8s3jHA9xapDVqHDGbGvS1OFJOa0H4Bvkc8dV3uTuOFF4Bo+3r+A/cNLZr+Ei9TQ==", "96f5b32e-5614-4f02-938b-c39dbacc45f7" });

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_Carts_CartId",
                schema: "RosaFiesta",
                table: "PurchaseDetails",
                column: "CartId",
                principalSchema: "RosaFiesta",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_Carts_CartId",
                schema: "RosaFiesta",
                table: "PurchaseDetails");

            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "RosaFiesta",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "RosaFiesta",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "State",
                schema: "RosaFiesta",
                table: "Addresses",
                newName: "Street");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "RosaFiesta",
                table: "Users",
                type: "character varying(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                schema: "RosaFiesta",
                table: "PurchaseDetails",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "FullName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c2f8286-5034-4e5d-9739-1a95a7babc79", new DateTimeOffset(new DateTime(2023, 7, 20, 12, 3, 16, 213, DateTimeKind.Unspecified).AddTicks(6160), new TimeSpan(0, -4, 0, 0, 0)), "Rosalba Pena", "AQAAAAIAAYagAAAAEBbSDD15HyL/AMWoV9AJCDj8FPaJrqqngkxCxVUiUTtXuHGQVZ7rIOksjbNCxLnvCA==", "17be6de5-7683-4ae3-a4eb-4d49c06775c7" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "FullName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0dbedc2a-829e-41a1-a4ed-3b46d40e355c", new DateTimeOffset(new DateTime(2023, 7, 20, 12, 3, 16, 213, DateTimeKind.Unspecified).AddTicks(6170), new TimeSpan(0, -4, 0, 0, 0)), "Jendry Pena", "AQAAAAIAAYagAAAAECTY9aNvAgC38XdLVkrIOCGaa5RJNyme8RjGqgC/tFsOTmSZEI0zUr1m8Tj+BwUWCw==", "98165d45-54b2-472c-ba1b-dfc20cc1fb58" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "FullName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c933618-3ccd-4cdf-85c6-e01cde3338b6", new DateTimeOffset(new DateTime(2023, 7, 20, 12, 3, 16, 213, DateTimeKind.Unspecified).AddTicks(6181), new TimeSpan(0, -4, 0, 0, 0)), "Rosmery Pena", "AQAAAAIAAYagAAAAELRyrtZmRqMFSiRJ+U8rxXZICkBZLQeT/F+dcWHKb0cjC/o/NqM1DL9xosHLCDIhkQ==", "5fdcdac3-90a4-4ace-9f8d-f95b7fb2766a" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "FullName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e970dc3f-4908-4200-ab0c-04258e9e84e0", new DateTimeOffset(new DateTime(2023, 7, 20, 12, 3, 16, 213, DateTimeKind.Unspecified).AddTicks(6134), new TimeSpan(0, -4, 0, 0, 0)), "Rosanny Pena", "AQAAAAIAAYagAAAAEDcKLOmvbdgwFstJ/IAwBQCmwDf0xcAOqrZSRXkfdLq3SfiwSTpySCTsNc8N7J0Lhg==", "be968566-e831-43b0-b6c0-39e91774fea8" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "FullName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60b7438a-3653-4e6d-ac77-8a910f863e27", new DateTimeOffset(new DateTime(2023, 7, 20, 12, 3, 16, 213, DateTimeKind.Unspecified).AddTicks(5955), new TimeSpan(0, -4, 0, 0, 0)), "Rosalba Pena", "AQAAAAIAAYagAAAAEKLNcTehR4KGwgBOoacVIcuKcCUjxsJ8jFuUaXas3pZrdu4ECsjSQDHeZloE3UzItQ==", "08851049-29c4-48e3-a27b-b9109f0a94e0" });

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_Carts_CartId",
                schema: "RosaFiesta",
                table: "PurchaseDetails",
                column: "CartId",
                principalSchema: "RosaFiesta",
                principalTable: "Carts",
                principalColumn: "Id");
        }
    }
}
