using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changednullabilities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AddressEntity_AddressId",
                schema: "RosaFiesta",
                table: "Orders");

            migrationBuilder.AlterColumn<double>(
                name: "Total",
                schema: "RosaFiesta",
                table: "Orders",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                schema: "RosaFiesta",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AddressEntity_AddressId",
                schema: "RosaFiesta",
                table: "Orders",
                column: "AddressId",
                principalSchema: "RosaFiesta",
                principalTable: "AddressEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AddressEntity_AddressId",
                schema: "RosaFiesta",
                table: "Orders");

            migrationBuilder.AlterColumn<double>(
                name: "Total",
                schema: "RosaFiesta",
                table: "Orders",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                schema: "RosaFiesta",
                table: "Orders",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c40af015-a157-444c-9c7b-68f224f42b90", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 4, 59, 136, DateTimeKind.Unspecified).AddTicks(7871), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEBUheOwixPdftLSLMCrsSqaMTpRr4FCn8IK78JPeJ+lhT40b36UqZWZIGq9PiPliug==", "b2326774-8b9e-4fee-b827-ed1b0a7ec0ce" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "087fd3d5-4d57-4e41-b1e5-3ebf2ec52934", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 4, 59, 136, DateTimeKind.Unspecified).AddTicks(7885), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEHxk7zKrQIODllPVCTCIHOetBOHwnaoFm0TrSaZzfIeMrSObkigsmOs8DufEJA4qZw==", "5002da16-71fc-4179-8b4d-b9aacb8fe221" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bebdfbde-0c94-4d81-9e62-9a214a8f3ed3", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 4, 59, 136, DateTimeKind.Unspecified).AddTicks(7933), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEL2JLoT2xZLoyYIt4uSlmKLelycqyXFUQ7+LaiXNevI7EyP+pbcLlHXO4m9QDTSeMA==", "ac71219c-3523-49dd-9472-8af6f381bfde" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba0dabd1-4dae-406c-9755-7b3cb3b3fbe2", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 4, 59, 136, DateTimeKind.Unspecified).AddTicks(7856), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEJYuDi0RhrYtKdQCPoABE516bYFqpg2uWxUYx83jnNPgtYTMja+dUPF25WVFi8DDWg==", "5c61eed8-ccca-4933-8c02-69466f2f83e6" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a1f5451-8d7c-4483-bb6a-5783cdb9ab94", new DateTimeOffset(new DateTime(2024, 1, 23, 13, 4, 59, 136, DateTimeKind.Unspecified).AddTicks(7552), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEEkM77dEKjadac7xY6pP12dPPe3fINkkQiY+0V+ltwtIzB/5mSPy5pGlKm8uxpEQVw==", "f2eb0b31-46c9-421e-8d18-8fac08616b94" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 4, 59, 422, DateTimeKind.Unspecified).AddTicks(6989), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 4, 59, 422, DateTimeKind.Unspecified).AddTicks(6992), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 4, 59, 422, DateTimeKind.Unspecified).AddTicks(6994), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 4, 59, 422, DateTimeKind.Unspecified).AddTicks(6985), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 23, 13, 4, 59, 422, DateTimeKind.Unspecified).AddTicks(6905), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AddressEntity_AddressId",
                schema: "RosaFiesta",
                table: "Orders",
                column: "AddressId",
                principalSchema: "RosaFiesta",
                principalTable: "AddressEntity",
                principalColumn: "Id");
        }
    }
}
