using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TransactionDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "TransactionDate",
                schema: "RosaFiesta",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionDate",
                schema: "RosaFiesta",
                table: "Orders");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c257c014-9599-4f24-91c3-6a06b25c5c74", new DateTimeOffset(new DateTime(2024, 1, 21, 16, 54, 27, 105, DateTimeKind.Unspecified).AddTicks(9511), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEDppVEpeFQUyL0FVk+Z1ERjsw/Jzmj8ruBUsuyeC9uiOdgHWEbUzE9nL4aOfcPEXAw==", "4031eccb-ab4c-40e8-b2c1-b7834d85e2d7" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80937e67-fff0-437a-ad97-071f59e4147e", new DateTimeOffset(new DateTime(2024, 1, 21, 16, 54, 27, 105, DateTimeKind.Unspecified).AddTicks(9522), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEIWgOgHjBSXvDZJxkf3mov9E0dTZSKvuRnnQ6ffklikIEGaayM7BR6J9SVY0o1wkXQ==", "aec64080-353b-454e-b328-ea91c329268f" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cae0d551-aa03-4928-8e3d-e8fa92ca5d84", new DateTimeOffset(new DateTime(2024, 1, 21, 16, 54, 27, 105, DateTimeKind.Unspecified).AddTicks(9534), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEKh4WaZvV5PSGBhaxohXC4NIcaGz0klM49h01PJDu5oBUpHvrTD6OiYUFcn/rQ8lGQ==", "eb395f23-834a-4f76-87ef-50d10d6602a6" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "faba3bfb-a35d-4af7-a953-812410fe56e8", new DateTimeOffset(new DateTime(2024, 1, 21, 16, 54, 27, 105, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAECWrxRBwx0dUSWgZC8gfr9KBvQrHh8QsWo6eA7FbAPJeENICCDVbQZRfNSBVxK2Bmw==", "6ddee03a-fefd-4e4c-bdb4-f2e488acea81" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49beb6a4-d47e-4fcc-8835-5114479d9954", new DateTimeOffset(new DateTime(2024, 1, 21, 16, 54, 27, 105, DateTimeKind.Unspecified).AddTicks(9242), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAELM358b2aA5RdlZH7w0HomyabS154FmLUbmO+wEWQIrHRm2GNDSKZ4/8uq12epfVzg==", "1ea924b7-e727-44c7-8ddf-59c8b6af0843" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 16, 54, 27, 498, DateTimeKind.Unspecified).AddTicks(7445), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 16, 54, 27, 498, DateTimeKind.Unspecified).AddTicks(7447), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 16, 54, 27, 498, DateTimeKind.Unspecified).AddTicks(7450), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 16, 54, 27, 498, DateTimeKind.Unspecified).AddTicks(7441), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 16, 54, 27, 498, DateTimeKind.Unspecified).AddTicks(7349), new TimeSpan(0, -4, 0, 0, 0)));
        }
    }
}
