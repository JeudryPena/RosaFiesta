using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OrderIdLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                schema: "RosaFiesta",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e76233bb-bb4b-476a-9da0-411809c17571", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 39, 53, 60, DateTimeKind.Unspecified).AddTicks(2762), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAED1grMXnpoitIJ35jha9YEZuVdBV6r4P3YL44Sbb07tswSVTrIk6aIMTUdCckpJbWw==", "e98ea3ba-f9b0-486c-98ed-0b1171f9f43a" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9843f627-e306-4183-bfa4-e01477104ffc", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 39, 53, 60, DateTimeKind.Unspecified).AddTicks(2789), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEKp2GU+cFKhEtJWT/qlyPIGcuvr6qEJLACnD9yXtD22pOi/YjCJ72eyh5fPZ0dIv5A==", "b925d9f8-d844-46a3-8eb4-792b02ccde1f" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ff74654-0191-4ce2-b63e-97aefa2eb1b8", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 39, 53, 60, DateTimeKind.Unspecified).AddTicks(2800), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEORiYVp936gPm/Cd4RkdJAdLfTcgAiiA+XknJEqs9WcZ+FCWe1+CNBnHA+W8vLGJ6g==", "e72bb7fe-1be7-4df0-a0ca-8db1d52a4c6b" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4380b07d-5f74-43fa-93b0-7e2dd25442a2", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 39, 53, 60, DateTimeKind.Unspecified).AddTicks(2745), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEMGuXwsUadyqj4Asz8Do3KRLCDUrKfb83jc+Z6TRLNa6+xKc5F2bJ1c1oYeT50qsjw==", "47f46a92-ec7c-443f-a76d-66c4fdc108fe" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88c8df74-47df-40e2-b626-59238c6a47c4", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 39, 53, 60, DateTimeKind.Unspecified).AddTicks(2503), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEHHNiGkkTQigBI/hZXqGRF+26/g2z8XMhB0W/Smv3+AVUs4Izuyk1kgFXvqGWV/G+w==", "d3b466ab-0d1d-4e1b-9089-f12274fe524a" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 39, 53, 477, DateTimeKind.Unspecified).AddTicks(3691), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 39, 53, 477, DateTimeKind.Unspecified).AddTicks(3698), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 39, 53, 477, DateTimeKind.Unspecified).AddTicks(3714), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 39, 53, 477, DateTimeKind.Unspecified).AddTicks(3682), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 39, 53, 477, DateTimeKind.Unspecified).AddTicks(3244), new TimeSpan(0, -4, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                schema: "RosaFiesta",
                table: "Orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27d77835-50ec-418f-8a03-a61f67175cf3", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 35, 28, 774, DateTimeKind.Unspecified).AddTicks(7228), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAENxRWXIUoNL3TPCfl4GREO+pUJI8qO4MEXDQsLz2Bo0HoqzJAsxcIkOvKZHD9u20Yg==", "41a4a3a3-8445-4f5b-88a1-a62f1dc7ec19" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67335116-9691-42f9-89d2-7fc246939451", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 35, 28, 774, DateTimeKind.Unspecified).AddTicks(7244), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAENYskHLxj+gMJGOHmx/C8cVeFGcJwYQqyXN7fpSAT2rdp/qDuKhMRuvJJc+9Rwv4HA==", "48952473-2736-48e6-961f-9a6026914c0e" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c24cdbb4-d8af-44ad-9f07-d801c76a0d4b", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 35, 28, 774, DateTimeKind.Unspecified).AddTicks(7261), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEMbbzxUtewia8sq4fYdUNZCGZQpqxfAp+qc2mRCRTWNBsznRb3s+TXg9Yf7jVGbbtQ==", "9f123130-b8ef-4294-9d76-122f7e059267" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33f7a075-1afd-4351-a09e-489d6b85838f", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 35, 28, 774, DateTimeKind.Unspecified).AddTicks(7185), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEG+O3fuvkXlEnhnSrmsc35qxLMwkKzojtGgA2lrDPlLybM6mRmKBqUN0sVmZXXkjsw==", "70abff94-e163-4f20-bd6a-c7c9ff71639b" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "145dfea5-906b-4dc8-bd01-8f38d64165a0", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 35, 28, 774, DateTimeKind.Unspecified).AddTicks(6917), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAENAPM70uV1ILkdgwUseNbC1MYFWGLDgYXcLUe7E0J0Eks4OmIWc0zZGnlx28NalbNA==", "2e97ed87-9f88-48d0-8254-f2573bfcafb4" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 35, 29, 294, DateTimeKind.Unspecified).AddTicks(7371), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 35, 29, 294, DateTimeKind.Unspecified).AddTicks(7374), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 35, 29, 294, DateTimeKind.Unspecified).AddTicks(7378), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 35, 29, 294, DateTimeKind.Unspecified).AddTicks(7366), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 35, 29, 294, DateTimeKind.Unspecified).AddTicks(7257), new TimeSpan(0, -4, 0, 0, 0)));
        }
    }
}
