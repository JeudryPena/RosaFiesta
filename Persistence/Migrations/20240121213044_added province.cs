using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedprovince : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Province",
                schema: "RosaFiesta",
                table: "AddressEntity",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5e8c92f-fdb5-4535-b988-1137b615bb34", new DateTimeOffset(new DateTime(2024, 1, 21, 17, 30, 43, 535, DateTimeKind.Unspecified).AddTicks(2195), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEMQvJjLCCEdP42jQU7Lcbp+ASAQgpJxz+hZhh6aI90DI2ZeMZRvLuzN5bHnC3cpEHQ==", "d656b12b-7018-4b28-bc6c-ea806fe473dc" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a813f07-b02e-45b6-8e8e-7fb429e6cdc2", new DateTimeOffset(new DateTime(2024, 1, 21, 17, 30, 43, 535, DateTimeKind.Unspecified).AddTicks(2209), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEHhJUrQ6IOcAZ2RRJbRe/8PO/hZq6SDvg6H74IdESyOJxr6DtDOJCjnuBAnOY/wkYA==", "9ab7e426-40aa-484b-aaaf-810d24c3120e" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef9b44eb-caf6-4037-bd32-452bebcbb132", new DateTimeOffset(new DateTime(2024, 1, 21, 17, 30, 43, 535, DateTimeKind.Unspecified).AddTicks(2261), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEHwLXAGoG4PPeeL454hjgeQCWFa+d8PoLAgnz86tEBem42YSONNfXQ8tOU37kUrPGw==", "44f3f327-0622-4210-aad3-18939380a8b2" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08ecbbe1-38ac-43b5-8d6a-bd4d61069a12", new DateTimeOffset(new DateTime(2024, 1, 21, 17, 30, 43, 535, DateTimeKind.Unspecified).AddTicks(2166), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEGvjSrO9cZF2vDCDQ7vXoLbNRdZ/No0pipqRl9PJRiHpMcQRgbzzECHz8IHZlJe2SA==", "07b40527-9dd1-46c0-88a4-bb3ea9be332a" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0eb6a908-be2a-42d5-b0d7-836a2295cb10", new DateTimeOffset(new DateTime(2024, 1, 21, 17, 30, 43, 535, DateTimeKind.Unspecified).AddTicks(1908), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAELNNhYyIF11fIuel/8KkMdLrZt32q5a+vtHmVcejYvd+B9/MwO41esXbjxekUGs9Mg==", "bf4776dc-9100-4434-9d4c-aa2fa1b9cc09" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 17, 30, 44, 3, DateTimeKind.Unspecified).AddTicks(46), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 17, 30, 44, 3, DateTimeKind.Unspecified).AddTicks(49), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 17, 30, 44, 3, DateTimeKind.Unspecified).AddTicks(53), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 17, 30, 44, 3, DateTimeKind.Unspecified).AddTicks(40), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 17, 30, 44, 2, DateTimeKind.Unspecified).AddTicks(9941), new TimeSpan(0, -4, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Province",
                schema: "RosaFiesta",
                table: "AddressEntity");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d21c0085-027d-4533-abfb-016642d9cdfb", new DateTimeOffset(new DateTime(2024, 1, 21, 17, 8, 44, 184, DateTimeKind.Unspecified).AddTicks(769), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEHQsifdaz+Fu/LusxtCz2llkHP+rc+QqOJ3KXyUaMWieHZLgYDBL+g1Dn+H8iM5fFQ==", "cc5b6a25-07b0-42f4-879e-d0614503b896" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad3554b7-ac99-432f-a4e1-14b9d899f753", new DateTimeOffset(new DateTime(2024, 1, 21, 17, 8, 44, 184, DateTimeKind.Unspecified).AddTicks(832), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEKzYjqsMF8OTkPAY+VTNhmcCsSxSrEnnOr/b2y48rVNgQk+NWJPoQAyAILjSRx3gxg==", "929e4e9d-7b5f-4da0-8b35-170942ad8b29" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16ad92ba-a51f-49ff-99bb-2db108cbf865", new DateTimeOffset(new DateTime(2024, 1, 21, 17, 8, 44, 184, DateTimeKind.Unspecified).AddTicks(847), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEHf/NpLRCllZvwFFFuEBrDI6hMzfVeQc6E+tI0uE8TTgLSdggXOt7assy7CLisog0g==", "9ba68f59-ee07-4fcb-abf2-e716c4ace442" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f164b514-2308-47ae-b2d4-06d7884b91bb", new DateTimeOffset(new DateTime(2024, 1, 21, 17, 8, 44, 184, DateTimeKind.Unspecified).AddTicks(729), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEOuciWyTOEFi6vRluUDQA7gMp4V4XBSMhiSh7DC3KMcRAZ/y7brDwyU2MwQ1pe5j/A==", "1b98f914-d618-4bc8-b774-63697bd532c6" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f868b5c-dca1-4614-ad35-5a12955205b9", new DateTimeOffset(new DateTime(2024, 1, 21, 17, 8, 44, 184, DateTimeKind.Unspecified).AddTicks(448), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEBHyx71HaG0SDfLnrN5IT0VXiUNFwpW2mWMffwltoG6eESmRAtP8tXz5j2lvPb6Xdg==", "6f336a28-0961-4d40-bc9c-0572f826ab70" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 17, 8, 44, 540, DateTimeKind.Unspecified).AddTicks(9245), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 17, 8, 44, 540, DateTimeKind.Unspecified).AddTicks(9248), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 17, 8, 44, 540, DateTimeKind.Unspecified).AddTicks(9251), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 17, 8, 44, 540, DateTimeKind.Unspecified).AddTicks(9240), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 17, 8, 44, 540, DateTimeKind.Unspecified).AddTicks(9161), new TimeSpan(0, -4, 0, 0, 0)));
        }
    }
}
