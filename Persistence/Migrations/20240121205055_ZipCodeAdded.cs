using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ZipCodeAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostalCode",
                schema: "RosaFiesta",
                table: "AddressEntity",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostalCode",
                schema: "RosaFiesta",
                table: "AddressEntity");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14995b56-9f74-4ded-8c87-93939ad39357", new DateTimeOffset(new DateTime(2024, 1, 21, 15, 59, 38, 276, DateTimeKind.Unspecified).AddTicks(4865), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEB4Ydy+04fEVceoulvM7EI3mgTzHtqma1XLnC1DO9qG4banYg7ayHZ/OV0k8w+gwUQ==", "a4894dbb-5fee-40de-8b79-0126c5f71397" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f9b6f25-d46c-4652-91e2-d8a2d2a70ef0", new DateTimeOffset(new DateTime(2024, 1, 21, 15, 59, 38, 276, DateTimeKind.Unspecified).AddTicks(4882), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEKtyqKoz6k5nH/XS5kohQSezItF0V0612vljWf/DhJqL9srijjVngx4xey9rCiorTw==", "d8ee78ed-9fc3-4a96-9c15-c9723e903ded" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ec59284-e38e-400f-831b-0979fe598d72", new DateTimeOffset(new DateTime(2024, 1, 21, 15, 59, 38, 276, DateTimeKind.Unspecified).AddTicks(4892), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAELF+XvoA496LCZxOehpkkGOre7uBEm87HsanvuQjoZHRF6GbaOgsalXaBKPC6l96Ww==", "d2d2fe1d-a174-4595-8af0-e4984078acb1" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc149675-38cd-4b85-8d09-31df8f50edfb", new DateTimeOffset(new DateTime(2024, 1, 21, 15, 59, 38, 276, DateTimeKind.Unspecified).AddTicks(4852), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEOohnL4QxPb7vXcPhS2hyCwCahLqLU3/DY/KyZS3TFHGCFNyRiQ/crcs3K90xcQuLQ==", "8dfd8808-8583-4080-90a1-8969b2ec7c3b" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98c67c8b-679d-4234-99f5-980cba4827b7", new DateTimeOffset(new DateTime(2024, 1, 21, 15, 59, 38, 276, DateTimeKind.Unspecified).AddTicks(4623), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEEP8WRqs899X8ba501aJMptJtUoeHx3jrGZF1KeDyAe+MY7WF2xdzlCyAerUei9lTQ==", "53156e0d-a94e-488f-ae8b-1458ad33559e" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e1"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 15, 59, 38, 601, DateTimeKind.Unspecified).AddTicks(9635), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e2"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 15, 59, 38, 601, DateTimeKind.Unspecified).AddTicks(9643), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("2301d884-221a-4e7d-b509-0113dcc043e3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 15, 59, 38, 601, DateTimeKind.Unspecified).AddTicks(9647), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("7d9b7113-a8f8-4035-99a7-a20dd400f6a3"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 15, 59, 38, 601, DateTimeKind.Unspecified).AddTicks(9630), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "WishesList",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 1, 21, 15, 59, 38, 601, DateTimeKind.Unspecified).AddTicks(9539), new TimeSpan(0, -4, 0, 0, 0)));
        }
    }
}
