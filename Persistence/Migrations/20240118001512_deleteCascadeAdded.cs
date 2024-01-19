using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class deleteCascadeAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetailsOptions_PurchaseDetails_DetailId",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97c1f44a-9837-48c1-b130-cecb41ed6484", new DateTimeOffset(new DateTime(2024, 1, 17, 20, 15, 11, 770, DateTimeKind.Unspecified).AddTicks(6195), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEHMBA39wnBp05ZPE4EqWRpl3jtVRGyBvFWASDo006rK1J9r8BfvBCUIOtKFJZDgJMA==", "38f34e4f-8aa1-4761-b357-baa92014ac90" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c4d7a4e-da09-41ac-ab91-1c9dfb530d71", new DateTimeOffset(new DateTime(2024, 1, 17, 20, 15, 11, 770, DateTimeKind.Unspecified).AddTicks(6209), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEOSkysjJGqr09zl5vb6X0Ddj9pMGdRc2zND96Tb6n3cU25S6yLI+rMXyB27iUF1b1Q==", "75f8601d-e67e-44b8-a201-93dadaa6ab13" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f601f8ec-182f-4051-85c3-5f5818324e80", new DateTimeOffset(new DateTime(2024, 1, 17, 20, 15, 11, 770, DateTimeKind.Unspecified).AddTicks(6224), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEOmsnswy3EO7FyjWmp5iIwNef8OVmt0X1CtlEPEPDBaYfe96SQbszmVdUjb38/nlBw==", "2e0753fc-a5a5-40b0-8e24-a30e22221b8b" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee65e090-9ec8-408f-8adc-598cd649bac6", new DateTimeOffset(new DateTime(2024, 1, 17, 20, 15, 11, 770, DateTimeKind.Unspecified).AddTicks(6151), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEL18w8zwFHLjxdM1MN/hx3a62CZCU58r/q0KSRfibljXYQ4mBoiGPj7MeJ5nmwz5NA==", "5bb45d6f-b9df-44d6-818b-46d368cc64c2" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55f5de52-b895-4229-b300-e43bdc6e1e33", new DateTimeOffset(new DateTime(2024, 1, 17, 20, 15, 11, 770, DateTimeKind.Unspecified).AddTicks(5915), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEG5IcfE4s6qQ4WEr/RmuzZTacn93i4TD3Iwg4QyU4ukhq+q7zhwuw6CIdST7NWfkZg==", "8ad5bae6-e211-4f08-90a0-9efc07b57c8a" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 20, 15, 12, 120, DateTimeKind.Unspecified).AddTicks(269), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 20, 15, 12, 120, DateTimeKind.Unspecified).AddTicks(272), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 20, 15, 12, 120, DateTimeKind.Unspecified).AddTicks(275), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 20, 15, 12, 120, DateTimeKind.Unspecified).AddTicks(266), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 20, 15, 12, 120, DateTimeKind.Unspecified).AddTicks(169), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetailsOptions_PurchaseDetails_DetailId",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions",
                column: "DetailId",
                principalSchema: "RosaFiesta",
                principalTable: "PurchaseDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetailsOptions_PurchaseDetails_DetailId",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88719ba4-c701-46ad-abce-1cf00c21a820", new DateTimeOffset(new DateTime(2024, 1, 17, 18, 56, 30, 380, DateTimeKind.Unspecified).AddTicks(7170), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEGHbFCdLSCE8eIuyiWBlD1uc2gw15LvgF8j8Q3TYqKmVs8NKqcVfqyi09V/KxvHI5Q==", "1e920086-7862-4362-b173-219be6686757" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31599845-a143-49c9-a51a-08c9a0e556d4", new DateTimeOffset(new DateTime(2024, 1, 17, 18, 56, 30, 380, DateTimeKind.Unspecified).AddTicks(7185), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEMPzldc0xaoi+h/I4IxvZkqMJaYxF9pvjFt9m6mMICKYA9WSs1NnI2DiD0QmTlrs8g==", "6a89e702-42df-4669-afec-2d425b186b25" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48f1431d-50f4-41c4-9c88-85a42445f90c", new DateTimeOffset(new DateTime(2024, 1, 17, 18, 56, 30, 380, DateTimeKind.Unspecified).AddTicks(7202), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEISw1ArZNH/hi8fHyKBPQIVQDvbHXGwJrz4Qhc+OpddD+AL7MGR8yEZrDF6ROrfTfQ==", "3213c788-ad68-4130-8629-79e98c18d416" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da58fd4a-4395-4d40-ae72-fc2604592fdd", new DateTimeOffset(new DateTime(2024, 1, 17, 18, 56, 30, 380, DateTimeKind.Unspecified).AddTicks(7124), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEGKgYFG0gW5t0wPIfiF3yxbpUCl9YbQTWCyoroItIvleDAQTMPOpWX83QO1VSr7oXg==", "aac1b247-ed13-4651-adbd-abe9f51386f6" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9179bb2-8b05-416a-b0e2-219e22238f06", new DateTimeOffset(new DateTime(2024, 1, 17, 18, 56, 30, 380, DateTimeKind.Unspecified).AddTicks(6867), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEMiG/2LKFANzUQl9eFdPLKnZTiQJVNAOT3+FMwU0ZgTeeGZVpOGyaT+UgbdtuvmsxA==", "83528602-a529-4389-8604-e53a0cb79281" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 18, 56, 30, 971, DateTimeKind.Unspecified).AddTicks(8891), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 18, 56, 30, 971, DateTimeKind.Unspecified).AddTicks(8895), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 18, 56, 30, 971, DateTimeKind.Unspecified).AddTicks(8933), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 18, 56, 30, 971, DateTimeKind.Unspecified).AddTicks(8885), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 17, 18, 56, 30, 971, DateTimeKind.Unspecified).AddTicks(8786), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetailsOptions_PurchaseDetails_DetailId",
                schema: "RosaFiesta",
                table: "PurchaseDetailsOptions",
                column: "DetailId",
                principalSchema: "RosaFiesta",
                principalTable: "PurchaseDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
