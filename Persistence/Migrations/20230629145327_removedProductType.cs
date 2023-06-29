using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removedProductType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                schema: "RosaFiesta",
                table: "Products");

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6601139-3d10-4ab4-9eeb-e0067358a545", new DateTimeOffset(new DateTime(2023, 6, 29, 10, 53, 26, 577, DateTimeKind.Unspecified).AddTicks(6330), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEOwi7OHYfzUvsAxx7lMuSeVrWxRHQzLDFMOfDe5PHW+dNCvF5ypN/RAVJCxfhT19hQ==", "ef7e40a5-bb8d-4a36-9603-1cb93e3908f8" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8122dc2-238f-47a9-b9a4-bd034c0540c2", new DateTimeOffset(new DateTime(2023, 6, 29, 10, 53, 26, 577, DateTimeKind.Unspecified).AddTicks(6344), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEN408xql9gBHt2IsJe4p5lago2AeOV0UmpYmf4brtgiPGHcuYlE0N1UtS5LjS4ibPw==", "1f0d01f4-57d4-40de-9964-7c1ce7f46ff0" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f0eac8d-db9d-4cb8-af10-7e683fb94665", new DateTimeOffset(new DateTime(2023, 6, 29, 10, 53, 26, 577, DateTimeKind.Unspecified).AddTicks(6361), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEM6kbbL2lilhTNT04kCZKsATtvns67ohNxSjKGiAczagE1JZO/1/UEfYiMBcNWoE8w==", "ac8ae373-0d5d-44e3-9949-7ccb25037672" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63d2846d-1c97-49ca-9a0f-608c297c68e7", new DateTimeOffset(new DateTime(2023, 6, 29, 10, 53, 26, 577, DateTimeKind.Unspecified).AddTicks(6228), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEGVzfAtawl868fL/SuvNj44m42LgFHNqSjgzgQmtgQwl3G5fZf5UOyapcrPpXlvvjA==", "78abc981-f634-4d2c-8f7a-409d94a43142" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66be7057-6c5e-4f18-a614-449e1f07a430", new DateTimeOffset(new DateTime(2023, 6, 29, 10, 53, 26, 577, DateTimeKind.Unspecified).AddTicks(4548), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEG5+ll9LhZPe8UG9sF9ftriTsJkPcbS0YP0V5F1ZuifsBZJkwQ6GtEiDEZc9/gH6mg==", "961a37ed-620c-4270-a309-74c31464971e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                schema: "RosaFiesta",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d85a77ad-8018-497e-a068-8cb5380cd993", new DateTimeOffset(new DateTime(2023, 6, 29, 10, 5, 56, 859, DateTimeKind.Unspecified).AddTicks(7603), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEKHap+Pr0c1FNYUC3tXWs5+3+8ZGF63oz25EOJ7U64xxdCk0OZPxQlacHBg77JZrWQ==", "86f3ee55-fde6-47a7-a394-86cbd06b525e" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97d652c8-622f-41bf-96c9-cbed08bc1e8d", new DateTimeOffset(new DateTime(2023, 6, 29, 10, 5, 56, 859, DateTimeKind.Unspecified).AddTicks(7618), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEEFFoOIULbtfB1MBUZ3lBWkv9GHHM9CMq+pHxbzcDhX2ic3oFtJ8X3f3yYMMo1as8w==", "6b18bfd2-44b7-40ad-95ef-92b68a04dd73" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59aef040-516a-44e3-91ed-2c9c090f2a8c", new DateTimeOffset(new DateTime(2023, 6, 29, 10, 5, 56, 859, DateTimeKind.Unspecified).AddTicks(7636), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEBupZSPlG2hOtjvA7LnXAFlhsknv2p0mNvWww4UIBTuGd0wWn4CWZnGHljIo6XibDg==", "3082d9de-d909-4510-8968-71443ac824e9" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7401672-f472-4818-8603-33a8b90e7b2b", new DateTimeOffset(new DateTime(2023, 6, 29, 10, 5, 56, 859, DateTimeKind.Unspecified).AddTicks(7560), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEGOPYqurMJkmL5IVqxyd94GLmhDTxsj+HKI/D3I4/h8wfNbb/YN/OR3As794ubpKbQ==", "93896029-80c7-4993-8d95-e06490b84dbb" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e98cc73-f5a4-4c15-8546-9d7a5444874c", new DateTimeOffset(new DateTime(2023, 6, 29, 10, 5, 56, 859, DateTimeKind.Unspecified).AddTicks(6832), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEHwEXOUB+ganyz9haws7oEiRpIqglCsXDFcMZT1lH0Tt1nUIOOP/zpQDBqiGGpeJZg==", "2985db7c-4369-4eaa-9ebe-ec07f4b97ba0" });
        }
    }
}
