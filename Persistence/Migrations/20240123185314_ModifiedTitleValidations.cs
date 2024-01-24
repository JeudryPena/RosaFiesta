using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedTitleValidations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<double>(
                name: "Taxes",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "Discounted",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d828152f-01c0-46e9-a72f-a4e6de723bc7", new DateTimeOffset(new DateTime(2024, 1, 23, 14, 53, 13, 996, DateTimeKind.Unspecified).AddTicks(4667), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEL+4EYjXoTP10uT4UEjGWODCVmZ+Z4xCiCSPj5g/aRLsj1+ldXwelpsqcVw9fw5EOg==", "f263cbe1-e4bc-455e-9390-87804c25cb59" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4de394a6-1d76-4eaa-b49d-c3b3bd034267", new DateTimeOffset(new DateTime(2024, 1, 23, 14, 53, 13, 996, DateTimeKind.Unspecified).AddTicks(4692), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEFdxffEeFNgrgzM9itEkNMX7BOyfPPoQQ7vINgWZ6xOyQ4KT85I8KlqcKTRnkISHrw==", "f646c3c5-358e-4d9f-a147-a7c36602e0ba" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b22aa36-ebd9-4f66-8d69-46bdd87b7f72", new DateTimeOffset(new DateTime(2024, 1, 23, 14, 53, 13, 996, DateTimeKind.Unspecified).AddTicks(4716), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEGAakEjHr0b3IYsBR+G5gnQi5+IMF04ol0J5QmhsJjDqdX+kFZeSlkqwM5npicPNRA==", "7527f5e8-2855-450e-b530-25073204d120" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b3d8788-9375-4508-9b68-d4fe4c83fde1", new DateTimeOffset(new DateTime(2024, 1, 23, 14, 53, 13, 996, DateTimeKind.Unspecified).AddTicks(4621), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEKmQOGjL5B/jcYNoaEELBy58XXGfzlGF7g1Meg+AQrbo4OB0KM9O21GLm/P28keTBg==", "05cff717-275e-4eb7-b283-927e30d65075" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "245d209e-f807-4e4d-a04c-f83d3c82f44e", new DateTimeOffset(new DateTime(2024, 1, 23, 14, 53, 13, 996, DateTimeKind.Unspecified).AddTicks(4200), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAELXUBi9a6Bws6/+gMmJDNN2xXvpspWP6Lpm1VftAxsYfEfzOCzryyAsrWwslKkoI1Q==", "36cbcb93-446d-49d7-80e0-7bf6277975be" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 14, 53, 14, 673, DateTimeKind.Unspecified).AddTicks(7920), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 14, 53, 14, 673, DateTimeKind.Unspecified).AddTicks(7924), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 14, 53, 14, 673, DateTimeKind.Unspecified).AddTicks(7927), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 14, 53, 14, 673, DateTimeKind.Unspecified).AddTicks(7915), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 14, 53, 14, 673, DateTimeKind.Unspecified).AddTicks(7816), new TimeSpan(0, -4, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<double>(
                name: "Taxes",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Discounted",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
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
    }
}
