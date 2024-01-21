using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class total : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Total",
                schema: "RosaFiesta",
                table: "Orders",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                schema: "RosaFiesta",
                table: "Orders");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "948154f9-976f-4fa3-8e4f-0c24affe5802", new DateTimeOffset(new DateTime(2024, 1, 21, 16, 50, 54, 882, DateTimeKind.Unspecified).AddTicks(2961), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEF44lrKX7GPnC6jw9lemW/G2nKNepkJ5FgrqV1eoX2R2ABNz9LqWFx0V9wmYSIOGnw==", "9d9f5d64-cf08-4d23-90c7-ad5c8150eae9" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "510098b3-885d-494a-a708-74a83212ae93", new DateTimeOffset(new DateTime(2024, 1, 21, 16, 50, 54, 882, DateTimeKind.Unspecified).AddTicks(2973), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEDvQ9qyzj9CDvO2edxZ1Z0iRG8oM218k1jcpN9JTvu2YhJwQCS5VFyHSizTpc+dqSw==", "dcea6609-4b6e-4b96-be97-f254a472a1cb" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "028a9fac-bfe4-49f2-b327-d877bececf81", new DateTimeOffset(new DateTime(2024, 1, 21, 16, 50, 54, 882, DateTimeKind.Unspecified).AddTicks(2983), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEAcbyrQaEzNZC4EMUHHzgyOOosCe1PY0yxBuIJI4t4X9hAyXzfVlZrVlSRRCfuasrQ==", "d2d1bade-0394-433e-b415-a74b5550d397" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b14640a3-c403-41be-9c8c-1a490fde3c52", new DateTimeOffset(new DateTime(2024, 1, 21, 16, 50, 54, 882, DateTimeKind.Unspecified).AddTicks(2940), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAECNVr7cBUCZ6jr7xf2UqxOaQa2HRxOArAdFAf3mJyVM7HAObDtZkER7LxmSrkc2uHA==", "3eb81b3d-129e-4098-b54f-fae5799e04e6" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "155aba8c-82a3-45c3-85b0-3931602476d1", new DateTimeOffset(new DateTime(2024, 1, 21, 16, 50, 54, 882, DateTimeKind.Unspecified).AddTicks(2651), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEEvrEzseLtzwcAV1m15gk93cBK1x0eDIr9u4JMcTVqX/bO8iBJD6LesGOpljFDkbRA==", "ecb10222-4ed5-4acb-ab23-a230a0c8fbfd" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 16, 50, 55, 251, DateTimeKind.Unspecified).AddTicks(6394), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 16, 50, 55, 251, DateTimeKind.Unspecified).AddTicks(6396), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 16, 50, 55, 251, DateTimeKind.Unspecified).AddTicks(6398), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 16, 50, 55, 251, DateTimeKind.Unspecified).AddTicks(6391), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 16, 50, 55, 251, DateTimeKind.Unspecified).AddTicks(6311), new TimeSpan(0, -4, 0, 0, 0)));
        }
    }
}
