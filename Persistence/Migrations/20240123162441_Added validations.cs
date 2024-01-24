using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Addedvalidations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Orders_OrderId",
                schema: "RosaFiesta",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_OrderId",
                schema: "RosaFiesta",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "OrderId",
                schema: "RosaFiesta",
                table: "Quotes");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionId",
                schema: "RosaFiesta",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PayerId",
                schema: "RosaFiesta",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                schema: "RosaFiesta",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "RosaFiesta",
                table: "AddressEntity",
                type: "character varying(258)",
                maxLength: 258,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d609301-0eb0-42af-8e28-ad7375c31f2f", new DateTimeOffset(new DateTime(2024, 1, 23, 12, 24, 41, 418, DateTimeKind.Unspecified).AddTicks(4099), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEJK5fjC1LRLTfOkE6YUoK7l1OrDrkqvfwxTNfuVs9FdIqRGtfyTnViBfVp3wK7FQNQ==", "fef7506f-3536-472a-8d15-d65119057ddf" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d66f749a-1423-42b4-9080-ef95efd781b5", new DateTimeOffset(new DateTime(2024, 1, 23, 12, 24, 41, 418, DateTimeKind.Unspecified).AddTicks(4111), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEOauJgchXpDkiBsZ59Ejxow83WOkvGR9YafMKF7OvSvkcy+T6P6Keyhm2PMBaTgg8w==", "da306f73-a07d-4e84-9195-e83a31fa674c" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e83543e4-6e5a-4c07-974c-1e6c1132a61a", new DateTimeOffset(new DateTime(2024, 1, 23, 12, 24, 41, 418, DateTimeKind.Unspecified).AddTicks(4123), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAELpJMsQfVfNyhDWeP0226zPft4KoSdvZ247nUJul6I++mX8n5nA9N/m/177Fastmmw==", "d1c32388-a0a2-48c6-abab-882bfe1d4eec" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4cc610a9-b4bf-4f9f-82fb-b17ca3508687", new DateTimeOffset(new DateTime(2024, 1, 23, 12, 24, 41, 418, DateTimeKind.Unspecified).AddTicks(4067), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEFR2ErY67pGPDkRD4Zr6t0YEL+JZHO2U0gJnoK04vUfdN5eNZOXVVXtQ7aGG+1/fNQ==", "e1eee43e-71c3-4fcd-8977-e92c052e1d27" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4309eff0-1502-4393-9a84-3cde345c53d7", new DateTimeOffset(new DateTime(2024, 1, 23, 12, 24, 41, 418, DateTimeKind.Unspecified).AddTicks(3834), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEMX7Dx/HS8MOFE1mZWxWijggZqnMqcvO4Y3AJ641giZV3wo86Lfmr5CbUeAMcSGxMA==", "c51cd0f8-f04b-4c34-95b9-c9bb0aed3306" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 12, 24, 41, 758, DateTimeKind.Unspecified).AddTicks(5881), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 12, 24, 41, 758, DateTimeKind.Unspecified).AddTicks(5884), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 12, 24, 41, 758, DateTimeKind.Unspecified).AddTicks(5886), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 12, 24, 41, 758, DateTimeKind.Unspecified).AddTicks(5877), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 12, 24, 41, 758, DateTimeKind.Unspecified).AddTicks(5798), new TimeSpan(0, -4, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                schema: "RosaFiesta",
                table: "Quotes",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TransactionId",
                schema: "RosaFiesta",
                table: "Orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PayerId",
                schema: "RosaFiesta",
                table: "Orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                schema: "RosaFiesta",
                table: "Orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "RosaFiesta",
                table: "AddressEntity",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(258)",
                oldMaxLength: 258);

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b066dfa7-195c-4160-ab10-59014d82bf96", new DateTimeOffset(new DateTime(2024, 1, 22, 21, 6, 56, 378, DateTimeKind.Unspecified).AddTicks(7577), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAECKrlCkNOu5/oJAjDKgHtUJfhJVYy7aoi8Nwx1ohYOyb7DwYzAt0nWhS+tOUl/Ohsg==", "b1bed865-7a32-4640-9926-14a1539d3092" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a5526aa-fc35-4fee-b003-b5ebbfa99830", new DateTimeOffset(new DateTime(2024, 1, 22, 21, 6, 56, 378, DateTimeKind.Unspecified).AddTicks(7649), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEJ8SUWyZ0cCFOxHZ5fezMFfpm656lBpqFbh2Fp5j83qvE2qRO2nANEXZ+2K7ne+Zgg==", "959e402e-a427-4215-9d31-de778d1125b4" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc5c3e96-2f83-44ae-ab43-34790d435b74", new DateTimeOffset(new DateTime(2024, 1, 22, 21, 6, 56, 378, DateTimeKind.Unspecified).AddTicks(7667), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEIVCgycrPdmJoOGNQpdWGMEwgEvS97PVpUxowaqqdce6sFBwYer4goKstouXGb9ZDQ==", "f05e05d6-0c0c-4c62-8c3b-3481281147e0" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65322174-ae26-4abb-af12-0170b8a872a9", new DateTimeOffset(new DateTime(2024, 1, 22, 21, 6, 56, 378, DateTimeKind.Unspecified).AddTicks(7547), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEBvmH2qJr+onqI651oh7m4+bSOXefwlVQ0SFZ9fSF3X4yD9IPCwKaOyRn3wZLAH33A==", "100c15ad-da26-4f30-b2dd-9d845a8c311e" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77c580cc-55c0-4641-898b-55d6dee2b99f", new DateTimeOffset(new DateTime(2024, 1, 22, 21, 6, 56, 378, DateTimeKind.Unspecified).AddTicks(7277), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEIJ+O1LZtTE4s81mKdMlcHrmVIiYoijxIvNyMAS86XCXOSARSOE6zNl61Ftnlr379g==", "92b92a11-a310-442a-b24b-ae9e384cf887" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 22, 21, 6, 56, 943, DateTimeKind.Unspecified).AddTicks(7003), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 22, 21, 6, 56, 943, DateTimeKind.Unspecified).AddTicks(7010), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 22, 21, 6, 56, 943, DateTimeKind.Unspecified).AddTicks(7016), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 22, 21, 6, 56, 943, DateTimeKind.Unspecified).AddTicks(6992), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 22, 21, 6, 56, 943, DateTimeKind.Unspecified).AddTicks(6876), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_OrderId",
                schema: "RosaFiesta",
                table: "Quotes",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Orders_OrderId",
                schema: "RosaFiesta",
                table: "Quotes",
                column: "OrderId",
                principalSchema: "RosaFiesta",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
