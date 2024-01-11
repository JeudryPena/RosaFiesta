using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedViewCountToProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "RosaFiesta",
                table: "PayMethods");

            migrationBuilder.AddColumn<int>(
                name: "Views",
                schema: "RosaFiesta",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "RosaFiesta",
                table: "PayMethods",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                schema: "RosaFiesta",
                table: "PayMethods",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cvv",
                schema: "RosaFiesta",
                table: "PayMethods",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExpirationDate",
                schema: "RosaFiesta",
                table: "PayMethods",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                schema: "RosaFiesta",
                table: "PayMethods",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b74af7f-e10a-4f01-8237-9c16e48e4b78", new DateTimeOffset(new DateTime(2024, 1, 8, 7, 27, 7, 815, DateTimeKind.Unspecified).AddTicks(3929), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEIh8L7AeuKuoSgd/LzKVTxt2h0Xv6PsYkOsU/K0OgFS8zjyXeH1lEmCydII9HBdrTA==", "10610b73-6018-49e8-bb7b-e53ee8785b42" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b98318e-504a-4022-a5e4-c0be8ff1f208", new DateTimeOffset(new DateTime(2024, 1, 8, 7, 27, 7, 815, DateTimeKind.Unspecified).AddTicks(3963), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEDVk2Bcc1MjKTKq2UfdnSXx5fMWIGlMFWtFwnlnfdCLa7eXicvE3uE+qGiLoy/OoSg==", "2d1b4fd6-2b0a-48fc-bfe0-27f4fc40bd1f" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7db81e4a-bac3-475a-a7d9-f9a7a5b5f0d7", new DateTimeOffset(new DateTime(2024, 1, 8, 7, 27, 7, 815, DateTimeKind.Unspecified).AddTicks(3976), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEJsnChgsN4Kc0ycEsOLuwDl7B2um+H650yDGnlsU9Fk3jfeu5D8u1WV587i1fz9KMg==", "e770956a-5597-4a8c-a147-d70da862ee68" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be950c5b-cfba-4c88-a9dc-4cffcbec6d40", new DateTimeOffset(new DateTime(2024, 1, 8, 7, 27, 7, 815, DateTimeKind.Unspecified).AddTicks(3895), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEM39W5TJ7zLfGQKH9oMaG3WQcCtu3WUwLgXRGxS8Bdm8FubzB6xzpNKDrV/OJJK8Sg==", "840b3ec4-0d70-4829-8e3f-12511fc4f2df" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f9c3a29-5348-4964-9d04-b19d23a1bca2", new DateTimeOffset(new DateTime(2024, 1, 8, 7, 27, 7, 815, DateTimeKind.Unspecified).AddTicks(3690), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEBSva7yT2S3a4LVZbfq5LRXHwHDSEju+Mo7uSzXdTpWKGMKcJBwKmBAUkkxv17354g==", "94c7258d-94c1-4a4c-8527-4ad46fb2c224" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Views",
                schema: "RosaFiesta",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                schema: "RosaFiesta",
                table: "PayMethods");

            migrationBuilder.DropColumn(
                name: "Cvv",
                schema: "RosaFiesta",
                table: "PayMethods");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                schema: "RosaFiesta",
                table: "PayMethods");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                schema: "RosaFiesta",
                table: "PayMethods");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "RosaFiesta",
                table: "PayMethods",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "RosaFiesta",
                table: "PayMethods",
                type: "character varying(30)",
                maxLength: 30,
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
        }
    }
}
