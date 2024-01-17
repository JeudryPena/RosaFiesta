using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changedBehaviorCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Options_OptionId",
                schema: "RosaFiesta",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserEntityId",
                schema: "RosaFiesta",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_UserEntityId",
                schema: "RosaFiesta",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                schema: "RosaFiesta",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "RosaFiesta",
                table: "Quotes");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Options_OptionId",
                schema: "RosaFiesta",
                table: "Products",
                column: "OptionId",
                principalSchema: "RosaFiesta",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Options_OptionId",
                schema: "RosaFiesta",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "UserEntityId",
                schema: "RosaFiesta",
                table: "Reviews",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "RosaFiesta",
                table: "Quotes",
                type: "character varying(320)",
                maxLength: 320,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "278e3ac7-02f6-4f7e-844f-dcdf8db81761", new DateTimeOffset(new DateTime(2024, 1, 11, 19, 22, 57, 474, DateTimeKind.Unspecified).AddTicks(1517), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEGiqd7ChpUtAiKF7I6XFxBHTZEP3CXFst12dExxmyzrMVK2BeAehIohwWsDmcVlQFA==", "495f29a0-c9ae-4435-b13f-5c97edeb069b" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad24c06e-5494-48fc-8a9f-91d3e52329c9", new DateTimeOffset(new DateTime(2024, 1, 11, 19, 22, 57, 474, DateTimeKind.Unspecified).AddTicks(1557), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEG7NOT+DewnuLef71WnrjCJw0hF+mEaBc+bmq8kmkmr9/TrM4v3q2x5bNiIS4L5Zyg==", "3e993eb6-a779-45f9-b7d6-b908f9cecad2" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7978b69e-a588-4b2e-86e1-a4f0defc213f", new DateTimeOffset(new DateTime(2024, 1, 11, 19, 22, 57, 474, DateTimeKind.Unspecified).AddTicks(1582), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEEMbJKpUyDxPQqUs6S26ejSobUwSj1riAG6upA52uvyYjgyQI2VOyxxMEUZEj3ggtQ==", "118eaed6-16bb-47e7-a08c-0a80bd87848c" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fcb496c8-b201-499d-96ee-11851992936c", new DateTimeOffset(new DateTime(2024, 1, 11, 19, 22, 57, 474, DateTimeKind.Unspecified).AddTicks(1474), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEIODxf206eSJ6K08io+TSSOkitig/o6sB2SDb6SlMYb+a25QO3ddH8pROMTPvBH3lA==", "5c574509-7ea4-4d55-8fc2-80ce9254c34a" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e63f065-0167-4ebb-abd2-9a07c52a826e", new DateTimeOffset(new DateTime(2024, 1, 11, 19, 22, 57, 474, DateTimeKind.Unspecified).AddTicks(1020), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEMX/t90gc03OsT0DKY8W85uDQZ7c7M3QHpChw+bPRzpBE02b6Eg52zFCU/aMVFi0bg==", "b848d8ba-9314-4fb2-8bd2-e51ae35d8a18" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 19, 22, 58, 680, DateTimeKind.Unspecified).AddTicks(5191), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 19, 22, 58, 680, DateTimeKind.Unspecified).AddTicks(5199), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 19, 22, 58, 680, DateTimeKind.Unspecified).AddTicks(5205), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 19, 22, 58, 680, DateTimeKind.Unspecified).AddTicks(5179), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 11, 19, 22, 58, 680, DateTimeKind.Unspecified).AddTicks(5057), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserEntityId",
                schema: "RosaFiesta",
                table: "Reviews",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Options_OptionId",
                schema: "RosaFiesta",
                table: "Products",
                column: "OptionId",
                principalSchema: "RosaFiesta",
                principalTable: "Options",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserEntityId",
                schema: "RosaFiesta",
                table: "Reviews",
                column: "UserEntityId",
                principalSchema: "RosaFiesta",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
